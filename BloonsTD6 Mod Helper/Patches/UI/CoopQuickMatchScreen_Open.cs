using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.Coop;
using Il2CppSystem;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(CoopQuickMatchScreen), nameof(CoopQuickMatchScreen.Open))]
internal class CoopQuickMatchScreen_Open
{
    [HarmonyPrefix]
    private static bool Prefix(GameMenu __instance, ref Object data)
    {
        return ModGameMenu.CheckOpen(__instance, data, out data);
    }
        
    [HarmonyPostfix]
    internal static void Postfix()
    {
        SessionData.Instance.IsInPublicCoop = true;
    }
}