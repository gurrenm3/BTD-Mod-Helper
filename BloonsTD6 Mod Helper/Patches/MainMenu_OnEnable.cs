using Assets.Scripts.Unity.UI_New.Main;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Open))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            ResetSessionData();

            MelonMain.PerformHook(mod => mod.OnMainMenu());
        }

        private static void ResetSessionData()
        {
            SessionData.Reset();
        }
    }
}