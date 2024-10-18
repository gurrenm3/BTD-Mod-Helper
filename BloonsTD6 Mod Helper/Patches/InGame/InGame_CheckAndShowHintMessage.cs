using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.CheckAndShowHintMessage))]
internal static class InGame_CheckAndShowHintMessage
{
    [HarmonyPrefix]
    private static bool Prefix(InGame __instance)
    {
        if (!ModRoundSet.Cache.TryGetValue(__instance.GetGameModel().roundSet.name, out var modRoundSet)) return true;

        if ((modRoundSet.AlwaysShowHints || Game.Player.Data.inGameSettings.gameHints) &&
            modRoundSet.GetHint(__instance.bridge.GetCurrentRound() + 1) is string hint)
        {
            __instance.roundHintTxt.SetText(hint);
            __instance.roundHintAnimator.SetIntegerString("AnimIndex", 1);
            __instance.roundHintTimer = __instance.roundHintAutoHideTime;
        }

        return false;
    }
}