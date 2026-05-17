using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TowerSelectionMenuThemeManager), nameof(TowerSelectionMenuThemeManager.InfoChanged))]
internal static class TowerSelectionMenuThemeManager_InfoChanged
{
    [HarmonyPostfix]
    internal static void Postfix(TowerSelectionMenuThemeManager __instance, Selectable selectable)
    {
        if (__instance.CurrentTheme == null || !selectable.Is(out TowerToSimulation tower)) return;

        ModBaseTsmTheme.PerformAction(__instance.CurrentTheme, theme =>
        {
            theme.TowerChanged(__instance.CurrentTheme, tower);
        });
    }
}