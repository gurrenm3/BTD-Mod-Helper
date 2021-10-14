using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.Lose))]
    internal class UnityToSimulation_Lose
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.DoPatchMethods(mod => mod.OnDefeat());
        }
    }
}