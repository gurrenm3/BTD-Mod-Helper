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
        public static SpriteReference Blue => VanillaSprites.MainBGPanelBlue;
        public static SpriteReference Grey => VanillaSprites.MainBGPanelGrey;
        public static SpriteReference Gold => VanillaSprites.MainBGPanelYellow;
        public static SpriteReference Hematite => VanillaSprites.MainBgPanelHematite;
        public static SpriteReference BlueNotches => VanillaSprites.MainBGPanelBlueNotches;
        public static SpriteReference BlueInset => VanillaSprites.BlueInsertPanel;
        public static SpriteReference BrownInset => VanillaSprites.BrownInsertPanel;
        public static SpriteReference GoldInset => VanillaSprites.GoldInsertRibbon;
        public static SpriteReference WhiteInset => VanillaSprites.InsertPanelWhiteRound;
        public static SpriteReference BlueInsetRound => VanillaSprites.BlueInsertPanelRound;

        /// <summary>
        /// The background image
        /// </summary>
        public Image Background { get; private set; }

        /// <inheritdoc />
        public ModHelperPanel(IntPtr ptr) : base(ptr)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect">The position and size</param>
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

            modHelperPanel.Background = modHelperPanel.AddComponent<Image>();
            modHelperPanel.Background.type = Image.Type.Sliced;
            modHelperPanel.Background.SetSprite(backgroundSprite ?? Blue);

            return modHelperPanel;
        }
    }
}