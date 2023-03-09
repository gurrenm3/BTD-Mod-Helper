using Il2CppAssets.Scripts.Unity.UI_New.Pause;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(PauseScreen), nameof(PauseScreen.Close))]
internal static class PauseScreen_Close
{
    [HarmonyPrefix]
    private static bool Prefix(ref PauseScreen __instance)
    {
        var result = true;
        var unref__instance = __instance;
        ModHelper.PerformAdvancedModHook(mod=> result &= mod.PrePauseScreenClosed(ref unref__instance));
        return result;
    }
    [HarmonyPostfix]
    private static void Postfix(PauseScreen __instance)
    {
        ModHelper.PerformAdvancedModHook(mod => mod.PostPauseScreenClosed(__instance));
        SessionData.Instance.IsPaused = false;
    }
}