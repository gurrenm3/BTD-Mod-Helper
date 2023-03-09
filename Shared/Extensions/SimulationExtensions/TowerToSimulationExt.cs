using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for TowerToSimulation
/// </summary>
public static class TowerToSimulationExt
{
    /// <summary>
    /// Return the Tower associated with this TowerToSimulation
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