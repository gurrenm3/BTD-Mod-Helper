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
    /// Attempts to save a Sprite to a PNG at the given filePath, even if it isn't marked as readable
    /// </summary>
    public static void TrySaveToPNG(this Sprite sprite, string filePath)
    {
        try
        {
            var texture = sprite.texture;
            var spriteRect = sprite.textureRect;
            var tmp = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.Default,
                RenderTextureReadWrite.Linear);
            Graphics.Blit(texture, tmp);
            var previous = RenderTexture.active;
            RenderTexture.active = tmp;
            var myTexture2D = new Texture2D((int) spriteRect.width, (int) spriteRect.height);
            myTexture2D.ReadPixels(new Rect(spriteRect.x, spriteRect.y, spriteRect.width, spriteRect.height), 0, 0);
            myTexture2D.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(tmp);
            var bytes = myTexture2D.EncodeToPNG();
            File.WriteAllBytes(filePath, bytes);
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }
    }

}