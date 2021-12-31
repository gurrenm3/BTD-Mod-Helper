using Assets.Scripts.Models.Map;
using Assets.Scripts.Unity.Map;
using HarmonyLib;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(MapLoader), nameof(MapLoader.Load))]
    internal class MapLoader_Load
    {
        [HarmonyPrefix]
        internal static bool Prefix(MapLoader __instance, ref string map, ref Il2CppSystem.Action<MapModel> loadedCallback)
        {
            //map = "My Custom Map"; // using this line to test when map is invalid
            var originalCallback = loadedCallback.Duplicate<Il2CppSystem.Action<MapModel>>();
            loadedCallback = new System.Action<MapModel>((mapModel) =>
            {
                if (mapModel == null)
                    MelonLoader.MelonLogger.Msg("Map Model is null");

                ModHelper.PerformHook((mod) => mod.OnMapModelLoaded(ref mapModel));
                originalCallback.Invoke(mapModel);
            });

            return true;
        }
    }



    /// ==============================================================================
    /// 

}
