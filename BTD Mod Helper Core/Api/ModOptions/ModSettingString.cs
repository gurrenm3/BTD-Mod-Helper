using System;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.ModOptions
{
    
    /// <summary>
    /// 
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
        
        public string validation;

        /// <inheritdoc />
        public ModSettingString(string value) : base(value)
        {
        }

        public static implicit operator ModSettingString(string value)
        {
            return new ModSettingString(value);
        }

        public static implicit operator string(ModSettingString modSettingString)
        {
            return modSettingString.value;
        }

        /// <inheritdoc />
        public override ModOption ConstructModOption(GameObject parent)
        {
            return new InputOption(parent, this);
        }

        public InputField.CharacterValidation GetValidation()
        {
            return Enum.TryParse(validation, out InputField.CharacterValidation val) ? val : InputField.CharacterValidation.None;
        }
    }
}