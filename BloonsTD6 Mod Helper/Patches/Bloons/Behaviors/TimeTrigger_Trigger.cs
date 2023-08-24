using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
namespace BTD_Mod_Helper.Patches.Bloons.Behaviors;

[HarmonyPatch(typeof(TimeTrigger), nameof(TimeTrigger.Trigger))]
internal static class TimeTrigger_Trigger
{
    [HarmonyPrefix]
    private static void Prefix(TimeTrigger __instance)
    {
        if (ModBossTier.Cache.TryGetValue(__instance.bloon.bloonModel.name, out var modBossTier))
        {
            modBossTier.TimerTick(__instance.bloon);
        }
    }
}