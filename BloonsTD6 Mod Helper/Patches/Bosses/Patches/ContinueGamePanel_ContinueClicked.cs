using System;
using System.Linq;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Data.Boss;
using Il2CppAssets.Scripts.Models.ServerEvents;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

/// <summary>
/// Activate the appropriate boss mode if the save has the correct metadata
/// </summary>
[HarmonyPatch(typeof(ContinueGamePanel), nameof(ContinueGamePanel.ContinueClicked))]
internal static class ContinueGamePanel_ContinueClicked
{
    [HarmonyPrefix]
    private static void Prefix(ContinueGamePanel __instance)
    {
        var map = __instance.saveData;
        if (map != null &&
            map.metaData.ContainsKey(ModBoss.BossTypeKey) &&
            map.metaData.ContainsKey(ModBoss.IsEliteKey) &&
            Enum.TryParse(map.metaData[ModBoss.BossTypeKey], out BossType bossType) &&
            bool.TryParse(map.metaData[ModBoss.IsEliteKey], out var isElite))
        {
            var inGameData = InGameData.Editable;
            if (ModBoss.Cache.TryGetValue((int) bossType, out var boss))
            {
                inGameData.SetupBoss(ModBoss.EventId, bossType, isElite, false,
                    boss.SpawnRounds.ToArray(), new DailyChallengeModel
                    {
                        difficulty = map.mapDifficulty,
                        map = map.mapName,
                        mode = map.modeName
                    }, LeaderboardScoringType.GameTime);
                return;
            }
            inGameData.SetupBoss(ModBoss.EventId, bossType, isElite, false,
                BossGameData.DefaultSpawnRounds, new DailyChallengeModel
                {
                    difficulty = map.mapDifficulty,
                    map = map.mapName,
                    mode = map.modeName
                }, LeaderboardScoringType.GameTime);
        }
    }
}