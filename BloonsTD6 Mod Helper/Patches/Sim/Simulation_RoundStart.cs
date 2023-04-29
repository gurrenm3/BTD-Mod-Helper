using System;
using System.Linq;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
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

            foreach (var (_, boss) in ModBoss.Cache.Where(x => x.Value.SpawnRounds.Contains(currentRound)))
            {
                boss.OnSpawn(InGame.instance.GetMap().spawner.Emit(boss.ModifyForRound(boss.bloonModel, currentRound)));
            }
        }
        catch (Exception e)
        {
            ModHelper.Error(e);
        }
    }
}