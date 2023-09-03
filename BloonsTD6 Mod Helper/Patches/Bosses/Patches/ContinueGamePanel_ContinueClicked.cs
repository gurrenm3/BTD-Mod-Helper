using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Data.Boss;
using Il2CppAssets.Scripts.Models.ServerEvents;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem.Linq;
using UnityEngine;
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
                        mode = map.modeName,
                        chalType = ChallengeType.BossBloon,
                        eventID = ModBoss.EventId,
                        endTimeUTC = Il2CppSystem.DateTime.MaxValue,
                        startTimeUTC = Il2CppSystem.DateTime.MinValue,
                        hasDailyChallengeStats = false,
                    }, LeaderboardScoringType.GameTime);
                inGameData.bossData.spawnRounds = boss.SpawnRounds.ToArray();
                List<int> checkpointRounds = new(boss.SpawnRounds.Count());
                foreach (var round in boss.SpawnRounds)
                {
                    if (boss.SpawnRounds.First() == round)
                    {
                        var newRound = Mathf.FloorToInt((round) / 2f);
                        if (newRound > 0)
                        {
                            checkpointRounds.Add(newRound);
                        }
                    }
                    checkpointRounds.Add(round - 1);
                }
                inGameData.checkpointRounds = checkpointRounds.ToArray();
            }
            else
            {
                inGameData.SetupBoss(ModBoss.EventId, bossType, isElite, false,
                    BossGameData.DefaultSpawnRounds, new DailyChallengeModel
                    {
                        difficulty = map.mapDifficulty,
                        map = map.mapName,
                        mode = map.modeName,
                        chalType = ChallengeType.BossBloon,
                        eventID = ModBoss.EventId,
                        endTimeUTC = Il2CppSystem.DateTime.MaxValue,
                        startTimeUTC = Il2CppSystem.DateTime.MinValue,
                        hasDailyChallengeStats = false,
                    }, LeaderboardScoringType.GameTime);
                inGameData.checkpointRounds = BossGameData.DefaultCheckpointRounds
                    .Cast<Il2CppSystem.Collections.Generic.IEnumerable<int>>().ToArray().ToArray();
            }
        }

        if (map != null && map.metaData.ContainsKey("RoundSet") && ModRoundSet.Cache.TryGetValue(map.metaData["RoundSet"], out var roundSet))
        {
            RoundSetChanger.RoundSetOverride = map.metaData["RoundSet"];
            RoundSetChanger.button.Image.SetSprite(roundSet.IconReference.guidRef);
        }
    }
}