
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Vectors
/// </summary>
public static class Vector3Ext
{
    /// <summary>
    /// Convert UnityEngine.Vector3 to NinjaKiwi's SMath.Vector3
    /// </summary>
    /// <param name="vector3"></param>
    /// <returns></returns>
    public static Il2CppAssets.Scripts.Simulation.SMath.Vector3 ToSMathVector(this Vector3 vector3) => new(vector3);

    /// <inheritdoc cref="Vector2Ext.Raycast"/>
    public static List<RaycastResult> Raycast(this Vector3 vector)
    {
        return ((Vector2) vector).Raycast();
    }
}