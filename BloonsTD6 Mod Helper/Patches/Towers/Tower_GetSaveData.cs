using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Simulation.Towers;
namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(Tower), nameof(Tower.GetSaveData))]
internal class Tower_GetSaveData
{
    [HarmonyPostfix]
    internal static void Postfix(Tower __instance, TowerSaveDataModel __result)
    {
        ModHelper.PerformHook(mod => mod.OnTowerSaved(__instance, __result));
    }
}