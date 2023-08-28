using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Models.ServerEvents;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

/// <summary>
/// Save matches into the map save slot, not into the special save slot for bosses
/// </summary>
[HarmonyPatch(typeof(DailyChallengeExtensions), nameof(DailyChallengeExtensions.GetContinueMapSaveId))]
internal static class DailyChallengeExtensions_GetContinueMapSaveId
{
    [HarmonyPrefix]
    private static bool Prefix(ChallengeType chalType, ref string __result)
    {
        if (chalType == ChallengeType.BossBloon && InGameData.CurrentGame?.gameEventId == ModBoss.EventId)
        {
            __result = InGameData.CurrentGame.selectedMap;
            return false;
        }

        return true;
    }
}