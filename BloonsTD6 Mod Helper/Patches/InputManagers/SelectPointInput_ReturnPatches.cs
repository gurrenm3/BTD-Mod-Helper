using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.InputManagers;

[HarmonyPatch]
internal static class SelectPointInput_ReturnPatches
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(SelectPointInput), nameof(SelectPointInput.IsPositionValid));
        yield return AccessTools.Method(typeof(SelectPointInput), nameof(SelectPointInput.GetHelperMessage));
        yield return AccessTools.Method(typeof(CustomInput), nameof(CustomInput.GetCantActivateMessage));
    }

    [HarmonyPrefix]
    internal static bool Prefix(CustomInput __instance, MethodBase __originalMethod, object[] __args,
        ref object __result)
    {
        if (ModCustomInput.ActiveInput is not { } customInput) return true;

        __result = AccessTools.Method(customInput.GetType(), __originalMethod.Name)
            .Invoke(customInput, __args.Prepend(__instance).ToArray());
        return false;
    }
}