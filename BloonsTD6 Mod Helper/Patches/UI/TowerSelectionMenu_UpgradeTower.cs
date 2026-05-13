namespace BTD_Mod_Helper.Patches.UI;

/// <summary>
/// This is a benign patch that helps fix unexpected issues with changing upgrade restrictions
/// </summary>
[HarmonyPatch(typeof(Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenu), nameof(Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenu.TowerUpgraded))]
internal class TowerSelectionMenu_UpgradeTower
{
    [HarmonyPostfix]
    internal static void Postfix(Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenu __instance)
    {
        __instance.triggerUiUpdate = true;
    }
}