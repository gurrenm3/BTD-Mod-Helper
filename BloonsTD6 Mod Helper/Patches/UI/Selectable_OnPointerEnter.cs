using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(Selectable), nameof(Selectable.OnPointerEnter))]
internal static class Selectable_OnPointerEnter
{
    [HarmonyPrefix]
    private static bool Prefix(ref Selectable __instance, ref PointerEventData eventData)
    {
        var result = true;
        var unref__instance = __instance;
        var unref_eventData = eventData;
        ModHelper.PerformAdvancedModHook(mod => result &=  mod.PrePointerEnterSelectable(ref unref__instance, ref unref_eventData));
        __instance = unref__instance;
        eventData = unref_eventData;
        return result;
    }
    
    [HarmonyPostfix]
    private static void Postfix(ref Selectable __instance, PointerEventData eventData)
    {
        var unref__instance = __instance;
        ModHelper.PerformAdvancedModHook(mod => mod.PostPointerEnterSelectable(ref unref__instance, eventData));
        __instance = unref__instance;
    }
}