using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.OnPlayerDeath))]
    internal class InGame_OnPlayerDeath
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.DoPatchMethods(mod => mod.OnDefeat());
        }
    }
}