using BTD_Mod_Helper.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.ModOptions
{
    internal class InputOption : SharedOption
    {
        public Button button;
        public Text buttonText;
        public InputField inputField;

        private readonly ModSetting modSetting;

        private InputOption(GameObject parentGO, ModSetting modSetting) : base(parentGO, modSetting, "TextInputOption")
        {
            button = instantiatedGameObject.transform.Find("Button").GetComponent<Button>();
            buttonText = instantiatedGameObject.transform.Find("Button/Text").GetComponent<Text>();
            inputField = instantiatedGameObject.transform.Find("InputField").GetComponent<InputField>();

            inputField.SetText(modSetting.GetValue().ToString());

            buttonText.text = "Reset";
            button.AddOnClick(() => modSetting.SetValue(modSetting.GetDefaultValue()));
        }
        
        public InputOption(GameObject parentGO, ModSettingString modSettingInt) : this(parentGO, (ModSetting)modSettingInt)
        {
            inputField.characterValidation = modSettingInt.validation;
            inputField.AddSubmitEvent(modSettingInt.SetValue);
        }
        
        public InputOption(GameObject parentGO, ModSettingInt modSettingInt) : this(parentGO, (ModSetting)modSettingInt)
        {
            inputField.characterValidation = InputField.CharacterValidation.Integer;
            inputField.AddSubmitEvent(value =>
            {
                var i = int.Parse(value);
                if (modSettingInt.maxValue.HasValue && i > modSettingInt.maxValue.Value)
                {
                    i = (int) modSettingInt.maxValue.Value;
                } else if (modSettingInt.minValue.HasValue && i < modSettingInt.minValue.Value)
                {
                    i = (int) modSettingInt.minValue.Value;
                }
                inputField.SetText(i.ToString());
                modSettingInt.SetValue(i);
            });
        }
        
        public InputOption(GameObject parentGO, ModSettingDouble modSettingDouble) : this(parentGO, (ModSetting)modSettingDouble)
        {
            inputField.characterValidation = InputField.CharacterValidation.Decimal;
            inputField.AddSubmitEvent(value =>
            {
                var d = double.Parse(value);
                if (modSettingDouble.maxValue.HasValue && d > modSettingDouble.maxValue.Value)
                {
                    d = (int) modSettingDouble.maxValue.Value;
                } else if (modSettingDouble.minValue.HasValue && d < modSettingDouble.minValue.Value)
                {
                    d = (int) modSettingDouble.minValue.Value;
                }
                inputField.SetText(d.ToString());
                modSettingDouble.SetValue(d);
            });
        }

        internal static RectTransform GetOriginalAsset(GameObject parentGO)
        {
            return GetOriginalAsset(parentGO, "TextInputOption");
        }
    }
}
