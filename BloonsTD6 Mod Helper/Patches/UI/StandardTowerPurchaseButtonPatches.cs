using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(StandardTowerPurchaseButton), nameof(StandardTowerPurchaseButton.DetermineBackgroundSprite))]
    internal class StandardTowerPurchaseButton_DetermineBackgroundSprite
    {
        [HarmonyPostfix]
        internal static void Postfix(StandardTowerPurchaseButton __instance, ref SpriteReference __result)
        {
            if (__instance.towerModel.GetModTower()?.ModTowerSet is ModTowerSet modTowerSet)
            {
                __result = modTowerSet.ContainerReference;
            }
        }
    }

    [HarmonyPatch(typeof(StandardTowerPurchaseButton), nameof(StandardTowerPurchaseButton.UpdateTowerDisplay))]
    internal class StandardTowerPurchaseButton_UpdateTowerDisplay
    {
        [HarmonyPostfix]
        internal static void Postfix(StandardTowerPurchaseButton __instance)
        {
            if (__instance.towerModel.GetModTower()?.ModTowerSet is ModTowerSet modTowerSet)
            {
                ResourceLoader.LoadSpriteFromSpriteReferenceAsync(modTowerSet.ContainerReference, __instance.GetComponent<Image>());
            }
        }
    }












}