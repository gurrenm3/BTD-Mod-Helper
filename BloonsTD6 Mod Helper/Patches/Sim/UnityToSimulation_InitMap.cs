using Assets.Scripts.Models.Map;
using Assets.Scripts.Unity.Bridge;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;

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

            // these crash for some reason. Gives an IndexOutOfBounds of array exception 
            /*map.spawner = modMap.spawner;
            map.paths = modMap.paths.ToArray();*/

            return true;
        }
    }
}