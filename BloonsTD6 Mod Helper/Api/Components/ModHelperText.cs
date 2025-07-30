using System;
using Il2CppNinjaKiwi.Common;
using Il2CppTMPro;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent for a background panel
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperText : ModHelperComponent
{
    /// <summary>
    /// Makes the width of this object scale with the text its holding
    /// </summary>
    public bool SizingWidthToText { get; set; }

    /// <inheritdoc />
    public ModHelperText(IntPtr ptr) : base(ptr)
    {
    }

    /// <summary>
    /// The component that handles the Text rendering
    /// </summary>
    public NK_TextMeshProUGUI Text => GetComponent<NK_TextMeshProUGUI>();

    /// <summary>
    /// Sets the text of this text to the given text
    /// </summary>
    public void SetText(string text)
    {
        if (Text.AutoLocalize)
        {
            Text.localizeKey = text;
            Text.SetText(text.Localize());
        }
        else
        {
            Text.SetText(text);
        }
    }

    /// <inheritdoc />
    protected override void OnUpdate()
    {
        if (!SizingWidthToText) return;

        if (LayoutElement is { } layoutElement)
        {
            layoutElement.minWidth = Text.minWidth;
            layoutElement.preferredWidth = Text.preferredWidth;
        }
        else
        {
            RectTransform.sizeDelta = RectTransform.sizeDelta with
            {
                x = Text.preferredWidth
            };
        }
    }

    /// <summary>
    /// Creates a new ModHelperText
    /// </summary>
    /// <param name="info">The name/position/size info</param>
    /// <param name="text">The text to display</param>
    /// <param name="fontSize">Size of font</param>
    /// <param name="align">Alignment of text</param>
    /// <returns>The created ModHelperText</returns>
    public static ModHelperText Create(Info info, string text, float fontSize = 42,
        TextAlignmentOptions align = DefaultTextAlignment)
    {
        var modHelperText = Create<ModHelperText>(info);

        var textMesh = modHelperText.AddComponent<NK_TextMeshProUGUI>();

        textMesh.AutoLocalize = true;
        textMesh.localizeKey = text;
        textMesh.SetText(text.Localize());
        textMesh.alignment = align;
        textMesh.fontSize = fontSize;
        textMesh.font = Fonts.Btd6FontTitle;
        textMesh.overflowMode = TextOverflowModes.Ellipsis;
        textMesh.lineSpacing = fontSize / 2;
        textMesh.parseCtrlCharacters = false;

        return modHelperText;
    }


    /// <summary>
    /// Enables auto sizing for this <see cref="Text"/> component
    /// </summary>
    public void EnableAutoSizing()
    {
        Text.enableAutoSizing = true;
    }

    /// <summary>
    /// Enables or disables auto sizing for this <see cref="Text"/> component
    /// </summary>
    public void EnableAutoSizing(bool enable)
    {
        Text.enableAutoSizing = enable;
    }

    /// <summary>
    /// Enables auto sizing for this <see cref="Text"/> component
    /// </summary>
    public void EnableAutoSizing(float fontSizeMax)
    {
        Text.enableAutoSizing = true;
        Text.fontSizeMax = fontSizeMax;
    }

    /// <summary>
    /// Enables auto sizing for <see cref="Text"/> 
    /// </summary>
    public void EnableAutoSizing(float fontSizeMax, float fontSizeMin)
    {
        Text.enableAutoSizing = true;
        Text.fontSizeMax = fontSizeMax;
        Text.fontSizeMin = fontSizeMin;
    }

    /// <summary>
    /// Makes the width of this object scale with the text its holding
    /// </summary>
    public void SizeWidthToText(bool sizeWidthToText = true)
    {
        SizingWidthToText = sizeWidthToText;
        if (sizeWidthToText) OnUpdate();
    }
}