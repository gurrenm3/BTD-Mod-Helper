using Il2CppSystem.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Vectors
/// </summary>
public static class Vector2Ext
{
    /// <summary>
    /// Raycasts this screen point
    /// </summary>
    /// <param name="vector">screen point</param>
    /// <returns>raycast results</returns>
    public static List<RaycastResult> Raycast(this Vector2 vector)
    {
        var raycastResults = new List<RaycastResult>();
        var data = new PointerEventData(EventSystem.current)
        {
            position = vector
        };
        EventSystem.current.RaycastAll(data, raycastResults);

        return raycastResults;
    }
}