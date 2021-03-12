using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper.Api;
using Harmony;
using System.Collections.Generic;

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
            SessionData.PoppedBloons = new Dictionary<string, int>();
            SessionData.RoundSet = null;
            SessionData.IsInPublicCoop = false;
            SessionData.IsInRace = false;
            SessionData.IsInOdyssey = false;
        }
    }
}