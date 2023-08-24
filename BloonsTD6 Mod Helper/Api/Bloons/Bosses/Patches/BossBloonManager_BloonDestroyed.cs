using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

//todo: set things like this up in BossBloonManager.Init
[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.BloonDestroyed))]
internal static class BossBloonManager_BloonDestroyed
{
    [HarmonyPrefix]
    private static void Prefix(BossBloonManager __instance, ref ModBoss __state)
    {
        if(InGameData.CurrentGame.gameEventId == ModBoss.EventId)
            __instance.BossDefeatedEvent = null;
        if (ModBossTier.Cache.TryGetValue(__instance.currentBoss.bloonModel.name, out var modBossTier))
        {
            modBossTier.Boss.OnPop(__instance.currentBoss);
            __state = modBossTier.Boss;
            if (__instance.bossTimes.Length < __state.highestTier)
            {
                __instance.bossTimes = Enumerable.Repeat(new KonFuze(), __state.highestTier).ToArray();
            }
        }
    }

    [HarmonyPostfix]
    private static void Postfix(BossBloonManager __instance, ModBoss __state)
    {
        if (__state is not null && __instance.CurrentBossTier < __state.highestTier)
        {
            __instance.checkForVictory = false;
            //todo: make ui display the proper stars
        }
    }
}

