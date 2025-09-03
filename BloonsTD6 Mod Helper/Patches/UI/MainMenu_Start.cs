using System;
using System.Collections.Generic;
using System.Reflection;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.UI.Menus;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Unity.UI_New.Main;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch]
internal static class MainMenu_OnEnable
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        var start = AccessTools.Method(typeof(MainMenu), "Start");

        if (start != null)
        {
            yield return start;
            yield break;
        }

        var awake = AccessTools.Method(typeof(MainMenu), "Awake");

        if (awake != null)
        {
            yield return awake;
            yield break;
        }

        var onEnable = AccessTools.Method(typeof(MainMenu), "OnEnable");
        if (onEnable != null)
        {
            yield return onEnable;
            yield break;
        }

        throw new MissingMethodException("No method found for MainMenu initialization patch");
    }


    [HarmonyPostfix]
    private static void Postfix(MainMenu __instance)
    {
        ModsButton.Create(__instance);
        ModsMenu.selectedMod = null;
        ModdedMonkeySelectMenu.ResetGameModel();
        ModHelper.PerformHook(mod => mod.OnMainMenu());

        if (MelonMain.AutoUpdate)
        {
            UpdaterPlugin.CheckUpdatedMods();
        }
    }
}