using Assets.Scripts.Unity.UI_New.Popups;
using TMPro;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for PopupScreen
/// </summary>
public static class PopupScreenExt
{
    /// <summary>
    /// Gets the InputField of the ActivePopup, or null
    /// </summary>
    /// <param name="popupScreen"></param>
    /// <returns></returns>
    public static TMP_InputField? GetTMP_InputField(this PopupScreen popupScreen)
    {
        return popupScreen.GetFirstActivePopup()?.GetComponentInChildren<TMP_InputField>();
    }
}