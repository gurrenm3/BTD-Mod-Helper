using Il2CppAssets.Scripts.Unity.UI_New.Upgrade;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(SelectedUpgrade), nameof(SelectedUpgrade.UpdateButtonState))]
internal class SelectedUpgrade_UpdateButtonState
{
    [HarmonyPostfix]
    internal static void Postfix(SelectedUpgrade __instance)
    {
        if (__instance.selectedDetails.upgrade.GetModUpgrade()?.Tower.ModTowerSet is ModTowerSet modTowerSet &&
            !__instance.isParagon)
        {
            ResourceLoader.LoadSpriteFromSpriteReferenceAsync(modTowerSet.ContainerLargeReference,
                __instance.portraitBackground);
        }
    }
}