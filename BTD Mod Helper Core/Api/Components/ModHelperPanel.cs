using System;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent for a background panel
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperPanel : ModHelperComponent
    {
        /// <summary>
        /// The background image
        /// </summary>
        public Image Background { get; private set; }

        /// <inheritdoc />
        public ModHelperPanel(IntPtr ptr) : base(ptr)
        {
        }

        /// <summary>
        /// Creates a new ModHelperPanel
        /// </summary>
        /// <param name="rect">The position (offset of child center from parent center) and size</param>
        /// <param name="objectName">The Unity name of the object</param>
        /// <param name="backgroundSprite">The panel's background sprite</param>
        /// <returns>The created ModHelperPanel</returns>
        public static ModHelperPanel Create(Rect rect, string objectName = "ModHelperPanel",
            SpriteReference backgroundSprite = null)
        {
            return Create<ModHelperPanel>(rect, objectName, backgroundSprite);
        }

        internal static T Create<T>(Rect rect, string objectName = "ModHelperPanel",
            SpriteReference backgroundSprite = null) where T : ModHelperPanel
        {
            var modHelperPanel = ModHelperComponent.Create<T>(rect, objectName);

            if (backgroundSprite != null)
            {
                modHelperPanel.Background = modHelperPanel.AddComponent<Image>();
                modHelperPanel.Background.type = Image.Type.Sliced;
                modHelperPanel.Background.SetSprite(backgroundSprite);
            }

            return modHelperPanel;
        }
    }
}