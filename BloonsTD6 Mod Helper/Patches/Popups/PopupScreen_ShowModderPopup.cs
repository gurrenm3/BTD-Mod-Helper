using Il2CppAssets.Scripts.Unity.UI_New.Popups;
namespace BTD_Mod_Helper.Patches.Popups;

[HarmonyPatch(typeof(PopupScreen), nameof(PopupScreen.ShowModderPopup))]
internal class PopupScreen_ShowModderPopup
{
    [HarmonyPrefix]
    private static bool Prefix(PopupScreen __instance)
    {
        __instance.hasSeenModderWarning = MelonMain.AutoHideModdedClientPopup;
        return MelonMain.AutoHideModdedClientPopup;
    }
}