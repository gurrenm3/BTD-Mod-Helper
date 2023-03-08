using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Unity.Menu;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(GameMenu), nameof(GameMenu.PlayAnim))]
internal static class GameMenu_PlayCloseAnimation
{
    [HarmonyPrefix]
    private static bool Prefix(GameMenu __instance, int state)
    {
        if (state == 1 &&
            __instance.gameObject.HasComponent<ModGameMenuTracker>(out var tracker) &&
            ModGameMenu.Cache.TryGetValue(tracker.modGameMenuId ?? "", out var modGameMenu))
        {
            modGameMenu.Closing = true;
            modGameMenu.OnMenuClosed();
        }
        return true;
    }
}