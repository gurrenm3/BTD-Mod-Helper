using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// ModSetting for int values
    /// </summary>
    public class ModSettingInt : ModSetting<long> //it's a long because of JSON parsing
    {
        /// <summary>
        /// The lowest allowed value, or null for unbounded
        /// </summary>
        public long? minValue;
        
        /// <summary>
        /// The largest allowed value, or null for unbounded
        /// </summary>
        public long? maxValue;
        
        /// <summary>
        /// Whether this displays as a slider
        /// </summary>
        public bool isSlider;

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
        public override ModOption ConstructModOption(GameObject parent)
        {
            return isSlider ? (ModOption)new SliderOption(parent, this) : new InputOption(parent, this);
        }
    }
}