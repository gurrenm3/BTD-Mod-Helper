using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(Simulation), nameof(Simulation.RoundStart))]
internal class Simulation_RoundStart
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        ModHelper.PerformHook(mod => mod.OnRoundStart());
        if (ModBoss.Cache.Count > 0)
        {
            var currentRound = Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame.instance.GetUnityToSimulation().GetCurrentRound() + 1;
            var aliveBloons = Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame.instance.GetAllBloonToSim().Select(x => x.GetSimBloon()).ToList();

            var bossesForRound = ModBoss.Cache.Where(x => x.Value.SpawnRounds.Contains(currentRound));
            
            foreach (var (name, boss) in bossesForRound)
            {
                boss.currentTier = boss.tiers.First(x => x.Round == currentRound);
                var bossModel = Game.instance.model.GetBloon(boss.Id).Duplicate();   
                bossModel.speedFrames = BloonModelUtils.SpeedToSpeedFrames(bossModel.speed);
                boss.currentTier.ModifyBossBloonModel(bossModel);

                if(boss.DefeatIfNotPopped && aliveBloons.Exists(bloon => bloon.bloonModel.name == name))
                {
                    boss.OnLeak(aliveBloons.First(bloon => bloon.bloonModel.name == name));
                    Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame.instance.causeOfDefeat.finalDataList[boss.Id] = bossModel.maxHealth;
                    Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame.instance.Lose();
                    Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame.instance.SetHealth(0);
                    return;
                }
                
                var bossBloon = Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame.instance.GetMap().spawner
                    .Emit(bossModel, 0, 0); 
                boss.OnSpawn(bossBloon, boss);
            }          
            
            ModBossUI.UpdateWaitPanel();
        }
    }
}