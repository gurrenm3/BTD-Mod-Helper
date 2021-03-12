using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Linq;

namespace BTD_Mod_Helper.Extensions
{
    public static class TowerToSimulationExt
    {
        public static Tower GetSimTower(this TowerToSimulation towerToSim)
        {
            return InGame.instance.GetTowers().FirstOrDefault(t => t.GetTowerSim().Equals(towerToSim));
        }
    }
}
