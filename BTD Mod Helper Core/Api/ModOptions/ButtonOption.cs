using System;
using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.ModOptions
{
    internal class ButtonOption : SharedOption
    {
        public Button button;
        public Text buttonText;

        public ButtonOption(GameObject parentGO, ModSettingBool modSetting) : base(parentGO, modSetting, "ButtonOption")
        {
            button = instantiatedGameObject.transform.Find("Button").GetComponent<Button>();
            buttonText = instantiatedGameObject.transform.Find("Button/Text").GetComponent<Text>();

            //button.onClick.AddListener(new Action(() => { buttonPressed(); })); //how you'd normally setup button events
            //button.AddOnClick(buttonPressed); //you can also add OnClick events using this BTD6 Mod Helper extension
        }

        //This is an example of how to setup button events, using the buttonClick code above.
        private void buttonPressed()
        {
            
        }

        internal static RectTransform GetOriginalAsset(GameObject parentGO)
        {
            return GetOriginalAsset(parentGO, "ButtonOption");
        }
    }
}
