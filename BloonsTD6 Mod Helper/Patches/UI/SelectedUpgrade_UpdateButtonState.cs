using Il2CppAssets.Scripts.Unity.UI_New.Upgrade;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(SelectedUpgrade), nameof(SelectedUpgrade.UpdateButtonState))]
internal class SelectedUpgrade_UpdateButtonState
{
    [HarmonyPostfix]
    internal static void Postfix(SelectedUpgrade __instance)
    {
        if (__instance.selectedDetails.Exists()?.upgrade?.GetModUpgrade()?.Tower.ModTowerSet is { } modTowerSet &&
            !__instance.isParagon)
        {
            ResourceLoader.LoadSpriteFromSpriteReferenceAsync(modTowerSet.ContainerLargeReference,
                __instance.portraitBackground);
        }
    }
}