using System.Reflection;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Simulation.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

/// <summary>
/// Prevent crashes for non-subtowers that aren't in the inventory
/// </summary>
[HarmonyPatch]
internal static class TowerInventory_Patches
{
    private static System.Collections.Generic.IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(TowerInventory), nameof(TowerInventory.UpdatedTower));
        yield return AccessTools.Method(typeof(TowerInventory), nameof(TowerInventory.DestroyedTower));
        yield return AccessTools.Method(typeof(TowerInventory), nameof(TowerInventory.CreatedTower));
    }

    [HarmonyPrefix]
    private static bool Prefix(TowerInventory __instance, TowerModel def) => __instance.towerMaxes.ContainsKey(def.baseId);
}

[HarmonyPatch]
internal static class TowerInventory_Patches2
{
    private static System.Collections.Generic.IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(TowerInventory), nameof(TowerInventory.IsPathTierLocked));
    }

    [HarmonyPrefix]
    private static bool Prefix(TowerInventory __instance, Tower tower) =>
        __instance.towerMaxes.ContainsKey(tower.towerModel.baseId);
}