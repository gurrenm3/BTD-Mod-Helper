using System;
using System.IO;
using System.Linq;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Texture2Ds
/// </summary>
public static class Texture2DExt
{
    /// <summary>
    /// Create Texture2D from a unity Color. Texture will only be this color
    /// </summary>
    /// <param name="texture2D"></param>
    /// <param name="color">Color to make new texture</param>
    public static Texture2D CreateFromColor(this Texture2D texture2D, Color color)
    {
        var texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        return texture;
    }

    /// <summary>
    /// Save Texture2D as a png to file.
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="filePath">File path to save texture to</param>
    public static void SaveToPNG(this Texture2D texture, string filePath)
    {
        var bytes = ImageConversion.EncodeToPNG(texture).ToArray();
        File.Create(filePath).Write(bytes, 0, bytes.Length);
    }
        
    /// <summary>
    /// Attempts to save a Texture to a png at the given filePath, even if it isn't marked as readable
    /// </summary>
    public static void TrySaveToPNG(this Texture texture, string filePath)
    {
        try
        {
            var tmp = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
            Graphics.Blit(texture, tmp);
            var previous = RenderTexture.active;
            RenderTexture.active = tmp;
            var myTexture2D = new Texture2D(texture.width, texture.height);
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
    /// Create Texture2D from a file on local PC
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="filePath">path of file on PC</param>
    public static Texture2D LoadFromFile(this Texture2D texture, string filePath)
    {
        ImageConversion.LoadImage(texture, File.ReadAllBytes(filePath));
        return texture;
    }

    /// <summary>
    /// Create a Sprite from this Texture2D
    /// </summary>
    /// <param name="texture2D"></param>
    /// <param name="pixelsPerUnit">Number of pixels you want in each unit. More pixels means bigger sprite in game</param>
    public static Sprite CreateSpriteFromTexture(this Texture2D texture2D, float pixelsPerUnit)
    {
        return texture2D.CreateSpriteFromTexture(pixelsPerUnit, new Vector2(0.5f, 0.5f));
    }

    /// <summary>
    /// Create a Sprite from this Texture2D
    /// </summary>
    /// <param name="texture2D"></param>
    /// <param name="pixelsPerUnit">Number of pixels you want in each unit. More pixels means bigger sprite in game</param>
    /// <param name="pivot"></param>
    public static Sprite CreateSpriteFromTexture(this Texture2D texture2D, float pixelsPerUnit, Vector2 pivot)
    {
        return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), pivot, pixelsPerUnit);
    }
}