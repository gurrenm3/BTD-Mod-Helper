using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;

namespace BTD_Mod_Helper.Patches.Bloons.Behaviors;

[HarmonyPatch(typeof(TimeTrigger), nameof(TimeTrigger.Trigger))]
internal static class TimeTrigger_Trigger
{
    [HarmonyPrefix]
    private static void Prefix(TimeTrigger __instance)
    {
        if (ModBoss.Cache.ContainsKey(__instance.bloon.bloonModel.name))
        {
            ModBoss.Cache[__instance.bloon.bloonModel.name].TimerTick(__instance.bloon);
        }
    }
}