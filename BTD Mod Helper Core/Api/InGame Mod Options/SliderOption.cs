using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.InGame_Mod_Options
{
    public class SliderOption : ModOption
    {
        private GameObject parent;

        public GameObject gameObject;
        public Text title;
        public Slider slider;
        public Image fill;
        public Image handle;

        private readonly ModSetting modSetting;

        private SliderOption(GameObject parentGO, ModSetting modSetting)
        {
            parent = parentGO;
            this.modSetting = modSetting;
            gameObject = parentGO.transform.Find("ModOptions/UI Elements/ButtonOption").GetComponent<GameObject>();

            title = parentGO.transform.Find("ModOptions/UI Elements/SliderOption/OptionBase/Name").GetComponent<Text>();
            slider = parentGO.transform.Find("ModOptions/UI Elements/SliderOption/Slider").GetComponent<Slider>();
            fill = parentGO.transform.Find("ModOptions/UI Elements/SliderOption/Slider/Fill Area/Fill").GetComponent<Image>();
            handle = parentGO.transform.Find("ModOptions/UI Elements/SliderOption/Slider/Handle Slide Area/Handle").GetComponent<Image>();

            title.text = modSetting.GetName();
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

        public ModSetting GetModSetting()
        {
            return modSetting;
        }
    }
}
