using System.Collections.Generic;
using System.Reflection;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Unity.Player;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

/// <summary>
/// Prevent these methods for non real boss events
/// </summary>
[HarmonyPatch]
internal static class PreventMethods
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(Btd6Player), nameof(Btd6Player.BossEventBestRound));
        yield return AccessTools.Method(typeof(Btd6Player), nameof(Btd6Player.CompleteBossEvent));
        yield return AccessTools.Method(typeof(InGame), nameof(InGame.RetrieveTopScoreAndPostAnalytics));
    }

    [HarmonyPrefix]
    private static bool Prefix() => InGameData.CurrentGame.gameEventId != ModBoss.EventId;
}