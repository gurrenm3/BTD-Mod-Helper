using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Patches.UI;

//todo: test whether custom towerset backgrounds still work
/*[HarmonyPatch(typeof(TowerPurchaseButton2D), nameof(TowerPurchaseButton2D.UpdateDisplay))]
internal class TowerPurchaseButton2D_DetermineBackgroundSprite
{
    [HarmonyPrefix]
    internal static bool Prefix(TowerPurchaseButton2D __instance, ref SpriteReference __result)
    {
        if (__instance.towerModel.GetModTower()?.ModTowerSet is ModTowerSet modTowerSet)
        {
            __result = modTowerSet.ContainerReference;
            ModHelper.Log($"TowerPurchaseButton2D_DetermineBackgroundSprite: {modTowerSet.ContainerReference}");
            return false;
        }

        return true;
    }
}*/

[HarmonyPatch(typeof(TowerPurchaseButton2D), nameof(TowerPurchaseButton2D.UpdateDisplay))]
internal class TowerPurchaseButton2D_UpdateTowerDisplay
{
    [HarmonyPostfix]
    internal static void Postfix(TowerPurchaseButton2D __instance)
    {
        if (__instance.towerModel.GetModTower()?.ModTowerSet is ModTowerSet modTowerSet)
        {
            ResourceLoader.LoadSpriteFromSpriteReferenceAsync(modTowerSet.ContainerReference,
                __instance.GetComponent<Image>());
        }
    }
}