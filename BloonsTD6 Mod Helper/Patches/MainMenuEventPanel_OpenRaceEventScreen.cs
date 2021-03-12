using Assets.Scripts.Unity.UI_New.Main.EventPanel;
using BTD_Mod_Helper.Api;
using Harmony;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(MainMenuEventPanel), nameof(MainMenuEventPanel.OpenRaceEventScreen))]
    internal class MainMenuEventPanel_OpenRaceEventScreen
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.IsInRace = true;
        }
    }
}
