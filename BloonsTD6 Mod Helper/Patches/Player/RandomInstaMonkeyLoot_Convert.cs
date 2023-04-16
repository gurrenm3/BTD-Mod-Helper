using System.Linq;
using Il2CppAssets.Scripts.Models.Store.Loot;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using UnityEngine;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(RandomInstaMonkeyLoot), nameof(RandomInstaMonkeyLoot.Convert))]
internal static class RandomInstaMonkeyLoot_Convert
{
    [HarmonyPrefix]
    private static void Prefix(RandomInstaMonkeyLoot __instance)
    {
        if (string.IsNullOrEmpty(__instance.fixedBaseTower))
        {
            var gameModel = Game.instance.model;
            var towerSet = __instance.fixedTowerSetType;

            var towers = gameModel.towerSet
                .Where(details => details.Is<ShopTowerDetailsModel>())
                .Select(details => gameModel.GetTowerFromId(details.towerId))
                .Where(tower => tower.IsVanillaTower() && (towerSet == TowerSet.None || tower.towerSet == towerSet))
                .Select(tower => tower.baseId)
                .ToArray();

            __instance.fixedBaseTower = towers[Random.RandomRangeInt(0, towers.Length)];
        }
    }
}