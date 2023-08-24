using Il2CppAssets.Scripts.Unity.UI_New.GameOver;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

/// <summary>
/// Allow restarting boss rounds games
/// </summary>
[HarmonyPatch(typeof(BossDefeatScreen), nameof(BossDefeatScreen.CanPlayAgain), MethodType.Getter)]
internal static class BossDefeatScreen_CanPlayAgain
{
    [HarmonyPrefix]
    private static bool Prefix(ref bool __result)
    {
        if (InGameData.CurrentGame.gameEventId == ModBoss.EventId)
        {
            __result = true;
            return false;
        }

        return true;
    }
}

/// <summary>
/// Allow restarting boss rounds games
/// </summary>
[HarmonyPatch(typeof(BossVictoryScreen), nameof(BossVictoryScreen.CanPlayAgain), MethodType.Getter)]
internal static class BossVictoryScreen_CanPlayAgain
{
    [HarmonyPrefix]
    private static bool Prefix(ref bool __result)
    {
        if (InGameData.CurrentGame.gameEventId == ModBoss.EventId)
        {
            __result = true;
            return false;
        }

        return true;
    }
}
