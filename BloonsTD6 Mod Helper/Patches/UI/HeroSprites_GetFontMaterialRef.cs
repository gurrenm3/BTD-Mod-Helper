using Assets.Scripts.Data.Global;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(HeroSprites), nameof(HeroSprites.GetFontMaterialRef))]
internal static class HeroSprites_GetFontMaterialRef
{
    [HarmonyPrefix]
    private static void Prefix(HeroSprites __instance, ref string heroId)
    {
            
    }
}