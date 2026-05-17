using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes;
using Il2CppNinjaKiwi.Common;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for GameObjects
/// </summary>
public static class GameObjectExt
{
    /// <summary>
    /// Finds a component with the given path and type
    /// </summary>
    public static T GetComponent<T>(this GameObject gameObject, string componentPath) =>
        gameObject.transform.Find(componentPath).GetComponent<T>();

    /// <summary>
    /// Try to get a component in a child of this GameObject by it's name. Equivelant to a foreach with GetComponentsInChildren
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <param name="componentName"></param>
    /// <returns></returns>
    public static T GetComponentInChildrenByName<T>(this GameObject gameObject, string componentName)
        where T : Component
    {
        return gameObject.transform.GetComponentsInChildren<T>(true)
            .FirstOrDefault(component => component.name == componentName);
    }

    /// <summary>
    /// Makes the Game Object visible by setting the scale to the default value of 1
    /// </summary>
    /// <param name="gameObject"></param>
    public static void Show(this GameObject gameObject)
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
    }

    /// <summary>
    /// Makes the Game Object hidden (not visible) by setting the scale to zero
    /// </summary>
    /// <param name="gameObject"></param>
    public static void Hide(this GameObject gameObject)
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0);
    }

    /// <summary>
    /// Destroys this GameObject
    /// </summary>
    /// <param name="gameObject"></param>
    public static void Destroy(this GameObject gameObject)
    {
        if (gameObject == null)
        {
            ModHelper.Warning("Tried to destroy null game object");
            return;
        }

        Object.Destroy(gameObject);
    }

    /// <summary>
    /// Logs a GameObject's hierarchy recursively
    /// </summary>
    public static void RecursivelyLog(this GameObject gameObject, int depth = 0)
    {
        var str = gameObject.name;
        for (var i = 0; i < depth; i++)
        {
            str = "|  " + str;
        }

        str += " (";
        str = gameObject.GetComponents<Component>()
            .Aggregate(str, (current, component) => current + " " + component.GetIl2CppType().Name);

        str += ")";
        ModHelper.Log(str);
        for (var i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.RecursivelyLog(depth + 1);
        }
    }

    /// <summary>
    /// Translates this GameObject scaled with it's "lossyScale", making it move the same
    /// amount regardless of screen resolution
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="translation"></param>
    public static void TranslateScaled(this GameObject gameObject, Vector3 translation)
    {
        var transform = gameObject.transform;
        transform.TranslateScaled(translation);
    }

    /// <summary>
    /// Removes a Component from a GameObject by destroying it
    /// </summary>
    public static void RemoveComponent<T>(this GameObject gameObject) where T : Component
    {
        gameObject.GetComponent<T>()?.DestroyImmediate();
    }

    /// <summary>
    /// Returns whether a component of the given type exists on a game object
    /// </summary>
    public static bool HasComponent<T>(this GameObject gameObject) where T : Component =>
        gameObject.GetComponent<T>() != null;

    /// <summary>
    /// Returns whether a component of the given type exists on a game object, and puts it in the out param
    /// </summary>
    public static bool HasComponent<T>(this GameObject gameObject, out T component) where T : Component
    {
        component = gameObject.GetComponent<T>();
        return component != null;
    }

    /// <summary>
    /// Instantiate a clone of the GameObject keeping the same parent
    /// </summary>
    public static T Duplicate<T>(this T gameObject) where T : Object
    {
        if (gameObject == null)
        {
            ModHelper.Warning("Tried to duplicate a null Unity Object");
            return null;
        }

        return Object.Instantiate(gameObject);
    }

    /// <summary>
    /// Instantiate a clone of the GameObject with the new transform as parent
    /// </summary>
    public static T Duplicate<T>(this T gameObject, Transform parent) where T : Object
    {
        if (gameObject == null)
        {
            ModHelper.Warning("Tried to duplicate a null Unity Object");
            return null;
        }

        return Object.Instantiate(gameObject, parent);
    }

    /// <summary>
    /// Adds the ModHelperComponent to a parent GameObject, returning the ModHelperComponent
    /// <br />
    /// (This is an extension method just so that we can return the type generically)
    /// </summary>
    public static T AddModHelperComponent<T>(this GameObject gameObject, T modHelperComponent)
        where T : ModHelperComponent
    {
        modHelperComponent.SetParent(gameObject.transform);
        return modHelperComponent;
    }

    /// <summary>
    /// Destroys all children of a game object
    /// </summary>
    public static void DestroyAllChildren(this GameObject gameObject)
    {
        // ReSharper disable once InvokeAsExtensionMethod
        TransformExtensions.DestroyAllChildren(gameObject.transform);
    }

    /// <summary>
    /// Used to null check unity objects without bypassing the lifecycle
    /// </summary>
    public static T Exists<T>(this T obj) where T : Object => obj == null ? null : obj;

    /// <summary>
    /// Used to null check unity objects without bypassing the lifecycle
    /// </summary>
    public static bool Exists<T>(this T obj, out T result) where T : Object
    {
        result = obj;
        return obj != null;
    }

    /// <summary>
    /// Gets the direct children of this gameobject
    /// </summary>
    /// <param name="gameObject">this</param>
    /// <returns></returns>
    public static IEnumerable<GameObject> GetChildren(this GameObject gameObject)
    {
        foreach (var o in gameObject.transform)
        {
            if (o.Is(out Transform transform))
            {
                yield return transform.gameObject;
            }
        }
    }

    /// <summary>
    /// Adds a TSMButton to this with the given buttonId and optional customInputId
    /// </summary>
    /// <param name="gameObject">this</param>
    /// <param name="info">Mod Helper Component info</param>
    /// <param name="sprite">sprite guid for the button</param>
    /// <param name="buttonId">tsm buttonId</param>
    /// <param name="customInputId">optional tsm customInputId</param>
    /// <returns>created TSMButton</returns>
    public static TSMButton AddTSMButton(this GameObject gameObject, Info info, string sprite, string buttonId,
        string customInputId = null)
    {
        var modHelperButton = gameObject.AddButton(info, sprite, null);

        var button = modHelperButton.AddComponent<TSMButton>();
        button.buttonId = buttonId;
        button.canInvokeCustomInput = true;
        button.customInputId = customInputId;
        button.sounds = new Il2CppSystem.Collections.Generic.List<AudioClip>();
        button.soundsRef = new[] {new AudioClipReference(VanillaAudioClips.UIReturn01)}.ToIl2CppList();

        modHelperButton.Button.onClick.SetListener(button.OnButtonPressed);

        return button;
    }

    /// <inheritdoc cref="ModHelperComponent.AddPanel(BTD_Mod_Helper.Api.Components.Info)" />
    public static ModHelperPanel AddModHelperPanel(this GameObject gameObject, Info info,
        string backgroundSprite = null, RectTransform.Axis? layoutAxis = null, float spacing = 50,
        int padding = 0) => gameObject.AddModHelperComponent(ModHelperPanel.Create(info, backgroundSprite, layoutAxis,
        spacing, padding));

    /// <inheritdoc cref="ModHelperComponent.AddScrollPanel(BTD_Mod_Helper.Api.Components.Info)" />
    public static ModHelperScrollPanel AddModHelperScrollPanel(this GameObject gameObject, Info info,
        RectTransform.Axis? axis, string backgroundSprite = null, float spacing = 0, int padding = 0) =>
        gameObject.AddModHelperComponent(ModHelperScrollPanel.Create(info, axis, backgroundSprite, spacing,
            padding));


    /// <inheritdoc cref="ModHelperButton.Create" />
    public static ModHelperButton AddButton(this GameObject gameObject, Info info, string sprite, Action onClick) =>
        gameObject.AddModHelperComponent(ModHelperButton.Create(info, sprite, onClick));

    /// <inheritdoc cref="ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,string)" />
    public static ModHelperImage AddImage(this GameObject gameObject, Info info, string sprite) =>
        gameObject.AddModHelperComponent(ModHelperImage.Create(info, sprite));

    /// <inheritdoc cref="ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,string)" />
    public static ModHelperImage AddImage(this GameObject gameObject, Info info, Sprite sprite) =>
        gameObject.AddModHelperComponent(ModHelperImage.Create(info, sprite));

    #region AddPanel

    /// <inheritdoc cref="ModHelperPanel.Create" />
    public static ModHelperPanel AddPanel(this GameObject gameObject, Info info) => gameObject.AddPanel(info, null);

    /// <inheritdoc cref="ModHelperPanel.Create" />
    public static ModHelperPanel AddPanel(this GameObject gameObject, Info info, string backgroundSprite) =>
        gameObject.AddPanel(info, backgroundSprite, null);

    /// <inheritdoc cref="ModHelperPanel.Create" />
    public static ModHelperPanel AddPanel(this GameObject gameObject, Info info, string backgroundSprite,
        RectTransform.Axis? layoutAxis) => gameObject.AddPanel(info, backgroundSprite, layoutAxis, 0);

    /// <inheritdoc cref="ModHelperPanel.Create" />
    public static ModHelperPanel AddPanel(this GameObject gameObject, Info info, string backgroundSprite,
        RectTransform.Axis? layoutAxis,
        float spacing) => gameObject.AddPanel(info, backgroundSprite, layoutAxis, spacing, 0);

    /// <inheritdoc cref="ModHelperPanel.Create" />
    public static ModHelperPanel AddPanel(this GameObject gameObject, Info info, string backgroundSprite,
        RectTransform.Axis? layoutAxis,
        float spacing, int padding) =>
        gameObject.AddModHelperComponent(ModHelperPanel.Create(info, backgroundSprite, layoutAxis, spacing, padding));

    #endregion

    #region AddScrollPanel

    /// <inheritdoc
    ///     cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)" />
    public static ModHelperScrollPanel AddScrollPanel(this GameObject gameObject, Info info) =>
        gameObject.AddScrollPanel(info, null);

    /// <inheritdoc
    ///     cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)" />
    public static ModHelperScrollPanel AddScrollPanel(this GameObject gameObject, Info info, RectTransform.Axis? axis) =>
        gameObject.AddScrollPanel(info, axis, null);

    /// <inheritdoc
    ///     cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)" />
    public static ModHelperScrollPanel AddScrollPanel(this GameObject gameObject, Info info, RectTransform.Axis? axis,
        string backgroundSprite) => gameObject.AddScrollPanel(info, axis, backgroundSprite, 0);

    /// <inheritdoc
    ///     cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)" />
    public static ModHelperScrollPanel AddScrollPanel(this GameObject gameObject, Info info, RectTransform.Axis? axis,
        string backgroundSprite,
        float spacing) => gameObject.AddScrollPanel(info, axis, backgroundSprite, spacing, 0);

    /// <inheritdoc
    ///     cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)" />
    public static ModHelperScrollPanel AddScrollPanel(this GameObject gameObject, Info info, RectTransform.Axis? axis,
        string backgroundSprite,
        float spacing, int padding) =>
        gameObject.AddModHelperComponent(ModHelperScrollPanel.Create(info, axis, backgroundSprite, spacing, padding));

    #endregion

    #region AddText

    /// <inheritdoc cref="ModHelperText.Create" />
    public static ModHelperText AddText(this GameObject gameObject, Info info, string text) =>
        gameObject.AddText(info, text, ModHelperComponent.DefaultFontSize);

    /// <inheritdoc cref="ModHelperText.Create" />
    public static ModHelperText AddText(this GameObject gameObject, Info info, string text, float fontSize) =>
        gameObject.AddText(info, text, fontSize, ModHelperComponent.DefaultTextAlignment);

    /// <inheritdoc cref="ModHelperText.Create" />
    public static ModHelperText AddText(this GameObject gameObject, Info info, string text, float fontSize,
        TextAlignmentOptions align) =>
        gameObject.AddModHelperComponent(ModHelperText.Create(info, text, fontSize, align));

    #endregion

    #region AddDropdown

    /// <inheritdoc cref="ModHelperDropdown.Create" />
    public static ModHelperDropdown AddDropdown(this GameObject gameObject, Info info,
        Il2CppSystem.Collections.Generic.List<string> options, float windowHeight,
        UnityAction<int> onValueChanged) => gameObject.AddDropdown(info, options, windowHeight, onValueChanged, null);

    /// <inheritdoc cref="ModHelperDropdown.Create" />
    public static ModHelperDropdown AddDropdown(this GameObject gameObject, Info info,
        Il2CppSystem.Collections.Generic.List<string> options, float windowHeight,
        UnityAction<int> onValueChanged, string background) => gameObject.AddDropdown(info, options, windowHeight,
        onValueChanged, background, ModHelperComponent.DefaultFontSize);

    /// <inheritdoc cref="ModHelperDropdown.Create" />
    public static ModHelperDropdown AddDropdown(this GameObject gameObject, Info info,
        Il2CppSystem.Collections.Generic.List<string> options, float windowHeight,
        UnityAction<int> onValueChanged, string background, float labelFontSize) => gameObject.AddModHelperComponent(
        ModHelperDropdown.Create(info, options, windowHeight, onValueChanged, background, labelFontSize));

    #endregion

    #region AddSlider

    /// <inheritdoc cref="ModHelperSlider.Create" />
    public static ModHelperSlider AddSlider(this GameObject gameObject, Info info, float defaultValue, float minValue,
        float maxValue, float stepSize,
        Vector2 handleSize) => gameObject.AddSlider(info, defaultValue, minValue, maxValue, stepSize, handleSize, null);

    /// <inheritdoc cref="ModHelperSlider.Create" />
    public static ModHelperSlider AddSlider(this GameObject gameObject, Info info, float defaultValue, float minValue,
        float maxValue,
        float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged) => gameObject.AddSlider(info, defaultValue,
        minValue,
        maxValue, stepSize, handleSize, onValueChanged, ModHelperComponent.DefaultFontSize);

    /// <inheritdoc cref="ModHelperSlider.Create" />
    public static ModHelperSlider AddSlider(this GameObject gameObject, Info info, float defaultValue, float minValue,
        float maxValue,
        float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize) => gameObject.AddSlider(info,
        defaultValue, minValue, maxValue, stepSize, handleSize, onValueChanged, fontSize, "");

    /// <inheritdoc cref="ModHelperSlider.Create" />
    public static ModHelperSlider AddSlider(this GameObject gameObject, Info info, float defaultValue, float minValue,
        float maxValue, float stepSize,
        Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize, string labelSuffix) =>
        gameObject.AddModHelperComponent(
            ModHelperSlider.Create(info, defaultValue, minValue, maxValue, stepSize, handleSize, onValueChanged,
                fontSize, labelSuffix));

    /// <inheritdoc cref="ModHelperSlider.Create" />
    public static ModHelperSlider AddSlider(this GameObject gameObject, Info info, float defaultValue, float minValue,
        float maxValue, float stepSize,
        Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize, string labelSuffix, float startingValue) =>
        gameObject.AddModHelperComponent(ModHelperSlider.Create(info, defaultValue, minValue, maxValue, stepSize, handleSize,
            onValueChanged,
            fontSize, labelSuffix, startingValue));

    #endregion

    #region AddCheckbox

    /// <inheritdoc cref="ModHelperCheckbox.Create" />
    public static ModHelperCheckbox
        AddCheckbox(this GameObject gameObject, Info info, bool defaultValue, string background) =>
        gameObject.AddCheckbox(info, defaultValue, background, null);

    /// <inheritdoc cref="ModHelperCheckbox.Create" />
    public static ModHelperCheckbox AddCheckbox(this GameObject gameObject, Info info, bool defaultValue, string background,
        UnityAction<bool> onValueChanged) => gameObject.AddCheckbox(info, defaultValue, background, onValueChanged, null);

    /// <inheritdoc cref="ModHelperCheckbox.Create" />
    public static ModHelperCheckbox AddCheckbox(this GameObject gameObject, Info info, bool defaultValue, string background,
        UnityAction<bool> onValueChanged, string checkImage) =>
        gameObject.AddCheckbox(info, defaultValue, background, onValueChanged, checkImage, 20);

    /// <inheritdoc cref="ModHelperCheckbox.Create" />
    public static ModHelperCheckbox AddCheckbox(this GameObject gameObject, Info info, bool defaultValue, string background,
        UnityAction<bool> onValueChanged, string checkImage, int padding) =>
        gameObject.AddModHelperComponent(ModHelperCheckbox.Create(info, defaultValue, background, onValueChanged, checkImage,
            padding));

    #endregion

    #region AddInputField

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public static ModHelperInputField AddInputField(this GameObject gameObject, Info info, string defaultValue,
        string background) => gameObject.AddInputField(info, defaultValue, background, null);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public static ModHelperInputField AddInputField(this GameObject gameObject, Info info, string defaultValue,
        string background,
        UnityAction<string> onValueChanged) => gameObject.AddInputField(info, defaultValue, background, onValueChanged,
        ModHelperComponent.DefaultFontSize);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public static ModHelperInputField AddInputField(this GameObject gameObject, Info info, string defaultValue,
        string background,
        UnityAction<string> onValueChanged, float fontSize) => gameObject.AddInputField(info, defaultValue, background,
        onValueChanged, fontSize, TMP_InputField.CharacterValidation.None);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public static ModHelperInputField AddInputField(this GameObject gameObject, Info info, string defaultValue,
        string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation) =>
        gameObject.AddInputField(info, defaultValue, background, onValueChanged, fontSize, validation,
            ModHelperComponent.DefaultTextAlignment);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public static ModHelperInputField AddInputField(this GameObject gameObject, Info info, string defaultValue,
        string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation,
        TextAlignmentOptions align) => gameObject.AddInputField(info, defaultValue, background, onValueChanged, fontSize,
        validation, align, null);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public static ModHelperInputField AddInputField(this GameObject gameObject, Info info, string defaultValue,
        string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation,
        TextAlignmentOptions align, string placeholder) => gameObject.AddInputField(info, defaultValue, background,
        onValueChanged,
        fontSize, validation, align, placeholder,
        0);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public static ModHelperInputField AddInputField(this GameObject gameObject, Info info, string defaultValue,
        string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation,
        TextAlignmentOptions align, string placeholder, int padding) => gameObject.AddModHelperComponent(
        ModHelperInputField.Create(info,
            defaultValue, background, onValueChanged, fontSize, validation, align, placeholder, padding));

    #endregion



}