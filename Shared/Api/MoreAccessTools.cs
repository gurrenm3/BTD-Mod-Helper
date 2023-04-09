using System;
using System.Linq;
using System.Reflection;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// Further methods along the lines of Harmony's <see cref="AccessTools"/>
/// </summary>
public static class MoreAccessTools
{
    /// <summary>
    /// Safely gets the MethodInfo for a method within a nested class. This is recommended to use because over
    /// directly targeting it with typeof and nameof because the nested class names can change randomly.
    /// </summary>
    /// <param name="outerType">The outer type whose name won't change</param>
    /// <param name="nestedTypeName">The name of nested type, not including the _s</param>
    /// <param name="methodName">The desired method name within the nested type</param>
    /// <param name="index">If multiple nested classes share a name portion, use the one at this index, default 0</param>
    /// <returns>The MethodInfo, or null alongside a console warning if one couldn't be found</returns>
    public static MethodInfo SafeGetNestedClassMethod(Type outerType, string nestedTypeName, string methodName = "MoveNext",
        int index = 0)
    {
        var innerTypes = outerType.GetNestedTypes().Where(type => type.Name.Contains($"_{nestedTypeName}_")).ToArray();

        if (!innerTypes.Any() || index >= innerTypes.Length || index < 0)
        {
            ModHelper.Warning($"Failed to find nested type {nestedTypeName} within {outerType.Name} with index {0}");
            return null;
        }

        var innerType = innerTypes[index];

        return AccessTools.Method(innerType, methodName);
    }

    /// <inheritdoc cref="SafeGetNestedClassMethod"/>
    public static bool TryGetNestedClassMethod(Type outerType, string nestedClassName, string methodName, out MethodInfo method, int index = 0)
    {
        method = SafeGetNestedClassMethod(outerType, nestedClassName, methodName, index);
        return method != null;
    }
}