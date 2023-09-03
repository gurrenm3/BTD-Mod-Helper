using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches;


[HarmonyPatch(typeof(Map), nameof(Map.GetSaveData))]
internal class Map_GetSaveData
{
    [HarmonyPostfix]
    internal static void Postfix(MapSaveDataModel mapData)
    {
        mapData.metaData["RoundSet"] = InGame.instance.GetGameModel().roundSet.name;
        ModHelper.PerformHook(mod => mod.OnMapDataSaved(mapData));
    }
}