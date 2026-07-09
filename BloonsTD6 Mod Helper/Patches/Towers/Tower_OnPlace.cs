using Il2CppAssets.Scripts.Simulation.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(Tower), nameof(Tower.OnPlace))]
internal static class Tower_OnPlace
{
    [HarmonyPostfix]
    internal static void Postfix(Tower __instance, bool playPlacementEffects)
    {
        if (!playPlacementEffects) return;
        ModHelper.PerformHook(mod => mod.OnTowerPlaced(__instance));
        if (__instance.towerModel.GetModTower() is { } modTower)
        {
            modTower.OnPlaced(__instance);
        }
    }
}