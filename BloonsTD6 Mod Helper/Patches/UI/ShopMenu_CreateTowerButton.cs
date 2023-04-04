using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(ShopMenu), nameof(ShopMenu.CreateTowerButton))]
internal static class ShopMenu_CreateTowerButton
{
    [HarmonyPrefix]
    private static bool Prefix(ref TowerModel model, ref int buttonIndex, ref bool showCounts,
        ref TowerPurchaseButton __result)
    {
        var result = true;
        var unrefmodel = model;
        var unrefbuttonIndex = buttonIndex;
        var unrefshowTowerCounts = showCounts;
        var unref__result = __result;
        ModHelper.PerformAdvancedModHook(mod => result &= mod.PreTowerButtonCreated(ref unrefmodel,
            ref unrefbuttonIndex, ref unrefshowTowerCounts, ref unref__result));
        model = unrefmodel;
        buttonIndex = unrefbuttonIndex;
        showCounts = unrefshowTowerCounts;
        __result = unref__result;
        return result;
    }

    [HarmonyPostfix]
    private static void Postfix(TowerModel model, int buttonIndex, bool showCounts,
        ref TowerPurchaseButton __result)
    {
        var unref__result = __result;
        ModHelper.PerformAdvancedModHook(mod =>
            mod.PostTowerButtonCreated(model, buttonIndex, showCounts, ref unref__result));
        __result = unref__result;
    }
}