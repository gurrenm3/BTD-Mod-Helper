using System;
using BTD_Mod_Helper.Api.UI;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppInterop.Runtime;
using Il2CppSystem.Collections.Generic;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Action = Il2CppSystem.Action;
using Object = UnityEngine.Object;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// Base for a helper component for making custom UIs in the same style as Vanilla ones
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperComponent : MonoBehaviour
{
    /// <summary>
    /// Default font size for UI labels
    /// </summary>
    public const float DefaultFontSize = 42f;

    /// <summary>
    /// Default alignment for texts and input fields
    /// </summary>
    public const TextAlignmentOptions DefaultTextAlignment = TextAlignmentOptions.Midline;

    /// <summary>
    /// Bool for if this should disable itself on the next frame
    /// </summary>
    public bool disableNextFrame;

    /// <summary>
    /// Bool for if this should enable itself on the next frame
    /// </summary>
    public bool enableNextFrame;

    /// <summary>
    /// The ModHelperComponent that this is a child of, if any
    /// </summary>
    public ModHelperComponent parent;

    /// <summary>
    /// The Info object that this was defined with, determining its initial name, position and size
    /// </summary>
    public Info initialInfo;

    /// <inheritdoc />
    public ModHelperComponent(IntPtr ptr) : base(ptr)
    {
    }

    /// <summary>
    /// The RectTransform for this GameObject
    /// </summary>
    public RectTransform RectTransform => transform.Cast<RectTransform>();

    /// <summary>
    /// The LayoutElement component, if this has been assigned one
    /// </summary>
    public LayoutElement LayoutElement => GetComponent<LayoutElement>();

    /// <summary>
    /// The LayoutGroup component, if this has been assigned one
    /// </summary>
    public HorizontalOrVerticalLayoutGroup LayoutGroup => GetComponent<HorizontalOrVerticalLayoutGroup>();

    private void Update()
    {
        if (disableNextFrame)
        {
            disableNextFrame = false;
            gameObject.SetActive(false);
        }

        OnUpdate();
    }

    /// <summary>
    /// Sets a particular transform to be the parent of this
    /// </summary>
    public void SetParent(Transform newParent)
    {
        var t = transform;
        // t.parent = newParent;
        t.SetParent(newParent, false);
        initialInfo.Apply(RectTransform);
    }

    /// <summary>
    /// Sets a particular ModHelperComponent to be the parent of this
    /// </summary>
    public void SetParent(ModHelperComponent newParent)
    {
        parent = newParent;

        if (newParent.GetComponent<LayoutGroup>() != null && !gameObject.HasComponent<ContentSizeFitter>())
        {
            AddLayoutElement();
        }

        SetParent(newParent.transform);
    }

    /// <summary>
    /// Adds another ModHelperComponent as a child of this, returning the child
    /// </summary>
    public T Add<T>(T child) where T : ModHelperComponent
    {
        child.SetParent(this);
        return child;
    }

    /// <inheritdoc cref="GameObject.AddComponent{T}" />
    public T AddComponent<T>() where T : Component => gameObject.AddComponent<T>();

    /// <inheritdoc cref="GameObjectExt.RemoveComponent{T}" />
    public void RemoveComponent<T>() where T : Component
    {
        gameObject.RemoveComponent<T>();
    }

    /// <summary>
    /// Adds and returns a LayoutElement for this, making it work as part of a LayoutGroup
    /// </summary>
    public LayoutElement AddLayoutElement()
    {
        if (LayoutElement == null)
        {
            AddComponent<LayoutElement>();
        }

        LayoutElement!.minWidth = LayoutElement.preferredWidth = initialInfo.SizeDelta.x;
        LayoutElement.minHeight = LayoutElement.preferredHeight = initialInfo.SizeDelta.y;
        LayoutElement.flexibleWidth = initialInfo.FlexWidth;
        LayoutElement.flexibleHeight = initialInfo.FlexHeight;

        return LayoutElement;
    }

    /// <summary>
    /// Adds and returns a ContentSizeFitter with the given properties
    /// </summary>
    public ContentSizeFitter FitContent(
        ContentSizeFitter.FitMode horizontal = ContentSizeFitter.FitMode.Unconstrained,
        ContentSizeFitter.FitMode vertical = ContentSizeFitter.FitMode.Unconstrained)
    {
        var contentSizeFitter = AddComponent<ContentSizeFitter>();
        contentSizeFitter.horizontalFit = horizontal;
        contentSizeFitter.verticalFit = vertical;

        if (LayoutElement != null)
        {
            LayoutElement.enabled = false;
        }

        return contentSizeFitter;
    }

    /// <summary>
    /// Gets a descendent component with the given name
    /// </summary>
    public T GetDescendent<T>(string s = "") where T : Component => string.IsNullOrEmpty(s)
                                                                        ? gameObject.GetComponentInChildren<T>()
                                                                        : gameObject.GetComponentInChildrenByName<T>(s);

    /// <summary>
    /// Sets whether or not this is active
    /// </summary>
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    internal static T Create<T>(Info info) where T : ModHelperComponent
    {
        var newGameObject = new GameObject(info.Name, Il2CppType.Of<RectTransform>())
        {
            layer = CommonLayerNames.kUI
        };
        var modHelperComponent = newGameObject.AddComponent<T>();
        modHelperComponent.initialInfo = info;
        info.Apply(modHelperComponent);

        return modHelperComponent;
    }

    /// <summary>
    /// Applies the properties of an info struct to this
    /// </summary>
    public void SetInfo(Info newInfo)
    {
        initialInfo = newInfo;
        newInfo.Apply(this);
    }

    /// <summary>
    /// Unity Component OnUpdate
    /// </summary>
    protected virtual void OnUpdate()
    {
    }

    /// <summary>
    /// Unity Component OnDestroy
    /// </summary>
    protected virtual void OnDestroy()
    {
        if (gameObject.HasComponent(out Button button))
        {
            button.onClick.RemoveAllListeners();
        }

        if (gameObject.HasComponent(out Toggle toggle))
        {
            toggle.onValueChanged.RemoveAllListeners();
        }

        if (gameObject.HasComponent(out Slider slider))
        {
            slider.onValueChanged.RemoveAllListeners();
        }

        if (gameObject.HasComponent(out Dropdown dropdown))
        {
            dropdown.onValueChanged.RemoveAllListeners();
        }

        if (gameObject.HasComponent(out InputField inputField))
        {
            inputField.onValueChanged.RemoveAllListeners();
        }

        if (gameObject.HasComponent(out Scrollbar scrollbar))
        {
            scrollbar.onValueChanged.RemoveAllListeners();
        }

        if (gameObject.HasComponent(out ScrollRect scrollRect))
        {
            scrollRect.onValueChanged.RemoveAllListeners();
        }
    }

    /// <summary>
    /// Deletes the underlying GameObject this is attached to, not just the component
    /// </summary>
    public void DeleteObject()
    {
        gameObject.Destroy();
    }

    /// <summary>
    /// Implicitly get the gameObject
    /// </summary>
    public static implicit operator GameObject(ModHelperComponent component) => component.gameObject;

    /// <summary>
    /// Implicitly get the RectTransform
    /// </summary>
    public static implicit operator RectTransform(ModHelperComponent component) => component.RectTransform;

    /// <inheritdoc cref="ModHelperButton.Create" />
    public ModHelperButton AddButton(Info info, string sprite, Action onClick) =>
        Add(ModHelperButton.Create(info, sprite, onClick));

    /// <inheritdoc cref="ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,string)" />
    public ModHelperImage AddImage(Info info, string sprite) => Add(ModHelperImage.Create(info, sprite));

    /// <inheritdoc cref="ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,string)" />
    public ModHelperImage AddImage(Info info, Sprite sprite) => Add(ModHelperImage.Create(info, sprite));

    #region AddPanel

    /// <inheritdoc cref="ModHelperPanel.Create" />
    public ModHelperPanel AddPanel(Info info) => AddPanel(info, null);

    /// <inheritdoc cref="ModHelperPanel.Create" />
    public ModHelperPanel AddPanel(Info info, string backgroundSprite) => AddPanel(info, backgroundSprite, null);

    /// <inheritdoc cref="ModHelperPanel.Create" />
    public ModHelperPanel AddPanel(Info info, string backgroundSprite, RectTransform.Axis? layoutAxis) =>
        AddPanel(info, backgroundSprite, layoutAxis, 0);

    /// <inheritdoc cref="ModHelperPanel.Create" />
    public ModHelperPanel AddPanel(Info info, string backgroundSprite, RectTransform.Axis? layoutAxis,
        float spacing) => AddPanel(info, backgroundSprite, layoutAxis, spacing, 0);

    /// <inheritdoc cref="ModHelperPanel.Create" />
    public ModHelperPanel AddPanel(Info info, string backgroundSprite, RectTransform.Axis? layoutAxis,
        float spacing, int padding) => Add(ModHelperPanel.Create(info, backgroundSprite, layoutAxis, spacing, padding));

    #endregion

    #region AddScrollPanel

    /// <inheritdoc
    ///     cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)" />
    public ModHelperScrollPanel AddScrollPanel(Info info) => AddScrollPanel(info, null);

    /// <inheritdoc
    ///     cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)" />
    public ModHelperScrollPanel AddScrollPanel(Info info, RectTransform.Axis? axis) => AddScrollPanel(info, axis, null);

    /// <inheritdoc
    ///     cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)" />
    public ModHelperScrollPanel AddScrollPanel(Info info, RectTransform.Axis? axis, string backgroundSprite) =>
        AddScrollPanel(info, axis, backgroundSprite, 0);

    /// <inheritdoc
    ///     cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)" />
    public ModHelperScrollPanel AddScrollPanel(Info info, RectTransform.Axis? axis, string backgroundSprite,
        float spacing) => AddScrollPanel(info, axis, backgroundSprite, spacing, 0);

    /// <inheritdoc
    ///     cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},string,float,int)" />
    public ModHelperScrollPanel AddScrollPanel(Info info, RectTransform.Axis? axis, string backgroundSprite,
        float spacing, int padding) => Add(ModHelperScrollPanel.Create(info, axis, backgroundSprite, spacing, padding));

    #endregion

    #region AddText

    /// <inheritdoc cref="ModHelperText.Create" />
    public ModHelperText AddText(Info info, string text) => AddText(info, text, DefaultFontSize);

    /// <inheritdoc cref="ModHelperText.Create" />
    public ModHelperText AddText(Info info, string text, float fontSize) =>
        AddText(info, text, fontSize, DefaultTextAlignment);

    /// <inheritdoc cref="ModHelperText.Create" />
    public ModHelperText AddText(Info info, string text, float fontSize, TextAlignmentOptions align) =>
        Add(ModHelperText.Create(info, text, fontSize, align));

    #endregion

    #region AddDropdown

    /// <inheritdoc cref="ModHelperDropdown.Create" />
    public ModHelperDropdown AddDropdown(Info info, List<string> options, float windowHeight,
        UnityAction<int> onValueChanged) => AddDropdown(info, options, windowHeight, onValueChanged, null);

    /// <inheritdoc cref="ModHelperDropdown.Create" />
    public ModHelperDropdown AddDropdown(Info info, List<string> options, float windowHeight,
        UnityAction<int> onValueChanged, string background) =>
        AddDropdown(info, options, windowHeight, onValueChanged, background, DefaultFontSize);

    /// <inheritdoc cref="ModHelperDropdown.Create" />
    public ModHelperDropdown AddDropdown(Info info, List<string> options, float windowHeight,
        UnityAction<int> onValueChanged, string background, float labelFontSize) => Add(
        ModHelperDropdown.Create(info, options, windowHeight, onValueChanged, background, labelFontSize));

    #endregion

    #region AddSlider

    /// <inheritdoc cref="ModHelperSlider.Create" />
    public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue, float stepSize,
        Vector2 handleSize) => AddSlider(info, defaultValue, minValue, maxValue, stepSize, handleSize, null);

    /// <inheritdoc cref="ModHelperSlider.Create" />
    public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue,
        float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged) => AddSlider(info, defaultValue, minValue,
        maxValue, stepSize, handleSize, onValueChanged, DefaultFontSize);

    /// <inheritdoc cref="ModHelperSlider.Create" />
    public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue,
        float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize) => AddSlider(info,
        defaultValue, minValue, maxValue, stepSize, handleSize, onValueChanged, fontSize, "");

    /// <inheritdoc cref="ModHelperSlider.Create" />
    public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue, float stepSize,
        Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize, string labelSuffix) => Add(
        ModHelperSlider.Create(info, defaultValue, minValue, maxValue, stepSize, handleSize, onValueChanged,
            fontSize, labelSuffix));

    /// <inheritdoc cref="ModHelperSlider.Create" />
    public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue, float stepSize,
        Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize, string labelSuffix, float startingValue) =>
        Add(ModHelperSlider.Create(info, defaultValue, minValue, maxValue, stepSize, handleSize, onValueChanged,
            fontSize, labelSuffix, startingValue));

    #endregion

    #region AddCheckbox

    /// <inheritdoc cref="ModHelperCheckbox.Create" />
    public ModHelperCheckbox AddCheckbox(Info info, bool defaultValue, string background) =>
        AddCheckbox(info, defaultValue, background, null);

    /// <inheritdoc cref="ModHelperCheckbox.Create" />
    public ModHelperCheckbox AddCheckbox(Info info, bool defaultValue, string background,
        UnityAction<bool> onValueChanged) => AddCheckbox(info, defaultValue, background, onValueChanged, null);

    /// <inheritdoc cref="ModHelperCheckbox.Create" />
    public ModHelperCheckbox AddCheckbox(Info info, bool defaultValue, string background,
        UnityAction<bool> onValueChanged, string checkImage) =>
        AddCheckbox(info, defaultValue, background, onValueChanged, checkImage, 20);

    /// <inheritdoc cref="ModHelperCheckbox.Create" />
    public ModHelperCheckbox AddCheckbox(Info info, bool defaultValue, string background,
        UnityAction<bool> onValueChanged, string checkImage, int padding) =>
        Add(ModHelperCheckbox.Create(info, defaultValue, background, onValueChanged, checkImage, padding));

    #endregion

    #region AddInputField

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background) =>
        AddInputField(info, defaultValue, background, null);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged) =>
        AddInputField(info, defaultValue, background, onValueChanged, DefaultFontSize);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged, float fontSize) => AddInputField(info, defaultValue, background,
        onValueChanged, fontSize, TMP_InputField.CharacterValidation.None);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation) => AddInputField(
        info, defaultValue, background, onValueChanged, fontSize, validation,
        DefaultTextAlignment);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation,
        TextAlignmentOptions align) =>
        AddInputField(info, defaultValue, background, onValueChanged, fontSize, validation, align, null);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation,
        TextAlignmentOptions align, string placeholder) => AddInputField(info, defaultValue, background, onValueChanged,
        fontSize, validation, align, placeholder,
        0);

    /// <inheritdoc cref="ModHelperInputField.Create" />
    /// <exclude />
    public ModHelperInputField AddInputField(Info info, string defaultValue, string background,
        UnityAction<string> onValueChanged, float fontSize, TMP_InputField.CharacterValidation validation,
        TextAlignmentOptions align, string placeholder, int padding) => Add(ModHelperInputField.Create(info,
        defaultValue, background, onValueChanged, fontSize, validation, align, placeholder, padding));

    #endregion
}

/// <summary>
/// Extensions for mod helper components, for using generics and based on restricts for il2cpp objects
/// </summary>
public static class ModHelperComponentExt
{
    /// <summary>
    /// Adds the ModHelperComponent to a parent Transform, returning the ModHelperComponent
    /// <br />
    /// (This is an extension method just so that we can return the type generically)
    /// </summary>
    public static T AddTo<T>(this T modHelperComponent, Transform parent) where T : ModHelperComponent =>
        parent.gameObject.AddModHelperComponent(modHelperComponent);


    /// <summary>
    /// Adds the ModHelperComponent to a parent GameObject, returning the ModHelperComponent
    /// <br />
    /// (This is an extension method just so that we can return the type generically)
    /// </summary>
    public static T AddModHelperComponent<T>(this ModHelperComponent parentComponent, T modHelperComponent)
        where T : ModHelperComponent
    {
        modHelperComponent.SetParent(parentComponent);
        return modHelperComponent;
    }


    /// <summary>
    /// Creates a copy of this ModHelperComponent with the same parent
    /// </summary>
    /// <param name="component">this</param>
    /// <param name="name">Its new name</param>
    public static T Duplicate<T>(this T component, string name) where T : ModHelperComponent
    {
        var gameObject = Object.Instantiate(component.gameObject, component.transform.parent);
        var newComponent = gameObject.GetComponent<T>();
        gameObject.name = name;

        newComponent.SetInfo(component.initialInfo.Duplicate(name));
        return newComponent;
    }

    /// <summary>
    /// Applies a ModWindowColor theme to this component
    /// </summary>
    /// <param name="component">this</param>
    /// <param name="color">window theme</param>
    /// <param name="type">panel type</param>
    /// <returns>this</returns>
    public static T ApplyColor<T>(this T component, ModWindowColor color, ModWindowColor.PanelType type)
        where T : ModHelperComponent
    {
        color.Apply(component.gameObject, type);
        return component;
    }
}