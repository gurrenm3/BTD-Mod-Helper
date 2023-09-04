using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Unity.UI_New.Pause;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(PauseScreen), nameof(PauseScreen.TryQuitToMenu))]
internal static class PauseScreen_TryQuitToMenu
{
    [HarmonyPostfix]
    private static void Postfix()
    {
        if (ModRoundSet.Cache.TryGetValue(RoundSetChanger.RoundSetOverride, out _))
        {
            RoundSetChanger.RoundSetOverride = RoundSetChanger.PreviousRoundSetOverride;
        }
    }
}