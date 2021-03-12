using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.InGame_Mod_Options
{
    public class InputOption
    {
        private GameObject parent;

        public GameObject gameObject;
        public Text title;
        public Button button;
        public Text buttonText;
        public InputField inputField;

        public InputOption(GameObject parentGO)
        {
            parent = parentGO;
            gameObject = parentGO.transform.Find("ModOptions/UI Elements/ButtonOption").GetComponent<GameObject>();

            title = parentGO.transform.Find("ModOptions/UI Elements/TextInputOption/OptionBase/Name").GetComponent<Text>();
            button = parentGO.transform.Find("ModOptions/UI Elements/TextInputOption/Button").GetComponent<Button>();
            buttonText = parentGO.transform.Find("ModOptions/UI Elements/TextInputOption/Button/Text").GetComponent<Text>();
            inputField = parentGO.transform.Find("ModOptions/UI Elements/TextInputOption/InputField").GetComponent<InputField>();
        }
    }
}
