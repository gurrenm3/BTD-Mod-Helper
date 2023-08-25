using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System.Linq;
namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.SpawnBoss))]
internal static class BossBloonManager_SpawnBoss
{
    [HarmonyPostfix]
    private static void Postfix(BossBloonManager __instance)
    {
        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            if (boss.tiersByRound.TryGetValue(InGame.Bridge.GetCurrentRound() + 1, out var tier))
            {
                boss.CurrentTier = tier;
            }
            boss.OnSpawnCallback(__instance.currentBoss);
        }
    }
}