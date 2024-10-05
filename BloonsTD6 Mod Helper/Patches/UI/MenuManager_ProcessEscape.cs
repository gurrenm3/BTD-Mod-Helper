using BTD_Mod_Helper.Api.Internal;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Settings;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MenuManager), nameof(MenuManager.ProcessEscape))]
internal static class MenuManager_ProcessEscape
{
    [HarmonyPrefix]
    private static bool Prefix(MenuManager __instance)
    {
        if (__instance.GetCurrentMenu().Is(out HotkeysScreen hotkeysScreen) && hotkeysScreen.fieldBeingChanged != null)
        {
            hotkeysScreen.rebindingOperation?.Dispose();
            hotkeysScreen.ChangeField(hotkeysScreen.fieldBeingChanged, HotkeyModifier.None, "");
            return false;
        }

        if (ConsoleHandler.ConsoleShowing)
        {
            ConsoleHandler.ProcessEscape();
            return false;
        }

        return true;
    }
}