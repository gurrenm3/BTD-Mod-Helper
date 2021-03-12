using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using Harmony;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.OnRoundStart))]
    internal class Simulation_OnRoundStart
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.DoPatchMethods(mod => mod.OnRoundStart());
        }
    }
}