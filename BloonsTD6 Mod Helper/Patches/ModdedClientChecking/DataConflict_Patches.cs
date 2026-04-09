using Il2CppAssets.Scripts.Unity.Player;
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