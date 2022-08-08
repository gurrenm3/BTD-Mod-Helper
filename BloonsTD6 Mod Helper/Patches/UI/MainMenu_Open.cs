using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.UI.Modded;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Open))]
internal class MainMenu_Open
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        ResetSessionData();
        ModHelper.PerformHook(mod => mod.OnMainMenu());
    }

    private static void ResetSessionData()
    {
        SessionData.Reset();
    }
}