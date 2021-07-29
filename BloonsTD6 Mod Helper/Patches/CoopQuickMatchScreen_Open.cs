using Assets.Scripts.Unity.UI_New.Coop;
using BTD_Mod_Helper.Api;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(CoopQuickMatchScreen), nameof(CoopQuickMatchScreen.Open))]
    internal class CoopQuickMatchScreen_Open
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.IsInPublicCoop = true;
        }
    }
}
