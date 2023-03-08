using Il2CppAssets.Scripts.Unity.UI_New.Settings;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(SettingsScreen), nameof(SettingsScreen.Open))]
internal static class SettingsScreen_Open
{
    [HarmonyPostfix]
    private static void Postfix()
    {
    }
}