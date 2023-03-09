using System;
using Il2CppTMPro;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent for a background panel
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperText : ModHelperComponent
{
    /// <summary>
    /// The component that handles the Text rendering
    /// </summary>
    public NK_TextMeshProUGUI Text => GetComponent<NK_TextMeshProUGUI>();


    /// <inheritdoc />
    public ModHelperText(IntPtr ptr) : base(ptr)
    {
    }

    /// <summary>
    /// Sets the text of this text to the given text
    /// </summary>
    public void SetText(string text)
    {
        Text.SetText(text);
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

        textMesh.SetText(text);
        textMesh.alignment = align;
        textMesh.fontSize = fontSize;
        textMesh.font = Fonts.Btd6FontTitle;
        textMesh.overflowMode = TextOverflowModes.Ellipsis;
        textMesh.lineSpacing = fontSize / 2;

        return modHelperText;
    }
}