using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BTD_Mod_Helper.Api.Hooks;

/// <summary>
/// Provides a base mod hook for intercepting and modifying method calls using prefix and postfix hooks
/// </summary>
/// <typeparam name="TN">The type of the unmanaged delegate</typeparam>
/// <typeparam name="TM">The type of the managed delegate</typeparam>
public abstract class ModHook<TN, TM> : ModContent where TN : Delegate where TM : Delegate
{
    /// <summary>
    /// Gets the target method information that this mod hook intercepts
    /// </summary>
    protected abstract MethodInfo TargetMethod { get; }

    private bool attached;

    /// <summary>
    /// The native hook instance used for attaching the hook
    /// </summary>
    protected MelonLoader.NativeUtils.NativeHook<TN> Hook;

    /// <summary>
    /// The delegate instance representing the hook method
    /// </summary>
    protected TN HookDelegate;

    /// <summary>
    /// Gets the unmanaged hook method used to intercept the target method
    /// </summary>
    protected abstract TN HookMethod { get; }

    /// <summary>
    /// Stores prefix hook methods sorted by their priority
    /// </summary>
    protected Dictionary<int, List<TM>> PrefixList = [];

    /// <summary>
    /// Stores postfix hook methods sorted by their priority
    /// </summary>
    protected Dictionary<int, List<TM>> PostfixList = [];

    private nint methodInfo;

    /// <summary>
    /// Gets or sets the method information pointer for the hooked method.
    /// The setter only sets the value if it is not already set.
    /// </summary>
    /// <exclude/>
    protected nint MethodInfo {
        get => methodInfo;
        set
        {
            if (methodInfo == default)
            {
                methodInfo = value;
            }
        }
    }

    /// <summary>
    /// Adds a prefix hook method to be executed before the original method
    /// </summary>
    /// <param name="method">The prefix hook method</param>
    public void AddPrefix(TM method)
    {
        if (!attached)
            CreateAndAttachHook();

        var hookPriority = method.Method.GetCustomAttribute<HookPriorityAttribute>();
        var priority = hookPriority?.Priority ?? 0;

        if (!PrefixList.ContainsKey(priority))
        {
            PrefixList[priority] = [];
        }

        PrefixList[priority].Add(method);
    }


    /// <summary>
    /// Adds a postfix hook method to be executed after the original method
    /// </summary>
    /// <param name="method">The postfix hook method</param>
    public void AddPostfix(TM method)
    {
        if (!attached)
            CreateAndAttachHook();

        var hookPriority = method.Method.GetCustomAttribute<HookPriorityAttribute>();
        var priority = hookPriority?.Priority ?? 0;

        if (!PostfixList.ContainsKey(priority))
        {
            PostfixList[priority] = [];
        }

        PostfixList[priority].Add(method);
    }

    /// <summary>
    /// Unused
    /// </summary>
    public override void Register()
    {
    }

    /// <summary>
    /// Calls the original (trampoline) method with the specified arguments
    /// </summary>
    /// <param name="args">Arguments to pass to the original method</param>
    /// <returns>The result of the original method call</returns>
    public object CallOriginalMethod(params object[] args) =>
        TrampolineInvoker.Invoke(Hook.Trampoline, args, MethodInfo);

    /// <summary>
    /// Delegate for retrieving the FieldInfo pointer for a generated method's Il2Cpp method info
    /// </summary>
    /// <param name="method">The method info of the target method</param>
    /// <returns>The FieldInfo containing the method info pointer</returns>
    public delegate FieldInfo GetIl2CppMethodInfoPointerFieldForGeneratedMethod(MethodInfo method);

    /// <summary>
    /// Creates and attaches the native hook to the target method.
    /// Validates the delegate type and attaches the hook if valid.
    /// </summary>
    public void CreateAndAttachHook()
    {
        attached = true;
        var delegateType = typeof(TN);

        var attribute = delegateType.GetCustomAttribute<UnmanagedFunctionPointerAttribute>(inherit: false);

        if (attribute == null)
        {
            ModHelper.Error($"Mod Hook {Name}'s delegate type lacking an UnmanagedFunctionPointer attribute.");
            return;
        }

        if (attribute.CallingConvention != CallingConvention.Cdecl)
        {
            ModHelper.Error($"Mod Hook {Name}'s delegate type's Calling Convention is not Cdecl.");
            return;
        }

        var getIl2CppMethodInfoPointerFieldForGeneratedMethod =
            AccessTools.MethodDelegate<GetIl2CppMethodInfoPointerFieldForGeneratedMethod>(
                AccessTools.Method(AccessTools.TypeByName("Il2CppInterop.Common.Il2CppInteropUtils"),
                    "GetIl2CppMethodInfoPointerFieldForGeneratedMethod"));
        var pointerField = getIl2CppMethodInfoPointerFieldForGeneratedMethod(TargetMethod);
        var rawPtr = (nint) pointerField.GetValue(null)!;
        var originalMethod = Marshal.ReadIntPtr(rawPtr);

        HookDelegate = HookMethod;

        nint delegatePointer = Marshal.GetFunctionPointerForDelegate(
            HookDelegate
        );

        Hook = new MelonLoader.NativeUtils.NativeHook<TN>(
            originalMethod,
            delegatePointer
        );

        Hook.Attach();
    }

    /// <summary>
    /// Converts a boolean value to its byte representation.
    /// </summary>
    /// <param name="value">The boolean value to convert.</param>
    /// <returns>A byte value where true is 1 and false is 0.</returns>
    protected static byte GetBoolValue(bool value) => (byte) (value ? 1 : 0);

    private static class TrampolineInvoker {
        private static readonly Func<TN, object[], nint, object> Invoker;

        // ReSharper disable StaticMemberInGenericType
        private static readonly ParameterInfo[] Parameters;
        private static readonly int UserArgCount;

        static TrampolineInvoker() {
            var delegateType = typeof(TN);
            var invokeMethod = delegateType.GetMethod("Invoke")!;
            Parameters = invokeMethod.GetParameters();
            UserArgCount = Parameters.Length - 1;

            var delParam = Expression.Parameter(delegateType, "del");
            var argsParam = Expression.Parameter(typeof(object[]), "args");
            var methodInfoParam = Expression.Parameter(typeof(nint), "methodInfo");

            var callArgs = new Expression[Parameters.Length];
            for (var i = 0; i < UserArgCount; i++) {
                callArgs[i] = Expression.Convert(
                    Expression.ArrayIndex(argsParam, Expression.Constant(i)),
                    Parameters[i].ParameterType
                );
            }
            callArgs[UserArgCount] = methodInfoParam;

            var invokeExpr = Expression.Invoke(delParam, callArgs);
            Expression body = invokeMethod.ReturnType == typeof(void)
                ? Expression.Block(invokeExpr, Expression.Constant(null, typeof(object)))
                : Expression.Convert(invokeExpr, typeof(object));

            Invoker = Expression.Lambda<Func<TN, object[], nint, object>>(body, delParam, argsParam, methodInfoParam).Compile();
        }

        public static object Invoke(TN del, object[] args, nint methodInfo) {
            if (args.Length != UserArgCount)
                throw new ArgumentException(
                    $"Expected {UserArgCount} arguments, but received {args.Length}.",
                    nameof(args));

            var pool = ArrayPool<object>.Shared;
            var scratch = pool.Rent(UserArgCount);

            try {
                for (var i = 0; i < UserArgCount; i++) {
                    var paramType = Parameters[i].ParameterType;
                    var arg = args[i];

                    if (arg is null) {
                        scratch[i] = paramType.IsValueType ? Activator.CreateInstance(paramType)! : null!;
                    } else if (!paramType.IsInstanceOfType(arg) && arg is IConvertible conv) {
                        var target = Nullable.GetUnderlyingType(paramType) ?? paramType;
                        scratch[i] = Convert.ChangeType(conv, target);
                    } else {
                        scratch[i] = arg;
                    }
                }

                return Invoker(del, scratch, methodInfo);
            } finally {
                for (var i = 0; i < UserArgCount; i++)
                    scratch[i] = null!;
                pool.Return(scratch);
            }
        }
    }
}