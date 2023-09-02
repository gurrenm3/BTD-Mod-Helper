using System.Linq;
using System.Reflection;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppSystem.Collections.Generic;
namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(TowerInventory), nameof(TowerInventory.Init))]
internal static class TowerInventory_Init
{
    [HarmonyPrefix]
    private static void Prefix(TowerInventory __instance, ref IEnumerable<TowerDetailsModel> allTowersInTheGame)
    {
        var list = allTowersInTheGame.ToList();
        var unref_allTowersInTheGame = (System.Collections.Generic.IEnumerable<TowerDetailsModel>) list;

        ModHelper.PerformHook(mod => mod.PreTowerInventoryInit(__instance, ref unref_allTowersInTheGame));

        allTowersInTheGame = list.ToIl2CppReferenceArray()
            .Cast<IEnumerable<TowerDetailsModel>>();

    }

    [HarmonyPostfix]
    private static void Postfix(TowerInventory __instance, IEnumerable<TowerDetailsModel> allTowersInTheGame)
    {
        ModHelper.PerformHook(mod => mod.OnTowerInventoryInit(__instance, allTowersInTheGame.ToList()));
    }
}

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