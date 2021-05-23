using System;
using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Extensions;
using Harmony;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Initialise))]
    internal class Bloon_Initialize
    {

        [HarmonyPrefix]
        internal static bool Prefix(Bloon __instance, Model modelToUse)
        {
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance, Model modelToUse)
        {
            SessionData.bloonTracker.TrackBloon(__instance);
            // Creating new BloonToSimulation will automatically start Tracking BloonSim via the Constructor
            __instance.CreateBloonToSim();

            MelonMain.DoPatchMethods(mod => mod.OnBloonCreated(__instance));
            MelonMain.DoPatchMethods(mod => mod.OnBloonModelUpdated(__instance, modelToUse));
        }
    }
}