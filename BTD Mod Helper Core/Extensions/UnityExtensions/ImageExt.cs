using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class ImageExt
    {
        /// <summary>
        /// (Cross-Game compatible) Saves an image as a PNG files
        /// Coded in a robust manner that should work for all images, including those with multiple sprites on them being used
        /// </summary>
        /// <param name="filePath">Absolute file path on the machine to save the file to</param>
        public static void SaveToPNG(this Image image, string filePath)
        {
            Texture texture;
            if (image.sprite == null || image.sprite.texture == null)
            {
                texture = image.material.mainTexture;
            }
            else
            {
                texture = image.sprite.texture;
            }
            
            texture.TrySaveToPNG(filePath);
        }

        /// <summary>
        /// (Cross-Game compatible) Set the sprite for this image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sprite">Sprite to change image to</param>
        public static void SetSprite(this Image image, Sprite sprite)
        {
            image.canvasRenderer.SetTexture(sprite.texture);
            image.sprite = sprite;
        }
    }
}