using System;
using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace BTD_Mod_Helper.Api.ModOptions
{
    internal class SliderOption : SharedOption
    {
        public Slider slider;
        public Image fill;
        public Image handle;
        public Text sliderValueText;
        public Button button;
        public Text buttonText;

        private SliderOption(GameObject parentGO, ModSetting modSetting) :  base(parentGO, modSetting, "SliderOption")
        {
            slider = instantiatedGameObject.transform.Find("Slider").GetComponent<Slider>();
            fill = instantiatedGameObject.transform.Find("Slider/Fill Area/Fill").GetComponent<Image>();
            handle = instantiatedGameObject.transform.Find("Slider/Handle Slide Area/Handle").GetComponent<Image>();
            sliderValueText = instantiatedGameObject.transform.Find("Slider/SliderValue").GetComponent<Text>();
            
            button = instantiatedGameObject.transform.Find("Button").GetComponent<Button>();
            buttonText = instantiatedGameObject.transform.Find("Button/Text").GetComponent<Text>();
            
            buttonText.text = "Reset";
            button.AddOnClick(() => slider.Set(Convert.ToSingle(modSetting.GetDefaultValue())));
        }

        public SliderOption(GameObject parentGO, ModSettingInt modSettingInt) : this(parentGO, (ModSetting)modSettingInt)
        {
            slider.value = modSettingInt.value;
            sliderValueText.text = modSettingInt.value.ToString();
            slider.minValue = (long) modSettingInt.minValue;
            slider.maxValue = (long) modSettingInt.maxValue;
            
            slider.onValueChanged.AddListener(value =>
            {
                var l = (long) value;
                modSettingInt.SetValue(l);
                sliderValueText.text = l.ToString();
            });
        }
        
        public SliderOption(GameObject parentGO, ModSettingDouble modSettingDouble) : this(parentGO, (ModSetting)modSettingDouble)
        {
            slider.value = (float) modSettingDouble.value;
            sliderValueText.text = modSettingDouble.value.ToString("F");
            slider.minValue = (float) modSettingDouble.minValue;
            slider.maxValue = (float) modSettingDouble.maxValue;
            slider.onValueChanged.AddListener(value => 
            {
                modSettingDouble.SetValue((double)value);
                sliderValueText.text = value.ToString("F");
            });
        }

        internal static RectTransform GetOriginalAsset(GameObject parentGO)
        {
            return GetOriginalAsset(parentGO, "SliderOption");
        }
    }
}
