using Il2CppAssets.Scripts.Unity.Menu;
using BTD_Mod_Helper.UI.Modded;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MenuManager), nameof(MenuManager.OpenMenu))]
internal static class MenuManager_OpenMenu
{
    [HarmonyPrefix]
    private static void Prefix(MenuManager __instance, string menuName)
    {
        RoundSetChanger.OnMenuChanged(__instance.GetCurrentMenu().Exists()?.name ?? "", menuName);
    }
}
