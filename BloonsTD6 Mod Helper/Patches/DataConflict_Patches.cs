using Assets.Scripts.Unity.Player;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Patches.ModdedClientChecking;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(DataConflict), nameof(DataConflict.ShowUpdatePopup))]
internal static class DataConflict_ShowUpdatePopup
{
    [HarmonyPrefix]
    private static bool Prefix()
    {
        if (!ModdedClientBypassing.ForceNoSave)
        {
            PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(
                "You aren't using the latest version of the game, " +
                "so Mod Helper's profile saving fix has been disabled."));
            ModdedClientBypassing.ForceNoSave = true;
        }
        return false;
    }
}

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