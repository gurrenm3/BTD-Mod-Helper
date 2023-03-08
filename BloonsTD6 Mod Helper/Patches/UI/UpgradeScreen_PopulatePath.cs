using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Unity.UI_New.Upgrade;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(UpgradeScreen), nameof(UpgradeScreen.PopulatePath))]
internal class UpgradeScreen_PopulatePath
{
    [HarmonyPostfix]
    internal static void Postfix(UpgradeScreen __instance, TowerModel tower, int pathIndex,
        Il2CppReferenceArray<UpgradeDetails> pathUpgrades)
    {
        if (tower?.GetModTower() is not ModTower modTower) return;

        var portrait = modTower.PortraitReference;
        var maxPathTier = modTower.TierMaxes[pathIndex];
        var emptyAbilities = new List<AbilityModel>().Cast<ICollection<AbilityModel>>();
        var upgradeModel = modTower.dummyUpgrade;
        for (var i = maxPathTier; i < 5; i++)
        {
            var upgradeDetails = pathUpgrades[i];
            upgradeDetails.SetUpgrade(tower.baseId, upgradeModel, emptyAbilities, pathIndex, portrait);
            upgradeDetails.gameObject.SetActive(false);
        }

        if (maxPathTier < 5)
        {
            var bgLines = __instance.transform.GetComponentFromChildrenByName<RectTransform>($"{pathIndex + 1}");
            bgLines.GetComponentsInChildren<CanvasRenderer>().Do(renderer =>
            {
                renderer.SetAlpha(0);
            });
        }
    }
}