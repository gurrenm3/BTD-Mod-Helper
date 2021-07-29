using System;
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
        /// The Text in the middle of the slider that shows the current value
        /// </summary>
        public Text SliderValueText { get; set; }

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
            SliderValueText = instantiatedGameObject.transform.Find("Slider/SliderValue").GetComponent<Text>();
            
            Button = instantiatedGameObject.transform.Find("Button").GetComponent<Button>();
            ButtonText = instantiatedGameObject.transform.Find("Button/Text").GetComponent<Text>();
            
            ButtonText.text = "Reset";
            Button.AddOnClick(() => Slider.Set(Convert.ToSingle(modSetting.GetDefaultValue())));
        }

        internal SliderOption(GameObject parentGO, ModSettingInt modSettingInt) : this(parentGO, (ModSetting)modSettingInt)
        {
            Slider.value = modSettingInt.value;
            SliderValueText.text = modSettingInt.value.ToString();
            Slider.minValue = (long) modSettingInt.minValue;
            Slider.maxValue = (long) modSettingInt.maxValue;
            
            Slider.onValueChanged.AddListener(value =>
            {
                var l = (long) value;
                modSettingInt.SetValue(l);
                SliderValueText.text = l.ToString();
            });
            modSettingInt.OnInitialized.InvokeAll(this);
        }

        internal SliderOption(GameObject parentGO, ModSettingDouble modSettingDouble) : this(parentGO, (ModSetting)modSettingDouble)
        {
            Slider.value = (float) modSettingDouble.value;
            SliderValueText.text = modSettingDouble.value.ToString("F");
            Slider.minValue = (float) modSettingDouble.minValue;
            Slider.maxValue = (float) modSettingDouble.maxValue;
            Slider.onValueChanged.AddListener(value => 
            {
                modSettingDouble.SetValue((double)value);
                SliderValueText.text = value.ToString("F");
            });
            modSettingDouble.OnInitialized.InvokeAll(this);
        }

        internal static RectTransform GetOriginalAsset(GameObject parentGO)
        {
            return GetOriginalAsset(parentGO, "SliderOption");
        }
    }
}
