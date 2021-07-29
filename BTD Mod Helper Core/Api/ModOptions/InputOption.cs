using BTD_Mod_Helper.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class InputOption : SharedOption
    {
        /// <summary>
        /// The Reset button. Can be used for other things if desired
        /// </summary>
        public Button Button { get; set; }

        /// <summary>
        /// The Text for the Reset button
        /// </summary>
        public Text ButtonText { get; set; }

        /// <summary>
        /// The input field where the user types
        /// </summary>
        public InputField InputField { get; set; }


        private InputOption(GameObject parentGO, ModSetting modSetting) : base(parentGO, modSetting, "TextInputOption")
        {
            Button = instantiatedGameObject.transform.Find("Button").GetComponent<Button>();
            ButtonText = instantiatedGameObject.transform.Find("Button/Text").GetComponent<Text>();
            InputField = instantiatedGameObject.transform.Find("InputField").GetComponent<InputField>();

            InputField.SetText(modSetting.GetValue().ToString());

            ButtonText.text = "Reset";
            Button.AddOnClick(() =>
            {
                InputField.SetText(modSetting.GetDefaultValue().ToString());
            });
        }
        
        internal InputOption(GameObject parentGO, ModSettingString modSettingString) : this(parentGO, (ModSetting)modSettingString)
        {
            InputField.characterValidation = modSettingString.GetValidation();
            InputField.AddSubmitEvent(modSettingString.SetValue);
            modSettingString.OnInitialized.InvokeAll(this);
        }

        internal InputOption(GameObject parentGO, ModSettingInt modSettingInt) : this(parentGO, (ModSetting)modSettingInt)
        {
            InputField.characterValidation = InputField.CharacterValidation.Integer;
            InputField.AddOnValueChangedEvent(value =>
            {
                var i = long.Parse(value);
                if (modSettingInt.maxValue.HasValue && i > modSettingInt.maxValue.Value)
                {
                    i = modSettingInt.maxValue.Value;
                } else if (modSettingInt.minValue.HasValue && i < modSettingInt.minValue.Value)
                {
                    i = modSettingInt.minValue.Value;
                }
                InputField.SetText(i.ToString());
                modSettingInt.SetValue(i);
            });
            modSettingInt.OnInitialized.InvokeAll(this);
        }

        internal InputOption(GameObject parentGO, ModSettingDouble modSettingDouble) : this(parentGO, (ModSetting)modSettingDouble)
        {
            InputField.characterValidation = InputField.CharacterValidation.Decimal;
            InputField.AddOnValueChangedEvent(value =>
            {
                var d = double.Parse(value);
                if (modSettingDouble.maxValue.HasValue && d > modSettingDouble.maxValue.Value)
                {
                    d = (int) modSettingDouble.maxValue.Value;
                } else if (modSettingDouble.minValue.HasValue && d < modSettingDouble.minValue.Value)
                {
                    d = (int) modSettingDouble.minValue.Value;
                }
                InputField.SetText(d.ToString());
                modSettingDouble.SetValue(d);
            });
            modSettingDouble.OnInitialized.InvokeAll(this);
        }

        internal static RectTransform GetOriginalAsset(GameObject parentGO)
        {
            return GetOriginalAsset(parentGO, "TextInputOption");
        }
    }
}
