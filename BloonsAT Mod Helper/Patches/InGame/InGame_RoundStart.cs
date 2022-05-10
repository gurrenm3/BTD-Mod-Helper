using Assets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.RoundStart))]
    internal class InGame_RoundStart
    {
        [HarmonyPostfix]
        internal static void Postfix(int roundNumber)
        {
            MelonMain.DoPatchMethods(mod => mod.OnRoundStart(roundNumber));
        }
    }
}