using Assets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.OnDestroy))]
    internal class Bloon_OnDestroy
    {
        [HarmonyPrefix]
        internal static bool Prefix(Bloon __instance)
        {
            SessionData.Instance.bloonTracker.StopTrackingBloon(__instance.GetId());
            SessionData.Instance.bloonTracker.StopTrackingBloonToSim(__instance.GetId());
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance)
        {
            MelonMain.DoPatchMethods(mod => { mod.OnBloonDestroy(__instance); });

            if (__instance.WasBloonPopped())
                MelonMain.DoPatchMethods(mod => { mod.OnBloonPopped(__instance); });
        }
    }
}