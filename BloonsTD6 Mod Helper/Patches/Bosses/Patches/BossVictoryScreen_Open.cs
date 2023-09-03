using Il2CppAssets.Scripts.Unity.UI_New.GameOver;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

[HarmonyPatch(typeof(BossVictoryScreen), nameof(BossVictoryScreen.Open))]
internal static class BossVictoryScreen_Open
{
    [HarmonyPostfix]
    private static void Postfix()
    {
        InGame.instance.RemoveCurrentMapSave(true);
    }
}