using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(TowerInventory), nameof(TowerInventory.Init))]
internal static class TowerInventory_Init
{
    [HarmonyPrefix]
    private static bool Prefix(ref TowerInventory __instance,
        ref Il2CppSystem.Collections.Generic.IEnumerable<TowerDetailsModel> allTowersInTheGame)
    {
        var result = true;
        var unref__instance = __instance;
        var list = allTowersInTheGame.ToList();
        var unref_allTowersInTheGame = (IEnumerable<TowerDetailsModel>) list;

        ModHelper.PerformAdvancedModHook(mod =>
            result &= mod.PreTowerInventoryInit(ref unref__instance, ref unref_allTowersInTheGame));
        __instance = unref__instance;

        allTowersInTheGame = list.ToIl2CppReferenceArray()
            .Cast<Il2CppSystem.Collections.Generic.IEnumerable<TowerDetailsModel>>();

        return result;
    }

    [HarmonyPostfix]
    private static void Postfix(TowerInventory __instance, IEnumerable<TowerDetailsModel> allTowersInTheGame)
    {
        ModHelper.PerformAdvancedModHook(mod => mod.PostTowerInventoryInit(__instance, allTowersInTheGame.ToList()));
    }
}

/// <summary>
/// Prevent crashes for non-subtowers that aren't in the inventory
/// </summary>
[HarmonyPatch]
internal static class TowerInventory_Patches
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(TowerInventory), nameof(TowerInventory.UpdatedTower));
        yield return AccessTools.Method(typeof(TowerInventory), nameof(TowerInventory.DestroyedTower));
        yield return AccessTools.Method(typeof(TowerInventory), nameof(TowerInventory.CreatedTower));
    }

    [HarmonyPrefix]
    private static bool Prefix(TowerInventory __instance, TowerModel def)
    {
        return __instance.towerMaxes.ContainsKey(def.baseId);
    }
}