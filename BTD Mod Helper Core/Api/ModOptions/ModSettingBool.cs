using System;
using Assets.Scripts.Unity.Menu;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// ModSetting class for a boolean value
    /// </summary>
    public class ModSettingBool : ModSetting<bool>
    {
        /// <summary>
        /// Action to modify the ModHelperCheckbox after it's created
        /// </summary>
        public Action<ModHelperCheckbox> modifyCheckbox;

        /// <summary>
        /// Whether this should display as an Enabled/Disabled button instead of a checkbox
        /// </summary>
        public bool button;

        /// <summary>
        /// The text that the button should have when it's enabled, if this is a button
        /// </summary>
        public string enabledText = "Enabled";

        /// <summary>
        /// The text that the button should have when it's disabled, if this is a button
        /// </summary>
        public string disabledText = "Disabled";

        /// <summary>
        /// The sprite to use for the button when it's enabled, GreenBtnLong by default
        /// </summary>
        public SpriteReference enabledButton = VanillaSprites.GreenBtnLong;

        /// <summary>
        /// The sprite to use for the button when it's disabled, RedBtnLong by default
        /// </summary>
        public SpriteReference disabledButton = VanillaSprites.RedBtnLong;

        /// <summary>
        /// Action to modify the ModHelperCheckbox after it's created
        /// </summary>
        public Action<ModHelperButton> modifyButton;


        /// <summary>
        /// Old way to do a button before ModSettingButton was a thing
        /// </summary>
        [Obsolete]
        public bool IsButton { get; set; }

        /// <inheritdoc />
        public ModSettingBool(bool value) : base(value)
        {
        }

        /// <summary>
        /// Create a new ModSetting bool with the given value as default
        /// </summary>
        public static implicit operator ModSettingBool(bool value)
        {
            return new ModSettingBool(value);
        }

        /// <summary>
        /// Gets the current value out of a ModSettingBool
        /// </summary>
        /// <param name="modSettingBool"></param>
        /// <returns></returns>
        public static implicit operator bool(ModSettingBool modSettingBool)
        {
            return modSettingBool.value;
        }

        /// <inheritdoc />
        public override ModHelperOption CreateComponent()
        {
            var option = CreateBaseOption();

            if (button)
            {
                var buttonComponent = option.BottomRow.AddButton(
                    new Info("Button", width: 562, height: 200), value ? enabledButton : disabledButton, null
                );
                var text = buttonComponent.AddText(
                    new Info("Text", anchorMin: Vector2.zero, anchorMax: Vector2.one),
                    value ? enabledText : disabledText, 80f
                );

                var action = new Action<bool>(newValue =>
                {
                    SetValue(newValue);
                    buttonComponent.Image.SetSprite(value ? enabledButton : disabledButton);
                    text.SetText(value ? enabledText : disabledText);
                    onValueChanged?.Invoke(newValue);
                });
                buttonComponent.Button.onClick.AddListener(new Action(() =>
                {
                    action(!value);
                    MenuManager.instance.buttonClickSound.Play("ClickSounds");
                }));
                
                option.SetResetAction(new Action(() => action(defaultValue)));
                modifyButton?.Invoke(buttonComponent);
            }
            else
            {
                var checkbox = option.BottomRow.AddCheckbox(
                    new Info("Checkbox", size: 200), value, VanillaSprites.BlueInsertPanelRound,
                    new Action<bool>(enabled =>
                    {
                        SetValue(enabled);
                        onValueChanged?.Invoke(enabled);
                        MenuManager.instance.buttonClick2Sound.Play("ClickSounds");
                    })
                );
                option.SetResetAction(new Action(() => checkbox.SetChecked(defaultValue)));
                modifyCheckbox?.Invoke(checkbox);
            }

            return option;
        }
    }
}