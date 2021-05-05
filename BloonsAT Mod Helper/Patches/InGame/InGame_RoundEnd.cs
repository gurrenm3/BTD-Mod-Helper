using Assets.Scripts.Simulation;
using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.RoundEnd))]
    internal class InGame_RoundEnd
    {
        [HarmonyPostfix]
        internal static void Postfix(int roundNumber, bool roundCompleted)
        {
            MelonMain.DoPatchMethods(mod => mod.OnRoundEnd(roundNumber, roundCompleted));
        }
    }
}