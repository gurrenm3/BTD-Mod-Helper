using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class SliderOption : SharedOption
    {
        public Slider slider;
        public Image fill;
        public Image handle;

        private SliderOption(GameObject parentGO, ModSetting modSetting) :  base(parentGO, modSetting, "SliderOption")
        {
            MelonLoader.MelonLogger.Msg("---");
            MelonLoader.MelonLogger.Msg("SliderOption Info:");
            MelonLoader.MelonLogger.Msg(rectTransform.position.x);
            MelonLoader.MelonLogger.Msg(rectTransform.position.y);

            slider = instantiatedGameObject.transform.Find("Slider").GetComponent<Slider>();
            fill = instantiatedGameObject.transform.Find("Slider/Fill Area/Fill").GetComponent<Image>();
            handle = instantiatedGameObject.transform.Find("Slider/Handle Slide Area/Handle").GetComponent<Image>();
        }

        public SliderOption(GameObject parentGO, ModSettingInt modSettingInt) : this(parentGO, (ModSetting)modSettingInt)
        {
            slider.value = modSettingInt.value;
            slider.minValue = (long) modSettingInt.minValue;
            slider.maxValue = (long) modSettingInt.maxValue;
            
            slider.onValueChanged.AddListener(value => modSettingInt.SetValue((long)value));
        }
        
        public SliderOption(GameObject parentGO, ModSettingDouble modSettingDouble) : this(parentGO, (ModSetting)modSettingDouble)
        {
            slider.value = (float) modSettingDouble.value;
            slider.minValue = (float) modSettingDouble.minValue;
            slider.maxValue = (float) modSettingDouble.maxValue;
            
            slider.onValueChanged.AddListener(value => modSettingDouble.SetValue((double)value));
        }

        internal static RectTransform GetOriginalAsset(GameObject parentGO)
        {
            return GetOriginalAsset(parentGO, "SliderOption");
        }
    }
}
