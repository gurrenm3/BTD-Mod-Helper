using System;
using BTD_Mod_Helper.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// ModSetting class for a boolean value
    /// </summary>
    public class ModSettingBool : ModSetting<bool>
    {
        /// <inheritdoc />
        public ModSettingBool(bool value) : base(value)
        {
        }

        /// <summary>
        /// Should the UI for this be a button? If not it will be a Checkbox
        /// </summary>
        public bool IsButton { get; set; }

        /// <summary>
        /// If this is a button, then what action should be performed if you click it.
        /// </summary>
        public Action<Button> OnButtonPressed { get; set; }

        /// <summary>
        /// If this is a Button, then the text on the Button will be changed from "" to this
        /// </summary>
        public string ButtonText { get; set; }

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
        public override ModOption ConstructModOption(GameObject parent)
        {
            if (IsButton)
            {
                var modOption = new ButtonOption(parent, this);
                if (OnButtonPressed != null)
                {
                    modOption.Button.AddOnClick(() => OnButtonPressed(modOption.Button));
                }

                return modOption;
            }

            return new CheckboxOption(parent, this);
        }
    }
}