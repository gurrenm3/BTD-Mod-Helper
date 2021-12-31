using System;
using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// ModSetting for an Enum value
    /// </summary>
    /// <typeparam name="T">The Enum in question</typeparam>
    public class ModSettingEnum<T> : ModSetting<T> where T : Enum
    {
        /// <inheritdoc />
        public ModSettingEnum(T value) : base(value)
        {
        }

        /// <summary>
        /// Constructs a new ModSetting with the given value as default
        /// </summary>
        public static implicit operator ModSettingEnum<T>(T value)
        {
            return new ModSettingEnum<T>(value);
        }

        /// <summary>
        /// Gets the current value out of a ModSetting
        /// </summary>
        public static implicit operator T(ModSettingEnum<T> modSettingEnum)
        {
            return modSettingEnum.value;
        }

        /// <inheritdoc />
        public override void SetValue(object val)
        {
            base.SetValue(Enum.Parse(typeof(T), value.ToString()));
        }

        /// <inheritdoc />
        public override object GetValue()
        {
            return base.GetValue().ToString();
        }

        /// <inheritdoc />
        public override object GetDefaultValue()
        {
            return base.GetDefaultValue().ToString();
        }

        /// <inheritdoc />
        public override ModOption ConstructModOption(GameObject parent)
        {
             //TODO DropDownOption
             return null;
        }
    }
}