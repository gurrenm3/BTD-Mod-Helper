using System;
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static BTD_Mod_Helper.Extensions.SelectableExt;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// An option for a <see cref="ModHelperPopupMenu"/>
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperPopupOption : ModHelperPanel
{
    /// <summary>
    /// The parent pop up menu if this is a sub option
    /// </summary>
    public ModHelperPopupMenu parentMenu;

    /// <summary>
    /// The icon for the option
    /// </summary>
    public ModHelperImage icon;

    /// <summary>
    /// The label for the option
    /// </summary>
    public ModHelperText text;

    /// <summary>
    /// The Toggle component for the option
    /// </summary>
    public Toggle toggle;

    /// <summary>
    /// The sub popup menu that this leads to, or null
    /// </summary>
    public ModHelperPopupMenu subMenu;

    /// <summary>
    /// Whether to hide the parent menu when this option is pressed
    /// </summary>
    public bool hideParentOnClick = true;

    /// <summary>
    /// Whether to hide ALL parent menus when this option is pressed
    /// </summary>
    public bool hideAllParentsOnClick = true;

    /// <inheritdoc />
    public ModHelperPopupOption(IntPtr pointer) : base(pointer)
    {
    }

    private Il2CppSystem.Func<bool> getSelected;
    private Il2CppSystem.Func<bool> getHidden;

    private bool IsSelected => toggle.currentSelectionState is Selectable.SelectionState.Highlighted
                                   or Selectable.SelectionState.Pressed;

    private bool lastSelected;

    /// <summary>
    /// Shows the sub menu for this option, if there is one
    /// </summary>
    public void ShowSubMenu()
    {
        if (subMenu is null) return;

        if (!subMenu.gameObject.active)
        {
            FixSubMenuPosition();

            if (subMenu.RectTransform.rect == Rect.zero)
            {
                Invoke(nameof(FixSubMenuPosition), Time.deltaTime);
            }
        }
        subMenu.Show();
        SetSelected(true);
    }

    /// <summary>
    /// Hides the sub menu for this option, if there is one
    /// </summary>
    public void HideSubMenu()
    {
        if (subMenu is null) return;

        subMenu.Hide();
        SetSelected(false);
    }

    private void Awake()
    {
        toggle ??= GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        SetSelected(getSelected?.Invoke() ?? false);

        if (getHidden != null)
        {
            SetActive(!getHidden.Invoke());
        }
    }

    private void Start()
    {
        if (getSelected != null)
        {
            SetSelected(getSelected?.Invoke() ?? false);
        }

        if (getHidden != null)
        {
            SetActive(!getHidden.Invoke());
        }
    }

    /// <summary>
    /// Sets whether this option is selected
    /// </summary>
    /// <param name="selected"></param>
    public void SetSelected(bool selected)
    {
        toggle?.SetIsOnWithoutNotify(selected);
        UpdateColor();
    }

    private void AfterSelected()
    {
        if (parentMenu is not null)
        {
            foreach (var option in parentMenu.Options)
            {
                if (option == this) continue;
                option.HideSubMenu();
            }
        }

        if (IsSelected && subMenu is not null)
        {
            ShowSubMenu();
        }
    }

    private void Update()
    {
        UpdateColor();

        if (!lastSelected && IsSelected)
        {
            if (parentMenu != null)
            {
                foreach (var option in parentMenu.Options)
                {
                    option.CancelInvoke(nameof(AfterSelected));
                }
            }
            Invoke(nameof(AfterSelected), .5f);
        }
        lastSelected = IsSelected;
    }

    private void UpdateColor()
    {
        if (toggle is null) return;
        toggle.colors = toggle.colors with
        {
            normalColor = toggle.isOn || (subMenu?.IsShowing ?? false) ? HighlightColor : NormalColor
        };
    }


    /// <summary>
    /// Fixes the submenu position to not be off screen
    /// </summary>
    public void FixSubMenuPosition()
    {
        if (subMenu is null) return;

        subMenu.RectTransform.pivot = new Vector2(0, 1);
        subMenu.RectTransform.anchorMin = new Vector2(1, 1);
        subMenu.RectTransform.anchorMax = new Vector2(1, 1);
        subMenu.RectTransform.anchoredPosition = new Vector2(ModHelperWindow.Margin, ModHelperWindow.Margin);

        LayoutRebuilder.ForceRebuildLayoutImmediate(subMenu);

        var parents = GetComponentsInParent<ModHelperPopupMenu>();

        if (ModHelperWindow.IsOutsideScreenRight(subMenu) || parents.Any(menu => subMenu.RectTransform.OverlapsWith(menu)))
        {
            subMenu.RectTransform.pivot = new Vector2(1, 1);
            subMenu.RectTransform.anchorMin = new Vector2(0, 1);
            subMenu.RectTransform.anchorMax = new Vector2(0, 1);
            subMenu.RectTransform.anchoredPosition = new Vector2(-ModHelperWindow.Margin, ModHelperWindow.Margin);
        }

        if (ModHelperWindow.IsOutsideScreenBottom(subMenu))
        {
            subMenu.RectTransform.pivot = subMenu.RectTransform.pivot with
            {
                y = 0
            };
            subMenu.RectTransform.anchorMin = subMenu.RectTransform.anchorMin with
            {
                y = 0
            };
            subMenu.RectTransform.anchorMax = subMenu.RectTransform.anchorMax with
            {
                y = 0
            };
            subMenu.RectTransform.anchoredPosition = subMenu.RectTransform.anchoredPosition with
            {
                y = -ModHelperWindow.Margin
            };
        }
    }

    /// <summary>
    /// Adds a submenu to to this option
    /// </summary>
    /// <param name="menu">The popup menu to use</param>
    /// <returns>this option</returns>
    public ModHelperPopupOption AddSubMenu(ModHelperPopupMenu menu)
    {
        if (initialInfo.Width <= 0)
        {
            AddPanel(new Info("Filler", InfoPreset.Flex));
        }

        var arrow = AddImage(new Info("Arrow", initialInfo.Height - ModHelperWindow.Margin), VanillaSprites.NextArrowSmall);
        arrow.RectTransform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        LayoutGroup.padding.right = ModHelperWindow.Margin / 2;

        subMenu = menu;

        Add(subMenu);
        var layoutElement = menu.AddComponent<LayoutElement>();
        layoutElement.ignoreLayout = true;

        menu.parentComponent = this;

        FixSubMenuPosition();

        return this;
    }

    /// <summary>
    /// Adds a submenu to to this option
    /// </summary>
    /// <returns>this option</returns>
    public ModHelperPopupMenu AddSubMenu(Info info)
    {
        var menu = ModHelperPopupMenu.Create(info);
        AddSubMenu(menu);

        return menu;
    }

    /// <summary>
    /// Constructs a new option for a popupmenu
    /// </summary>
    /// <param name="info">The info to use for its size, if no Height is set, 75 will be used</param>
    /// <param name="text">Option label, if null then uses the Name from the info</param>
    /// <param name="icon">Option icon, null for no icon, empty string for still creating the icon but it being empty</param>
    /// <param name="action">Action to perform when this option is clicked</param>
    /// <param name="subMenu">Sub menu that this option opens</param>
    /// <param name="isSelected">Function to determine if this option should display as selected or not</param>
    /// <param name="isHidden">Function to determine if this option should be visible or should be hidden</param>
    /// <returns></returns>
    public static ModHelperPopupOption Create(Info info, string text = null, string icon = null, UnityAction action = null,
        ModHelperPopupMenu subMenu = null, Il2CppSystem.Func<bool> isSelected = null,
        Il2CppSystem.Func<bool> isHidden = null)
    {
        if (info.Height == 0)
        {
            info = info with
            {
                Height = 75
            };
        }
        var option = Create<ModHelperPopupOption>(info, VanillaSprites.SmallSquareWhiteGradient,
            RectTransform.Axis.Horizontal, ModHelperWindow.Margin);
        option.LayoutGroup.padding = new RectOffset
        {
            left = ModHelperWindow.Margin,
            bottom = ModHelperWindow.Margin,
            top = ModHelperWindow.Margin,
            right = ModHelperWindow.Margin
        };
        var itemHeight = info.Height - ModHelperWindow.Margin;

        var toggle = option.AddComponent<Toggle>();
        option.toggle = toggle;
        toggle.onValueChanged.AddListener(new Action<bool>(_ =>
        {
            if (action is not null)
            {
                action.Invoke();
                if (option.hideParentOnClick)
                {
                    option.parentMenu?.Hide(option.hideAllParentsOnClick);
                }
            }
            else if (option.subMenu is not null)
            {
                option.ShowSubMenu();
            }
        }));

        toggle.UseBackgroundTint();
        toggle.colors = toggle.colors with
        {
            pressedColor = action != null ? PressedColor : HighlightColor
        };

        if (icon != null)
        {
            var image = option.icon = option.AddImage(new Info("Icon", itemHeight), icon);
            image.Image.type = Image.Type.Sliced;
            image.Image.enabled = !string.IsNullOrWhiteSpace(icon);
        }

        option.text = option.AddText(new Info("Text")
        {
            Height = itemHeight,
            FlexWidth = info.Width > 0 ? 1 : 0
        }, text ?? info.Name);
        option.text.Text.horizontalAlignment = HorizontalAlignmentOptions.Left;
        option.text.Text.lineSpacing = 0;
        if (info.Width > 0)
        {
            option.text.EnableAutoSizing(42f);
        }
        else
        {
            option.text.SizeWidthToText();
        }

        if (subMenu is not null)
        {
            option.AddSubMenu(subMenu);
        }

        option.getSelected = isSelected;
        option.getHidden = isHidden;

        return option;
    }


}