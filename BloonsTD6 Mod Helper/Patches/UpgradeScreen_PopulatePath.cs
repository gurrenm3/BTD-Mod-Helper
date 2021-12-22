using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Unity.UI_New.Upgrade;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using UnityEngine;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(UpgradeScreen), nameof(UpgradeScreen.PopulatePath))]
    internal class UpgradeScreen_PopulatePath
    {
        [HarmonyPostfix]
        internal static void Postfix(UpgradeScreen __instance, TowerModel tower, int pathIndex, Il2CppReferenceArray<UpgradeDetails> pathUpgrades)
        {
            var modTower = tower.GetModTower();
            if (modTower != null)
            {
                var portrait = modTower.PortraitReference;
                var maxPathTier = modTower.tierMaxes[pathIndex];
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
    }
}