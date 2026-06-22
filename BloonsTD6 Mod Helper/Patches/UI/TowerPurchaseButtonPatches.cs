using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu;
using Il2CppNinjaKiwi.Common.ResourceUtils;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TowerPurchaseButton2D), nameof(TowerPurchaseButton2D.UpdateDisplay))]
internal class TowerPurchaseButton2D_UpdateTowerDisplay
{
    [HarmonyPostfix]
    internal static void Postfix(TowerPurchaseButton2D __instance)
    {
        if (__instance.towerModel.GetModTower()?.ModTowerSet is ModTowerSet modTowerSet)
        {
            ResourceLoader.LoadSpriteFromSpriteReferenceAsync(modTowerSet.ContainerReference, __instance.bg);
        }
    }
}