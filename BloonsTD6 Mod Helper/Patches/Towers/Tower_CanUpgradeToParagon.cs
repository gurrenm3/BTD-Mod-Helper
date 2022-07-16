using Assets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(Tower), nameof(Tower.CanUpgradeToParagon))]
internal static class Tower_CanUpgradeToParagon
{
    [HarmonyPostfix]
    private static void Postfix(Tower __instance, ref bool __result)
    {
        var towerModel = __instance.towerModel;
        if (towerModel.paragonUpgrade != null &&
            ModContent.Find<ModUpgrade>(towerModel.paragonUpgrade.upgrade) is ModParagonUpgrade modUpgrade &&
            modUpgrade.RestrictUpgrading(__instance))
        {
            __result = false;
        }
    }
}