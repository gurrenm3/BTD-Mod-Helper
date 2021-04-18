using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
    public static class InputFieldExt
    {
        public static void AddSubmitEvent(this InputField inputField, InputFieldSubmitEvent.Function funcToExecute)
        {
            inputField.onEndEdit.AddListener(funcToExecute);
        }

        public static void AddOnValueChangeEvent(this InputField inputField, InputFieldOnValueChanged.Function funcToExecute)
        {
            inputField.onValueChange.AddListener(funcToExecute);
        }

        public static void AddOnValueChangedEvent(this InputField inputField, InputFieldOnValueChanged.Function funcToExecute)
        {
            inputField.onValueChanged.AddListener(funcToExecute);
        }
    }
}
