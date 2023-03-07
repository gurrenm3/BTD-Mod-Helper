using BTD_Mod_Helper.Api.Components;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(Button), nameof(Button.OnPointerClick))]
internal static class Button_OnPointerClick
{
    [HarmonyPrefix]
    private static bool Prefix(ref Button __instance, ref PointerEventData eventData)
    {
        var result = true;
        var unref__instance = __instance;
        var unref_eventData = eventData;
        ModHelper.PerformAdvancedModHook(mod => result &=  mod.PreButtonClicked(ref unref__instance, ref unref_eventData));
        __instance = unref__instance;
        eventData = unref_eventData;
        return result;
    }
    [HarmonyPostfix]
    private static void Postfix(Button __instance, PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right &&
            __instance.IsActive() &&
            __instance.IsInteractable())
        {
            var parent = __instance.transform.parent;
            if (parent != null && parent.gameObject.HasComponent(out ModsMenuMod modsMenuMod))
            {
                modsMenuMod.toggleMod?.Invoke();
            }
        }
        
        ModHelper.PerformAdvancedModHook(mod => mod.PostButtonClicked(__instance, eventData));
        
    }
}