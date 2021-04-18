using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.InGame_Mod_Options
{
    public class SliderOption
    {
        private GameObject parent;

        public GameObject gameObject;
        public Text title;
        public Slider slider;
        public Image fill;
        public Image handle;

        public SliderOption(GameObject parentGO)
        {
            parent = parentGO;
            gameObject = parentGO.transform.Find("ModOptions/UI Elements/ButtonOption").GetComponent<GameObject>();

            title = parentGO.transform.Find("ModOptions/UI Elements/SliderOption/OptionBase/Name").GetComponent<Text>();
            slider = parentGO.transform.Find("ModOptions/UI Elements/SliderOption/Slider").GetComponent<Slider>();
            fill = parentGO.transform.Find("ModOptions/UI Elements/SliderOption/Slider/Fill Area/Fill").GetComponent<Image>();
            handle = parentGO.transform.Find("ModOptions/UI Elements/SliderOption/Slider/Handle Slide Area/Handle").GetComponent<Image>();
        }
    }
}
