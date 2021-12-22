using Assets.Main;
using Assets.Scripts.Unity.Tasks;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(Main), nameof(Main.UpdateStatusMessage))]
    internal static class Main_UpdateStatusMessage
    {
        [HarmonyPrefix]
        private static bool Prefix(Main __instance, SeriesTasks tasks)
        {
            
            return true;
        }

        [HarmonyPostfix]
        private static void Postfix(Main __instance)
        {

        }
    }
}