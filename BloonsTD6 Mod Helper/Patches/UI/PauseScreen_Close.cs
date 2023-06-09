using Il2CppAssets.Scripts.Unity.UI_New.Pause;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(PauseScreen), nameof(PauseScreen.Close))]
internal static class PauseScreen_Close
{
    [HarmonyPostfix]
    private static void Postfix(PauseScreen __instance)
    {
        ModHelper.PerformHook(mod => mod.OnPauseScreenClosed(__instance));
        SessionData.Instance.IsPaused = false;
    }
}