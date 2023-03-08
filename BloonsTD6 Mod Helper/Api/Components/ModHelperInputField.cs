using System;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent for a text input field
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperInputField : ModHelperComponent
{
    /// <summary>
    /// The InputField component
    /// </summary>
    public NK_TextMeshProInputField InputField => GetComponent<NK_TextMeshProInputField>();

    /// <summary>
    /// The Text ModHelperComponent
    /// </summary>
    public ModHelperText Text => GetDescendent<ModHelperText>("Text");

    /// <summary>
    /// Gets the current value of the InputField
    /// </summary>
    public string CurrentValue => Text.Text.text;

    /// <summary>
    /// Sets the current value of this
    /// </summary>
    /// <param name="text">The new text</param>
    /// <param name="sendCallback">Whether the onValueChanged listener should fire</param>
    public void SetText(string text, bool sendCallback = true)
    {
        InputField.SetText(text, sendCallback);
    }

    /// <inheritdoc />
    public ModHelperInputField(IntPtr ptr) : base(ptr)
    {
    }

    /// <summary>
    /// Creates a new ModHelperInputField
    /// </summary>
    /// <param name="info">The name/position/size info</param>
    /// <param name="defaultValue">The default text that's in the field</param>
    /// <param name="background">The sprite for the background panel</param>
    /// <param name="onValueChanged">An action to be called when the text is changed</param>
    /// <param name="fontSize">The size of the displayed text</param>
    /// <param name="validation">The type of validation used on user input</param>
    /// <param name="align">The alignment of the text</param>
    /// <param name="placeholder"></param>
    /// <param name="padding"></param>
    /// <returns>The created ModHelperInputField</returns>
    /// <exclude/>
    public static ModHelperInputField Create(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged = null, float fontSize = 42,
        TMP_InputField.CharacterValidation validation = TMP_InputField.CharacterValidation.None,
        TextAlignmentOptions align = TextAlignmentOptions.Capline, string placeholder = null, int padding = 0)
    {
        var modHelperInputField = Create<ModHelperInputField>(info);
        modHelperInputField.AddComponent<Mask>();


        var backgroundImage = modHelperInputField.AddComponent<Image>();
        backgroundImage.type = Image.Type.Sliced;
        backgroundImage.SetSprite(background);

        var textViewPort = modHelperInputField.AddPanel(new Info("TextViewport", InfoPreset.FillParent));

        var text = textViewPort.AddText(new Info("Text", InfoPreset.FillParent)
        {
            Width = padding * -2
        }, defaultValue, fontSize, align);
        text.Text.overflowMode = TextOverflowModes.Masking;
        text.Text.font = Fonts.Btd6FontBody;


        var inputField = modHelperInputField.AddComponent<NK_TextMeshProInputField>();
        inputField.characterValidation = validation;
        inputField.textComponent = text.Text;
        inputField.textViewport = textViewPort;
        inputField.caretWidth = 5;

        if (placeholder != null)
        {
            var placeholderText = textViewPort.AddText(new Info("Placeholder", InfoPreset.FillParent)
            {
                Width = padding * -2
            }, placeholder, fontSize, align);
            placeholderText.Text.overflowMode = TextOverflowModes.Masking;
            placeholderText.Text.font = Fonts.Btd6FontBody;
            inputField.placeholder = placeholderText.Text;
            placeholderText.Text.color = new Color(1, 1, 1, .5f);
        }

        if (onValueChanged != null)
        {
            inputField.onValueChanged.AddListener(onValueChanged);
        }

        inputField.SetText(defaultValue);

        inputField.enabled = false;

        return modHelperInputField;
    }


    /// <inheritdoc />
    protected override void OnUpdate()
    {
        InputField.enabled = true;
    }
}