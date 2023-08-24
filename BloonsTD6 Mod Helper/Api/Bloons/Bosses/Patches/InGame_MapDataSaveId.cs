using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

/// <summary>
/// Make boss rounds games save to the maps and not the boss event
/// </summary>
[HarmonyPatch(typeof(InGame), nameof(InGame.MapDataSaveId), MethodType.Getter)]
internal static class InGame_MapDataSaveId
{
    [HarmonyPrefix]
    private static bool Prefix(ref string __result)
    {
        if (InGameData.CurrentGame.gameEventId == ModBoss.EventId)
        {
            __result = InGameData.CurrentGame.selectedMap;
            return false;
        }

        return true;
    }
}