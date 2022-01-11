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
        /// <param name="rect">The position and size</param>
        /// <param name="sprite">The sprite to display</param>
        /// <param name="objectName">The Unity name of the object</param>
        /// <returns></returns>
        public static ModHelperImage Create(Rect rect, SpriteReference sprite, string objectName = "ModHelperImage")
        {
            var modHelperImage = ModHelperComponent.Create<ModHelperImage>(rect, objectName);

            var image = modHelperImage.Image = modHelperImage.AddComponent<Image>();
            image.SetSprite(sprite);

            return modHelperImage;
        }
    }
}