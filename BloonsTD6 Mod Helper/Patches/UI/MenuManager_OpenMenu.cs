using Assets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Api;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(MenuManager), nameof(MenuManager.OpenMenu))]
    internal static class MenuManager_OpenMenu
    {
        [HarmonyPostfix]
        private static void Postfix(MenuManager __instance, string menuName, Il2CppSystem.Object menuData)
        {
            ModGameMenu.GameMenuCloses.Push(() => { });
        }
    }

    [HarmonyPatch(typeof(MenuManager), nameof(MenuManager.CloseCurrentMenu))]
    internal static class MenuManager_CloseCurrentMenu
    {
        [HarmonyPrefix]
        private static void Prefix()
        {
            if (ModGameMenu.GameMenuCloses.Peek() != null)
            {
                var action = ModGameMenu.GameMenuCloses.Pop();
                action?.Invoke();
            }
            else
            {
                ModHelper.Warning("It peeked at null...");
            }
        }
    }
}