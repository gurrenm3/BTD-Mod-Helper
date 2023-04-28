using System.Collections.Generic;
using System.Reflection;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Patches.ModdedClientChecking;

[HarmonyPatch]
internal static class IsModdedClientPatches
{
    public static bool ForceNoSave { get; set; }

    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.PropertyGetter(typeof(Game), nameof(Game.IsModdedClient));
        yield return AccessTools.Method(typeof(Modding), nameof(Modding.CheckForMods));
    }

    [HarmonyPrefix]
    private static bool Prefix(ref bool __result)
    {
        if (MelonMain.BypassSavingRestrictions && !ForceNoSave)
        {
            __result = false;
            return false;
        }
        return true;
    }
}