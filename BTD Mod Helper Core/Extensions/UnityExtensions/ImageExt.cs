using System.IO;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
    public static class ImageExt
    {
        /// <summary>
        /// Saves an image as a PNG files
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
            
            RenderTexture tmp = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
            Graphics.Blit(texture, tmp);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = tmp;
            Texture2D myTexture2D = new Texture2D(texture.width, texture.height);
            myTexture2D.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
            myTexture2D.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(tmp);
            var bytes = ImageConversion.EncodeToPNG(myTexture2D);
            File.WriteAllBytes(filePath, bytes);
        }
    }
}