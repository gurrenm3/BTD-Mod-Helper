using Assets.Scripts.Unity.UI_New.Main.ModeSelect;
using BTD_Mod_Helper.UI.Modded;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(ModeScreen), nameof(ModeScreen.OnModeSelected))]
internal static class ModeSelectScreen_OnModeSelected
{
    [HarmonyPrefix]
    private static void Prefix()
    {
        RoundSetChanger.EnsureHidden();
    }
}