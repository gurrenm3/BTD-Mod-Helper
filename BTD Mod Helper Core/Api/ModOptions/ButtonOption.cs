using System;
using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class ButtonOption : SharedOption
    {
        /// <summary>
        /// The actual Button for this option
        /// </summary>
        public Button Button { get; private set; }

        /// <summary>
        /// The Text for the Button
        /// </summary>
        public Text ButtonText { get; private set; }


        internal ButtonOption(GameObject parentGO, ModSettingBool modSetting) : base(parentGO, modSetting, "ButtonOption")
        {
            Button = instantiatedGameObject.transform.Find("Button").GetComponent<Button>();
            ButtonText = instantiatedGameObject.transform.Find("Button/Text").GetComponent<Text>();

            //button.onClick.AddListener(new Action(() => { buttonPressed(); })); //how you'd normally setup button events
            //button.AddOnClick(buttonPressed); //you can also add OnClick events using this BTD6 Mod Helper extension
            
            modSetting.OnInitialized.InvokeAll(this);
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
