using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Projectiles;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.Display.Animation;
using Assets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class TowerExt
    {
        /// <summary>
        /// Get the MonkeyAnimationController for this Tower. Needed to modify 3D models
        /// </summary>
        /// <returns></returns>
        public static MonkeyAnimationController GetMonkeyAnimController(this Tower tower)
        {
            return tower.GetUnityDisplayNode()?.monkeyAnimationController;
        }
    }
}
