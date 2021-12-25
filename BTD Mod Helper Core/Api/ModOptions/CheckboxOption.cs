using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class CheckboxOption : SharedOption
    {
        /// <summary>
        /// The actual CheckBox associated with this option
        /// </summary>
        public Toggle Checkbox { get; private set; }

        /// <summary>
        /// The Text for the Checkbox
        /// </summary>
        public Text CheckboxText;

        private readonly ModSettingBool modSettingBool;

        internal CheckboxOption(GameObject parentGO, ModSettingBool modSettingBool) : base(parentGO, modSettingBool, "CheckboxOption")
        {
            this.modSettingBool = modSettingBool;
            Checkbox = instantiatedGameObject.transform.Find("Checkbox1").GetComponent<Toggle>();
            CheckboxText = instantiatedGameObject.transform.Find("Checkbox1/Label").GetComponent<Text>();

            Checkbox.Set(modSettingBool);
            Checkbox.AddOnValueChanged(value => modSettingBool.SetValue(value));
            modSettingBool.OnInitialized.InvokeAll(this);
        }

        public override ModSetting GetModSetting()
        {
            return modSettingBool;
        }

        internal static RectTransform GetOriginalAsset(GameObject parentGO)
        {
            return GetOriginalAsset(parentGO, "CheckboxOption");
        }
    }
}
