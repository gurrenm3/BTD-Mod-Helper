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
        try
        {
            if (__instance.IsCurrentSpawnRoundEmitting())
            {
                //__result = false;
                //return false;
                return true;
            }

            var aliveBloons = InGame.instance.GetAllBloonToSim().Select(x => x.GetSimBloon()).ToList();

            var activeBoss = aliveBloons.Any(bloon => bloon is not null && ModBoss.Cache.ContainsKey(bloon.bloonModel.id) && !ModBoss.Cache[bloon.bloonModel.id].BlockRounds);

            if (activeBoss && !aliveBloons.Any(bloon => bloon is not null && !ModBoss.Cache.ContainsKey(bloon.bloonModel.id)))
            {
                if (!Game.instance.GetPlayerProfile().inGameSettings.autoPlay)
                {
                    Game.instance.GetPlayerProfile().inGameSettings.autoPlay = true;
                    InGame.instance.bridge.SetAutoPlay(true); //TODO: better way to force rounds to keep coming
                }

                __result = true;
                return false;
            }
        }
        catch (System.Exception e)
        {
            ModHelper.Error(e);
        }

        return true;
    }
}