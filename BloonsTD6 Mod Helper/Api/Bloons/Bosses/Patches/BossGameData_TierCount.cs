using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

[HarmonyPatch(typeof(BossGameData), nameof(BossGameData.TierCount), MethodType.Getter)]
internal static class BossGameData_TierCount
{
    [HarmonyPrefix]
    private static bool Prefix(BossGameData __instance, ref int __result)
    {
        if (ModBoss.Cache.TryGetValue((int) __instance.bossBloon, out var boss))
        {
            __result = boss.highestTier;
            return false;
        }
        return true;
    }
}