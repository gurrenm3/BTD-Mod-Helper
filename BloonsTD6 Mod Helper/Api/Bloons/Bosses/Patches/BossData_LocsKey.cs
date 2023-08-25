using Il2CppAssets.Scripts.Data.Boss;
namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

[HarmonyPatch(typeof(BossData), nameof(BossData.LocsKey), MethodType.Getter)]
internal static class BossData_LocsKey
{
    [HarmonyPrefix]
    static bool Prefix(BossData __instance, ref string __result)
    {
        if (ModBoss.Cache.TryGetValue((int) __instance.id, out var boss))
        {
            __result = boss.DisplayName;
            return false;
        }
        return true;
    }
}