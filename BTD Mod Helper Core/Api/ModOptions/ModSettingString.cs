using System;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.ModOptions
{
    
    /// <summary>
    /// ModSetting for a string value
    /// </summary>
    public class ModSettingString : ModSetting<string>
    {
        /// <summary>
        /// Allow all characters
        /// </summary>
        public static readonly string None = InputField.CharacterValidation.None.ToString();
        /// <summary>
        /// Allow only alphanumeric characters
        /// </summary>
        public static readonly string Alphanumeric = InputField.CharacterValidation.Alphanumeric.ToString();
        /// <summary>
        /// Allow only valid decimals
        /// </summary>
        public static readonly string Decimal = InputField.CharacterValidation.Decimal.ToString();
        /// <summary>
        /// Allow only valid integers
        /// </summary>
        public static readonly string Integer = InputField.CharacterValidation.Integer.ToString();
        
        /// <summary>
        /// InputField validation, use one of the ModSettingString.[thing] constants 
        /// </summary>
        public string validation;

        /// <inheritdoc />
        public ModSettingString(string value) : base(value)
        {
        }

        /// <summary>
        /// Constructs a new ModSetting with the given value as default
        /// </summary>
        public static implicit operator ModSettingString(string value)
        {
            return new ModSettingString(value);
        }

        /// <summary>
        /// Gets the current value out of a ModSetting
        /// </summary>
        public static implicit operator string(ModSettingString modSettingString)
        {
            return modSettingString.value;
        }

        /// <inheritdoc />
        public override ModOption ConstructModOption(GameObject parent)
        {
            return new InputOption(parent, this);
        }

        /// <summary>
        /// Gets the current Validation option
        /// </summary>
        public InputField.CharacterValidation GetValidation()
        {
            return Enum.TryParse(validation, out InputField.CharacterValidation val) ? val : InputField.CharacterValidation.None;
        }
    }
}