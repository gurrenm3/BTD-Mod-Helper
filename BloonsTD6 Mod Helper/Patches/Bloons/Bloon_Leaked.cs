using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using BTD_Mod_Helper.Api.Data;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Leaked))]
internal class Blooon_Leaked
{
    [HarmonyPrefix]
    internal static bool Prefix(Bloon __instance)
    {
        var result = true;
        SessionData.Instance.LeakedBloons.Add(__instance);

        ModHelper.PerformHook(mod => result &= mod.PreBloonLeaked(__instance));
        return result;
    }

    [HarmonyPostfix]
    internal static void Postfix(Bloon __instance)
    {
        ModHelper.PerformHook(mod => mod.PostBloonLeaked(__instance));
        if (ModBossTier.Cache.TryGetValue(__instance.bloonModel.id, out var modBossTier))
        {
            modBossTier.Boss.OnLeak(__instance);
        }
    }
}