using Assets.Scripts.Unity.UI_New.Popups;
using TMPro;

namespace BTD_Mod_Helper.Extensions
{
    public static class PopupScreenExt
    {
        public static TMP_InputField GetTMP_InputField(this PopupScreen popupScreen)
        {
            return popupScreen.GetFirstActivePopup()?.GetComponentInChildren<TMP_InputField>();
        }
    }
}