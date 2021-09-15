using System;
using System.Collections.Generic;
using HarmonyLib;
using Assets.Scripts.Unity.UI;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(FrontendWorld), nameof(FrontendWorld.Start))]
    internal class FrontendWorld_Start
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            ResetSessionData();

            MelonMain.DoPatchMethods(mod => mod.OnFrontEndWorld());
        }

        private static void ResetSessionData()
        {
            SessionData.Reset();
        }
    }
}
