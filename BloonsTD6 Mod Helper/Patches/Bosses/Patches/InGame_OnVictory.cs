using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

/// <summary>
/// Allow rewards for boss rounds games
/// </summary>
[HarmonyPatch(typeof(InGame), nameof(InGame.OnVictory))]
internal static class InGame_OnVictory
{
    [HarmonyPrefix]
    private static void Prefix()
    {
        if (InGameData.CurrentGame.gameEventId == ModBoss.EventId)
        {
            InGameData.CurrentGame.gameType = GameType.Standard;
        }
    }

    [HarmonyPostfix]
    private static void Postfix()
    {
        if (InGameData.CurrentGame.gameEventId == ModBoss.EventId)
        {
            InGameData.CurrentGame.gameType = GameType.BossBloon;
        }
    }
}