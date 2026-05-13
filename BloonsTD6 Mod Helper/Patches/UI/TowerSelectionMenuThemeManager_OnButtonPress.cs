using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TowerSelectionMenuThemeManager), nameof(TowerSelectionMenuThemeManager.OnButtonPress))]
internal static class TowerSelectionMenuThemeManager_OnButtonPress
{
    [HarmonyPostfix]
    internal static void Postfix(TowerSelectionMenuThemeManager __instance, TSMButton button)
    {
        if (__instance.CurrentTheme == null) return;

        ModBaseTsmTheme.PerformAction(__instance.CurrentTheme, theme =>
        {
            theme.OnButtonPressed(__instance.CurrentTheme, __instance.PlayerContext.towerSelectionMenu.selectedTower,
                button.ButtonId);
        });
    }
}