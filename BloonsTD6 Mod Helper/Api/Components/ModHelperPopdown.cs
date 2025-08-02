using System;
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using Il2CppSystem.Collections.Generic;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;
using static BTD_Mod_Helper.Extensions.SelectableExt;

namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// A ModHelperComponent for a dropdown menu that utilizes a <see cref="ModHelperPopupMenu"/>
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperPopdown : ModHelperPanel
{
    /// <summary>
    /// The component which handles the dropdown
    /// </summary>
    public TMP_Dropdown dropdown;

    /// <summary>
    /// The popup menu used
    /// </summary>
    public ModHelperPopupMenu menu;


    /// <inheritdoc />
    public ModHelperPopdown(IntPtr ptr) : base(ptr)
    {
    }

    private bool lastExpanded;

    private string[] images;

    /// <summary>
    /// Whether to automatically size the component that opens the dropdown based on the text width
    /// </summary>
    public bool autosize;

    /// <inheritdoc />
    protected override void OnUpdate()
    {
        if (dropdown.IsExpanded && !lastExpanded)
        {
            var popUpMenu = dropdown.m_Dropdown.GetComponent<ModHelperPopupMenu>();
            popUpMenu.autoHide = false;
            popUpMenu.parentComponent = this;

            if (images != null)
            {
                foreach (var (item, icon) in dropdown.m_Items.ToArray().Zip(images))
                {
                    item.image.enabled = true;
                    item.image.gameObject.SetActive(true);
                    item.image.SetSprite(icon);
                }
            }
            else
            {
                foreach (var item in dropdown.m_Items)
                {
                    item.image?.gameObject?.SetActive(false);
                }
            }
        }

        lastExpanded = dropdown.IsExpanded;

        dropdown.colors = dropdown.colors with
        {
            normalColor = dropdown.IsExpanded ? HighlightColor : NormalColor
        };
    }

    /// <summary>
    /// Constructs a new popup menu dropdown
    /// </summary>
    /// <param name="info">the initial info to use, should have a Height defined</param>
    /// <param name="itemSize">size of each option in the popup menu (before margins/padding)</param>
    /// <param name="options">the labels for the options</param>
    /// <param name="onValueChanged">called when an option is selected, index passed in</param>
    /// <param name="direction">the direction of the dropdown, Vector2.down or Vector2.up will be the most used</param>
    /// <param name="labelFontSize">text size for label</param>
    /// <param name="background">background image, or null</param>
    /// <param name="menuOffset">position offset for the menu</param>
    /// <param name="images">images guids to use for the options</param>
    /// <param name="autosize"><see cref="autosize"/></param>
    /// <returns>the created popdown</returns>
    public static ModHelperPopdown Create(Info info, Vector2 itemSize, List<string> options,
        UnityAction<int> onValueChanged, Vector2 direction = default, float labelFontSize = 42f,
        string background = null, Vector2 menuOffset = default, List<string> images = null, bool autosize = false)
    {
        var popdown = Create<ModHelperPopdown>(info, background ?? VanillaSprites.SmallSquareWhiteGradient);
        popdown.autosize = autosize;

        var text = popdown.AddText(new Info("DropdownText", InfoPreset.FillParent), "", labelFontSize,
            TextAlignmentOptions.MidlineLeft);
        text.RectTransform.offsetMin = new Vector2(ModHelperWindow.Margin / 2f, 0);

        var arrow = popdown.AddImage(new Info("Arrow", info.Height * 1.5f)
        {
            Anchor = new Vector2(1, 0.5f),
            X = info.Height * -.75f
        }, VanillaSprites.NextArrowSmall);

        if (direction == default)
        {
            direction = Vector2.down;
        }
        arrow.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

        var menu = popdown.menu = ModHelperPopupMenu.Create(new Info("Template")
        {
            Position = menuOffset,
            Anchor = new Vector2(0.5f, 0.5f) + direction / 2,
            Pivot = new Vector2(0.5f, 0.5f) - direction / 2,
        });
        menu.parentComponent = popdown;
        menu.autoHide = false;
        menu.disableNextFrame = true;

        var option = ModHelperPopupOption.Create(new Info("Item")
        {
            SizeDelta = itemSize
        }, "", images == null ? null : "");
        option.text.Text.fontSize = labelFontSize;
        menu.AddOption(option);

        var dropdown = popdown.dropdown = popdown.AddComponent<TMP_Dropdown>();
        dropdown.captionText = text.Text;
        dropdown.template = menu;
        dropdown.itemText = option.text.Text;
        dropdown.itemImage = option.icon?.Image;
        dropdown.image = popdown.Background;
        dropdown.UseBackgroundTint();
        dropdown.alphaFadeSpeed = 0;

        dropdown.ClearOptions();
        dropdown.AddOptions(options);

        if (images != null)
        {
            dropdown.captionImage = popdown.AddImage(new Info("Icon", info.Height)
            {
                Anchor = new Vector2(0, 0.5f),
                Pivot = new Vector2(0, 0.5f)
            }, "").Image;
            text.RectTransform.offsetMin = new Vector2(info.Height + ModHelperWindow.Margin, 0);
            popdown.images = images.ToArray();
        }

        dropdown.onValueChanged.AddListener(new Action<int>(i =>
        {
            onValueChanged?.Invoke(i);
            if (images != null)
            {
                dropdown.captionImage.SetSprite(images.Get(i));
            }

            if (!popdown.autosize) return;

            TaskScheduler.ScheduleTask(() =>
            {
                var desiredWidth =
                    dropdown.captionText.preferredWidth +
                    info.Height * 1.5f +
                    ModHelperWindow.Margin +
                    (dropdown.captionImage == null ? 0 : info.Height + ModHelperWindow.Margin / 2f);
                popdown.LayoutElement.preferredWidth = popdown.LayoutElement.minWidth = desiredWidth;
            });
        }));

        TaskScheduler.ScheduleTask(() =>
        {
            dropdown.onValueChanged.Invoke(dropdown.value);
        }, () => dropdown.transform.parent != null && dropdown.isActiveAndEnabled, stopCondition: () => dropdown == null);

        popdown.Add(menu);

        return popdown;
    }
}