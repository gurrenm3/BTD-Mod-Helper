﻿using Assets.Scripts.Unity.UI_New.Coop;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(CoopQuickMatchScreen), nameof(CoopQuickMatchScreen.Open))]
    internal class CoopQuickMatchScreen_Open
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.Instance.IsInPublicCoop = true;
        }
    }
}
