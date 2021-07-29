using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.OnDefeat))]
    internal class Simulation_OnDefeat
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.DoPatchMethods(mod => mod.OnDefeat());
        }
    }
}