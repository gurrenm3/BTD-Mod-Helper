using System.Linq;
using Assets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.UI.Modded;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MenuManager), nameof(MenuManager.CloseCurrentMenu))]
internal static class MenuManager_CloseCurrentMenu
{
    [HarmonyPrefix]
    private static void Prefix(MenuManager __instance, ref string __state)
    {
        var current = __instance.GetCurrentMenu();
        if (current != null &&
            current.gameObject.HasComponent(out ModGameMenuTracker tracker) &&
            ModGameMenu.Cache.TryGetValue(tracker.modGameMenuId ?? "", out var modGameMenu))
        {
            modGameMenu.Closing = true;
            modGameMenu.OnMenuClosed();
        }

        __state = current.Exists()?.name ?? "";

    }

    [HarmonyPostfix]
    private static void Postfix(MenuManager __instance, ref string __state)
    {
        RoundSetChanger.OnMenuChanged(__state, __instance.menuStack.ToList().LastOrDefault()?.Item1 ?? "");
    }
}