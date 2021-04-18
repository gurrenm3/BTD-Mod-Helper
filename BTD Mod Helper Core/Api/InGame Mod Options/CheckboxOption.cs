using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;
using System;

namespace BTD_Mod_Helper.Api.InGame_Mod_Options
{
    public class CheckboxOption
    {
        private GameObject parent;

        public GameObject gameObject;
        public Text title;
        public Toggle checkbox;
        public Text checkboxText;


        public CheckboxOption(GameObject parentGO)
        {
            parent = parentGO;
            gameObject = parentGO.transform.Find("ModOptions/UI Elements/ButtonOption").GetComponent<GameObject>();

            title = parentGO.transform.Find("ModOptions/UI Elements/CheckboxOption/OptionBase/Name").GetComponent<Text>();
            checkbox = parentGO.transform.Find("ModOptions/UI Elements/CheckboxOption/Checkbox1").GetComponent<Toggle>();
            checkboxText = parentGO.transform.Find("ModOptions/UI Elements/CheckboxOption/Checkbox1/Label").GetComponent<Text>();
        }
    }
}
