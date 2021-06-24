using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.ModOptions
{
    internal class SliderOption : SharedOption
    {
        public Slider slider;
        public Image fill;
        public Image handle;
        public Text sliderValueText;

        private SliderOption(GameObject parentGO, ModSetting modSetting) :  base(parentGO, modSetting, "SliderOption")
        {
            slider = instantiatedGameObject.transform.Find("Slider").GetComponent<Slider>();
            fill = instantiatedGameObject.transform.Find("Slider/Fill Area/Fill").GetComponent<Image>();
            handle = instantiatedGameObject.transform.Find("Slider/Handle Slide Area/Handle").GetComponent<Image>();
            sliderValueText = instantiatedGameObject.transform.Find("Slider/SliderValue").GetComponent<Text>();
        }

        public SliderOption(GameObject parentGO, ModSettingInt modSettingInt) : this(parentGO, (ModSetting)modSettingInt)
        {
            slider.value = modSettingInt.value;
            sliderValueText.text = modSettingInt.value.ToString();
            slider.minValue = (long) modSettingInt.minValue;
            slider.maxValue = (long) modSettingInt.maxValue;
            
            slider.onValueChanged.AddListener(value => 
            {
                modSettingInt.SetValue((long)value);
                sliderValueText.text = value.ToString();
            });
        }
        
        public SliderOption(GameObject parentGO, ModSettingDouble modSettingDouble) : this(parentGO, (ModSetting)modSettingDouble)
        {
            slider.value = (float) modSettingDouble.value;
            sliderValueText.text = modSettingDouble.value.ToString("C2");
            slider.minValue = (float) modSettingDouble.minValue;
            slider.maxValue = (float) modSettingDouble.maxValue;
            
            slider.onValueChanged.AddListener(value => 
            {
                modSettingDouble.SetValue((double)value);
                sliderValueText.text = value.ToString("C2");
            });
        }

        internal static RectTransform GetOriginalAsset(GameObject parentGO)
        {
            return GetOriginalAsset(parentGO, "SliderOption");
        }
    }
}
