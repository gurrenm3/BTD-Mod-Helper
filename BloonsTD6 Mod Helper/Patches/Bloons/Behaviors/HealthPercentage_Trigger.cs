using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
namespace BTD_Mod_Helper.Patches.Bloons.Behaviors;

[HarmonyPatch(typeof(HealthPercentTrigger), nameof(HealthPercentTrigger.Trigger))]
internal static class HealthPercentage_Trigger
{
    [HarmonyPrefix]
    private static void Prefix(HealthPercentTrigger __instance)
    {
        if (ModBoss.Cache.TryGetValue(__instance.bloon.bloonModel.name, out var boss))
        {
            boss.currentTier.SkullReachedUI(__instance.bloon);
            boss.currentTier.SkullReached(__instance.bloon);
        }
    }
}