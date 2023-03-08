using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Unity.Bridge;
using UnityEngine;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.InitMap))]
internal class UnityToSimulation_InitMap
{
    static string[] rainObjectNames = { "Rain", "WaterSplashes", "Ripples" };

    [HarmonyPrefix]
    internal static bool Prefix(UnityToSimulation __instance, ref MapModel map)
    {
        if (!ModMap.IsCustomMap(map.mapName, out var modMap))
            return true;
            
        // testing resize code here
        var imageBytes = modMap.GetMapBytes();
        if (imageBytes == null)
        {
            ModHelper.Error("Image bytes are null!");
        }
            


        // remove all unwanted game objects
        foreach (var ob in Object.FindObjectsOfType<GameObject>())
        {
            if (ob.name == "MuddyPuddlesTerrain")
                continue;

            if (ob.name.Contains("Festive") || ob.name.Contains("Rocket") || ob.name.Contains("Firework") || ob.name.Contains("Box") || ob.name.Contains("Candy") || ob.name.Contains("Gift") || ob.name.Contains("Snow") || ob.name.Contains("Grass") || ob.name.Contains("Christmas") || ob.name.Contains("WhiteFlower") || ob.name.Contains("Tree") || ob.name.Contains("Rock") || ob.name.Contains("Shadow"))
                ob.transform.position = new Vector3(1000, 1000, 1000);

            if (rainObjectNames.Any(rainName => ob.name.Contains(rainName)))
                ob.active = modMap.EnableRain;
        }

        // set the map texture
        var mapRenderer = GameObject.Find("MuddyPuddlesTerrain").GetComponent<Renderer>();
        mapRenderer.material.mainTexture = modMap.GetTexture();

        return true;
    }
}