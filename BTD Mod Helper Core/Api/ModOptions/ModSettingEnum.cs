using System;
using System.Linq;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// ModSetting for an Enum value
    /// </summary>
    /// <typeparam name="T">The Enum in question</typeparam>
    public class ModSettingEnum<T> : ModSetting<T> where T : Enum
    {
        /// <summary>
        /// Action to modify the ModHelperDropdown after it's created
        /// </summary>
        public Action<ModHelperDropdown> modifyDropdown;

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
        internal override ModHelperOption CreateComponent()
        {
            var option = CreateBaseOption();

            var dropdown = option.BottomRow.AddDropdown(
                new Info("Dropdown", width: 1000, height: 150), Enum.GetNames(typeof(T)).ToIl2CppList(), 500,
                new Action<int>(i =>
                {
                    var e = (T) Enum.GetValues(typeof(T)).GetValue(i);
                    SetValue(e);
                    onValueChanged?.Invoke(e);
                }), VanillaSprites.BlueInsertPanelRound, 80f
            );


            option.SetResetAction(new Action(() =>
            {
                dropdown.Dropdown.SetValue(Enum.GetValues(typeof(T)).Cast<T>().ToList().IndexOf(defaultValue));
            }));

            modifyDropdown?.Invoke(dropdown);

            return option;
        }
    }
}