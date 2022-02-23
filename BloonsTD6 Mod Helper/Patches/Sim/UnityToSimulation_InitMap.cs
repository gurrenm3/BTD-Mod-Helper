using Assets.Scripts.Models.Map;
using Assets.Scripts.Unity.Bridge;
using BTD_Mod_Helper.Api;
using HarmonyLib;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.Sim
{
    [HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.InitMap))]
    internal class UnityToSimulation_InitMap
    {
        [HarmonyPrefix]
        internal static bool Prefix(UnityToSimulation __instance, ref MapModel map)
        {
            if (!ModMap.IsCustomMap(map.mapName))
                return true;

            var modMap = ModContent.GetModMap(map.mapName);


            var ob2 = GameObject.Find("MuddyPuddlesTerrain");
            ob2.GetComponent<Renderer>().material.mainTexture = modMap.MapTexture;
            foreach (var ob in Object.FindObjectsOfType<GameObject>())
            {
                if (ob.name.Contains("Festive") || ob.name.Contains("Rocket") || ob.name.Contains("Firework") || ob.name.Contains("Box") || ob.name.Contains("Candy") || ob.name.Contains("Gift") || ob.name.Contains("Snow") || ob.name.Contains("Ripples") || ob.name.Contains("Grass") || ob.name.Contains("Christmas") || ob.name.Contains("WhiteFlower") || ob.name.Contains("Tree") || ob.name.Contains("Rock") || ob.name.Contains("Shadow") || ob.name.Contains("WaterSplashes"))// || ob.name.Contains("Body")   || ob.name.Contains("Ouch") || ob.name.Contains("Statue")|| ob.name.Contains("Chute")  || ob.name.Contains("Jump") || ob.name.Contains("Timer") || ob.name.Contains("Wheel") || ob.name.Contains("Body") || ob.name.Contains("Axle") || ob.name.Contains("Leg") || ob.name.Contains("Clock") ||
                    if (ob.name != "MuddyPuddlesTerrain")
                        ob.transform.position = new Vector3(1000, 1000, 1000);
            }

            if (GameObject.Find("Rain"))
                GameObject.Find("Rain").active = false;

            return true;
        }
    }
}