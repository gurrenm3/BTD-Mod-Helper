using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class ModSettingInt : ModSetting<long> //it's a long because of JSON parsing
    {
        public long? minValue;
        public long? maxValue;
        public bool isSlider;
        
        public ModSettingInt(int value) : base(value)
        {
        }

        public static implicit operator ModSettingInt(int value)
        {
            return new ModSettingInt(value);
        }

        public static implicit operator int(ModSettingInt modSettingInt)
        {
            return (int) modSettingInt.value;
        }

        public override ModOption ConstructModOption(GameObject parent)
        {
            return isSlider ? (SharedOption)new SliderOption(parent, this) : new InputOption(parent, this);
        }
    }
}