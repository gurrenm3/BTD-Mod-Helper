using Assets.Scripts.Simulation.Track;
using Assets.Scripts.Unity.UI_New.InGame;
using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class MapExt
    {
        public static RectTransform GetMapRect(this Map map)
        {
            return InGame.instance.mapRect;
        }
    }
}
