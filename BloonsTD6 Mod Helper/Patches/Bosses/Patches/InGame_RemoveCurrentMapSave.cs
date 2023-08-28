using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

/// <summary>
/// Allow continuing from check point on defeat
/// </summary>
[HarmonyPatch(typeof(InGame), nameof(InGame.RemoveCurrentMapSave))]
internal static class InGame_RemoveCurrentMapSave
{
    [HarmonyPrefix]
    private static bool Prefix(bool canClearCheckpoints) =>
        canClearCheckpoints || InGameData.CurrentGame.gameEventId != ModBoss.EventId;
}