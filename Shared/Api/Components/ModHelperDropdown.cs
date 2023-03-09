using System;
using BTD_Mod_Helper.Api.Enums;
using Il2CppSystem.Collections.Generic;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent for a 
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperDropdown : ModHelperComponent
{
    /// <summary>
    /// The Image being displayed
    /// </summary>
    public Image Background => GetComponent<Image>();

#if BloonsTD6
    /// <summary>
    /// The Text which shows the currently selected value
    /// </summary>
    public ModHelperText Text => GetDescendent<ModHelperText>("DropdownText");
#endif

    /// <summary>
    /// The component which handles the dropdown
    /// </summary>
    public TMP_Dropdown Dropdown => GetComponent<TMP_Dropdown>();

    /// <summary>
    /// The Arrow image
    /// </summary>
    public ModHelperImage Arrow => GetDescendent<ModHelperImage>("Arrow");

    /// <summary>
    /// The template object for the window of the dropdown
    /// </summary>
    public ModHelperScrollPanel TemplatePanel => GetDescendent<ModHelperScrollPanel>("Template");

    /// <summary>
    /// The default item in the template
    /// </summary>
    public ModHelperPanel TemplateItem => TemplatePanel.GetDescendent<ModHelperPanel>("Item");

    /// <inheritdoc />
    public ModHelperDropdown(IntPtr ptr) : base(ptr)
    {
    }


    /// <summary>
    /// Creates a new ModHelperDropdown
    /// </summary>
    /// <param name="info">The name/position/size info. NOTE: width/height must be set to actual values</param>
    /// <param name="options">The list of options</param>
    /// <param name="windowHeight">Height of the created dropdown window</param>
    /// <param name="onValueChanged">Action that should happen when an option of the given index is selected</param>
    /// <param name="background">The background image</param>
    /// <param name="labelFontSize">Text size of label</param>
    /// <returns>The created ModHelperDropdown</returns>
    public static ModHelperDropdown Create(Info info, List<string> options, float windowHeight,
        UnityAction<int> onValueChanged, string background = null, float labelFontSize = 42f)
    {
        var (width, height) = info.SizeDelta;

        var contentHeight = options.Count * height;
        var realHeight = Math.Min(windowHeight, contentHeight);

        var modHelperDropdown = Create<ModHelperDropdown>(info);

#if BloonsTD6
        modHelperDropdown.AddImage(
            new Info("Arrow", -64, 0, 64, 40, anchor: new Vector2(1, 0.5f)), VanillaSprites.MonkeyKnowledgeArrow
        );

        var text = modHelperDropdown.AddText(new Info("DropdownText", InfoPreset.FillParent), "", labelFontSize);

        var dropdown = modHelperDropdown.AddComponent<TMP_Dropdown>();
        dropdown.captionText = text.Text;
#elif BloonsAT
            throw new NotImplementedException(); // need to get ModHelperText working for BloonsAT
#endif
        dropdown.ClearOptions();
        dropdown.AddOptions(options);

        if (onValueChanged != null)
        {
            dropdown.onValueChanged.AddListener(onValueChanged);
        }

        if (background != null)
        {
            var image = dropdown.image = modHelperDropdown.AddComponent<Image>();
            image.SetSprite(background);
            image.type = Image.Type.Sliced;
        }

#if BloonsTD6
        var template = modHelperDropdown.AddScrollPanel(
            new Info("Template", 0, height / -2 - realHeight / 2, width, realHeight),
            RectTransform.Axis.Vertical, VanillaSprites.UISprite);
#elif BloonsAT
            // Need to figure out how to get the Vanilla Sprites mentioned above for BloonsAT
            throw new NotImplementedException();
#endif

        template.Background.color = new Color(0.262f, 0.435f, 0.658f);
        dropdown.template = template;
        template.disableNextFrame = true;

        var item =
            ModHelperPanel.Create(new Info("Item", width: width, height: height));
        var toggle = item.AddComponent<Toggle>();
        toggle.transition = (Selectable.Transition) Toggle.ToggleTransition.Fade;

        var itemBackground = item.AddPanel(new Info("ItemBackground", width: width, height: height));
        var backgroundImage = itemBackground.AddComponent<Image>();
        backgroundImage.color = new Color(0.219f, 0.364f, 0.552f);

        var itemSelected = item.AddPanel(new Info("ItemSelected", width: width, height: height));
        var selectedImage = toggle.graphic = itemSelected.AddComponent<Image>();
        selectedImage.color = new Color(0.591f, 1, 0);

#if BloonsTD6
        var itemLabel = item.AddText(new Info("ItemLabel", width: width, height: height), "", labelFontSize);

        dropdown.itemText = itemLabel.Text;
#endif

        template.AddScrollContent(item);

        return modHelperDropdown;
    }
}