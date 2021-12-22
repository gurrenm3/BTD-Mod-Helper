using HarmonyLib;
using MelonLoader;
using Main = Assets.Main.Main;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(Main._LoadingSequence_d__42), nameof(Main._LoadingSequence_d__42.MoveNext))]
    internal static class LoadingSequence_MoveNext
    {
        [HarmonyPrefix]
        private static bool Prefix(Main._LoadingSequence_d__42 __instance)
        {
            return true;
        }

        [HarmonyPostfix]
        private static void Postfix(Main._LoadingSequence_d__42 __instance)
        {
            MelonLogger.Msg($"moving next! {__instance.__1__state}");
            
        }
    }
}