using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch]
internal static class TowerSelectionMenuThemeManager_UpdateThemeAsync
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return MoreAccessTools.SafeGetNestedClassMethod(typeof(TowerSelectionMenuThemeManager),
            nameof(TowerSelectionMenuThemeManager.UpdateThemeAsync));
    }

    [HarmonyPrefix]
    internal static void Prefix(object __instance, ref int __state)
    {
        try
        {
            var tsmThemeManager = (TowerSelectionMenuThemeManager) AccessTools.GetDeclaredProperties(__instance.GetType())
                .First(field => field.PropertyType == typeof(TowerSelectionMenuThemeManager))
                .GetValue(__instance)!;

            __state = tsmThemeManager.themes.Count;
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }
    }

    [HarmonyPostfix]
    internal static void Postfix(object __instance, int __state)
    {
        try
        {
            var tsmThemeManager = (TowerSelectionMenuThemeManager) AccessTools.GetDeclaredProperties(__instance.GetType())
                .First(field => field.PropertyType == typeof(TowerSelectionMenuThemeManager))
                .GetValue(__instance)!;

            if (tsmThemeManager.themes.Count <= __state) return;

            var newTheme = tsmThemeManager.themes.Last();

            var tower = (TowerToSimulation) AccessTools.GetDeclaredProperties(__instance.GetType())
                .First(info => info.PropertyType == typeof(TowerToSimulation)).GetValue(__instance)!;

            TaskScheduler.ScheduleTask(() => ModBaseTsmTheme.Setup(newTheme, tower));
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }
    }
}