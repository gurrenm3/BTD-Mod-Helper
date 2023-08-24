using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem.Collections.Generic;
namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

/// <summary>
/// Save the boss type / eliteness to the map save metadata
/// </summary>
[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.SetSaveMetaData))]
[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.GetSaveMetaData))]
internal static class BossBloonManager_GetSaveMetaData
{
    [HarmonyPostfix]
    private static void Postfix(Dictionary<string, string> metaData)
    {
        var inGameData = InGameData.CurrentGame;
        if (InGameData.CurrentGame.gameEventId == ModBoss.EventId)
        {
            metaData[ModBoss.BossTypeKey] = inGameData.bossData.bossBloon.ToString();
            metaData[ModBoss.IsEliteKey] = inGameData.bossData.bossEliteMode.ToString();
        }
    }
}