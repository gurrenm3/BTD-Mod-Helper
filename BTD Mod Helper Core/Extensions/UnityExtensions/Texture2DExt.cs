using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    public static class Texture2DExt
    {
        /// <summary>
        /// (Cross-Game compatible) Create Texture2D from a unity Color. Texture will only be this color
        /// </summary>
        /// <param name="color">Color to make new texture</param>
        public static Texture2D CreateFromColor(this Texture2D texture2D, UnityEngine.Color color)
        {
            texture2D = new Texture2D(1, 1);
            texture2D.SetPixel(0, 0, color);
            texture2D.Apply();
            return texture2D;
        }

        /// <summary>
        /// (Cross-Game compatible) Save Texture2D as a png to file.
        /// </summary>
        /// <param name="filePath">File path to save texture to</param>
        public static void SaveToPNG(this Texture2D texture, string filePath)
        {
            byte[] bytes = ImageConversion.EncodeToPNG(texture).ToArray();
            File.Create(filePath).Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// (Cross-Game compatible) Create Texture2D from a file on local PC
        /// </summary>
        /// <param name="filePath">path of file on PC</param>
        public static Texture2D LoadFromFile(this Texture2D texture, string filePath)
        {
            ImageConversion.LoadImage(texture, File.ReadAllBytes(filePath));
            return texture;
        }

        /// <summary>
        /// (Cross-Game compatible) Create Texture2D from a visual studio Project Resource. Requires adding image as a resource to project
        /// </summary>
        /// <param name="manager">The resource manager for your current project</param>
        /// <param name="resourceName">The name of your image, as it is in the resource manager</param>
        public static Texture2D CreateFromProjResource(this Texture2D texture2D, ResourceManager manager, string resourceName)
        {
            object resource = manager.GetObject(resourceName);
            object resourceBytes = new ImageConverter().ConvertTo(resource, typeof(byte[]));
            ImageConversion.LoadImage(texture2D, (byte[])resourceBytes);
            return texture2D;
        }

        /// <summary>
        /// (Cross-Game compatible) Create Texture2D from an existing bitmap
        /// </summary>
        /// <param name="bitmapImage">bitmap to create Texture2D from</param>
        public static Texture2D CreateFromBitmap(this Texture2D texture2D, Bitmap bitmapImage)
        {
            object resourceBytes = new ImageConverter().ConvertTo(bitmapImage, typeof(byte[]));
            ImageConversion.LoadImage(texture2D, (byte[])resourceBytes);
            return texture2D;
        }

        /// <summary>
        /// (Cross-Game compatible) Create a Sprite from this Texture2D
        /// </summary>
        /// <param name="pixelsPerUnit">Number of pixels you want in each unit. More pixels means bigger sprite in game</param>
        public static Sprite CreateSpriteFromTexture(this Texture2D texture2D, float pixelsPerUnit)
        {
            return texture2D.CreateSpriteFromTexture(pixelsPerUnit, new Vector2(0.5f, 0.5f));
        }

        /// <summary>
        /// (Cross-Game compatible) Create a Sprite from this Texture2D
        /// </summary>
        /// <param name="pixelsPerUnit">Number of pixels you want in each unit. More pixels means bigger sprite in game</param>
        public static Sprite CreateSpriteFromTexture(this Texture2D texture2D, float pixelsPerUnit, Vector2 pivot)
        {
            return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), pivot, pixelsPerUnit);
        }
    }
}