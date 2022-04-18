#if BloonsTD6
using System;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// ModSetting for adding a button in the settings that performs a given action, with the setting just tracking
    /// the number of times that the button has been pressed.
    /// </summary>
    public class ModSettingButton : ModSetting<long>
    {
        /// <summary>
        /// The action that this button performs
        /// </summary>
        public Action action;

        /// <summary>
        /// The text that will appear on the button, "Dew It" by default
        /// </summary>
        public string buttonText;

        /// <summary>
        /// The sprite to use for the button, BlueBtnLong by default
        /// </summary>
        public SpriteReference buttonSprite = VanillaSprites.BlueBtnLong;

        /// <summary>
        /// Action to modify the ModHelperButton after it's created
        /// </summary>
        public Action<ModHelperButton> modifyButton;

        /// <inheritdoc />
        public ModSettingButton() : base(0)
        {
        }

        /// <inheritdoc />
        public ModSettingButton(Action action) : base(0)
        {
            this.action = action;
        }

        /// <inheritdoc />
        internal override ModHelperOption CreateComponent()
        {
            var option = CreateBaseOption();

            var button = option.BottomRow.AddButton(
                new Info("Button", width: 562, height: 200), buttonSprite, new Action(() =>
                {
                    SetValue(value + 1);
                    action?.Invoke();
                })
            );

            button.AddText(
                new Info("Text", anchorMin: Vector2.zero, anchorMax: Vector2.one), buttonText ?? "Dew It", 80f
            );

            option.ResetButton.gameObject.active = false;

            modifyButton?.Invoke(button);
            return option;
        }
    }
}
#endif