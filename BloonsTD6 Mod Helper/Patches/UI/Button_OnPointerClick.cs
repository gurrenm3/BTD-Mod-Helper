using BTD_Mod_Helper.UI.Menus;
using BTD_Mod_Helper.UI.Modded;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(Button), nameof(Button.OnPointerClick))]
internal static class Button_OnPointerClick
{
    [HarmonyPostfix]
    private static void Postfix(Button __instance, PointerEventData eventData)
    {
        ModHelper.PerformHook(mod => mod.OnButtonClicked(__instance, eventData));
    }
}