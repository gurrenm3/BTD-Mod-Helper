using Il2CppAssets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(GameMenu), nameof(GameMenu.PlayCloseAnimation))]
internal static class GameMenu_PlayCloseAnimation
{
    [HarmonyPrefix]
    private static bool Prefix(GameMenu __instance)
    {
        if (__instance.gameObject.HasComponent<ModGameMenuTracker>(out var tracker))
        {
            if (ModGameMenu.Cache.TryGetValue(tracker.modGameMenuId ?? "", out var modGameMenu))
            {
                modGameMenu.Closing = true;
                modGameMenu.OnMenuClosed();
            }
        }
        return true;
    }
}