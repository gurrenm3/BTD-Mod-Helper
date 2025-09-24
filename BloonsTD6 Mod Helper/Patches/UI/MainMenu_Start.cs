using System;
using System.Collections.Generic;
using System.Linq;
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
        var methods = typeof(MainMenu).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        var start = methods.FirstOrDefault(x => x.Name == "Start");

        if (start != null)
        {
            yield return start;
            yield break;
        }

        var awake = methods.FirstOrDefault(x => x.Name == "Awake");
        if (awake != null)
        {
            yield return awake;
            yield break;
        }

        var onEnable = methods.FirstOrDefault(x => x.Name == "OnEnable");
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