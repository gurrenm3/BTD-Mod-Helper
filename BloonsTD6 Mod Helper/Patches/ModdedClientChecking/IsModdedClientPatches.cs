using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Unity;

namespace BTD_Mod_Helper.Patches.ModdedClientChecking;

[HarmonyPatch]
internal static class IsModdedClientPatches
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.PropertyGetter(typeof(Game), nameof(Game.IsModdedClient));
        yield return AccessTools.Method(typeof(Modding), nameof(Modding.CheckForMods));
    }

    [HarmonyPrefix]
    private static bool Prefix(ref bool __result)
    {
        if (MelonMain.BypassSavingRestrictions)
        {
            __result = false;
            return false;
        }
        return true;
    }
}