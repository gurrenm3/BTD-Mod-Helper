using BTD_Mod_Helper.Api.Internal;
using Il2CppAssets.Scripts.Unity.Menu;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MenuManager), nameof(MenuManager.IsAnyMenuOrPopupShowing))]
internal static class MenuManager_IsAnyMenuOrPopupShowing
{
    [HarmonyPrefix]
    internal static bool Prefix(ref bool __result)
    {
        if (ConsoleHandler.ConsoleShowing)
        {
            __result = true;
            return false;
        }
        
        return true;
    }
}