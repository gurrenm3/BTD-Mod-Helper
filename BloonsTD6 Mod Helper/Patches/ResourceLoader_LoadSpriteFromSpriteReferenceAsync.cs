using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api;
using Harmony;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(ResourceLoader), nameof(ResourceLoader.LoadSpriteFromSpriteReferenceAsync))]
    internal class ResourceLoader_LoadSpriteFromSpriteReferenceAsync
    {
        [HarmonyPostfix]
        internal static void Postfix(ref SpriteReference reference, ref Image image)
        {
            if (reference is null || image is null || !SpriteRegister.register.Any())
                return;

            string guid = reference.GUID;
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
