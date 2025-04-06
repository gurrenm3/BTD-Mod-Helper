using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace BTD_Mod_Helper.Api.Hooks;
/// <summary>
/// Provides a base mod hook for intercepting and modifying method calls using prefix and postfix hooks
/// </summary>
/// <typeparam name="TN">The type of the unmanaged delegate</typeparam>
/// <typeparam name="TM">The type of the managed delegate</typeparam>
public abstract class ModHook<TN, TM> : ModContent where TN : Delegate where TM : Delegate {
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

    /// <summary>
    /// Gets or sets the method information pointer for the hooked method.
    /// The setter only sets the value if it is not already set.
    /// </summary>
    protected nint MethodInfo {
        get => field;
        set {
            if (field == default) {
                field = value;
            }
        }
    }

    /// <summary>
    /// Adds a prefix hook method to be executed before the original method
    /// </summary>
    /// <param name="method">The prefix hook method</param>
    public void AddPrefix(TM method) {
        if (!attached)
            CreateAndAttachHook();

        var hookPriority = method.Method.GetCustomAttribute<HookPriorityAttribute>();
        var priority = hookPriority?.Priority ?? 0;

        if (!PrefixList.ContainsKey(priority)) {
            PrefixList[priority] = [];
        }

        PrefixList[priority].Add(method);
    }


    /// <summary>
    /// Adds a postfix hook method to be executed after the original method
    /// </summary>
    /// <param name="method">The postfix hook method</param>
    public void AddPostfix(TM method) {
        if (!attached)
            CreateAndAttachHook();

        var hookPriority = method.Method.GetCustomAttribute<HookPriorityAttribute>();
        var priority = hookPriority?.Priority ?? 0;

        if (!PostfixList.ContainsKey(priority)) {
            PostfixList[priority] = [];
        }

        PostfixList[priority].Add(method);
    }

    /// <summary>
    /// Unused
    /// </summary>
    public override void Register() { }

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
    public void CreateAndAttachHook() {
        attached = true;
        var delegateType = typeof(TN);

        var attribute = delegateType.GetCustomAttribute<UnmanagedFunctionPointerAttribute>(inherit: false);

        if (attribute == null) {
            ModHelper.Error($"Mod Hook {Name}'s delegate type lacking an UnmanagedFunctionPointer attribute.");
            return;
        }

        if (attribute.CallingConvention != CallingConvention.Cdecl) {
            ModHelper.Error($"Mod Hook {Name}'s delegate type's Calling Convention is not Cdecl.");
            return;
        }

        unsafe {
            var getIl2CppMethodInfoPointerFieldForGeneratedMethod = AccessTools.
                MethodDelegate<GetIl2CppMethodInfoPointerFieldForGeneratedMethod>(
                    AccessTools.Method(AccessTools.TypeByName("Il2CppInterop.Common.Il2CppInteropUtils"),
                        "GetIl2CppMethodInfoPointerFieldForGeneratedMethod"));

            var originalMethod = *(nint*)
                (nint) getIl2CppMethodInfoPointerFieldForGeneratedMethod(TargetMethod).GetValue(null)!;

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
    }

    /// <summary>
    /// Converts a boolean value to its byte representation.
    /// </summary>
    /// <param name="value">The boolean value to convert.</param>
    /// <returns>A byte value where true is 1 and false is 0.</returns>
    protected static byte GetBoolValue(bool value) => (byte)(value ? 1 : 0);

    private static class TrampolineInvoker {
        private static readonly Func<TN, object[], nint, object> Invoker;
        // ReSharper disable once StaticMemberInGenericType
        private static readonly int ExpectedUserArgCount;

        static TrampolineInvoker() {
            var delegateType = typeof(TN);
            var invokeMethod = delegateType.GetMethod("Invoke")
                ?? throw new InvalidOperationException("Delegate has no Invoke method.");
            var parameters = invokeMethod.GetParameters();
            ExpectedUserArgCount = parameters.Length - 1;

            var dynamicMethod = new DynamicMethod(
                "TrampolineInvoke",
                typeof(object), [delegateType, typeof(object[]), typeof(nint)],
                delegateType.Module,
                true);

            var il = dynamicMethod.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);
            for (var i = 0; i < ExpectedUserArgCount; i++) {
                il.Emit(OpCodes.Ldarg_1);
                EmitLoadConstant(il, i);
                il.Emit(OpCodes.Ldelem_Ref);
                EmitCastOrUnbox(il, parameters[i].ParameterType);
            }
            il.Emit(OpCodes.Ldarg_2);

            il.Emit(OpCodes.Callvirt, invokeMethod);

            if (invokeMethod.ReturnType == typeof(void))
                il.Emit(OpCodes.Ldnull);
            else if (invokeMethod.ReturnType.IsValueType)
                il.Emit(OpCodes.Box, invokeMethod.ReturnType);

            il.Emit(OpCodes.Ret);

            Invoker = (Func<TN, object[], nint, object>) dynamicMethod.CreateDelegate(typeof(Func<TN, object[], nint, object>));
        }

        public static object Invoke(TN del, object[] args, nint methodInfo) {
            if (args.Length != ExpectedUserArgCount)
                throw new ArgumentException($"Expected {ExpectedUserArgCount} arguments, but received {args.Length}.");
            return Invoker(del, args, methodInfo);
        }

        private static void EmitLoadConstant(ILGenerator il, int value) {
            switch (value) {
                case 0:
                    il.Emit(OpCodes.Ldc_I4_0);
                    break;
                case 1:
                    il.Emit(OpCodes.Ldc_I4_1);
                    break;
                case 2:
                    il.Emit(OpCodes.Ldc_I4_2);
                    break;
                case 3:
                    il.Emit(OpCodes.Ldc_I4_3);
                    break;
                case 4:
                    il.Emit(OpCodes.Ldc_I4_4);
                    break;
                case 5:
                    il.Emit(OpCodes.Ldc_I4_5);
                    break;
                case 6:
                    il.Emit(OpCodes.Ldc_I4_6);
                    break;
                case 7:
                    il.Emit(OpCodes.Ldc_I4_7);
                    break;
                case 8:
                    il.Emit(OpCodes.Ldc_I4_8);
                    break;
                default:
                    il.Emit(OpCodes.Ldc_I4, value);
                    break;
            }
        }

        private static void EmitCastOrUnbox(ILGenerator il, Type type) {
            il.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);
        }
    }
}
