using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    public static class SpriteExt
    {
        /// <summary>
        /// (Cross-Game compatible) Set this Sprite's texture
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="newTexture"></param>
        public static void SetTexture(this Sprite sprite, Texture2D newTexture)
        {
            var bytes = ImageConversion.EncodeToPNG(newTexture);
            ImageConversion.LoadImage(sprite.texture, bytes);
        }
    }
}
