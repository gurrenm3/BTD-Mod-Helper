using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(TowerManager), nameof(TowerManager.IsParagonLocked))]
internal static class TowerManager_IsParagonLocked
{
    [HarmonyPrefix]
    private static bool Prefix(TowerManager __instance, ref Tower tower, ref bool __result)
    {
        var result = false;
        var keepexecuting = true;
        
        var unreftower = tower;

        ModHelper.PerformAdvancedModHook(mod => keepexecuting &= mod.PreIsParagonLocked(ref __instance, ref unreftower, ref result));

        tower = unreftower;
        
        __result = result;
        return keepexecuting;
    }
    
    [HarmonyPostfix]
    private static void Postfix(TowerManager __instance, Tower tower, ref bool __result)
    {
        var result = tower.towerModel.GetModTower() is {paragonUpgrade: ModParagonUpgrade modParagonUpgrade} &&
                     modParagonUpgrade.RestrictUpgrading(tower);

        ModHelper.PerformAdvancedModHook(mod => mod.PostIsParagonLocked(__instance, tower, ref result));

        __result = result;
    }
    
}