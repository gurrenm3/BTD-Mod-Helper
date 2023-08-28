using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Unity.UI_New.GameOver;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

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
