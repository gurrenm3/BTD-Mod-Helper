using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(ShopMenu), nameof(ShopMenu.CreateTowerButton))]
internal static class ShopMenu_CreateTowerButton
{

    [HarmonyPostfix]
    private static void Postfix(TowerModel model, int buttonIndex, bool showCounts,
        ref TowerPurchaseButton __result)
    {
        var unref__result = __result;
        ModHelper.PerformHook(mod =>
            mod.OnTowerButtonCreated(model, buttonIndex, showCounts, ref unref__result));
        __result = unref__result;
    }
}