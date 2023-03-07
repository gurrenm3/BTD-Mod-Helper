using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(TowerManager), nameof(TowerManager.UpgradeTower))]
internal class TowerManager_UpgradeTower
{
    [HarmonyPrefix]
    internal static bool Prefix(ref Tower tower, ref TowerModel def, ref string __state)
    {
        var result = true;
        __state = null;
        foreach (var upgrade in def.appliedUpgrades)
        {
            if (!tower.towerModel.appliedUpgrades.Contains(upgrade))
            {
                __state = upgrade;
                var unrefTower = tower;
                var unrefDef = def;
                ModHelper.PerformAdvancedModHook(mod => result&=  mod.PreTowerUpgraded(ref unrefTower, upgrade, ref unrefDef));
                tower = unrefTower;
                def = unrefDef;
            }
        }

        return result;
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