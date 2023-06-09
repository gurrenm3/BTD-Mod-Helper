using BTD_Mod_Helper.Api.Components;
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

    }
}