using Assets.Scripts.Unity.UI_New.Upgrade;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(UpgradeScreen), nameof(UpgradeScreen.UpdateUi))]
    internal class UpgradeScreen_UpdateUi
    {
        [HarmonyPrefix]
        internal static void Prefix(UpgradeScreen __instance)
        {
            for (var i = 1; i <= 3; i++)
            {
                var bgLines = __instance.transform.GetComponentFromChildrenByName<RectTransform>(i.ToString());
                bgLines.GetComponentsInChildren<CanvasRenderer>().Do(renderer =>
                {
                    renderer.SetAlpha(1);
                });
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