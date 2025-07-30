using System.Collections.Generic;
using UnityEngine;
using BTD_Mod_Helper.Api.Components;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.UI;

/// <summary>
/// Defines a Window Color theme for <see cref="ModHelperWindow"/>s and related UI components
/// </summary>
public abstract class ModWindowColor : NamedModContent
{
    private static readonly Dictionary<string, ModWindowColor> Cache = new();

    /// <summary>
    /// Sprite to use for the main panels of windows
    /// </summary>
    public abstract string MainPanelSprite { get; }

    /// <summary>
    /// Sprite to use for the "insert" or sub-panels of windows that are nested in the outer panels
    /// </summary>
    public abstract string InsertPanelSprite { get; }

    /// <summary>
    /// For main panels, a multiplier to the <see cref="Image.pixelsPerUnitMultiplier"/> to change the scale
    /// </summary>
    public virtual float PanelPixelMult => 1f;

    /// <summary>
    /// For insert panels, a multiplier to the <see cref="Image.pixelsPerUnitMultiplier"/> to change the scale
    /// </summary>
    public virtual float InsertPanelPixelMult => 1f;

    /// <inheritdoc />
    public sealed override void Register()
    {
        Cache[Name] = this;
    }

    /// <summary>
    /// Get the corresponding sprite to use for a given panel type
    /// </summary>
    /// <param name="type">panel type</param>
    /// <returns>sprite guid</returns>
    public string GetSprite(PanelType type) => type switch
    {
        PanelType.Main => MainPanelSprite,
        PanelType.Insert => InsertPanelSprite,
        _ => MainPanelSprite
    };

    /// <summary>
    /// Get the corresponding pixels per unit multiplier for a given panel type
    /// </summary>
    /// <param name="type">panel type</param>
    /// <returns>pixels per unit multiplier</returns>
    public float GetPixelMult(PanelType type) => type switch
    {
        PanelType.Main => PanelPixelMult,
        PanelType.Insert => InsertPanelPixelMult,
        _ => PanelPixelMult
    };

    /// <summary>
    /// Apply this color to a specific image for a given panel type via a <see cref="WindowColorSetter"/> component
    /// </summary>
    /// <param name="gobject">GameObject that has an Image component</param>
    /// <param name="type">panel type</param>
    /// <returns>the added WindowColorSetter component</returns>
    public WindowColorSetter Apply(GameObject gobject, PanelType type)
    {
        if (!gobject.HasComponent(out WindowColorSetter setter))
        {
            setter = gobject.AddComponent<WindowColorSetter>();
            setter.type = type;
            setter.image = gobject.GetComponent<Image>();
        }

        setter.SetColor(this);

        return setter;
    }

    /// <summary>
    /// Gets a ModWindowColor instance from its <see cref="ModContent.Name"/>
    /// </summary>
    /// <param name="name">the mod content name</param>
    /// <returns>ModWindowColor instance, Blue if no name match</returns>
    public static ModWindowColor Of(string name) => Cache.GetValueOrDefault(name, Cache[nameof(WindowColors.Blue)]);

    /// <summary>
    /// Implicitly converts a string into the corresponding ModWindowColor instance
    /// </summary>
    /// <param name="name">the mod content name</param>
    /// <returns>ModWindowColor instance</returns>
    public static implicit operator ModWindowColor(string name) => Of(name);

    /// <summary>
    /// Implicitly turns a ModWindowColor isntance into its Name
    /// </summary>
    /// <param name="modWindowColor">mod window color instance</param>
    /// <returns>its name</returns>
    public static implicit operator string(ModWindowColor modWindowColor) => modWindowColor.Name;

    /// <summary>
    /// The different panel types that require different textures
    /// </summary>
    public enum PanelType
    {
        /// <summary>
        /// The primary panels of windows
        /// </summary>
        Main,
        /// <summary>
        /// The "insert" or sub-panels of windows that are nested in the outer panels
        /// </summary>
        Insert,
        /// <summary>
        /// If this window color wants to have a separate sprite for buttons. Currently just defaults to the Main Panel texture
        /// </summary>
        Button
    }

    /// <summary>
    /// Blue
    /// </summary>
    public static ModWindowColor Blue => GetInstance<WindowColors.Blue>();

    /// <summary>
    /// Bronze
    /// </summary>
    public static ModWindowColor Bronze => GetInstance<WindowColors.Bronze>();

    /// <summary>
    /// Brown
    /// </summary>
    public static ModWindowColor Brown => GetInstance<WindowColors.Brown>();

    /// <summary>
    /// Dark Blue
    /// </summary>
    public static ModWindowColor DarkBlue => GetInstance<WindowColors.DarkBlue>();

    /// <summary>
    /// Glass
    /// </summary>
    public static ModWindowColor Glass => GetInstance<WindowColors.Glass>();

    /// <summary>
    /// Hematite
    /// </summary>
    public static ModWindowColor Hematite => GetInstance<WindowColors.Hematite>();

    /// <summary>
    /// Purple
    /// </summary>
    public static ModWindowColor Purple => GetInstance<WindowColors.Purple>();

    /// <summary>
    /// Silver
    /// </summary>
    public static ModWindowColor Silver => GetInstance<WindowColors.Silver>();
}