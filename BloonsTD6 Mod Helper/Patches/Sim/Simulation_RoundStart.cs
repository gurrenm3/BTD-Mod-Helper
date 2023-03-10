using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(Simulation), nameof(Simulation.RoundStart))]
internal class Simulation_RoundStart
{
    [HarmonyPostfix]
    internal static void Postfix(Simulation __instance)
    {
        try
        {
            ModHelper.PerformHook(mod => mod.OnRoundStart());    
            var currentRound = InGame.instance.GetUnityToSimulation().GetCurrentRound();

            foreach (var (id, boss) in ModBoss.Cache.Where(x => x.Value.SpawnRounds.Contains(currentRound + 1)))
            {
                var list = new List<BloonEmissionModel>
                {
                    new(id + "_Boss", boss.SpawnDelay, boss.bloonModel.id, true)
                };
                InGame.instance.GetMap().spawner.AddEmissions(list.ToIl2CppReferenceArray(),
                    currentRound);
                
            }
        }
        catch (Exception e)
        {
            ModHelper.Error(e);
        }
    }
}