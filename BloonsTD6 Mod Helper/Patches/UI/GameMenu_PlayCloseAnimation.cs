using Il2CppAssets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;

namespace BTD_Mod_Helper.Patches.UI;

//TODO: go back to the old way of doing this before the animation plays
[HarmonyPatch(typeof(MenuManager), nameof(MenuManager.CloseCurrentMenuIfPossible))]
internal static class GameMenu_PlayCloseAnimation
{
    [HarmonyPrefix]
    private static bool Prefix(MenuManager __instance)
    {
        if (__instance.GetCurrentMenu().gameObject.HasComponent<ModGameMenuTracker>(out var tracker) && ModGameMenu.Cache.TryGetValue(tracker.modGameMenuId ?? "", out var modGameMenu))
        {
            modGameMenu.Closing = true;
            modGameMenu.OnMenuClosed();
        }
        return true;
    }
}
