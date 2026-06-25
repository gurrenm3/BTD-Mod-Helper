using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api.UI;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes;
using UnityEngine;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MenuThemeManager), nameof(MenuThemeManager.SetTheme))]
internal class MenuThemeManager_SetTheme
{
    [HarmonyPostfix]
    internal static void Postfix(MenuThemeManager __instance, BaseTSMTheme newTheme)
    {
        if (!__instance.PlayerContext.towerSelectionMenu.Is(out TowerSelectionMenu menu) ||
            menu.selectedTower.Def.GetModTower()?.ModTowerSet is not ModTowerSet modTowerSet ||
            menu.selectedTower.IsParagon ||
            !newTheme.Is(out TSMThemeDefault defaultTheme)) return;

        TaskScheduler.ScheduleTask(() => defaultTheme.towerBackgroundImage.LoadSprite(modTowerSet.PortraitReference));
    }
}