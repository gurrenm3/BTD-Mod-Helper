using BTD_Mod_Helper.UI.Menus;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Start))]
internal static class MainMenu_Start
{
    [HarmonyPostfix]
    private static void Postfix(MainMenu __instance)
    {
        ModsButton.Create(__instance);
        ModsMenu.selectedMod = null;
    }
}