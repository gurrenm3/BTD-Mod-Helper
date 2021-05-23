using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Extensions;
using Harmony;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Initialise))]
    internal class Bloon_Initialise
    {
        [HarmonyPrefix]
        internal static bool Prefix(Bloon __instance, Model modelToUse)
        {
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance)
        {
            SessionData.bloonTracker.TrackBloon(__instance);
            __instance.CreateBloonToSim(); // Creating new BloonToSimulation will automatically start Tracking BloonSim via the Constructor

            MelonMain.DoPatchMethods(mod =>
            {
                mod.OnBloonCreated(__instance);
            });
        }
    }
}