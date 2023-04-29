using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Leaked))]
internal class Blooon_Leaked
{
    [HarmonyPrefix]
    internal static bool Prefix(Bloon __instance)
    {
        var result = true;
        SessionData.Instance.LeakedBloons.Add(__instance);
        if (ModBoss.Cache.TryGetValue(__instance.bloonModel.id, out var boss))
        {
            if (boss.AlwaysDefeatOnLeak)
            {
                __instance.bloonModel.leakDamage = (float) InGame.instance.GetHealth() + InGame.instance.GetSimulation().shield.ValueFloat + 1;
                __instance.UpdateRootModel(__instance.bloonModel);
            }
        }
        
        ModHelper.PerformHook(mod => result &= mod.PreBloonLeaked(__instance));
        return result;
    }

    [HarmonyPostfix]
    internal static void Postfix(Bloon __instance)
    {
        ModHelper.PerformHook(mod => mod.PostBloonLeaked(__instance));
        if (ModBoss.Cache.TryGetValue(__instance.bloonModel.id, out var boss))
        {
            boss.OnLeak(__instance);
        }
    }
}