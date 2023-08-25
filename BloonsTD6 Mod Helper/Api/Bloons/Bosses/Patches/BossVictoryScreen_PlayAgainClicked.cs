using Il2CppAssets.Scripts.Unity.UI_New.GameOver;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

[HarmonyPatch(typeof(BossVictoryScreen), nameof(BossVictoryScreen.PlayAgainClicked))]
internal static class BossVictoryScreen_PlayAgainClicked
{
    [HarmonyPrefix]
    private static bool Prefix(BossVictoryScreen __instance)
    {
        if (InGameData.CurrentGame.gameEventId == ModBoss.EventId)
        {
            InGame.instance.bridge.Restart();
            return false;
        }
        return true;
    }
}