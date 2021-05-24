using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Upgrade;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Harmony;
using MelonLoader;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(UpgradeScreen), nameof(UpgradeScreen.UpdateUi))]
    internal class UpgradeScreen_UpdateUi
    {
        [HarmonyPrefix]
        internal static bool Prefix(UpgradeScreen __instance, ref string towerId, ref string __state)
        {
            foreach (var modTower in ModTowerHandler.ModTowers)
            {
                if (towerId == modTower.Id)
                {
                    __instance.hasTower = true;
                    __instance.towerTitle.text = modTower.DisplayName;
                    __instance.xpToSpend.text = "XP? Where we're going, we don't need XP.";
                    __instance.purchaseTowerXP.gameObject.SetActive(false);
                    __instance.purchaseFullTowerUnlock.gameObject.SetActive(false);
                    
                    
                    for (var tier = 0; tier < __instance.path1Upgrades.Count; tier++)
                    {
                        var upgradeDetails = __instance.path1Upgrades[tier];
                        ModifyUpgradeScreen(__instance, modTower, upgradeDetails, 0, tier);
                    }

                    //return false;
                }
            }

            return true;
        }
        
        [HarmonyPostfix]
        internal static void Postfix(UpgradeScreen __instance, ref string __state)
        {
            foreach (var modTower in ModTowerHandler.ModTowers)
            {
                if (__state == modTower.Id)
                {

                    return;
                }
            }
        }

        internal static void ModifyUpgradeScreen(UpgradeScreen upgradeScreen, ModTower modTower, UpgradeDetails details, int path, int tier)
        {
            if (modTower.upgrades[path, tier] is ModUpgrade modUpgrade)
            {
                var towerModel = modTower.GetTowerModel();
                details.upgrade = modUpgrade.GetUpgradeModel();
            }
            else
            {
                details.gameObject.SetActiveRecursively(false);
            }
        }
    }
}
