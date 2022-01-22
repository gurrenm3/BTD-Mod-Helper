using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// ModSetting class for a boolean value
    /// </summary>
    public class ModSettingBool : ModSetting<bool>
    {
        /// <summary>
        /// Action to modify the ModHelperCheckbox after it's created
        /// </summary>
        public Action<ModHelperCheckbox> modifyCheckbox;
        
        /// <inheritdoc />
        public ModSettingBool(bool value) : base(value)
        {
        }

        /// <summary>
        /// Create a new ModSetting bool with the given value as default
        /// </summary>
        public static implicit operator ModSettingBool(bool value)
        {
            return new ModSettingBool(value);
        }

        /// <summary>
        /// Gets the current value out of a ModSettingBool
        /// </summary>
        /// <param name="modSettingBool"></param>
        /// <returns></returns>
        public static implicit operator bool(ModSettingBool modSettingBool)
        {
            return modSettingBool.value;
        }

        /// <inheritdoc />
        public override ModHelperComponent CreateComponent()
        {
            var option = CreateBaseOption();

            var checkbox = option.AddCheckbox(
                new Info("Checkbox", 0, 0, 200, 200), value, VanillaSprites.BlueInsertPanelRound,
                new Action<bool>(enabled =>
                {
                    SetValue(enabled);
                    onValueChanged?.Invoke(enabled);
                })
            );
            option.SetResetAction(new Action(() => checkbox.SetChecked(defaultValue)));
            modifyCheckbox?.Invoke(checkbox);
            return option;
        }
    }
}