using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class ModSettingString : ModSetting<string>
    {
        internal InputField.CharacterValidation validation;
        
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

        public override ModOption ConstructModOption(GameObject parent)
        {
            return null;
            //return new InputOption(parent, this);
        }

        public override SharedOption ConstructModOption2(GameObject parent)
        {
            return new InputOption(parent, this);
        }
    }
}