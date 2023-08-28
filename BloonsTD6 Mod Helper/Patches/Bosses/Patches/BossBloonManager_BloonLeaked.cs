using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.BloonLeaked))]
internal static class BossBloonManager_BloonLeaked
{
    [HarmonyPrefix]
    private static bool Prefix(BossBloonManager __instance)
    {
        if(ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            boss.OnLeakCallback(__instance.currentBoss);
        }
        return !InGame.instance.bridge.IsSandboxMode();
    }
}