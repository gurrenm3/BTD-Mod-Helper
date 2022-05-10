using Assets.Scripts.Unity.Bridge;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.Lose))]
    internal class UnityToSimulation_Lose
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.PerformHook(mod => mod.OnDefeat());
        }
    }
}