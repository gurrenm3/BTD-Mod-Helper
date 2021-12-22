using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Patches.Resources
{
    [HarmonyPatch(typeof(ResourceLoader), nameof(ResourceLoader.LoadSpriteFromSpriteReferenceAsync))]
    internal class ResourceLoader_LoadSpriteFromSpriteReferenceAsync
    {
        [HarmonyPostfix]
        internal static void Postfix(ref SpriteReference reference, ref Image image)
        {
            if (reference is null || image is null || reference.GUID is null)
                return;

            var guid = reference.GUID;

            if (ResourceHandler.GetSprite(guid) is Sprite spr)
            {
                spr.texture.mipMapBias = -1;
                image.SetSprite(spr);
            }
        }
    }
}
