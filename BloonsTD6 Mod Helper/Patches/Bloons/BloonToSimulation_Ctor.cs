using System;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Unity.Bridge;
using HarmonyLib;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(BloonToSimulation))]
    [HarmonyPatch(MethodType.Constructor)]
    [HarmonyPatch(new Type[] { typeof(UnityToSimulation), typeof(int), typeof(Vector3), typeof(BloonModel) })]
    internal class BloonToSimulation_Ctor
    {
        [HarmonyPostfix]
        internal static void Postfix(BloonToSimulation __instance, int id)
        {
            SessionData.Instance.bloonTracker.TrackBloonToSim(__instance);
        }
    }
}