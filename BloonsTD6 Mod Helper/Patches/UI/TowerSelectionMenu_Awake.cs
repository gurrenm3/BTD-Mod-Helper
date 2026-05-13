using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenu), nameof(Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenu.Awake))]
internal static class TowerSelectionMenu_Awake
{
    [HarmonyPrefix]
    internal static void Prefix(Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenu __instance)
    {
        TaskScheduler.ScheduleTask(() =>
        {
            foreach (var modTsmTheme in ModContent.GetContent<ModTsmTheme>())
            {
                if (__instance.themeManager.themeReferencesByThemeId.ContainsKey(modTsmTheme.BaseTheme))
                {
                    var reference = __instance.themeManager.themeReferencesByThemeId[modTsmTheme.BaseTheme];
                    __instance.themeManager.themeReferencesByThemeId[modTsmTheme.Id] = reference;
                }
                else
                {
                    ModHelper.Warning($"Could not find base theme {modTsmTheme.BaseTheme} for ModTsmTheme {modTsmTheme.Id}");
                }
            }
        }, () => __instance.themeManager?.themeReferencesByThemeId != null, stopCondition: () => __instance == null);
    }
}