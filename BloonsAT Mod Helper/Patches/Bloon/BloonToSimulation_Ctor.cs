using System;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Unity.Bridge;
using Harmony;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(BloonToSimulation))]
    [HarmonyPatch(MethodType.Constructor)]
    [HarmonyPatch(new Type[] { typeof(UnityToSimulation), typeof(ulong), typeof(Vector3), typeof(float),
        typeof(float), typeof(BloonModel)})]
    internal class BloonToSimulation_Ctor
    {
        [HarmonyPostfix]
        internal static void Postfix(BloonToSimulation __instance, UnityToSimulation sim,
            ulong id, Vector3 position, float distanceTravelled, float pathTotalDistance, BloonModel def)
        {
            SessionData.bloonTracker.TrackBloonToSim(__instance);
        }
    }
}