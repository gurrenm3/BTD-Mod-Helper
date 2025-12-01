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
    public static List<RaycastResult> Raycast(this Vector3 vector) => ((Vector2) vector).Raycast();

    /// <summary>
    /// Deconstruct for Vector3
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public static void Deconstruct(this Vector3 vector, out float x, out float y, out float z) =>
        (x, y, z) = (vector.x, vector.y, vector.z);
}