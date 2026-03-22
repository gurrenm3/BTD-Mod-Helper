using System;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for PopupScreen
/// </summary>
public static class PopupScreenExt
{
    /// <summary>
    /// Recreates the previous GetFirstActivePopup method that existed before v53
    /// </summary>
    public static Popup GetFirstActivePopup(this PopupScreen popupScreen) =>
        popupScreen.TryGetActivePopup(out var popup) ? popup : null;

    /// <summary>
    /// Gets the InputField of the ActivePopup, or null
    /// </summary>
    /// <param name="popupScreen"></param>
    /// <returns></returns>
    public static TMP_InputField GetTMP_InputField(this PopupScreen popupScreen) =>
        popupScreen.GetFirstActivePopup()?.GetComponentInChildren<TMP_InputField>();

    /// <summary>
    /// Gets the NK_TextMeshProUGUI of the ActivePopup, or null
    /// </summary>
    /// <param name="popupScreen"></param>
    /// <returns></returns>
    public static NK_TextMeshProUGUI GetBodyText(this PopupScreen popupScreen) => popupScreen.GetFirstActivePopup()
        ?.gameObject.GetComponentInChildrenByName<NK_TextMeshProUGUI>("Body");

    /// <summary>
    /// Modifies the NK_TextMeshProUGUI of the most recently created popup
    /// </summary>
    public static void ModifyField(this PopupScreen popupScreen, Action<TMP_InputField> func)
    {
        TaskScheduler.ScheduleTask(
            () => func(popupScreen.GetTMP_InputField()!),
            () => popupScreen.GetTMP_InputField() != null
        );
    }

    /// <summary>
    /// Modifies the TMP InputField of the most recently created popup
    /// </summary>
    public static void ModifyBodyText(this PopupScreen popupScreen, Action<NK_TextMeshProUGUI> func)
    {
        TaskScheduler.ScheduleTask(
            () => func(popupScreen.GetBodyText()!),
            () => popupScreen.GetBodyText() != null
        );
    }

    /// <summary>
    /// Since a recent BTD6 update, trying to show a popup while there already is one can cause a game crash. This method
    /// safely queues a popup for once there aren't any already active
    /// </summary>
    public static void SafelyQueue(this PopupScreen popupScreen, Action<PopupScreen> action)
    {
        TaskScheduler.ScheduleTask(
            () => action(popupScreen),
            () => popupScreen != null && !popupScreen.IsPopupActive()
        );
    }

    /// <summary>
    /// Modifies the TMP InputField to be a scroll panel
    /// </summary>
    public static void MakeTextScrollable(this PopupScreen screen)
    {
        screen.ModifyBodyText(field =>
        {
            var scrollPanel = field.gameObject.AddModHelperScrollPanel(new Info("ScrollPanel",
                InfoPreset.FillParent), RectTransform.Axis.Vertical, VanillaSprites.WhiteSquareGradient);
            scrollPanel.Background.color = new Color(1, 1, 1, 1);
            scrollPanel.Mask.showMaskGraphic = false;
            scrollPanel.ScrollRect.movementType = ScrollRect.MovementType.Clamped;

            var newBody = field.gameObject.Duplicate(scrollPanel.ScrollContent.transform);
            newBody.GetComponentInChildren<ModHelperScrollPanel>().gameObject.Destroy();

            field.Destroy();
        });
    }
}