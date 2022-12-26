using BTD_Mod_Helper.Api.Components;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Patches.UI;

/// <summary>
/// I'm just annoyed that Unity doesn't work this way by default lol
/// </summary>
/*internal static class LayoutGroupPatches
{
    [HarmonyPatch(typeof(LayoutGroup), nameof(LayoutGroup.flexibleHeight), MethodType.Getter)]
    internal static class LayoutGroup_FlexibleHeight
    {
        [HarmonyPostfix]
        private static void Postfix(HorizontalLayoutGroup __instance, ref float __result)
        {
            if (__instance.GetComponent<ModHelperPanel>() != null)
            {
                var layoutElement = __instance.GetComponent<LayoutElement>();
                if (layoutElement != null && layoutElement.enabled)
                {
                    __result = layoutElement.flexibleHeight;
                }
            }
        }
    }

    [HarmonyPatch(typeof(LayoutGroup), nameof(LayoutGroup.flexibleWidth), MethodType.Getter)]
    internal static class LayoutGroup_FlexibleWidth
    {
        [HarmonyPostfix]
        private static void Postfix(HorizontalLayoutGroup __instance, ref float __result)
        {
            if (__instance.GetComponent<ModHelperPanel>() != null)
            {
                var layoutElement = __instance.GetComponent<LayoutElement>();
                if (layoutElement != null && layoutElement.enabled)
                {
                    __result = layoutElement.flexibleWidth;
                }
            }
        }
    }

    [HarmonyPatch(typeof(LayoutGroup), nameof(LayoutGroup.preferredHeight), MethodType.Getter)]
    internal static class LayoutGroup_PreferredHeight
    {
        [HarmonyPostfix]
        private static void Postfix(HorizontalLayoutGroup __instance, ref float __result)
        {
            if (__instance.GetComponent<ModHelperPanel>() != null)
            {
                var layoutElement = __instance.GetComponent<LayoutElement>();
                if (layoutElement != null && layoutElement.enabled)
                {
                    __result = layoutElement.preferredHeight;
                }
            }
        }
    }

    [HarmonyPatch(typeof(LayoutGroup), nameof(LayoutGroup.preferredWidth), MethodType.Getter)]
    internal static class LayoutGroup_PreferredWidth
    {
        [HarmonyPostfix]
        private static void Postfix(HorizontalLayoutGroup __instance, ref float __result)
        {
            if (__instance.GetComponent<ModHelperPanel>() != null)
            {
                var layoutElement = __instance.GetComponent<LayoutElement>();
                if (layoutElement != null && layoutElement.enabled)
                {
                    __result = layoutElement.preferredWidth;
                }
            }
        }
    }

    [HarmonyPatch(typeof(LayoutGroup), nameof(LayoutGroup.minHeight), MethodType.Getter)]
    internal static class LayoutGroup_MinHeight
    {
        [HarmonyPostfix]
        private static void Postfix(HorizontalLayoutGroup __instance, ref float __result)
        {
            if (__instance.GetComponent<ModHelperPanel>() != null)
            {
                var layoutElement = __instance.GetComponent<LayoutElement>();
                if (layoutElement != null && layoutElement.enabled)
                {
                    __result = layoutElement.minHeight;
                }
            }
        }
    }

    [HarmonyPatch(typeof(LayoutGroup), nameof(LayoutGroup.minWidth), MethodType.Getter)]
    internal static class LayoutGroup_MinWidth
    {
        [HarmonyPostfix]
        private static void Postfix(HorizontalLayoutGroup __instance, ref float __result)
        {
            if (__instance.GetComponent<ModHelperPanel>() != null)
            {
                var layoutElement = __instance.GetComponent<LayoutElement>();
                if (layoutElement != null && layoutElement.enabled)
                {
                    __result = layoutElement.minWidth;
                }
            }
        }
    }
}*/