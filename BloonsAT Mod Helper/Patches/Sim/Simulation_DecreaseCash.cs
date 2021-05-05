using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using Harmony;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.DecreaseCash))]
    internal class Simulation_DecreaseCash
    {
        [HarmonyPostfix]
        internal static void Postfix(double decrease)
        {
            MelonMain.DoPatchMethods(mod => mod.OnCashRemoved(decrease));
        }
    }
}