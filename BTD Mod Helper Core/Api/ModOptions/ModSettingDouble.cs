using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class ModSettingDouble : ModSetting<double>
    {
        public double? minValue;
        public double? maxValue;
        public bool isSlider;
        
        public ModSettingDouble(double value) : base(value)
        {
        }

        public static implicit operator ModSettingDouble(double value)
        {
            return new ModSettingDouble(value);
        }

        public static implicit operator double(ModSettingDouble modSettingDouble)
        {
            return modSettingDouble.value;
        }

        public override ModOption ConstructModOption(GameObject parent)
        {
            return isSlider ? (SharedOption) new SliderOption(parent, this) : new InputOption(parent, this);
        }
    }
}