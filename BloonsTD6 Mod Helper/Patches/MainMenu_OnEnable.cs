using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper.Api;
using HarmonyLib;
using System.Collections.Generic;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Open))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            ResetSessionData();
            
            MelonMain.DoPatchMethods(mod => mod.OnMainMenu());
        }

        private static void ResetSessionData()
        {
            SessionData.Reset();
        }
    }
}