using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Open))]
internal class MainMenu_Open
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        SessionData.Reset();
        Animations.Load();
        Fonts.Load();
    }
}