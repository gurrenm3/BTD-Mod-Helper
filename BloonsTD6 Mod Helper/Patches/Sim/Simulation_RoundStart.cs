using Il2CppAssets.Scripts.Simulation;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(Simulation), nameof(Simulation.RoundStart))]
internal class Simulation_RoundStart
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        ModHelper.PerformHook(mod => mod.OnRoundStart());
    }
}