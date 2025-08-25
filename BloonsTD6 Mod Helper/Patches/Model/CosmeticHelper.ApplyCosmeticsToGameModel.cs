using Il2CppAssets.Scripts.Models;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(CosmeticHelper), nameof(CosmeticHelper.ApplyCosmeticsToGameModel))]
internal static class CosmeticHelper_ApplyCosmeticsToGameModel
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        var result = CosmeticHelper.rootGameModel;

        foreach (var towerModel in result.towers)
        {
            if (towerModel.GetModTower() is not { } modTower) continue;

            modTower.ModifyTowerModelForMatch(towerModel, result);

            var modUpgrades = modTower.GetUpgradesForTiers(towerModel.tiers);

            foreach (var modUpgrade in modUpgrades)
            {
                modUpgrade.ApplyUpgradeForMatch(towerModel, result);
            }
        }

    }
}