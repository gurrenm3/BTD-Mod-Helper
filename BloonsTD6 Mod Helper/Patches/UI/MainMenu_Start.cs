using Assets.Scripts.Unity.UI_New.Main;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Start))]
    internal static class MainMenu_Start
    {
        [HarmonyPostfix]
        private static void Postfix(MainMenu __instance)
        {
            ModsButton.Create(__instance);
        }
    }
}