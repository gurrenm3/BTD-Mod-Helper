using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(TowerModel), nameof(TowerModel.GetPrimaryWeaponThrowMarkerHeight))]
internal static class TowerModel_GetPrimaryWeaponThrowMarkerHeight
{
    [HarmonyPrefix]
    internal static bool Prefix(TowerModel __instance, ref float __result)
    {
        if (__instance.GetModTower() is not ModFakeTower) return true;

        __result = 0;
        return false;
    }
}