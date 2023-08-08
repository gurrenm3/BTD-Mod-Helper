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
internal static class TowerInventory_Patches
{
    [HarmonyPatch(typeof(TowerInventory),"CreatedTower")]
    public class TowerInventoryCreatedTower_Patch{
        [HarmonyPrefix]
        public static bool Prefix(ref TowerInventory __instance,ref TowerModel def){
            if(!__instance.towerCounts.ContainsKey(def.baseId)){
                __instance.towerCounts.Add(def.baseId,0);
            }
	        __instance.towerCounts[def.baseId]=__instance.towerCounts[def.baseId]+1;
	        return false;
        }
    }
    [HarmonyPatch(typeof(TowerInventory),"DestroyedTower")]
    public class TowerInventoryDestroyedTower_Patch{
        [HarmonyPrefix]
        public static bool Prefix(ref TowerInventory __instance,ref TowerModel def){
            if(!__instance.towerCounts.ContainsKey(def.baseId)){
                __instance.towerCounts.Add(def.baseId,0);
            }
		    __instance.towerCounts[def.baseId]=__instance.towerCounts[def.baseId]-1;
		    return false;
        }
    }
}