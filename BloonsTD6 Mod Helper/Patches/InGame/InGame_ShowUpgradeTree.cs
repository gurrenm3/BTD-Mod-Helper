using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.ShowUpgradeTree), typeof(TowerModel), typeof(bool))]
internal static class InGame_ShowUpgradeTree
{
    [HarmonyPrefix]
    private static bool Prefix(ref TowerModel towerModel, ref bool doubleTapTowerPanel)
    {
        var result = true;
        var unref_towerModel = towerModel;
        var unref_doubleTapTowerPanel = doubleTapTowerPanel;
        ModHelper.PerformAdvancedModHook(mod => result &=  mod.PreShowUpgradeTree(ref unref_towerModel, ref unref_doubleTapTowerPanel));
        towerModel = unref_towerModel;
        doubleTapTowerPanel = unref_doubleTapTowerPanel;
        return result;
    }
    [HarmonyPostfix]
    private static void Postfix(TowerModel towerModel, bool doubleTapTowerPanel)
    {
        ModHelper.PerformAdvancedModHook(mod => mod.PostShowUpgradeTree(towerModel, doubleTapTowerPanel));
    }
}