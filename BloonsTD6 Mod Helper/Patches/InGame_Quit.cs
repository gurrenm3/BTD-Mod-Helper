using Assets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.Quit))]
    internal class InGame_Quit
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            ModHelper.PerformHook(mod => mod.OnMatchEnd());
        }
    }
}