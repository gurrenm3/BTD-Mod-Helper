using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(Button), nameof(Button.OnPointerEnter))]
internal static class Button_OnPointerEnter
{
    [HarmonyPrefix]
    private static bool Prefix(ref Button __instance, ref PointerEventData eventData)
    {
        var result = true;
        var unref__instance = __instance;
        var unref_eventData = eventData;
        ModHelper.PerformAdvancedModHook(mod => result &=  mod.PrePointerEnterButton(ref unref__instance, ref unref_eventData));
        __instance = unref__instance;
        eventData = unref_eventData;
        return result;
    }
    
    [HarmonyPostfix]
    private static void Postfix(ref Button __instance, PointerEventData eventData)
    {
        var unref__instance = __instance;
        ModHelper.PerformAdvancedModHook(mod => mod.PostPointerEnterButton(ref unref__instance, eventData));
        __instance = unref__instance;
    }
}