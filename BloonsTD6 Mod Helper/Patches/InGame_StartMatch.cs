using Assets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
    internal class InGame_StartMatch
    {
        [HarmonyPostfix]
        internal static void Postfix(InGame __instance)
        {
            ModHelper.PerformHook(mod => mod.OnMatchStart());
        }
    }
}