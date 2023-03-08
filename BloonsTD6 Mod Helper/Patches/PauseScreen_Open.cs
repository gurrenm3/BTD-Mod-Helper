using Il2CppAssets.Scripts.Unity.UI_New.Pause;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(PauseScreen), nameof(PauseScreen.Open))]
internal static class PauseScreen_Open
{
    [HarmonyPrefix]
    private static bool Prefix(ref PauseScreen __instance)
    {
        var result = true;
        var unref__instance = __instance;
        ModHelper.PerformAdvancedModHook(mod=> result &= mod.PrePauseScreenOpened(ref unref__instance));
        __instance = unref__instance;
        return result;
    }
    [HarmonyPostfix]
    private static void Postfix(PauseScreen __instance)
    {
        ModHelper.PerformAdvancedModHook(mod=> mod.PostPauseScreenOpened(__instance));
    }
}
