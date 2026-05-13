using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.InputManagers;

[HarmonyPatch]
internal static class SelectPointInput_VoidPatches
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(SelectPointInput), nameof(SelectPointInput.Update));
        yield return AccessTools.Method(typeof(SelectPointInput), nameof(SelectPointInput.EnterInputMode));
        yield return AccessTools.Method(typeof(SelectPointInput), nameof(SelectPointInput.ExitInputMode));
        yield return AccessTools.Method(typeof(SelectPointInput), nameof(SelectPointInput.OnValidPositionCursorUp));
        yield return AccessTools.Method(typeof(SelectPointInput), nameof(SelectPointInput.OnInvalidPositionCursorUp));
    }

    [HarmonyPrefix]
    internal static bool Prefix(CustomInput __instance, MethodBase __originalMethod, object[] __args)
    {
        if (ModCustomInput.ActiveInput is not { } customInput) return true;

        AccessTools.Method(customInput.GetType(), __originalMethod.Name)
            .Invoke(customInput, __args.Prepend(__instance).ToArray());

        if (__originalMethod.Name == nameof(ModCustomInput.ExitInputMode))
        {
            ModCustomInput.Deactivate(__instance);
        }

        return false;
    }
}