using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Components;
using UnityEngine;
namespace BTD_Mod_Helper.Api.UI;

/// <summary>
/// ModContent representing an entry that will be added to the custom "Start Menu" in game, primarily used to open custom Windows
/// </summary>
public abstract class ModStartMenuEntry : NamedModContent
{
    internal ModHelperPopupOption CurrentOption { get; set; }

    /// <summary>
    /// Height for the entry option within the Start Menu
    /// </summary>
    public virtual float StartMenuEntryHeight => 75;

    /// <summary>
    /// Width for the entry option within the Start Menu. 0 for automatic width
    /// </summary>
    public virtual float StartMenuEntryWidth => 0;

    /// <summary>
    /// The parent entry that this should be nested under
    /// </summary>
    public virtual ModStartMenuEntry ParentEntry => null;

    /// <summary>
    /// Entries nested beneath this entry
    /// </summary>
    public List<ModStartMenuEntry> ChildEntries { get; } = [];

    /// <summary>
    /// SpriteReference to use for an icon. Null means no icon, empty string "" means a blank icon (still creates the margin for it within the option)
    /// </summary>
    public virtual string Icon => null;

    /// <summary>
    /// Scale for the icon
    /// </summary>
    public virtual float IconScale => 1;

    /// <summary>
    /// The Mod Helper <see cref="Info"/> used to define the Start Menu entry
    /// </summary>
    public virtual Info StartMenuEntry => new(Name)
    {
        Width = StartMenuEntryWidth,
        Height = StartMenuEntryHeight
    };

    /// <summary>
    /// Whether this entry should be hidden from the start menu
    /// </summary>
    public virtual bool DontAddToStartMenu => false;

    /// <summary>
    /// What to do when the start menu entry is clicked. Not called if this has child entries
    /// </summary>
    public virtual void StartMenuEntryClicked()
    {
    }

    /// <inheritdoc />
    public override void Register()
    {
        ParentEntry?.ChildEntries.Add(this);
    }

    internal ModHelperPopupOption AddEntry(ModHelperPopupMenu menu)
    {
        var hasChildren = ChildEntries.Any();
        var option = ModHelperPopupOption.Create(StartMenuEntry, DisplayName, Icon,
            hasChildren ? null : new Action(StartMenuEntryClicked),
            isSelected: new Func<bool>(IsSelected),
            isHidden: new Func<bool>(IsHidden));
        menu.AddOption(option);
        if (option.icon is not null)
        {
            option.icon.RectTransform.localScale = Vector3.one * IconScale;
        }

        CurrentOption = option;

        if (hasChildren)
        {
            menu = option.AddSubMenu(new Info(Name + " Options"));
            menu.ApplyColor(MelonMain.CurrentDefaultWindowColor, ModWindowColor.PanelType.Main);
            foreach (var childEntry in ChildEntries)
            {
                childEntry.AddEntry(menu);
            }
        }

        return option;
    }

    /// <summary>
    /// Whether this start menu entry should appear as selected in the menu.
    /// </summary>
    /// <returns>whether it's selected or not</returns>
    public virtual bool IsSelected() => false;

    /// <summary>
    /// Whether this start menu entry should not appear in the menu at this time
    /// </summary>
    /// <returns>whether it's hidden or not</returns>
    public virtual bool IsHidden() => false;
}

/// <summary>
/// Helper class for a ModStartMenuEntry that is nested beneath another entry
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ModStartMenuEntry<T> : ModStartMenuEntry where T : ModStartMenuEntry
{
    /// <inheritdoc />
    public override ModStartMenuEntry ParentEntry => GetInstance<T>();
}