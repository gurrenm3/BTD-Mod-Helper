global using HarmonyLib;
global using MelonLoader;
global using BTD_Mod_Helper.Extensions;
global using Il2CppInterop.Runtime.InteropTypes;
global using Il2CppInterop.Runtime.Runtime;
global using Il2CppInterop.Runtime.InteropTypes.Arrays;
global using Il2Cpp;

using System.ComponentModel;

#pragma warning disable CS1591

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices;

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class IsExternalInit
{
}


[AttributeUsage(AttributeTargets.All, Inherited = false)]
public sealed class NullableAttribute : Attribute
{
    public readonly byte[] NullableFlags;
    public NullableAttribute(byte b) => NullableFlags = [b];
    public NullableAttribute(byte[] b) => NullableFlags = b;
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Module, Inherited = false)]
public sealed class NullableContextAttribute : Attribute
{
    public readonly byte Flag;
    public NullableContextAttribute(byte flag) => Flag = flag;
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Delegate | AttributeTargets.Parameter, Inherited = false)]
public sealed class IsUnmanagedAttribute : Attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, Inherited = false)]
public sealed class CollectionBuilderAttribute(Type builderType, string methodName) : Attribute
{
    public Type BuilderType { get; } = builderType;
    public string MethodName { get; } = methodName;
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
public sealed class RequiredMemberAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
public sealed class CompilerFeatureRequiredAttribute : Attribute
{
    public string FeatureName { get; }
    public bool IsOptional { get; init; }
    public CompilerFeatureRequiredAttribute(string featureName) => FeatureName = featureName;
}