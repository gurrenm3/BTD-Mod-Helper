using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Simulation.Track;
namespace BTD_Mod_Helper.Patches;


[HarmonyPatch(typeof(Map), nameof(Map.SetSaveData))]
internal class Map_SetSaveData
{
    [HarmonyPostfix]
    internal static void Postfix(MapSaveDataModel mapData)
    {
        if (mapData.metaData.ContainsKey("RoundSet"))
            RoundSetChanger.RoundSetOverride = mapData.metaData["RoundSet"];
        ModHelper.PerformHook(mod => mod.OnMapDataLoaded(mapData));
    }
}