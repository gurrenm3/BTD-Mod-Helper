using System;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using Action = Il2CppSystem.Action;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent for a background panel
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperButton : ModHelperComponent
    {
        /// <summary>
        /// Button animation for shrinking a bit while pressing
        /// </summary>
        public static RuntimeAnimatorController globalButtonAnimation;
        
        /// <summary>
        /// Button animation for rising up a bit
        /// </summary>
        public static RuntimeAnimatorController globalTabAnimation;
        
        /// <summary>
        /// The displayed image of the button
        /// </summary>
        public Image Image { get; private set; }
        
        /// <summary>
        /// The actual button component
        /// </summary>
        public Button Button { get; private set; }

        /// <inheritdoc />
        public ModHelperButton(IntPtr ptr) : base(ptr)
        {
        }

        
        /// <summary>
        /// Creates a new ModHelperButton
        /// </summary>
        /// <param name="rect">The position and size</param>
        /// <param name="sprite">The button's visuals</param>
        /// <param name="onClick">What should happen when the button is clicked</param>
        /// <param name="objectName">The Unity name of the object</param>
        /// <returns></returns>
        public static ModHelperButton Create(Rect rect, SpriteReference sprite, Action onClick,
            string objectName = "ModHelperButton")
        {
            var modHelperButton = ModHelperComponent.Create<ModHelperButton>(rect, objectName);
            
            var image = modHelperButton.Image = modHelperButton.AddComponent<Image>();
            image.type = Image.Type.Sliced;
            image.SetSprite(sprite);
            
            var button = modHelperButton.Button = modHelperButton.AddComponent<Button>();
            if (onClick != null)
            {
                button.onClick.AddListener(onClick.Invoke);
            }

            button.transition = Selectable.Transition.Animation;

            var animator = modHelperButton.AddComponent<Animator>();
            animator.runtimeAnimatorController = globalButtonAnimation;

            return modHelperButton;
        }
    }
}