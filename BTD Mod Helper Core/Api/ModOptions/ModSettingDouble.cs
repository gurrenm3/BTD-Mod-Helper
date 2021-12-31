using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// ModSetting for a decimal value
    /// </summary>
    public class ModSettingDouble : ModSetting<double>
    {
        /// <summary>
        /// The lowest allowed value, or null for unbounded
        /// </summary>
        public double? minValue;

        /// <summary>
        /// The largest allowed value, or null for unbounded
        /// </summary>
        public double? maxValue;

        /// <summary>
        /// Whether this displays as a slider
        /// </summary>
        public bool isSlider;

        /// <inheritdoc />
        public ModSettingDouble(double value) : base(value)
        {
        }

        /// <summary>
        /// Constructs a new ModSetting with the given value as default
        /// </summary>
        public static implicit operator ModSettingDouble(double value)
        {
            return new ModSettingDouble(value);
        }

        /// <summary>
        /// Gets the current value out of a ModSetting
        /// </summary>
        public static implicit operator double(ModSettingDouble modSettingDouble)
        {
            return modSettingDouble.value;
        }

        /// <inheritdoc />
        public override ModOption ConstructModOption(GameObject parent)
        {
            return isSlider ? (ModOption) new SliderOption(parent, this) : new InputOption(parent, this);
        }
    }
}