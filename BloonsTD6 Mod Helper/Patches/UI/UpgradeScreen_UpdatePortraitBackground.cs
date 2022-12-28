using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.Upgrade;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(UpgradeScreen), nameof(UpgradeScreen.UpdatePortraitBackground))]
internal static class UpgradeScreen_UpdatePortraitBackground
{
    [HarmonyPostfix]
    private static void Postfix(UpgradeScreen __instance)
    {
        if (ModTowerHelper.ModTowerCache.TryGetValue(__instance.currTowerId ?? "", out var tower) &&
            tower.ModTowerSet is { } towerSet)
        {
            __instance.selectedUpgrade.portraitBackground.SetSprite(towerSet.ContainerReference);
        }
    }
}