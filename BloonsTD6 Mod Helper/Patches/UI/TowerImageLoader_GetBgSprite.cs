using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TowerImageLoader), nameof(TowerImageLoader.GetBgSprite))]
internal static class TowerImageLoader_GetBgSprite
{
    [HarmonyPostfix]
    private static void Postfix(TowerImageLoader __instance, ref SpriteReference __result)
    {
        if (__instance.TowerModel?.GetModTower()?.ModTowerSet is { } modTowerSet)
        {
            __result = modTowerSet.ContainerReference;
        }
    }
}