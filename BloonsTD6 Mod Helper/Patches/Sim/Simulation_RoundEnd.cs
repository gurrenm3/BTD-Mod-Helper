using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.RoundEnd))]
    internal class Simulation_RoundEnd
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.DoPatchMethods(mod => mod.OnRoundEnd());
        }
    }
}