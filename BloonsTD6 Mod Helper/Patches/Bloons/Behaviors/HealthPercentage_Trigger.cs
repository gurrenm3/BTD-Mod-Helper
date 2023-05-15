using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;

namespace BTD_Mod_Helper.Patches.Bloons.Behaviors;

[HarmonyPatch(typeof(HealthPercentTrigger), nameof(HealthPercentTrigger.Trigger))]
internal static class HealthPercentage_Trigger
{
    [HarmonyPrefix]
    private static void Prefix(HealthPercentTrigger __instance)
    {
        if (ModBoss.Cache.ContainsKey(__instance.bloon.bloonModel.name))
        {
            ModBoss.Cache[__instance.bloon.bloonModel.name].SkullEffect(__instance.bloon);
        }
    }
}