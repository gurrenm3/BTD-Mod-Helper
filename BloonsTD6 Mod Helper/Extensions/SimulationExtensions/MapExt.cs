using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Maps
/// </summary>
public static partial class MapExt
{
    /// <summary>
    /// Gets the Map's rectangle
    /// </summary>
    public static RectTransform GetMapRect(this Map map)
    {
        return InGame.instance.mapRect;
    }
}