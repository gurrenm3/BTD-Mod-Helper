using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.IncreaseCash))]
    internal class Simulation_IncreaseCash
    {
        [HarmonyPostfix]
        internal static void Postfix(double increase, Simulation.CashIncreaseReason reason)
        {
            MelonMain.DoPatchMethods(mod => mod.OnCashAdded(increase, reason));
        }
    }
}