using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;

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