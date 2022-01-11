using Assets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(MenuManager), nameof(MenuManager.CloseCurrentMenu))]
    internal static class MenuManager_CloseCurrentMenu
    {
        [HarmonyPrefix]
        private static void Prefix(MenuManager __instance)
        {
            var current = __instance.GetCurrentMenu();
            if (current != null && current.gameObject.HasComponent(out ModGameMenuTracker tracker)
                && ModGameMenu.Cache.TryGetValue(tracker.modGameMenuId ?? "", out var modGameMenu))
            {
                modGameMenu.OnMenuClosed(current);
            }
        }
    }
}