using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Track;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(Map), nameof(Map.GetSaveData))]
internal static class Map_GetSaveData
{
    public static void Postfix(MapSaveDataModel mapData)
    {
        ModSaveData.SaveAll(mapData);
    }
}