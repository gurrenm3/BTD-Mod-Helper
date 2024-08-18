using System;
using Il2CppNinjaKiwi.Common;
using Il2CppSystem.Collections.Generic;

namespace BTD_Mod_Helper.Api;

/// <summary>
/// ModContent with DisplayName and Description that registers values in the LocalizationManger's textTable
/// </summary>
public abstract class NamedModContent : ModContent
{
    /// <summary>
    /// The name that will be actually displayed for this in game
    /// </summary>
    public virtual string DisplayName => Name.Spaced();

    /// <summary>
    /// The name that will actually be display when referring to multiple of these
    /// </summary>
    public virtual string DisplayNamePlural => $"[{Id}]s";

    /// <summary>
    /// The in game description of this
    /// </summary>
    public virtual string Description => null;


    /// <summary>
    /// Registers the text for this in the LocalizationManager
    /// </summary>
    /// <param name="textTable"></param>
    /// <exclude />
    public virtual void RegisterText(Dictionary<string, string> textTable)
    {
        if (DisplayName != null) textTable[Id] = DisplayName;
        if (DisplayNamePlural != null) textTable[Id + "s"] = DisplayNamePlural;
        if (Description != null) textTable[Id + " Description"] = Description;
    }

    internal static void RegisterAllText()
    {
        var table = LocalizationManager.Instance.defaultTable;
        foreach (var namedModContent in GetContent<NamedModContent>())
        {
            try
            {
                namedModContent.RegisterText(table);
            }
            catch (Exception e)
            {
                ModHelper.Log($"Failed to register text for {namedModContent}");
                ModHelper.Error(e);
            }
        }
        LocalizationManagerExt.MiscFixes();
    }
}