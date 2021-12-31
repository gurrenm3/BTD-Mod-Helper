using Assets.Scripts.Unity.UI_New.Settings;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(SettingsScreen), nameof(SettingsScreen.Open))]
    internal static class SettingsScreen_Open
    {
        [HarmonyPostfix]
        private static void Postfix()
        {
            ModOptionsMenu.modsButton = new ShowModOptions_Button();
            ModOptionsMenu.modsButton.Init();
        }
    }
}