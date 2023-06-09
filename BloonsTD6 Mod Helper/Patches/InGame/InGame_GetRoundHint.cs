using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.GetRoundHint))]
internal static class InGame_GetRoundHint
{
    [HarmonyPrefix]
    private static bool Prefix(InGame __instance, ref string __result)
    {
        var result = true;
        var unrefresult = __result;

        ModHelper.PerformHook(mod =>
            result &= mod.GetRoundHint(__instance, __instance.bridge.GetCurrentRound() + 1, ref unrefresult));

        __result = unrefresult;

        return result;
    }
}