using System;
using Assets.Scripts.Unity.UI_New.Popups;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using MelonLoader;
using UnityEngine;
using UnityEngine.Events;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent that's the base panel for the visual representation of a ModSetting
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperOption : ModHelperComponent
    {
        private const int PanelWidth = 2500;
        private const int PanelHeight = 500;
        private const int TextWidth = 2000;
        private const int TextHeight = 100;
        private const int IconSize = 250;
        private const int ResetSize = 200;

        /// <summary>
        /// The displayed name for this setting
        /// </summary>
        public ModHelperText Name { get; private set; }
        
        /// <summary>
        /// The button that resets this setting
        /// </summary>
        public ModHelperButton ResetButton { get; private set; }
        
        /// <summary>
        /// The Icon for this setting. Will be null if no Icon provided
        /// </summary>
        public ModHelperImage Icon { get; private set; }
        
        /// <summary>
        /// The button that popups the description when pressed
        /// </summary>
        public ModHelperButton InfoButton { get; private set; }

        /// <inheritdoc />
        public ModHelperOption(IntPtr ptr) : base(ptr)
        {
        }

        /// <summary>
        /// Adds an action to the reset button
        /// </summary>
        public void SetResetAction(UnityAction action)
        {
            ResetButton.Button.onClick.AddListener(action);
        }
        
        /// <summary>
        /// Creates a new MoodHelperOption
        /// </summary>
        /// <param name="displayName">The displayed name of the mod setting</param>
        /// <param name="description">The description of the mod setting, if any</param>
        /// <param name="icon">The icon of the mod setting, if any</param>
        /// <returns>The created ModHelperOptiom</returns>
        public static ModHelperOption Create(string displayName, string description = null, SpriteReference icon = null)
        {
            var modHelperOption = ModHelperComponent.Create<ModHelperOption>(
                new Info(displayName, width: PanelWidth, height: PanelHeight)
            );

            modHelperOption.Name = modHelperOption.AddText(
                new Info("Name", width: TextWidth, height: TextHeight, anchor: new Vector2(0.5f, 1)),
                displayName, 80f
            );

            if (icon != null)
            {
                modHelperOption.Icon = modHelperOption.AddImage(
                    new Info("Icon", size: IconSize, anchor: new Vector2(0, 1)), icon
                );
            }

            modHelperOption.ResetButton = modHelperOption.AddButton(
                new Info("Reset", width: ResetSize, height: ResetSize, anchor: new Vector2(1, 1)),
                VanillaSprites.RestartBtn, null
            );


            if (description != null)
            {
                modHelperOption.InfoButton = modHelperOption.AddButton(
                    new Info("Info", ResetSize * -2f, 0, ResetSize, ResetSize, anchor: new Vector2(1, 1)),
                    VanillaSprites.InfoBtn, new Action(() => { PopupScreen.instance.ShowOkPopup(description); })
                );
            }

            return modHelperOption;
        }
    }
}