using System;
using System.Collections.Generic;
using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class ModSettingBool : ModSetting<bool>
    {
        [Obsolete("This is obsolete. Use ModSettingBool.IsButton instead")]
        public bool isButton;

        /// <summary>
        /// Should the UI for this be a button? If not it will be a Checkbox
        /// </summary>
        public bool IsButton { get; set; }

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
            return (isButton || IsButton) ? (SharedOption) new ButtonOption(parent, this) : new CheckboxOption(parent, this);
        }
    }
}