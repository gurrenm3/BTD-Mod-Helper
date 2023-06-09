using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(TowerManager), nameof(TowerManager.UpgradeTower))]
internal class TowerManager_UpgradeTower
{
    [HarmonyPrefix]
    internal static void Prefix(ref Tower tower, ref TowerModel def, ref string __state)
    {
        __state = null;
        foreach (var upgrade in def.appliedUpgrades)
        {
            if (!tower.towerModel.appliedUpgrades.Contains(upgrade))
            {
                __state = upgrade;
                var unrefTower = tower;
                var unrefDef = def;
                tower = unrefTower;
                def = unrefDef;
            }
        }
    }

    [HarmonyPostfix]
    internal static void Postfix(Tower tower, TowerModel def, string __state)
    {
        if (__state != null)
        {
            ModHelper.PerformHook(mod => mod.OnTowerUpgraded(tower, __state, def));
        }
    }
}