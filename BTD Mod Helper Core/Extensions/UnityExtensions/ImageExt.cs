using System.IO;
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
            RenderTexture tmp = RenderTexture.GetTemporary(image.sprite.texture.width, image.sprite.texture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
            Graphics.Blit(image.sprite.texture, tmp);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = tmp;
            Texture2D myTexture2D = new Texture2D(image.sprite.texture.width, image.sprite.texture.height);
            myTexture2D.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
            myTexture2D.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(tmp);
            var bytes = ImageConversion.EncodeToPNG(myTexture2D);
            File.WriteAllBytes(filePath, bytes);
        }
    }
}