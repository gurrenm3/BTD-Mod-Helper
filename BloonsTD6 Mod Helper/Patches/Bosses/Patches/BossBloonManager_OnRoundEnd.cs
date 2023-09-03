using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.OnRoundEnd))]
internal static class BossBloonManager_OnRoundEnd
{
    [HarmonyPrefix]
    private static void Prefix(BossBloonManager __instance, ref Action __state)
    {
        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss) && __instance.CurrentBossTier < boss.highestTier)
        {
            __instance.checkForVictory = false;
            __state = __instance.sim.OnLost;
            __instance.sim.OnLost = null;
            __instance.sim.gameLost = false;
        }
    }

    [HarmonyPostfix]
    private static void Postfix(BossBloonManager __instance, Action __state)
    {
        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss) && __instance.CurrentBossTier < boss.highestTier)
        {
            __instance.checkForVictory = false;
            __instance.sim.gameLost = false;

            __instance.sim.OnLost = __state;
        }
    }
}