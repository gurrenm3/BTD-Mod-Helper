using Assets.Scripts.Simulation;
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
            SessionData.Instance.LeakedBloons.Clear();
            SessionData.Instance.DestroyedBloons.Clear();
        }
    }
}