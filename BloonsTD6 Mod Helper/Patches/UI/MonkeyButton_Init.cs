using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.Main.MonkeySelect;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MonkeyButton), nameof(MonkeyButton.Init))]
internal static class MonkeyButton_Init
{
    [HarmonyPostfix]
    private static void Postfix(MonkeyButton __instance)
    {
        if (ModTowerHelper.ModTowerCache.TryGetValue(__instance.towerId, out var tower) &&
            tower.ModTowerSet is { } towerSet)
        {
            __instance.bgImage.SetSprite(towerSet.ContainerReference);
        }
    }
}