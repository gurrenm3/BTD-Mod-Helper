using Assets.Scripts.Unity.UI_New.ChallengeEditor;
using BTD_Mod_Helper.Api;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(ExtraSettingsScreen), nameof(ExtraSettingsScreen.Open))]
    internal static class ExtraSettingsScreen_Open
    {
        [HarmonyPrefix]
        private static bool Prefix(ExtraSettingsScreen __instance, ref Il2CppSystem.Object menuData)
        {
            return ModGameMenu.CheckOpen(__instance, menuData, out menuData);
        }
    }
}