using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Linq;
using System;

namespace BTD_Mod_Helper.Extensions
{
    public static class TowerToSimulationExt
    {
        /// <summary>
        /// This is Obsolete, use GetTower instead. (Cross-Game compatible) Return the Tower associated with this TowerToSimulation. 
        /// </summary>
        /// <param name="towerToSim"></param>
        /// <returns></returns>
        [Obsolete]
        public static Tower GetSimTower(this TowerToSimulation towerToSim)
        {
            return InGame.instance.GetTowers().FirstOrDefault(t => t.GetTowerSim().Equals(towerToSim));
        }

        /// <summary>
        /// (Cross-Game compatible) Return the Tower associated with this TowerToSimulation
        /// </summary>
        /// <param name="towerToSim"></param>
        /// <returns></returns>
        public static Tower GetTower(this TowerToSimulation towerToSim)
        {
#if BloonsTD6
            return towerToSim.tower;
#elif BloonsAT
            return InGame.instance.GetTowers().FirstOrDefault(t => t.GetTowerToSim().Equals(towerToSim));
#endif

        }
    }
}
