using Il2CppAssets.Scripts.Unity.UI_New.Pause;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(PauseScreen), nameof(PauseScreen.Open))]
internal static class PauseScreen_Open
{
    [HarmonyPostfix]
    private static void Postfix(PauseScreen __instance)
    {
        ModHelper.PerformHook(mod => mod.OnPauseScreenOpened(__instance));
        SessionData.Instance.IsPaused = true;
    }
}