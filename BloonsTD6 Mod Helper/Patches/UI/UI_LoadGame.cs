using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Models.ServerEvents;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(Il2CppAssets.Scripts.Unity.UI_New.UI), nameof(Il2CppAssets.Scripts.Unity.UI_New.UI.LoadGame))]
internal static class UI_LoadGame
{
    [HarmonyPrefix]
    internal static void Prefix()
    {
        var gameData = InGameData.Editable;

        if (!string.IsNullOrEmpty(gameData.selectedMode) &&
            ModGameMode.Cache.TryGetValue(gameData.selectedMode, out var modGameMode))
        {
            if (modGameMode.ApplyChallengeRules)
            {
                gameData.dcModel ??= DailyChallengeModel.CreateDefaultEditorModel();
            }

            gameData.dcModel?.mode = modGameMode.Id;
            modGameMode.ModifyChallengeRules(gameData.dcModel);
        }
    }
}