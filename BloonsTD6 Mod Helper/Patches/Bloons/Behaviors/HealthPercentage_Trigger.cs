using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
namespace BTD_Mod_Helper.Patches.Bloons.Behaviors;

[HarmonyPatch(typeof(HealthPercentTrigger), nameof(HealthPercentTrigger.Trigger))]
internal static class HealthPercentage_Trigger
{
    [HarmonyPrefix]
    private static void Prefix(HealthPercentTrigger __instance)
    {
        if (ModBossTier.Cache.TryGetValue(__instance.bloon.bloonModel.name, out var modBossTier))
        {
            modBossTier.SkullReached(__instance.bloon);
        }
    }
}