using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;
namespace BTD_Mod_Helper.Api.Components;

// We're using method overloading instead of optional parameters to avoid breakage when new parameters need to be added
public partial class ModHelperComponent
{
    /// <inheritdoc cref="ModHelperButton.Create"/>
    public ModHelperButton AddButton(Info info, string sprite, Action onClick) =>
        Add(ModHelperButton.Create(info, sprite, onClick));

    /// <inheritdoc cref="ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,string)"/>
    public ModHelperImage AddImage(Info info, string sprite) => Add(ModHelperImage.Create(info, sprite));

    /// <inheritdoc cref="ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,string)"/>
    public ModHelperImage AddImage(Info info, Sprite sprite) => Add(ModHelperImage.Create(info, sprite));

    #region AddPanel

    /// <inheritdoc cref="ModHelperPanel.Create"/>
    public ModHelperPanel AddPanel(Info info) => AddPanel(info, null);

    /// <inheritdoc cref="ModHelperPanel.Create"/>
    public ModHelperPanel AddPanel(Info info, string backgroundSprite) =>
        AddPanel(info, backgroundSprite, null);

    /// <inheritdoc cref="ModHelperPanel.Create"/>
    public ModHelperPanel AddPanel(Info info, string backgroundSprite, RectTransform.Axis? layoutAxis) =>
        AddPanel(info, backgroundSprite, layoutAxis, 0);

    /// <inheritdoc cref="ModHelperPanel.Create"/>
    public ModHelperPanel AddPanel(Info info, string backgroundSprite, RectTransform.Axis? layoutAxis,
        float spacing) => AddPanel(info, backgroundSprite, layoutAxis, spacing, 0);

    /// <inheritdoc cref="ModHelperPanel.Create"/>
    public ModHelperPanel AddPanel(Info info, string backgroundSprite, RectTransform.Axis? layoutAxis,
        float spacing, int padding) => Add(ModHelperPanel.Create(info, backgroundSprite, layoutAxis, spacing, padding));

    #endregion

    #region AddScrollPanel

    /// <inheritdoc cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)"/>
    public ModHelperScrollPanel AddScrollPanel(Info info) => AddScrollPanel(info, null);

    /// <inheritdoc cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)"/>
    public ModHelperScrollPanel AddScrollPanel(Info info, RectTransform.Axis? axis) => AddScrollPanel(info, axis, null);

    /// <inheritdoc cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)"/>
    public ModHelperScrollPanel AddScrollPanel(Info info, RectTransform.Axis? axis, string backgroundSprite) =>
        AddScrollPanel(info, axis, backgroundSprite, 0);

    /// <inheritdoc cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)"/>
    public ModHelperScrollPanel AddScrollPanel(Info info, RectTransform.Axis? axis, string backgroundSprite,
        float spacing) => AddScrollPanel(info, axis, backgroundSprite, spacing, 0);

    /// <inheritdoc cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)"/>
    public ModHelperScrollPanel AddScrollPanel(Info info, RectTransform.Axis? axis, string backgroundSprite,
        float spacing, int padding) => Add(ModHelperScrollPanel.Create(info, axis, backgroundSprite, spacing, padding));

    #endregion

    #region AddText

    /// <inheritdoc cref="ModHelperText.Create"/>
    public ModHelperText AddText(Info info, string text) => AddText(info, text, DefaultFontSize);

    /// <inheritdoc cref="ModHelperText.Create"/>
    public ModHelperText AddText(Info info, string text, float fontSize) =>
        AddText(info, text, fontSize, DefaultTextAlignment);

    /// <inheritdoc cref="ModHelperText.Create"/>
    public ModHelperText AddText(Info info, string text, float fontSize, TextAlignmentOptions align) =>
        Add(ModHelperText.Create(info, text, fontSize, align));

    #endregion

    #region AddDropdown

    /// <inheritdoc cref="ModHelperDropdown.Create"/>
    public ModHelperDropdown AddDropdown(Info info, List<string> options, float windowHeight,
        UnityAction<int> onValueChanged) => AddDropdown(info, options, windowHeight, onValueChanged, null);

    /// <inheritdoc cref="ModHelperDropdown.Create"/>
    public ModHelperDropdown AddDropdown(Info info, List<string> options, float windowHeight,
        UnityAction<int> onValueChanged, string background) =>
        AddDropdown(info, options, windowHeight, onValueChanged, background, DefaultFontSize);

    /// <inheritdoc cref="ModHelperDropdown.Create"/>
    public ModHelperDropdown AddDropdown(Info info, List<string> options, float windowHeight,
        UnityAction<int> onValueChanged, string background, float labelFontSize) =>
        Add(ModHelperDropdown.Create(info, options, windowHeight, onValueChanged, background, labelFontSize));

    #endregion

    #region AddSlider

    /// <inheritdoc cref="ModHelperSlider.Create"/>
    public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue, float stepSize,
        Vector2 handleSize) => AddSlider(info, defaultValue, minValue, maxValue, stepSize, handleSize, null);

    /// <inheritdoc cref="ModHelperSlider.Create"/>
    public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue,
        float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged) =>
        AddSlider(info, defaultValue, minValue, maxValue, stepSize, handleSize, onValueChanged, DefaultFontSize);

    /// <inheritdoc cref="ModHelperSlider.Create"/>
    public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue,
        float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize) =>
        AddSlider(info, defaultValue, minValue, maxValue, stepSize, handleSize, onValueChanged, fontSize, "");

    /// <inheritdoc cref="ModHelperSlider.Create"/>
    public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue, float stepSize,
        Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize, string labelSuffix) =>
        Add(ModHelperSlider.Create(info, defaultValue, minValue, maxValue, stepSize, handleSize, onValueChanged,
            fontSize, labelSuffix));
    
    /// <inheritdoc cref="ModHelperSlider.Create"/>
    public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue, float stepSize,
        Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize, string labelSuffix, float startingValue) =>
        Add(ModHelperSlider.Create(info, defaultValue, minValue, maxValue, stepSize, handleSize, onValueChanged,
            fontSize, labelSuffix, startingValue));

    #endregion

    #region AddCheckbox

    /// <inheritdoc cref="ModHelperCheckbox.Create"/>
    public ModHelperCheckbox AddCheckbox(Info info, bool defaultValue, string background) =>
        AddCheckbox(info, defaultValue, background, null);

    /// <inheritdoc cref="ModHelperCheckbox.Create"/>
    public ModHelperCheckbox AddCheckbox(Info info, bool defaultValue, string background,
        UnityAction<bool> onValueChanged) => AddCheckbox(info, defaultValue, background, onValueChanged, null);

    /// <inheritdoc cref="ModHelperCheckbox.Create"/>
    public ModHelperCheckbox AddCheckbox(Info info, bool defaultValue, string background,
        UnityAction<bool> onValueChanged, string checkImage) =>
        AddCheckbox(info, defaultValue, background, onValueChanged, checkImage, 20);

    /// <inheritdoc cref="ModHelperCheckbox.Create"/>
    public ModHelperCheckbox AddCheckbox(Info info, bool defaultValue, string background,
        UnityAction<bool> onValueChanged, string checkImage, int padding) =>
        Add(ModHelperCheckbox.Create(info, defaultValue, background, onValueChanged, checkImage, padding));

    #endregion

    #region AddInputField

    /// <inheritdoc cref="ModHelperInputField.Create"/>
    /// <exclude/>
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background) =>
        AddInputField(info, defaultValue, background, null);

    /// <inheritdoc cref="ModHelperInputField.Create"/>
    /// <exclude/>
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged) =>
        AddInputField(info, defaultValue, background, onValueChanged, DefaultFontSize);

    /// <inheritdoc cref="ModHelperInputField.Create"/>
    /// <exclude/>
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged, float fontSize) => AddInputField(info, defaultValue, background,
        onValueChanged, fontSize, TMP_InputField.CharacterValidation.None);

    /// <inheritdoc cref="ModHelperInputField.Create"/>
    /// <exclude/>
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation) =>
        AddInputField(info, defaultValue, background, onValueChanged, fontSize, validation, DefaultTextAlignment);

    /// <inheritdoc cref="ModHelperInputField.Create"/>
    /// <exclude/>
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation,
        TextAlignmentOptions align) =>
        AddInputField(info, defaultValue, background, onValueChanged, fontSize, validation, align, null);

    /// <inheritdoc cref="ModHelperInputField.Create"/>
    /// <exclude/>
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation,
        TextAlignmentOptions align, string placeholder) =>
        AddInputField(info, defaultValue, background, onValueChanged, fontSize, validation, align, placeholder, 0);

    /// <inheritdoc cref="ModHelperInputField.Create"/>
    /// <exclude/>
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation,
        TextAlignmentOptions align, string placeholder, int padding) => Add(ModHelperInputField.Create(info,
        defaultValue, background, onValueChanged, fontSize, validation, align, placeholder, padding));

    #endregion
}