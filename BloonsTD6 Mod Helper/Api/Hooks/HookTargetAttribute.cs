using System;

namespace BTD_Mod_Helper.Api.Hooks;

/// <summary>
/// Specifies the target type and hook type for a method hook.
/// </summary>
/// <param name="targetType">The ModHook type that this hook targets</param>
/// <param name="hookType">The type of hook (Prefix or Postfix)</param>
[AttributeUsage(AttributeTargets.Method)]
public class HookTargetAttribute(Type targetType, HookTargetAttribute.EHookType hookType) : Attribute
{
    /// <summary>
    /// Represents the type of hook to apply
    /// </summary>
    public enum EHookType
    {
        /// <summary>
        /// Indicates that the hook is executed before the target method
        /// </summary>
        Prefix,
        /// <summary>
        /// Indicates that the hook is executed after the target method
        /// </summary>
        Postfix
    }

    /// <summary>
    /// Gets the target type that this hook applies to
    /// </summary>
    public Type TargetType { get; } = targetType;

    /// <summary>
    /// Gets the hook type indicating when the hook is applied
    /// </summary>
    public EHookType HookType { get; } = hookType;
}