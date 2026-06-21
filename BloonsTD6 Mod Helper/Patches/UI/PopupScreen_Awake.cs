using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.UI;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;

namespace BTD_Mod_Helper.Patches.UI;

/// <summary>
/// Register ModPopupImages
/// </summary>
[HarmonyPatch(typeof(PopupScreen), nameof(PopupScreen.Awake))]
internal static class PopupScreen_Awake
{
    [HarmonyPostfix]
    internal static void Postfix(PopupScreen __instance)
    {
        var images = __instance.popupImagesSR.ToList();

        foreach (var modHintImage in ModContent.GetContent<ModPopupImage>())
        {
            if (modHintImage.ImageReference is { } image)
            {
                modHintImage.Index = images.Count;
                images.Add(image);
            }
        }

        __instance.popupImagesSR = images.ToIl2CppReferenceArray();
    }
}