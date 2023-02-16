using System.Linq;
using Il2CppAssets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.UI.Modded;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MenuManager), nameof(MenuManager.CloseCurrentMenuIfPossible))]
internal static class MenuManager_CloseCurrentMenu
{
    [HarmonyPrefix]
    private static void Prefix(MenuManager __instance, ref GameMenu __state)
    {
        __state = __instance.GetCurrentMenu();
    }

    [HarmonyPostfix]
    private static void Postfix(MenuManager __instance, ref GameMenu __state)
    {
        if (__state != null &&
            __instance.IsClosingOrOpeningMenu &&
            __state.gameObject.HasComponent(out ModGameMenuTracker tracker) &&
            ModGameMenu.Cache.TryGetValue(tracker.modGameMenuId ?? "", out var modGameMenu))
        {
            modGameMenu.Closing = true;
            modGameMenu.OnMenuClosed();
        }
        
        RoundSetChanger.OnMenuChanged(__state.Exists()?.name ?? "",
            __instance.menuStack.ToList().SkipLast(1).LastOrDefault()?.Item1 ?? "");
    }
}