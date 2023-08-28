using System.Collections.Generic;
using System.Reflection;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

/// <summary>
/// Go back to the main menu instead of to the boss menu, which may not even exist atm
/// </summary>
[HarmonyPatch]
internal static class InGame_ReturnToMainMenu
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return MoreAccessTools.SafeGetNestedClassMethod(typeof(InGame),
            nameof(InGame.ReturnToMainMenu));
    }

    [HarmonyPrefix]
    private static void Prefix()
    {
        var inGameData = InGameData.CurrentGame;
        if (inGameData?.gameEventId == ModBoss.EventId)
        {
            inGameData.gameType = GameType.Standard;
        }
    }
}