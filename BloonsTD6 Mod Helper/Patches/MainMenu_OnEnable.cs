using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper.Api;
using Harmony;
using System.Collections.Generic;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
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
            SessionData.nkGI = null;
            SessionData.PoppedBloons = new Dictionary<string, int>();
            SessionData.RoundSet = null;
            SessionData.IsInPublicCoop = false;
            SessionData.IsInRace = false;
            SessionData.IsInOdyssey = false;
            SessionData.bloonTracker = new BloonTracker();
        }
    }
}