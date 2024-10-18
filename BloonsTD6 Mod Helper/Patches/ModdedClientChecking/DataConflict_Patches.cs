using Il2CppAssets.Scripts.Unity.Player;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
namespace BTD_Mod_Helper.Patches.ModdedClientChecking;

[HarmonyPatch(typeof(DataConflict), nameof(DataConflict.ReportIncompatibleDataVersion))]
internal static class DataConflict_ReportIncompatibleDataVersion
{
    [HarmonyPrefix]
    private static bool Prefix()
    {
        ModHelper.Msg("Preventing report of incompatible data version");
        return false;
    }
}