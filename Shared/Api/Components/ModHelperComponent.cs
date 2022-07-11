using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// Base for a helper component for making custom UIs in the same style as Vanilla ones
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public partial class ModHelperComponent : MonoBehaviour
{
    /// <summary>
    /// Default font size for UI labels
    /// </summary>
    public const float DefaultFontSize = 42f;

    /// <summary>
    /// Default alignment for texts and input fields
    /// </summary>
    public const TextAlignmentOptions DefaultTextAlignment = TextAlignmentOptions.Capline;

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
        t.parent = newParent;
        initialInfo.Apply(RectTransform);
    }

    /// <summary>
    /// Sets a particular ModHelperComponent to be the parent of this
    /// </summary>
    public void SetParent(ModHelperComponent newParent)
    {
        parent = newParent;

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

    /// <inheritdoc cref="GameObject.AddComponent{T}" />
    public T AddComponent<T>() where T : Component => gameObject.AddComponent<T>();

    /// <summary>
    /// Adds and returns a LayoutElement for this, making it work as part of a LayoutGroup
    /// </summary>
    public LayoutElement AddLayoutElement()
    {
        if (LayoutElement == null)
        {
            AddComponent<LayoutElement>();
        }

        LayoutElement.minWidth = LayoutElement.preferredWidth = initialInfo.SizeDelta.x;
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
        : gameObject.GetComponentInChildrenByName<T>(s)!;

    /// <summary>
    /// Sets whether or not this is active
    /// </summary>
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

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

    /// <summary>
    /// Unity Component Update
    /// </summary>
    protected virtual void OnUpdate()
    {
    }

    /// <summary>
    /// Deletes the underlying GameObject this is attached to, not just the component
    /// </summary>
    public void DeleteObject() => gameObject.Destroy();

    /// <summary>
    /// Implicitly get the gameObject
    /// </summary>
    public static implicit operator GameObject(ModHelperComponent component) => component.gameObject;

    /// <summary>
    /// Implicitly get the RectTransform
    /// </summary>
    public static implicit operator RectTransform(ModHelperComponent component) => component.RectTransform;
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
}