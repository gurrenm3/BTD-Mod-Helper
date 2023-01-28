using Il2CppAssets.Scripts.Unity.UI_New.Settings;
namespace BTD_Mod_Helper.Patches.UI;

/// <summary>
/// Ignore any exceptions coming from this method
/// </summary>
[HarmonyPatch(typeof(HotkeysScreenField), nameof(HotkeysScreenField.UpdateUi))]
internal static class HotkeysScreenField_UpdateUI
{
    [HarmonyPostfix]
    private static void Postfix()
    {
    }
}