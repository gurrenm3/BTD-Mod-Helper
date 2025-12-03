using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Internal;
using Il2CppAssets.Scripts.Unity.Menu;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch]
internal static class MenuManager_IsAnyMenuOrPopupShowing
{
    private static IEnumerable<MethodBase> TargetMethods() => typeof(MenuManager).GetMethods()
        .Where(info => info.Name == nameof(MenuManager.IsAnyMenuOrPopupShowing));

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