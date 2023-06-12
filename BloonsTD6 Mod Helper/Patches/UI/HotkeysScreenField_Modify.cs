using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Settings;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(HotkeysScreenField), nameof(HotkeysScreenField.Modify))]
internal static class HotkeysScreenField_Modify
{
    [HarmonyPostfix]
    private static void Postfix(HotkeysScreenField __instance, HotkeyModifier modifier, string path)
    {
        if (__instance == null ||
            !(MenuManager.instance.GetCurrentMenu().Is(out HotkeysScreen hotkeysScreen) &&
              hotkeysScreen.gameObject.HasComponent<ModGameMenuTracker>()))
        {
            return;
        }

        var unset = modifier == HotkeyModifier.None && string.IsNullOrEmpty(path);

        __instance.button.GetComponent<Image>().SetSprite(unset ? VanillaSprites.RedBtnLong : VanillaSprites.GreenBtnLong);
    }
}