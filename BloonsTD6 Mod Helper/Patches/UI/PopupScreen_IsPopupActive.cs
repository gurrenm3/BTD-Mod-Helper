using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Internal;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(PopupScreen), nameof(PopupScreen.IsPopupActive))]
internal static class PopupScreen_IsPopupActive
{
    [HarmonyPrefix]
    internal static bool Prefix(ref bool __result)
    {
        if (ConsoleHandler.ConsoleShowing || ModHelperWindow.AnyWindowFocused)
        {
            __result = true;
            return false;
        }

        return true;
    }
}