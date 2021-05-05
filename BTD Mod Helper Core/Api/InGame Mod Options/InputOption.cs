using BTD_Mod_Helper.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.InGame_Mod_Options
{
    public class InputOption : ModOption
    {
        private GameObject parent;

        public GameObject gameObject;
        public Text title;
        public Button button;
        public Text buttonText;
        public InputField inputField;

        private readonly ModSetting modSetting;

        private InputOption(GameObject parentGO, ModSetting modSetting)
        {
            parent = parentGO;
            this.modSetting = modSetting;
            gameObject = parentGO.transform.Find("ModOptions/UI Elements/ButtonOption").GetComponent<GameObject>();

            title = parentGO.transform.Find("ModOptions/UI Elements/TextInputOption/OptionBase/Name").GetComponent<Text>();
            button = parentGO.transform.Find("ModOptions/UI Elements/TextInputOption/Button").GetComponent<Button>();
            buttonText = parentGO.transform.Find("ModOptions/UI Elements/TextInputOption/Button/Text").GetComponent<Text>();
            inputField = parentGO.transform.Find("ModOptions/UI Elements/TextInputOption/InputField").GetComponent<InputField>();

            title.text = modSetting.GetName();
            
            inputField.SetText(modSetting.GetValue().ToString());

            buttonText.text = "Reset";
            button.AddOnClick(() => modSetting.SetValue(modSetting.GetDefaultValue()));
        }
        
        public InputOption(GameObject parentGO, ModSettingString modSettingInt) : this(parentGO, (ModSetting)modSettingInt)
        {
            inputField.characterValidation = modSettingInt.validation;
            inputField.AddSubmitEvent(modSettingInt.SetValue);
        }
        
        public InputOption(GameObject parentGO, ModSettingInt modSettingInt) : this(parentGO, (ModSetting)modSettingInt)
        {
            inputField.characterValidation = InputField.CharacterValidation.Integer;
            inputField.AddSubmitEvent(value =>
            {
                var i = int.Parse(value);
                if (modSettingInt.maxValue.HasValue && i > modSettingInt.maxValue.Value)
                {
                    i = (int) modSettingInt.maxValue.Value;
                } else if (modSettingInt.minValue.HasValue && i < modSettingInt.minValue.Value)
                {
                    i = (int) modSettingInt.minValue.Value;
                }
                inputField.SetText(i.ToString());
                modSettingInt.SetValue(i);
            });
        }
        
        public InputOption(GameObject parentGO, ModSettingDouble modSettingDouble) : this(parentGO, (ModSetting)modSettingDouble)
        {
            inputField.characterValidation = InputField.CharacterValidation.Decimal;
            inputField.AddSubmitEvent(value =>
            {
                var d = double.Parse(value);
                if (modSettingDouble.maxValue.HasValue && d > modSettingDouble.maxValue.Value)
                {
                    d = (int) modSettingDouble.maxValue.Value;
                } else if (modSettingDouble.minValue.HasValue && d < modSettingDouble.minValue.Value)
                {
                    d = (int) modSettingDouble.minValue.Value;
                }
                inputField.SetText(d.ToString());
                modSettingDouble.SetValue(d);
            });
        }

        public ModSetting GetModSetting()
        {
            return modSetting;
        }
    }
}
