namespace BTD_Mod_Helper.Patches;

/*[HarmonyPatch(typeof(MapLoader), nameof(MapLoader.Load))] TODO FIX THIS PATCH
internal class MapLoader_Load
{
    [HarmonyPrefix]
    internal static bool Prefix(ref string map, ref Il2CppSystem.Action<MapModel> loadedCallback)
    {
        // if this is a custom map, the variable "map" will be the name of the custom map.
        if (!ModMap.IsCustomMap(map))
            return true;

        var modMap = ModContent.GetModMap(map);
        loadedCallback += new System.Action<MapModel>((mapModel) =>
        {
            mapModel.mapName = modMap.Name;
            mapModel.mapDifficulty = (int)modMap.Difficulty;
            mapModel.mapWideBloonSpeed = modMap.MapWideBloonSpeed;
            mapModel.areas = modMap.areaModels.ToArray();
            mapModel.paths = modMap.paths.ToArray();
            mapModel.spawner = MapHelper.CreateSpawner(mapModel.paths); // create a spawner dynamically based on the path.
        });

        // When loading a custom map the game will crash if you leave "map" as the name of the Custom Map.
        // My speculation is it tries to load a MapModel with the name of "map" from an asset bundle, 
        // however it doesn't exist because it's a custom map and therefore crashes. To fix this we're
        // setting the map to an existing map within the game so it can load properly, then in the "loadedCallback"
        // we're modifying it to be our custom map.
        map = "MuddyPuddles";

        return true;
    }
}*/