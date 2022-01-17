using System;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent for a 
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperImage : ModHelperComponent
    {
        /// <summary>
        /// The Image being displayed
        /// </summary>
        public Image Image { get; private set; }

        /// <inheritdoc />
        public ModHelperImage(IntPtr ptr) : base(ptr)
        {
        }


        /// <summary>
        /// Creates a new ModHelperImage
        /// </summary>
        /// <param name="info">The name/position/size info</param>
        /// <param name="sprite">The sprite to display</param>
        /// <returns>The created ModHelperImage</returns>
        public static ModHelperImage Create(Info info, SpriteReference sprite)
        {
            var modHelperImage = ModHelperComponent.Create<ModHelperImage>(info);

            var image = modHelperImage.Image = modHelperImage.AddComponent<Image>();
            if (sprite != null)
            {
                image.SetSprite(sprite);
            }

            return modHelperImage;
        }
        
        /// <inheritdoc cref="Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference)"/>
        public static ModHelperImage Create(Info info, Sprite sprite)
        {
            var modHelperImage = ModHelperComponent.Create<ModHelperImage>(info);

            var image = modHelperImage.Image = modHelperImage.AddComponent<Image>();
            if (sprite != null)
            {
                image.SetSprite(sprite);
            }

            return modHelperImage;
        }
    }
}