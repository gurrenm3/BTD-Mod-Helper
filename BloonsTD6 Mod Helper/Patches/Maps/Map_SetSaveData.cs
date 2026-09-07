using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Simulation.Track;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(Map), nameof(Map.SetSaveData))]
internal static class Map_SetSaveData
{
    public static void Postfix(MapSaveDataModel mapData)
    {
        ModSaveData.LoadAll(mapData);
    }
}