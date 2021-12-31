using BTD_Mod_Helper.Extensions;
using Il2CppSystem;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// Visual option for ModSettings where you input values
    /// </summary>
    public class InputOption : ModOption
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

            ButtonText.text = "Reset";
        }
        
        internal InputOption(GameObject parentGO, ModSettingString modSettingString) : this(parentGO, (ModSetting)modSettingString)
        {
            InputField.SetText(modSettingString.GetValue().ToString());
            
            InputField.characterValidation = modSettingString.GetValidation();
            InputField.AddSubmitEvent(modSettingString.SetValue);
            modSettingString.OnInitialized.InvokeAll(this);
            Button.AddOnClick(() =>
            {
                InputField.SetText(modSettingString.GetDefaultValue().ToString());
            });
        }

        internal InputOption(GameObject parentGO, ModSettingInt modSettingInt) : this(parentGO, (ModSetting)modSettingInt)
        {
            InputField.SetText(modSettingInt.GetValue().ToString());
            
            InputField.characterValidation = InputField.CharacterValidation.Integer;
            InputField.AddOnValueChangedEvent(value =>
            {
                //InputField.SetText(value);
                if (!long.TryParse(value, out var i))
                {
                    i = 0;
                }
                if (modSettingInt.maxValue.HasValue && i > modSettingInt.maxValue.Value)
                {
                    i = modSettingInt.maxValue.Value;
                } else if (modSettingInt.minValue.HasValue && i < modSettingInt.minValue.Value)
                {
                    i = modSettingInt.minValue.Value;
                }
                modSettingInt.SetValue(i);
            });
            modSettingInt.OnInitialized.InvokeAll(this);
            Button.AddOnClick(() =>
            {
                InputField.SetText(modSettingInt.GetDefaultValue().ToString());
            });
        }

        internal InputOption(GameObject parentGO, ModSettingDouble modSettingDouble) : this(parentGO, (ModSetting)modSettingDouble)
        {
            InputField.SetText($"{Math.Round((double)modSettingDouble.GetValue(), 5):0.#####}");
            
            InputField.characterValidation = InputField.CharacterValidation.Decimal;
            InputField.AddOnValueChangedEvent(value =>
            {
                //InputField.SetText(value);
                if (!double.TryParse(value, out var d))
                {
                    d = 0;
                }
                if (modSettingDouble.maxValue.HasValue && d > modSettingDouble.maxValue.Value)
                {
                    d = (int) modSettingDouble.maxValue.Value;
                } else if (modSettingDouble.minValue.HasValue && d < modSettingDouble.minValue.Value)
                {
                    d = (int) modSettingDouble.minValue.Value;
                }
                modSettingDouble.SetValue(d);
            });
            modSettingDouble.OnInitialized.InvokeAll(this);
            Button.AddOnClick(() =>
            {
                InputField.SetText($"{Math.Round((double)modSettingDouble.GetDefaultValue(), 5):0.#####}");
            });
        }

        internal static RectTransform GetOriginalAsset(GameObject parentGO)
        {
            return GetOriginalAsset(parentGO, "TextInputOption");
        }
    }
}
