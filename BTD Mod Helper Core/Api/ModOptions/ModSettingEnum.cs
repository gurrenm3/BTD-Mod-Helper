using System;
using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class ModSettingEnum<T> : ModSetting<T> where T : Enum
    {
        public ModSettingEnum(T value) : base(value)
        {
        }

        public static implicit operator ModSettingEnum<T>(T value)
        {
            return new ModSettingEnum<T>(value);
        }

        public static implicit operator T(ModSettingEnum<T> modSettingEnum)
        {
            return modSettingEnum.value;
        }

        public override void SetValue(object val)
        {
            base.SetValue(Enum.Parse(typeof(T), value.ToString()));
        }

        public override object GetValue()
        {
            return base.GetValue().ToString();
        }

        public override object GetDefaultValue()
        {
            return base.GetDefaultValue().ToString();
        }
        

        public override ModOption ConstructModOption(GameObject parent)
        {
            throw new NotImplementedException(); //TODO DropDownOption
        }

        public override SharedOption ConstructModOption2(GameObject parent)
        {
            throw new NotImplementedException(); //TODO DropDownOption
        }
    }
}