using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;
using System;

namespace BTD_Mod_Helper.Api.InGame_Mod_Options
{
    public class CheckboxOption : ModOption
    {
        private GameObject parent;

        public GameObject gameObject;
        public Text title;
        public Toggle checkbox;
        public Text checkboxText;

        private readonly ModSettingBool modSettingBool;

        public CheckboxOption(GameObject parentGO, ModSettingBool modSettingBool)
        {
            parent = parentGO;
            this.modSettingBool = modSettingBool;
            
            gameObject = parentGO.transform.Find("ModOptions/UI Elements/ButtonOption").GetComponent<GameObject>();

            title = parentGO.transform.Find("ModOptions/UI Elements/CheckboxOption/OptionBase/Name").GetComponent<Text>();
            checkbox = parentGO.transform.Find("ModOptions/UI Elements/CheckboxOption/Checkbox1").GetComponent<Toggle>();
            checkboxText = parentGO.transform.Find("ModOptions/UI Elements/CheckboxOption/Checkbox1/Label").GetComponent<Text>();

            title.text = modSettingBool.displayName;
            checkbox.AddOnValueChanged(value => modSettingBool.SetValue(value));
        }

        public ModSetting GetModSetting()
        {
            return modSettingBool;
        }
    }
}
