using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TowerSelectionMenu), nameof(TowerSelectionMenu.OnUpdate))]
internal static class TowerSelectionMenu_Update
{
    private static BaseTSMTheme lastTheme;

    [HarmonyPostfix]
    internal static void Postfix(TowerSelectionMenu __instance)
    {
        if (!__instance.themeManager.Exists().Is(out var themeManager)) return;

        if (themeManager.currentTheme != lastTheme && themeManager.currentTheme != null)
        {
            ModBaseTsmTheme.Setup(themeManager.currentTheme, __instance.selectedTower);

            if (__instance.selectedTower.Def.GetModTower()?.ModTowerSet is ModTowerSet modTowerSet &&
                !(__instance.selectedTower.IsParagon ||
                  !themeManager.currentTheme.Is(out TSMThemeDefault defaultTheme)))
            {
                defaultTheme.towerBackgroundImage.LoadSprite(modTowerSet.PortraitReference);
            }
        }

        lastTheme = themeManager.currentTheme;
    }
}