using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Unity.UI_New.GameOver;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Pause;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

[HarmonyPatch]
internal static class RetryLastRound
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(CheckpointDefeatScreen.__c__DisplayClass13_0), nameof(CheckpointDefeatScreen.__c__DisplayClass13_0._RetryLastRoundClicked_b__0));
        yield return AccessTools.Method(typeof(PauseScreen), nameof(PauseScreen.RunCheckpoint));
        yield return AccessTools.Method(typeof(CheckpointDefeatScreen.__c__DisplayClass12_0), nameof(CheckpointDefeatScreen
            .__c__DisplayClass12_0._ContinueFromCheckpointClicked_b__0));
    }

    [HarmonyPrefix]
    private static void Prefix()
    {
        if (InGameData.CurrentGame == null || InGameData.CurrentGame.gameEventId != ModBoss.EventId)
            return;
        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            boss.CurrentTier = boss.tiers.Find(x => x.Tier == InGame.instance.GetMap().spawner.bossBloonManager.CurrentBossTier);
        }
    }

    [HarmonyPostfix]
    private static void Postfix()
    {
        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss) && boss.CurrentTier != null)
        {
            boss.OnSpawnCallback(InGame.instance.GetMap().spawner.bossBloonManager.currentBoss);
        }
    }
}