using System;

namespace BTD_Mod_Helper.Api.Hooks;

/// <summary>
/// Specifies the priority of this hook compared to others
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class HookPriorityAttribute : Attribute
{
    /// <summary>
    /// Backing priority value for sorting
    /// </summary>
    public int Priority;

    /// <summary>
    /// Represents the lower level with a value of -100
    /// </summary>
    public const int Lower = -100;

    /// <summary>
    /// Represents a low level with a value of -50
    /// </summary>
    public const int Low = -50;

    /// <summary>
    /// Represents the default level with a value of 0
    /// </summary>
    public const int Default = 0;

    /// <summary>
    /// Represents a high level with a value of 50
    /// </summary>
    public const int High = 50;

    /// <summary>
    /// Represents the higher level with a value of 100
    /// </summary>
    public const int Higher = 100;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="priority">The priority to set</param>
    public HookPriorityAttribute(int priority = Default) => Priority = priority;
}