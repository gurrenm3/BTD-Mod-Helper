using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper.BTD6_UI;
using HarmonyLib;

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