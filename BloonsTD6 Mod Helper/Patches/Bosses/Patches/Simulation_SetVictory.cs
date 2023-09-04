using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

[HarmonyPatch(typeof(Simulation), nameof(Simulation.SetVictory))]
internal static class Simulation_SetVictory
{
    [HarmonyPrefix]
    private static bool Prefix(Simulation __instance, ref bool __result)
    {
        if (InGameData.CurrentGame == null || InGameData.CurrentGame.gameEventId != ModBoss.EventId)
            return true;
        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var modBoss) &&
            InGame.instance.GetMap().spawner.bossBloonManager.CurrentBossTier < modBoss.highestTier)
        {
            __instance.gameWon = false;
            __instance._gameWon_k__BackingField = false;
            __instance.gameLost = false;
            __instance.matchJustWon = false;
            __result = false;
            return false;
        }
        return true;
    }
}

