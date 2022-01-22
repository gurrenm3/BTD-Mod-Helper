using System;
using TMPro;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// ModSetting for int values
    /// </summary>
    public class ModSettingInt : ModSettingNumber<long> //it's a long because of JSON parsing
    {
        /// <inheritdoc />
        public ModSettingInt(int value) : base(value)
        {
        }

        /// <summary>
        /// Constructs a new ModSetting with the given value as default
        /// </summary>
        public static implicit operator ModSettingInt(int value)
        {
            return new ModSettingInt(value);
        }

        /// <summary>
        /// Gets the current value out of a ModSetting
        /// </summary>
        public static implicit operator int(ModSettingInt modSettingInt)
        {
            return (int) modSettingInt.value;
        }

        /// <inheritdoc />
        protected override string ToString(long input) => input.ToString();

        /// <inheritdoc />
        protected override long FromString(string s) => int.TryParse(s, out var result) ? result : 0;

        /// <inheritdoc />
        protected override TMP_InputField.CharacterValidation Validation => TMP_InputField.CharacterValidation.Integer;

        /// <inheritdoc />
        protected override float ToFloat(long input) => input;
        
        /// <inheritdoc />
        protected override long FromFloat(float f) => (long) Math.Round(f);
    }
}