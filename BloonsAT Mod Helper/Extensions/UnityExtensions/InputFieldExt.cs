using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class InputFieldExt
    {
        public static void SetText(this InputField inputField, string newText)
        {
            inputField.text = newText;
        }
    }
}
