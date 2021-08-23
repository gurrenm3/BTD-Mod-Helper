using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class SliderOption : SharedOption
    {
        /// <summary>
        /// The actual slider for this option
        /// </summary>
        public Slider Slider { get; set; }

        /// <summary>
        /// The image to show for parts of the slider that are filled/have value
        /// </summary>
        public Image Fill { get; set; }

        /// <summary>
        /// The image to show for the slider handle, if you want it to be visible
        /// </summary>
        public Image Handle { get; set; }

        /// <summary>
        /// The input field where the user types
        /// </summary>
        public InputField InputField { get; set; }

        /// <summary>
        /// The Reset button. Can be used for other things if desired
        /// </summary>
        public Button Button { get; set; }

        /// <summary>
        /// The text for the Reset Button
        /// </summary>
        public Text ButtonText { get; set; }


        private SliderOption(GameObject parentGO, ModSetting modSetting) :  base(parentGO, modSetting, "SliderOption")
        {
            Slider = instantiatedGameObject.transform.Find("Slider").GetComponent<Slider>();
            Fill = instantiatedGameObject.transform.Find("Slider/Fill Area/Fill").GetComponent<Image>();
            Handle = instantiatedGameObject.transform.Find("Slider/Handle Slide Area/Handle").GetComponent<Image>();
            InputField = instantiatedGameObject.transform.Find("InputField").GetComponent<InputField>();
            
            Button = instantiatedGameObject.transform.Find("Button").GetComponent<Button>();
            ButtonText = instantiatedGameObject.transform.Find("Button/Text").GetComponent<Text>();
            
            ButtonText.text = "Reset";
            Button.AddOnClick(() =>
            {
                Slider.Set(Convert.ToSingle(modSetting.GetDefaultValue()));
            });
        }

        internal SliderOption(GameObject parentGO, ModSettingInt modSettingInt) : this(parentGO, (ModSetting)modSettingInt)
        {
            Slider.value = modSettingInt.value;
            InputField.text = modSettingInt.value.ToString();
            Slider.minValue = (long) modSettingInt.minValue;
            Slider.maxValue = (long) modSettingInt.maxValue;
            
            Slider.onValueChanged.AddListener(value =>
            {
                var l = (long) value;
                modSettingInt.SetValue(l);
                if (long.TryParse(InputField.text, out var num) && num != l)
                {
                    InputField.SetText(l.ToString());
                }
            });
            InputField.onValueChanged.AddListener(value =>
            {
                if (long.TryParse(InputField.text, out var l))
                {
                    if (l > modSettingInt.maxValue)
                    {
                        l = (long)modSettingInt.maxValue;
                    } else if (l < modSettingInt.minValue)
                    {
                        l = (long)modSettingInt.minValue;
                    }
                    modSettingInt.SetValue(l);
                    if ((long)Slider.value != l)
                    {
                        Slider.Set(l);
                    }
                }
            });
            InputField.characterValidation = InputField.CharacterValidation.Integer;
            
            Button.AddOnClick(() =>
            {
                InputField.SetText(modSettingInt.GetDefaultValue().ToString());
            });
            
            modSettingInt.OnInitialized.InvokeAll(this);
        }

        internal SliderOption(GameObject parentGO, ModSettingDouble modSettingDouble) : this(parentGO, (ModSetting)modSettingDouble)
        {
            Slider.value = (float) modSettingDouble.value;
            InputField.text = modSettingDouble.value.ToString("F");
            Slider.minValue = (float) modSettingDouble.minValue;
            Slider.maxValue = (float) modSettingDouble.maxValue;
            
            Slider.onValueChanged.AddListener(value =>
            {
                var l = (double) value;
                modSettingDouble.SetValue(l);
                if (double.TryParse(InputField.text, out var num) && Math.Abs(num - l) > .001)
                {
                    InputField.SetText(l.ToString("F"));
                }
            });
            
            InputField.onValueChanged.AddListener(value =>
            {
                if (double.TryParse(InputField.text, out var d))
                {
                    if (d > modSettingDouble.maxValue)
                    {
                        d = (double)modSettingDouble.maxValue;
                    } else if (d < modSettingDouble.minValue)
                    {
                        d = (double)modSettingDouble.minValue;
                    }
                    modSettingDouble.SetValue(d);
                    if (Math.Abs(Slider.value - d) > .001)
                    {
                        Slider.Set(Convert.ToSingle(d));
                    }
                }
            });
            InputField.characterValidation = InputField.CharacterValidation.Decimal;
            
            
            Button.AddOnClick(() =>
            {
                InputField.SetText(modSettingDouble.GetDefaultValue().ToString());
            });

            
            modSettingDouble.OnInitialized.InvokeAll(this);
        }

        internal static RectTransform GetOriginalAsset(GameObject parentGO)
        {
            return GetOriginalAsset(parentGO, "SliderOption");
        }
    }
}
