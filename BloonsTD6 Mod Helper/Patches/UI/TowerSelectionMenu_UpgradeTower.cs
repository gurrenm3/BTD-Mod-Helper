using Assets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.UI
{
    /// <summary>
    /// This is a benign patch that helps fix unexpected issues with changing upgrade restrictions
    /// </summary>
    [HarmonyPatch(typeof(TowerSelectionMenu), nameof(TowerSelectionMenu.TowerUpgraded))]
    internal class TowerSelectionMenu_UpgradeTower
    {
        [HarmonyPostfix]
        internal static void Postfix(TowerSelectionMenu __instance)
        {
            __instance.triggerUiUpdate = true;
        }
    }
}