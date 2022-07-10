using System;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Api;
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
    public static TMP_InputField GetTMP_InputField(this PopupScreen popupScreen)
    {
        return popupScreen.GetFirstActivePopup()?.GetComponentInChildren<TMP_InputField>();
    }

    /// <summary>
    /// Modifies the TMP InputField of the most recently created popup
    /// </summary>
    public static void ModifyField(this PopupScreen popupScreen, Action<TMP_InputField> func)
    {
        TaskScheduler.ScheduleTask(
            () => func(popupScreen.GetTMP_InputField()!),
            () => popupScreen.GetTMP_InputField() != null
        );
    }
}