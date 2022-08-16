using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions;

public static partial class ImageExt {
    /// <summary>
    /// Saves an image as a PNG files
    /// Coded in a robust manner that should work for all images, including those with multiple sprites on them being used
    /// </summary>
    /// <param name="image"></param>
    /// <param name="filePath">Absolute file path on the machine to save the file to</param>
    public static void SaveToPNG(this Image image, string filePath) {
        var texture = image.sprite == null || image.sprite.texture == null ? image.material.mainTexture : image.sprite.texture;
        texture.TrySaveToPNG(filePath);
    }

    /// <summary>
    /// Set the sprite for this image
    /// </summary>
    /// <param name="image"></param>
    /// <param name="sprite">Sprite to change image to</param>
    public static void SetSprite(this Image image, Sprite sprite) {
        image.canvasRenderer.SetTexture(sprite.texture);
        image.sprite = sprite;
    }
}