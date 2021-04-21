using UnityEngine;

namespace BTD_Mod_Helper.Api.InGame_Mod_Options
{
    public class ModSettingBool : ModSetting<bool>
    {
        private bool value { get; set; }
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
            return new CheckboxOption(parent, this);
        }
    }
}