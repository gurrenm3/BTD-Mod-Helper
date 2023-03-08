using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Input;
namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(TowerInventory), nameof(TowerInventory.Init))]
internal static class TowerInventory_Init
{
    [HarmonyPrefix]
    private static bool Prefix(ref TowerInventory __instance, ref IEnumerable<TowerDetailsModel> allTowersInTheGame)
    {
        var result = true;
        var unref__instance = __instance;
        var unref_allTowersInTheGame = allTowersInTheGame.ToList();
        ModHelper.PerformAdvancedModHook(mod => result &=  mod.PreTowerInventoryInit(ref unref__instance, ref unref_allTowersInTheGame));
        __instance = unref__instance;
        allTowersInTheGame = unref_allTowersInTheGame;
        return result;
    }
    [HarmonyPostfix]
    private static void Postfix(TowerInventory __instance, IEnumerable<TowerDetailsModel> allTowersInTheGame)
    {
        ModHelper.PerformAdvancedModHook(mod => mod.PostTowerInventoryInit(__instance, allTowersInTheGame.ToList()));
    }
}