using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(TowerManager), nameof(TowerManager.IsParagonLocked))]
internal static class TowerManager_IsParagonLocked
{
    [HarmonyPostfix]
    private static void Postfix(TowerManager __instance, Tower tower, ref bool __result)
    {       
        var result = false;

        if (tower.towerModel.GetModTower() is {paragonUpgrade: ModParagonUpgrade modParagonUpgrade} &&
            modParagonUpgrade.RestrictUpgrading(tower))
        {
            result = true;
        }
        
        ModHelper.PerformAdvancedModHook(mod => mod.PostIsParagonLocked(__instance, tower, result));

        __result = result;
    }
    
}