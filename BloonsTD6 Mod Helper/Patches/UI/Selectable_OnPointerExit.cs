using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(Selectable), nameof(Selectable.OnPointerExit))]
internal static class Selectable_OnPointerExit
{
    [HarmonyPostfix]
    private static void Postfix(Selectable __instance, PointerEventData eventData)
    {
        ModHelper.PerformHook(mod => mod.OnPointerExitSelectable(__instance, eventData));
    }
}