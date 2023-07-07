using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Tracking;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(AnalyticsTrackerSimManager), nameof(AnalyticsTrackerSimManager.OnCashSpent))]
internal static class AnalyticsTrackerSimManager_OnCashSpent
{
    [HarmonyPostfix]
    private static void Postfix(int playerId, double cash, Simulation.CashType from, Simulation.CashSource source)
    {
        ModHelper.PerformHook(mod => mod.OnCashRemoved(cash, from, playerId, source));
    }
}