using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Towers;

[RegisterTypeInIl2Cpp(false)]
internal class ModTsmInfo(IntPtr ptr) : MonoBehaviour(ptr)
{
    public ModBaseTsmTheme[] themes;

    private void OnEnable()
    {
        if (themes == null) return;
        foreach (var theme in themes)
        {
            theme.OnEnable(GetComponent<BaseTSMTheme>());
        }
    }

    private void OnDisable()
    {
        if (themes == null) return;
        foreach (var theme in themes)
        {
            theme.OnDisable(GetComponent<BaseTSMTheme>());
        }
    }

    private void Update()
    {
        if (themes == null) return;
        foreach (var theme in themes)
        {
            theme.Update(GetComponent<BaseTSMTheme>());
        }
    }

    private void OnDestroy()
    {
        if (themes == null) return;
        foreach (var theme in themes)
        {
            theme.OnDestroy(GetComponent<BaseTSMTheme>());
        }
    }
}

/// <summary>
/// Base ModContent for making Tower Selection Menu Theme related additions
/// </summary>
public abstract class ModBaseTsmTheme : ModContent
{
    /// <summary>
    /// X position of the left target type switch arrow, at which TSM Buttons are often placed
    /// </summary>
    public const int LeftArrowX = -372;

    /// <summary>
    /// X position of the right target type switch arrow, at which TSM Buttons are often placed
    /// </summary>
    public const int RightArrowX = 372;

    /// <summary>
    /// Y position above the target type switch arrows, at which TSM Buttons are often placed
    /// </summary>
    public const int AboveArrowsY = -428;

    /// <summary>
    /// Default size for <see cref="TSMButton"/>s
    /// </summary>
    public const int DefaultButtonSize = 180;

    /// <summary>
    /// Default size for icons within <see cref="TSMButton"/>s
    /// </summary>
    public const int DefaultIconSize = 128;

    internal static readonly Dictionary<string, ModBaseTsmTheme> ThemeCache = [];

    /// <inheritdoc />
    public sealed override void Register()
    {
        ThemeCache[Id] = this;
    }

    internal abstract void InitTheme(BaseTSMTheme theme, TowerToSimulation towerToSimulation);

    /// <summary>
    /// Called once the first time the theme is being setup, usually the first time a tower that uses it is selected
    /// </summary>
    /// <param name="theme">BaseTSMTheme</param>
    public abstract void SetupTheme(BaseTSMTheme theme);

    /// <summary>
    /// Called when the tower that uses this theme is changed, either from a change in which tower is selected or an update of that tower's info
    /// </summary>
    /// <param name="theme">BaseTSMTheme</param>
    /// <param name="tower">tower</param>
    public virtual void TowerChanged(BaseTSMTheme theme, TowerToSimulation tower)
    {
    }

    /// <summary>
    /// Called when a <see cref="TSMButton"/> is pressed on this theme
    /// </summary>
    /// <param name="theme">BaseTSMTheme</param>
    /// <param name="tower">tower</param>
    /// <param name="buttonId">id of the TSMButton</param>
    public virtual void OnButtonPressed(BaseTSMTheme theme, TowerToSimulation tower, string buttonId)
    {
    }

    /// <summary>
    /// Whether to affect the theme based on the Id, defaults to always affecting
    /// </summary>
    /// <param name="themeId">string ID for the theme, same as <see cref="TowerModel.towerSelectionMenuThemeId"/></param>
    /// <returns></returns>
    public virtual bool AppliesTo(string themeId) => true;

    internal static void Setup(BaseTSMTheme theme, TowerToSimulation towerToSimulation)
    {
        var themes = ThemeCache.Values
            .Where(t => t.AppliesTo(theme.ThemeId))
            .Select(t => (ModBaseTsmTheme) t.MemberwiseClone())
            .ToArray();

        if (!themes.Any()) return;

        var modTsmInfo = theme.gameObject.AddComponent<ModTsmInfo>();
        modTsmInfo.themes = themes;

        foreach (var modBaseTsmTheme in themes)
        {
            modBaseTsmTheme.InitTheme(theme, towerToSimulation);
        }
    }

    internal static void PerformAction(BaseTSMTheme theme, Action<ModBaseTsmTheme> action)
    {
        if (theme.gameObject.HasComponent(out ModTsmInfo modTsmInfo))
        {
            modTsmInfo.themes.ForEach(action);
        }
    }

    /// <summary>
    /// Unity lifecycle OnEnable for the theme component
    /// </summary>
    public virtual void OnEnable(BaseTSMTheme theme)
    {
    }

    /// <summary>
    /// Unity lifecycle OnDisable for the theme component
    /// </summary>
    public virtual void OnDisable(BaseTSMTheme theme)
    {
    }

    /// <summary>
    /// Unity lifecycle Update for the theme component
    /// </summary>
    public virtual void Update(BaseTSMTheme theme)
    {
    }

    /// <summary>
    /// Unity lifecycle OnDestroy for the theme component
    /// </summary>
    public virtual void OnDestroy(BaseTSMTheme theme)
    {
    }
}

/// <summary>
/// ModContent for defining a new Tower Selection Menu Theme that towers can use.
/// <example>
/// <code>
/// towerModel.towerSelectionMenuThemeId = ModContent.GetId&lt;MyModTsmTheme&gt;();
/// </code>
/// </example>
/// </summary>
public abstract class ModTsmTheme : ModBaseTsmTheme
{
    /// <summary>
    /// Which TSM theme to use as a base defaults to "Default" for <see cref="TSMThemeDefault"/>
    /// </summary>
    public virtual string BaseTheme => "Default";

    /// <inheritdoc />
    public sealed override bool AppliesTo(string themeId) => themeId == Id;

    internal override void InitTheme(BaseTSMTheme theme, TowerToSimulation towerToSimulation)
    {
        theme.gameObject.name = Id + "Clone";
        theme._ThemeId_k__BackingField = Id;

        SetupTheme(theme);
        TowerChanged(theme, towerToSimulation);
    }
}

/// <summary>
/// ModContent for defining changes to existing Tower Selection Menu Themes
/// </summary>
public abstract class ModVanillaTsmTheme : ModBaseTsmTheme
{
    internal override void InitTheme(BaseTSMTheme theme, TowerToSimulation towerToSimulation)
    {
        if (AppliesTo(theme.ThemeId))
        {
            SetupTheme(theme);
        }
    }
}