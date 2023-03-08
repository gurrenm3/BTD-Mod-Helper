using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TowerSelectionMenu), nameof(TowerSelectionMenu.IsUpgradePathClosed))]
internal class TowerSelectionMenu_IsUpgradePathClosed
{
    [HarmonyPostfix]
    internal static void Postfix(TowerSelectionMenu __instance, int path, ref bool __result)
    {
        var tower = __instance.selectedTower?.tower;
        if (tower?.GetUpgrade(path)?.GetModUpgrade() is ModUpgrade modUpgrade && modUpgrade.RestrictUpgrading(tower))
        {
            __result = true;
        }

        if (tower?.towerModel.GetModTower() is ModTower modTower &&
            modTower.IsUpgradePathClosed(__instance.selectedTower, path, __result) is bool newClosed)
        {
            __result = newClosed;
        }
    }
}