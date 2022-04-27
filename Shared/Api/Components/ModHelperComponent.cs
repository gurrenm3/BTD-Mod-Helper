using System;
using Assets.Scripts.Utils;
using Il2CppSystem.Collections.Generic;
using TMPro;
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
    /// The Info object that this was defined with, determining its initial name, position and size
    /// </summary>
    public Info initialInfo;

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
    public ModHelperComponent? parent;

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

    /// <inheritdoc />
    public ModHelperComponent(IntPtr ptr) : base(ptr)
    {
    }

    /// <summary>
    /// Sets a particular transform to be the parent of this
    /// </summary>
    public void SetParent(Transform newParent)
    {
        var t = transform;
        t.parent = newParent;
        initialInfo.Apply(RectTransform);
    }

    /// <summary>
    /// Sets a particular ModHelperComponent to be the parent of this
    /// </summary>
    public void SetParent(ModHelperComponent newParent)
    {
        this.parent = newParent;

        if (newParent.LayoutGroup != null && !gameObject.HasComponent<ContentSizeFitter>())
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

    /// <inheritdoc cref="GameObject.AddComponent{T}"/>
    public T AddComponent<T>() where T : Component
    {
        return gameObject.AddComponent<T>();
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
    public T GetDescendent<T>(string s = "") where T : Component
    {
        return string.IsNullOrEmpty(s)
            ? gameObject.GetComponentInChildren<T>()
            : gameObject.GetComponentInChildrenByName<T>(s)!;
    }

    /// <summary>
    /// Sets whether or not this is active
    /// </summary>
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    /// <inheritdoc cref="ModHelperPanel.Create"/>
    public ModHelperPanel AddPanel(Info info, SpriteReference? backgroundSprite = null,
        RectTransform.Axis? layoutAxis = null, float spacing = 0, int padding = 0)
    {
        return Add(ModHelperPanel.Create(info, backgroundSprite, layoutAxis, spacing, padding));
    }

    /// <inheritdoc cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},Assets.Scripts.Utils.SpriteReference,float,int)"/>
    public ModHelperScrollPanel AddScrollPanel(Info info, RectTransform.Axis? axis,
        SpriteReference? backgroundSprite = null, float spacing = 0, int padding = 0)
    {
        return Add(ModHelperScrollPanel.Create(info, axis, backgroundSprite, spacing, padding));
    }

#if BloonsTD6
    /// <inheritdoc cref="ModHelperText.Create"/>
    public ModHelperText AddText(Info info, string? text, float fontSize = 42,
        TextAlignmentOptions align = TextAlignmentOptions.Capline)
    {
        return Add(ModHelperText.Create(info, text, fontSize, align));
    }
#endif

    /// <inheritdoc cref="ModHelperButton.Create"/>
    public ModHelperButton AddButton(Info info, SpriteReference sprite, Action? onClick)
    {
        return Add(ModHelperButton.Create(info, sprite, onClick));
    }

    /// <inheritdoc cref="ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference)"/>
    public ModHelperImage AddImage(Info info, SpriteReference sprite)
    {
        return Add(ModHelperImage.Create(info, sprite));
    }

    /// <inheritdoc cref="ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference)"/>
    public ModHelperImage AddImage(Info info, Sprite? sprite)
    {
        return Add(ModHelperImage.Create(info, sprite));
    }

    /// <inheritdoc cref="ModHelperDropdown.Create"/>
    public ModHelperDropdown AddDropdown(Info info, List<string> options, float windowHeight,
        UnityAction<int> onValueChanged,
        SpriteReference? background = null, float labelFontSize = 42f)
    {
        return Add(ModHelperDropdown.Create(info, options, windowHeight, onValueChanged, background,
            labelFontSize));
    }

#if BloonsTD6
    /// <inheritdoc cref="ModHelperSlider.Create"/>
    public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue,
        float stepSize, Vector2 handleSize, UnityAction<float>? onValueChanged = null, float fontSize = 42f,
        string labelSuffix = "")
    {
        return Add(ModHelperSlider.Create(info, defaultValue, minValue, maxValue, stepSize, handleSize,
            onValueChanged, fontSize, labelSuffix));
    }
#endif

    /// <inheritdoc cref="ModHelperCheckbox.Create"/>
    public ModHelperCheckbox AddCheckbox(Info info, bool defaultValue, SpriteReference background,
        UnityAction<bool>? onValueChanged = null, SpriteReference? checkImage = null, int padding = 20)
    {
        return Add(ModHelperCheckbox.Create(info, defaultValue, background, onValueChanged, checkImage, padding));
    }

#if BloonsTD6
    /// <inheritdoc cref="ModHelperInputField.Create"/>
    public ModHelperInputField AddInputField(Info info, string? defaultValue, SpriteReference background,
        UnityAction<string>? onValueChanged = null, float fontSize = 42,
        TMP_InputField.CharacterValidation validation = TMP_InputField.CharacterValidation.None,
        TextAlignmentOptions align = TextAlignmentOptions.Capline, string? placeholder = null, int padding = 0)
    {
        return Add(ModHelperInputField.Create(info, defaultValue, background, onValueChanged, fontSize, validation,
            align, placeholder, padding));
    }
#endif

    internal static T Create<T>(Info info) where T : ModHelperComponent
    {
        var newGameObject = new GameObject(info.Name, new[] {UnhollowerRuntimeLib.Il2CppType.Of<RectTransform>()});
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
    /// Unity Component Update
    /// </summary>
    protected virtual void OnUpdate()
    {
    }

    /// <summary>
    /// Implicitly get the gameObject
    /// </summary>
    public static implicit operator GameObject(ModHelperComponent component)
    {
        return component.gameObject;
    }

    /// <summary>
    /// Implicitly get the RectTransform
    /// </summary>
    public static implicit operator RectTransform(ModHelperComponent component)
    {
        return component.RectTransform;
    }
}

/// <summary>
/// Extensions for mod helper components, for using generics and based on restricts for il2cpp objects
/// </summary>
public static class ModHelperComponentExt
{
    /// <summary>
    /// Adds the ModHelperComponent to a parent Transform, returning the ModHelperComponent
    /// <br/>
    /// (This is an extension method just so that we can return the type generically)
    /// </summary>
    public static T AddTo<T>(this T modHelperComponent, Transform parent) where T : ModHelperComponent
    {
        return parent.gameObject.AddModHelperComponent(modHelperComponent);
    }


    /// <summary>
    /// Adds the ModHelperComponent to a parent GameObject, returning the ModHelperComponent
    /// <br/>
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
    public static T Duplicate<T>(this T component, string? name) where T : ModHelperComponent
    {
        var gameObject = Object.Instantiate(component.gameObject, component.transform.parent);
        var newComponent = gameObject.GetComponent<T>();
        gameObject.name = name;

        newComponent.SetInfo(component.initialInfo.Duplicate(name));
        return newComponent;
    }
}