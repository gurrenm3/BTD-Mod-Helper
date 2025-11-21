using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.Quit))]
internal class InGame_Quit
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        var gameData = InGameData.CurrentGame;
        if (!string.IsNullOrEmpty(gameData.selectedMode) &&
            ModGameMode.Cache.TryGetValue(gameData.selectedMode, out var modGameMode) &&
            modGameMode.ApplyChallengeRules)
        {
            gameData.dcModel = null;
        }

        ModHelper.PerformHook(mod => mod.OnMatchEnd());
    }
}