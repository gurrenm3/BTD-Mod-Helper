﻿using System;
using System.IO;
using System.Linq;
using UnityEngine;
using Graphics = UnityEngine.Graphics;

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
        /// <param name="texture"></param>
        /// <param name="filePath">File path to save texture to</param>
        public static void SaveToPNG(this Texture2D texture, string filePath)
        {
            byte[] bytes = ImageConversion.EncodeToPNG(texture).ToArray();
            File.Create(filePath).Write(bytes, 0, bytes.Length);
        }
        
        public static void TrySaveToPNG(this Texture texture, string filePath)
        {
            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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