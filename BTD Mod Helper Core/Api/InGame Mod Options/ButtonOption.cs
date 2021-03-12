using System;
using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.InGame_Mod_Options
{
    public class ButtonOption
    {
        private GameObject parent;
        public GameObject gameObject;
        public Text title;
        public Button button;
        public Text buttonText;
        

        public ButtonOption(GameObject parentGO)
        {
            parent = parentGO;
            gameObject = parentGO.transform.Find("ModOptions/UI Elements/ButtonOption").GetComponent<GameObject>();
            button = parentGO.transform.Find("ModOptions/UI Elements/ButtonOption/Button").GetComponent<Button>();
            title = parentGO.transform.Find("ModOptions/UI Elements/ButtonOption/OptionBase/Name").GetComponent<Text>();
            buttonText = parentGO.transform.Find("ModOptions/UI Elements/ButtonOption/Button/Text").GetComponent<Text>();

            button.onClick.AddListener(new Action(() => { buttonPressed(); })); //how you'd normally setup button events
            button.AddOnClick(buttonPressed); //you can also add OnClick events using this BTD6 Mod Helper extension
        }

        //This won't help mod makers, but it will show you how to setup button events.
        private void buttonPressed()
        {
            
        }
    }
}
