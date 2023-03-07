using System;
using BTD_Mod_Helper.Api.Components;
namespace BTD_Mod_Helper.Api.ModOptions;

/// <summary>
/// Category of mod settings
/// </summary>
public class ModSettingCategory
{
    /// <summary>
    /// Name of the category
    /// </summary>
    public string displayName;

    /// <summary>
    /// Icon of the category, if any
    /// </summary>
    public string icon;

    /// <summary>
    /// Order of this category in relation to other categories. A setting not having a category will have order = 0
    /// </summary>
    public int order = 1;

    /// <summary>
    /// Whether this category is currently collapsed / hiding its elements
    /// </summary>
    public bool collapsed = true;
        
    /// <summary>
    /// Action to modify the ModHelperCategory after it's created
    /// </summary>
    public Action<ModHelperCategory> modifyCategory;

    /// <summary>
    /// Creates a new ModSettingCategory with the given displayName
    /// </summary>
    public ModSettingCategory(string displayName)
    {
        this.displayName = displayName;
    }

    /// <summary>
    /// Creates the visual ModHelperCategory for this option
    /// </summary>
    /// <returns></returns>
    public ModHelperCategory Create()
    {
        var modHelperCategory = ModHelperCategory.Create(displayName, collapsed, icon);
        modifyCategory?.Invoke(modHelperCategory);
        return modHelperCategory;
    }

    /// <summary>
    /// Gets the name from a category
    /// </summary>
    public static implicit operator string (ModSettingCategory category)
    {
        return category.displayName;
    }

    /// <summary>
    /// Creates a new category with the given name
    /// </summary>
    public static implicit operator ModSettingCategory(string displayName)
    {
        return new ModSettingCategory(displayName);
    }
}