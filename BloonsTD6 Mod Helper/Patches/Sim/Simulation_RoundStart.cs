using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(Simulation), nameof(Simulation.RoundStart))]
internal class Simulation_RoundStart
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        try
        {
            ModHelper.PerformHook(mod => mod.OnRoundStart());

            var currentRound = InGame.instance.GetUnityToSimulation().GetCurrentRound() + 1;
            ModBossUI.UpdateWaitPanel(currentRound);

            IEnumerable<KeyValuePair<string, ModBoss>> currentBosses = ModBoss.Cache.Where(x => x.Value.SpawnRounds.Contains(currentRound));
            foreach (var (_, boss) in currentBosses)
            {
                boss.OnSpawnMandatory(InGame.instance.GetMap().spawner.Emit(boss.ModifyForRound(boss.bloonModel, currentRound)));
            }

        }
        catch (Exception e)
        {
            ModHelper.Error(e);
        }
    }
}