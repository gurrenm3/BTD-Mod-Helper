using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppInterop.Runtime.Attributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using static BTD_Mod_Helper.Extensions.SelectableExt;

namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent for a PopUp menu similar to desktop right click menus
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperPopupMenu : ModHelperPanel
{
    /// <summary>
    /// The current <see cref="ModHelperPopupOption"/>s in the menu
    /// </summary>
    [HideFromIl2Cpp]
    public IEnumerable<ModHelperPopupOption> Options =>
        gameObject.GetChildren().Select(o => o.GetComponent<ModHelperPopupOption>()).Where(o => o != null);

    /// <summary>
    /// The parent object that this is for, used for determining if clicks elsewhere will auto hide the menu or not
    /// </summary>
    public ModHelperComponent parentComponent;

    /// <summary>
    /// Whether the menu should automatically hide when a click happens elsewhere
    /// </summary>
    public bool autoHide = true;

    /// <inheritdoc />
    public ModHelperPopupMenu(IntPtr pointer) : base(pointer)
    {
    }

    private void Update()
    {
        if (!autoHide) return;

        if (Input.GetMouseButton((int) MouseButton.Left) &&
            !(ModHelperWindow.RaycastedGameObject is { } target &&
              (target.transform.IsChildOf(transform) ||
               parentComponent is not null && target.transform.IsChildOf(parentComponent.transform))))
        {
            Hide();
        }
    }

    /// <summary>
    /// Whether this menu is open or not
    /// </summary>
    public bool IsShowing => gameObject.activeSelf;

    /// <summary>
    /// Show the menu
    /// </summary>
    public void Show()
    {
        foreach (var option in Options)
        {
            option.gameObject.SetActive(true);
        }
        gameObject.SetActive(true);

        if (parentComponent != null &&
            parentComponent.gameObject.HasComponent(out Selectable selectable) &&
            selectable.transition == Selectable.Transition.ColorTint &&
            selectable.colors.normalColor == NormalColor)
        {
            selectable.colors = selectable.colors with
            {
                normalColor = HighlightColor
            };
        }
    }

    /// <summary>
    /// Hide the menu
    /// </summary>
    public void Hide(bool propagate = false)
    {
        gameObject.SetActive(false);
        foreach (var option in Options)
        {
            option.HideSubMenu();
        }

        if (parentComponent == null) return;

        if (parentComponent.gameObject.HasComponent(out Selectable selectable) &&
            selectable.transition == Selectable.Transition.ColorTint &&
            selectable.colors.normalColor == HighlightColor)
        {
            if (selectable.Is(out Toggle toggle))
            {
                toggle.SetIsOnWithoutNotify(false);
            }
            else
            {
                selectable.colors = selectable.colors with
                {
                    normalColor = NormalColor
                };
            }
        }

        if (propagate && parentComponent.Is(out ModHelperPopupOption parentOption))
        {
            parentOption.parentMenu?.Hide(propagate);
        }
    }

    /// <summary>
    /// Add an option to the menu
    /// </summary>
    /// <param name="option">Option to add</param>
    /// <returns>this</returns>
    public ModHelperPopupMenu AddOption(ModHelperPopupOption option)
    {
        option.parentMenu = this;

        Add(option);

        if (option.initialInfo.Width <= 0)
        {
            option.LayoutElement.enabled = false;
        }

        return this;
    }

    /// <summary>
    /// Add an option to the menu
    /// </summary>
    /// <param name="info">The info to use for its size, if no Height is set, 75 will be used</param>
    /// <param name="text">Option label, if null then uses the Name from the info</param>
    /// <param name="icon">Option icon, null for no icon, empty string for still creating the icon but it being empty</param>
    /// <param name="action">Action to perform when this option is clicked</param>
    /// <param name="subMenu">Sub menu that this option opens</param>
    /// <param name="isSelected">Function to determine if this option should display as selected or not</param>
    /// <returns>this</returns>
    public ModHelperPopupMenu AddOption(Info info, string text = null, string icon = null, UnityAction action = null,
        ModHelperPopupMenu subMenu = null, Il2CppSystem.Func<bool> isSelected = null)
    {
        return AddOption(ModHelperPopupOption.Create(info, text, icon, action, subMenu, isSelected));
    }

    /// <summary>
    /// Adds a horizontal separation line to the menu
    /// </summary>
    /// <returns>this</returns>
    public ModHelperPopupMenu AddSeparator(int height = 2)
    {
        var panel = AddPanel(new Info("Separator", 50, height), "");

        panel.Background.color = PressedColor;

        return this;
    }

    /// <summary>
    /// Constructs a new PopUp Menu, and makes it inactive to start
    /// </summary>
    /// <param name="info">the initial info for the menu</param>
    /// <param name="fitSize">whether to use a <see cref="ContentSizeFitter"/></param>
    /// <returns>the created menu</returns>
    public static ModHelperPopupMenu Create(Info info, bool fitSize = true)
    {
        var menu = Create<ModHelperPopupMenu>(info, MelonMain.CurrentDefaultWindowColor.MainPanelSprite,
            RectTransform.Axis.Vertical, ModHelperWindow.Margin, ModHelperWindow.Margin);

        menu.Background.pixelsPerUnitMultiplier = 2;

        menu.LayoutGroup.childForceExpandWidth = true;

        if (fitSize)
        {
            var fitter = menu.AddComponent<ContentSizeFitter>();
            fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }

        menu.gameObject.SetActive(false);

        return menu;
    }

}