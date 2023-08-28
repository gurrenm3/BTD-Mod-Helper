using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.SpawnBoss))]
internal static class BossBloonManager_SpawnBoss
{
    [HarmonyPostfix]
    private static void Postfix(BossBloonManager __instance)
    {
        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            boss.CurrentTier = boss.tiersByRound[InGame.Bridge.GetCurrentRound() + 1];
            boss.OnSpawnCallback(__instance.currentBoss);
        }
    }
}