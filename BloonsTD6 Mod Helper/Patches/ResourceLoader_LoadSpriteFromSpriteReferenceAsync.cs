using System;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using MelonLoader;
using NinjaKiwi.Players.Files;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(ResourceLoader), nameof(ResourceLoader.LoadSpriteFromSpriteReferenceAsync))]
    internal class ResourceLoader_LoadSpriteFromSpriteReferenceAsync
    {
        [HarmonyPostfix]
        internal static void Postfix(ref SpriteReference reference, ref Image image)
        {
            if (reference is null || image is null)
                return;

            var guid = reference.GUID;

            if (ResourceHandler.GetSprite(guid) is Sprite spr)
            {
                spr.texture.mipMapBias = -1;
                image.SetSprite(spr);
                return;
            }
            
            KeyValuePair<string, Sprite>? entryAtRef = SpriteRegister.register.Where(e => e.Key == guid).Select(e => (KeyValuePair<string, Sprite>?)e).FirstOrDefault();
            if (entryAtRef.HasValue)
            {
                Sprite sprite = entryAtRef.Value.Value;
                if (sprite == null)
                {
                    Texture2D pngTexture = SpriteRegister.Instance.TextureFromPNG(guid);
                    sprite = Sprite.Create(pngTexture, new Rect(0.0f, 0.0f, pngTexture.width, pngTexture.height), default);
                }
                image.canvasRenderer.SetTexture(sprite.texture);
                image.sprite = sprite;
            }
        }
    }
}
