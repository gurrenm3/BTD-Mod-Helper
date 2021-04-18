using UnityEngine;

namespace BTD_Mod_Helper_Core.Extensions.UnityExtensions
{
    public static class SpriteExt
    {
        public static void SetTexture(this Sprite sprite, Texture2D newTexture)
        {
            var bytes = ImageConversion.EncodeToPNG(newTexture);
            ImageConversion.LoadImage(sprite.texture, bytes);
        }
    }
}
