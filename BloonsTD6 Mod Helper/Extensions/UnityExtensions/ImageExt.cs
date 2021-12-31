using Assets.Scripts.Utils;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
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
        }
    }
}
