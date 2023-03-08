using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(TowerSelectionMenu), nameof(TowerSelectionMenu.Show))]
internal class Tower_Highlight
{
    [HarmonyPostfix]
    internal static void Postfix(TowerSelectionMenu __instance)
    {
        ModHelper.PerformHook(mod => mod.OnTowerSelected(__instance.selectedTower.tower));
    }
}