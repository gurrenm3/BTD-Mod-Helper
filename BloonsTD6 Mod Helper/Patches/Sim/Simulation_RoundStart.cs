using Assets.Scripts.Simulation;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.RoundStart))]
    internal class Simulation_RoundStart
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            ModHelper.PerformHook(mod => mod.OnRoundStart());
        }
    }
}