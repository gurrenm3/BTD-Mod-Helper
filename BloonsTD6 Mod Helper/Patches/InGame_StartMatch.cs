using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
    internal class InGame_StartMatch
    {
        [HarmonyPostfix]
        internal static void Postfix(InGame __instance)
        {
            MelonMain.DoPatchMethods(mod => mod.OnMatchStart());
        }
    }
}