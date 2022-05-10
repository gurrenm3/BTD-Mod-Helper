using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class UnityToSimulationExt
    {
        public static List<Projectile> GetAllProjectiles(this UnityToSimulation unityToSimulation)
        {
            return InGame.instance.GetAllObjectsOfType<Projectile>();
        }
    }
}
