using System;
using System.IO;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Sprites
/// </summary>
public static class SpriteExt
{
    /// <summary>
    /// Set this Sprite's texture
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="newTexture"></param>
    public static void SetTexture(this Sprite sprite, Texture2D newTexture)
    {
        sprite.texture.LoadImage(newTexture.EncodeToPNG());
    }

    /// <summary>
    /// Creates a readable copy of this sprites texture
    /// </summary>
    /// <param name="sprite"></param>
    /// <returns></returns>
    public static Texture2D GetReadableTexture(this Sprite sprite)
    {
        RenderTexture tmp = null;
        RenderTexture previous = null;
        try
        {
            var texture = sprite.texture;
            var spriteRect = sprite.rect; // The full logical rect (with empty space)
            var tightRect = sprite.textureRect; // The actual pixels in the texture
            var offset = sprite.textureRectOffset; // The distance from bottom-left of rect to tightRect

            tmp = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.Default,
                RenderTextureReadWrite.Linear);
            Graphics.Blit(texture, tmp);
            previous = RenderTexture.active;
            RenderTexture.active = tmp;

            var myTexture2D = new Texture2D((int) spriteRect.width, (int) spriteRect.height, TextureFormat.RGBA32, false);
            myTexture2D.SetPixels(new Color[myTexture2D.width * myTexture2D.height]);
            myTexture2D.ReadPixels(new Rect(tightRect.x, tightRect.y, tightRect.width, tightRect.height), (int) offset.x, (int) offset.y);

            myTexture2D.Apply();
            return myTexture2D;
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
            return null;
        }
        finally
        {
            if (previous != null) RenderTexture.active = previous;
            if (tmp != null) RenderTexture.ReleaseTemporary(tmp);
        }
    }

    /// <summary>
    /// Attempts to save a Sprite to a PNG at the given filePath, even if it isn't marked as readable
    /// </summary>
    public static bool TrySaveToPNG(this Sprite sprite, string filePath)
    {
        try
        {
            var myTexture2D = sprite.GetReadableTexture();

            if (myTexture2D == null) return false;

            var bytes = myTexture2D.EncodeToPNG();
            File.WriteAllBytes(filePath, bytes);
            return true;
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
            return false;
        }
    }

}