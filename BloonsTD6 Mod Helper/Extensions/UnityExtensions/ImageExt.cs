using System;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Utils;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Images
/// </summary>
public static partial class ImageExt
{
    /// <summary>
    /// Set the sprite for this image 
    /// </summary>
    /// <param name="image"></param>
    /// <param name="spriteReference">Sprite to change image to</param>
    public static void SetSprite(this Image image, SpriteReference spriteReference)
    {
        ResourceLoader.LoadSpriteFromSpriteReferenceAsync(spriteReference, image);
        image.enabled = true;
    }
    
    /// <summary>
    /// Set the sprite for this image 
    /// </summary>
    /// <param name="image"></param>
    /// <param name="guid">Sprite to change image to</param>
    public static void SetSprite(this Image image, string guid)
    {
        ResourceLoader.LoadSpriteFromSpriteReferenceAsync(ModContent.CreateSpriteReference(guid), image);
        image.enabled = true;
    }
    
    /// <summary>
    /// Loads a sprite reference to this image
    /// </summary>
    /// <param name="image"></param>
    /// <param name="spriteReference"></param>
    public static void LoadSprite(this Image image, SpriteReference spriteReference)
    {
        ResourceLoader.LoadSpriteFromSpriteReferenceAsync(spriteReference, image);
    }

    /// <summary>
    /// Sets the sprite of this image to one with the given name in the named sprite atlas
    /// </summary>
    [Obsolete("Use SetSprite with a VanillaSpriteReference instead")]
    public static void SetSpriteFromAtlas(this Image image, string atlas, string spriteName)
    {
    }
}