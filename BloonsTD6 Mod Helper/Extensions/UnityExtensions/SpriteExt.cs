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
        var bytes = ImageConversion.EncodeToPNG(newTexture);
        ImageConversion.LoadImage(sprite.texture, bytes);
    }
}