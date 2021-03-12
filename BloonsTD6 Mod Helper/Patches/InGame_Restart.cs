using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.Restart))]
    internal class InGame_Restart
    {
        [HarmonyPostfix]
        internal static void Postfix(bool removeSave)
        {
            MelonMain.DoPatchMethods(mod => mod.OnRestart(removeSave));
        }
    }
}