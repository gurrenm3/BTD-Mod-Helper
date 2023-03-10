using System.Linq;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Spawners;

[HarmonyPatch(typeof(Spawner), nameof(Spawner.IsRoundOver))]
internal static class Spawner_IsRoundOver
{
    [HarmonyPrefix]
    private static bool Prefix(Spawner __instance, ref bool __result)
    {
        var aliveBloons = InGame.instance.GetAllBloonToSim().Select(x=>x.GetBloon()).ToList();
        
        var bossCount = aliveBloons.Count(bloon => bloon is not null && ModBoss.Cache.ContainsKey(bloon.bloonModel.id) && !ModBoss.Cache[bloon.bloonModel.id].BlockRounds);
        
        var bloonCount = aliveBloons.Count(bloon => bloon is not null && !ModBoss.Cache.ContainsKey(bloon.bloonModel.id));
        
        ModHelper.Msg("Boss Count: " + bossCount);
        ModHelper.Msg("bloon Count: " + bloonCount);
        
        if (bossCount >= 1 && bloonCount == 0)
        {
            if (!Game.instance.GetPlayerProfile().inGameSettings.autoPlay)
            {
                //__instance.StartRound();
            }
            
            __result = true;
            return false;
        }
        
        return true;
    }
}
