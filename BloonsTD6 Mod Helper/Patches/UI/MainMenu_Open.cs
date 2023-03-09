using Il2CppAssets.Scripts.Unity.UI_New.Main;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Open))]
internal class MainMenu_Open
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        SessionData.Reset();
        ModHelper.PerformHook(mod => mod.OnMainMenu());
    }
}