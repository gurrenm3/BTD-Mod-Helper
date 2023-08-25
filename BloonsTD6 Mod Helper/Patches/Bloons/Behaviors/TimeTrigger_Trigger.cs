using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bloons.Behaviors;

[HarmonyPatch(typeof(TimeTrigger), nameof(TimeTrigger.Trigger))]
internal static class TimeTrigger_Trigger
{
    [HarmonyPrefix]
    private static void Prefix(TimeTrigger __instance)
    {
        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            boss.TimerTickCallback(__instance.bloon);
        }
    }
}