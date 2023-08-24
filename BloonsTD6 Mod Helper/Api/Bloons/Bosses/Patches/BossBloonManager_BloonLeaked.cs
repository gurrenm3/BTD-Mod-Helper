using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.BloonLeaked))]
internal static class BossBloonManager_BloonLeaked
{
    [HarmonyPrefix]
    private static bool Prefix(BossBloonManager __instance)
    {
        if(ModBossTier.Cache.TryGetValue(__instance.currentBoss.bloonModel.name, out var boss))
        {
            boss.Boss.OnLeak(__instance.currentBoss);
        }
        return !InGame.instance.bridge.IsSandboxMode();
    }
}