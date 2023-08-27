using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Models.ServerEvents;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Main.ModeSelect;
using Il2CppSystem;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

/// <summary>
/// Activate the appropriate boss mode if a boss round is selected
/// </summary>
[HarmonyPatch(typeof(ModeScreen), nameof(ModeScreen.OnModeSelected))]
internal static class ModeScreen_OnModeSelected
{
    [HarmonyPrefix]
    private static void Prefix(string modeType)
    {
        if (!ModBossRoundSet.Cache.TryGetValue(RoundSetChanger.RoundSetOverride, out var bossRoundset)) return;

        var inGameData = InGameData.Editable;
        var dcm = new DailyChallengeModel
        {
            difficulty = inGameData.selectedDifficulty,
            map = inGameData.selectedMap,
            mode = modeType,
            towers = new TowerData[]
                {
                    new() {isHero = true, tower = DailyChallengeModel.CHOSENPRIMARYHERO, max = 1}
                }
                .ToIl2CppList(),
            chalType = ChallengeType.BossBloon,
            eventID = ModBoss.EventId,
            endTimeUTC = DateTime.MaxValue,
            startTimeUTC = DateTime.MinValue,
            hasDailyChallengeStats = false,
        };
        if(bossRoundset.modBoss == null)
        {
            inGameData.SetupBoss(ModBoss.EventId, bossRoundset.bossType, bossRoundset.elite, false,
            BossGameData.DefaultSpawnRounds, dcm, LeaderboardScoringType.GameTime);
            return;
        }

        inGameData.SetupBoss(ModBoss.EventId, bossRoundset.bossType, bossRoundset.elite, false,
            bossRoundset.modBoss.SpawnRounds.ToArray(), dcm, LeaderboardScoringType.GameTime);

        List<int> checkpointRounds = new(bossRoundset.modBoss.SpawnRounds.Count());
        foreach (var round in bossRoundset.modBoss.SpawnRounds)
        {
            if (bossRoundset.modBoss.SpawnRounds.First() == round)
            {
                var newRound = Mathf.FloorToInt((round) / 2f) - 1;
                if (newRound > 0)
                {
                    checkpointRounds.Add(newRound);
                }
            }
            checkpointRounds.Add(round-1);
        }
        inGameData.checkpointRounds = checkpointRounds.ToArray();
    }
}
