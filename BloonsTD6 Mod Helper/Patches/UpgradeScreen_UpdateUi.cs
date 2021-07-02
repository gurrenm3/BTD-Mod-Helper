using Assets.Scripts.Unity.UI_New.Upgrade;
using BTD_Mod_Helper.Extensions;
using Harmony;
using MelonLoader;
using UnityEngine;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(UpgradeScreen), nameof(UpgradeScreen.UpdateUi))]
    internal class UpgradeScreen_UpdateUi
    {
        [HarmonyPrefix]
        internal static void Prefix(UpgradeScreen __instance)
        {
            var bgArrows = __instance.GetComponentFromChildrenByName<RectTransform>("BGArrows");
            foreach (var arrow in bgArrows.GetComponentsInChildren<CanvasRenderer>())
            {
                arrow.gameObject.Show();
            }
        }
        
        [HarmonyPostfix]
        internal static void Postfix(UpgradeScreen __instance)
        {
            if (!__instance.selectedDetails.gameObject.active)
            {
                __instance.SelectUpgrade(__instance.path2Upgrades[0]);
            }
        }
    }
}