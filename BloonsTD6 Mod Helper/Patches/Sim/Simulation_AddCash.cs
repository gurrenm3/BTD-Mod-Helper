using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using Harmony;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.AddCash))]
    internal class Simulation_AddCash
    {
        [HarmonyPostfix]
        internal static void Postfix(double c, Simulation.CashType from, int cashIndex, Simulation.CashSource source,
            Tower tower)
        {
            MelonMain.DoPatchMethods(mod => mod.OnCashAdded(c, from, cashIndex, source, tower));
        }
    }
}