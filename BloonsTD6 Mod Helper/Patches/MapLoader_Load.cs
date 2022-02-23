using Assets.Scripts.Models.Map;
using Assets.Scripts.Unity.Map;
using HarmonyLib;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(MapLoader), nameof(MapLoader.Load))]
    internal class MapLoader_Load
    {
        [HarmonyPrefix]
        internal static bool Prefix(ref string map, ref Il2CppSystem.Action<MapModel> loadedCallback)
        {
            if (!ModMap.IsCustomMap(map))
                return true;

            var modMap = ModContent.GetModMap(map);
            loadedCallback += new System.Action<MapModel>((mapModel) =>
            {
                mapModel.name = modMap.Name;
                mapModel.mapName = modMap.Name;
                mapModel.mapDifficulty = (int)modMap.Difficulty;
                mapModel.mapWideBloonSpeed = modMap.MapWideBloonSpeed;
                mapModel.areas = modMap.areaModels.ToArray();

                // These still crash when being set here.
                /*mapModel.spawner = modMap.spawner;
                mapModel.paths = modMap.paths.ToArray();*/
            });

            map = "MuddyPuddles";

            return true;
        }
    }
}
