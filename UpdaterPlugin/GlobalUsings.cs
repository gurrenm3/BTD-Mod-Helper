global using HarmonyLib;
global using MelonLoader;

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