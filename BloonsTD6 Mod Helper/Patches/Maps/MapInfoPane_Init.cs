using Il2CppAssets.Scripts.Unity.UI_New.Main.MapSelect;
namespace BTD_Mod_Helper.Patches.Maps;

[HarmonyPatch(typeof(MapButton), nameof(MapButton.Init))]
internal class MapInfoPane_Init
{
    [HarmonyPrefix]
    internal static bool Prefix(MapButton __instance)
    {
        return true;
    }

    [HarmonyPostfix]
    internal static void Postfix(MapButton __instance, string mapId)
    {
        /*ModHelper.Log(__instance.mapImage.sprite.rect.ToString());
        if (!ModMap.IsCustomMap(mapId))
            return;

        var modMap = ModContent.GetModMap(mapId);

        // thumbnail is 255 x 255

        var texture = modMap.GetTexture();
        var dup = texture.Duplicate();
        dup.Resize(255, 255);
        dup.Apply();
        __instance.mapImage.sprite.SetTexture(dup);*/
    }
}