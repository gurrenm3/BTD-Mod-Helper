using BTD_Mod_Helper.Api;
using UnityEngine;
using UnityEngine.U2D;
namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(SpriteAtlas), nameof(SpriteAtlas.GetSprite))]
internal static class SpriteAtlas_GetSprite
{
    [HarmonyPrefix]
    private static bool Prefix(SpriteAtlas __instance, ref string name, ref Sprite __result)
    {
        var result = true;
        var unrefname = name;
        var unref__result = __result;


        ModHelper.PerformHook(mod => result &= mod.PreSpriteLoaded(__instance, ref unrefname, ref unref__result));
        name = unrefname;
        __result = unref__result;

        if (__instance.name == ModContent.HijackSpriteAtlas && ResourceHandler.GetSprite(name) is Sprite spr)
        {
            spr.texture.mipMapBias = -1;
            __result = spr;
            result = false;
        }


        return result;
    }

    [HarmonyPostfix]
    private static void Postfix(SpriteAtlas __instance, string name, ref Sprite __result)
    {
        var unref__result = __result;
        ModHelper.PerformHook(mod => mod.PostSpriteLoaded(__instance, name, ref unref__result));
        __result = unref__result;
    }
}