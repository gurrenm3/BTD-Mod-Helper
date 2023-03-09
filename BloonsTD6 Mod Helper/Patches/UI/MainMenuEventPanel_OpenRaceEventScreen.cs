using Il2CppAssets.Scripts.Unity.UI_New.Main.EventPanel;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MainMenuEventPanel), nameof(MainMenuEventPanel.OpenRaceEventScreen))]
internal class MainMenuEventPanel_OpenRaceEventScreen
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        SessionData.Instance.IsInRace = true;
    }
}