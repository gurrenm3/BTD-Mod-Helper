using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TowerImageLoader), nameof(TowerImageLoader.Load))]
internal static class TowerImageLoader_Load
{
    [HarmonyPostfix]
    private static void Postfix(TowerImageLoader __instance, string towerID, bool useRoundBg)
    {
        if (ModTowerHelper.ModTowerCache.TryGetValue(towerID, out var modTower) &&
            modTower.ModTowerSet is var modTowerSet &&
            __instance.bg != null)
        {
            ResourceLoader.LoadSpriteFromSpriteReferenceAsync(
                useRoundBg ? modTowerSet.SeatReference : modTowerSet.ContainerReference, __instance.bg);
        }
    }
}