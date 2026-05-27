using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
namespace BTD_Mod_Helper.Patches.UI;

/// <summary>
/// No sharing challenges with custom modes
/// </summary>
[HarmonyPatch(typeof(EditorPlayBase), nameof(EditorPlayBase.UpdateSharedStatus))]
internal static class EditorPlayBase_UpdateSharedStatus
{
    [HarmonyPrefix]
    internal static void Prefix(EditorPlayBase __instance)
    {
        if (__instance.mapSaveData != null &&
            ModGameMode.Cache.ContainsKey(__instance.mapSaveData.modeName) &&
            __instance.mapSaveData.matchWon)
        {
            __instance.mapSaveData.matchWon = false;
        }
    }
}