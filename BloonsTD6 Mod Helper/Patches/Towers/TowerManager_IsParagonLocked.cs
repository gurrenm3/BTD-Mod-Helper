using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(TowerManager), nameof(TowerManager.IsParagonLocked))]
internal static class TowerManager_IsParagonLocked
{
    [HarmonyPostfix]
    private static void Postfix(Tower tower, ref bool __result)
    {
        if (tower.towerModel.GetModTower() is {paragonUpgrade: ModParagonUpgrade modParagonUpgrade} &&
            modParagonUpgrade.RestrictUpgrading(tower))
        {
            __result = true;
        }
    }
}