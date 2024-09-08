using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu;
using UnityEngine.InputSystem;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(Hotkeys), nameof(Hotkeys.Setup))]
internal static class Hotkeys_Setup
{
    [HarmonyPostfix]
    private static void Postfix(Hotkeys __instance)
    {
        foreach (var towerPurchaseButton in ShopMenu.instance.ActiveTowerButtons)
        {
            var towerBaseId = towerPurchaseButton.TowerModel.baseId;

            if (!ModTowerHelper.ModTowerCache.TryGetValue(towerBaseId, out var modTower) || modTower.Hotkey == null)
                continue;

            var hotkeyButton = __instance.hotKeyButtonSet.buttons[towerBaseId] =
                new HotkeyButton(new InputAction(), modTower.Hotkey.hotKey, modTower.Hotkey.hotKey.path);

            __instance.towerHotkeys.Add(new Hotkeys.TowerHotkeyInfo
            {
                towerBaseId = towerBaseId,
                towerPurchaseButton = towerPurchaseButton,
                hotkeyButton = hotkeyButton
            });
        }
    }
}