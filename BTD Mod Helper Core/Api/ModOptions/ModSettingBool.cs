using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class ModSettingBool : ModSetting<bool>
    {
        private bool value { get; set; }
        public bool isButton;

        public ModSettingBool(bool value) : base(value)
        {
        }

        public static implicit operator ModSettingBool(bool value)
        {
            return new ModSettingBool(value);
        }
        
        public static implicit operator bool(ModSettingBool modSettingBool)
        {
            return modSettingBool.value;
        }

        public override ModOption ConstructModOption(GameObject parent)
        {
            return null;
            //return isButton ? (ModOption) new ButtonOption(parent, this) : new CheckboxOption(parent, this);
        }

        public override SharedOption ConstructModOption2(GameObject parent)
        {
            return isButton ? (SharedOption) new ButtonOption(parent, this) : new CheckboxOption(parent, this);
        }
    }
}