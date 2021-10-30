using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Upgrade;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches
{
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
}