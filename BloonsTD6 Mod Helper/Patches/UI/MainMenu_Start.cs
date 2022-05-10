﻿using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper.UI.Modded;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Start))]
internal static class MainMenu_Start
{
    [HarmonyPostfix]
    private static void Postfix(MainMenu __instance)
    {
        ModsButton.Create(__instance);
    }
}