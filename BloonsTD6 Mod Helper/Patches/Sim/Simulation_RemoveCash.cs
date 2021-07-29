using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.RemoveCash))]
    internal class Simulation_RemoveCash
    {
        [HarmonyPostfix]
        internal static void Postfix(double c, Simulation.CashType from, int cashIndex, Simulation.CashSource source)
        {
            MelonMain.DoPatchMethods(mod => mod.OnCashRemoved(c, from, cashIndex, source));
        }
    }
}