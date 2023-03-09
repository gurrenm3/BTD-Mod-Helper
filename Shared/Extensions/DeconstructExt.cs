using System.Collections.Generic;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Adding more deconstruct methods to things
/// </summary>
public static class DeconstructExt
{
    /// <summary>
    /// Deconstruct a rectangle
    /// </summary>
    public static void Deconstruct(this Rect rect, out float x, out float y, out float width, out float height)
    {
        x = rect.x;
        y = rect.y;
        width = rect.width;
        height = rect.height;
    }
        
    /// <summary>
    /// For some reason the normal deconstruct isn't accessible in all places?
    /// </summary>
    public static void Deconstruct(this Vector2 vector2, out float x, out float y)
    {
        x = vector2.x;
        y = vector2.y;
    }
        
    /// <summary>
    /// For some reason the normal deconstruct isn't accessible in all places?
    /// </summary>
    public static void Deconstruct<T1, T2>(this KeyValuePair<T1, T2> kvp, out T1 t1, out T2 t2)
    {
        t1 = kvp.Key;
        t2 = kvp.Value;
    }
}