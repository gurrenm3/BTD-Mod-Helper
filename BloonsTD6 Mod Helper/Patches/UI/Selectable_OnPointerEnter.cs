using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(Selectable), nameof(Selectable.OnPointerEnter))]
internal static class Selectable_OnPointerEnter
{
    [HarmonyPostfix]
    private static void Postfix(Selectable __instance, PointerEventData eventData)
    {
        ModHelper.PerformHook(mod => mod.OnPointerEnterSelectable(__instance, eventData));
    }
}