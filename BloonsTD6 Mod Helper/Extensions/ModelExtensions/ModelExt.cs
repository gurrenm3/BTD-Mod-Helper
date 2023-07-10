using System;
using Il2CppAssets.Scripts.Models;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Models
/// </summary>
public static class ModelExt
{
    /// <summary>
    /// Create a new and separate copy of this object. Same as using:  .Clone().Cast();
    /// </summary>
    /// <typeparam name="T">Type of object you want to cast to when duplicating. Done automatically</typeparam>
    public static T Duplicate<T>(this T model) where T : Model => model.Clone().Cast<T>();

    /// <summary>
    /// Turns any descendants with "_" as their name into unique named models
    /// </summary>
    internal static void GenerateDescendentNames(this Model model)
    {
        var i = 0;
        model.GetDescendants<Model>().ForEach(m =>
        {
            i++;
            if (m != null && (string.IsNullOrEmpty(m.name) || m.name == "_"))
            {
                m.name = m.GetIl2CppType().Name + "__" + i;
            }
        });
    }

    /// <summary>
    /// Finds the first descendent of a given type whose name contains the specified string, or null if not found
    /// </summary>
    public static T FindDescendant<T>(this Model model, string nameContains) where T : Model
    {
        return model.GetDescendants<T>().FirstOrDefault(m => m != null && m.name.Contains(nameContains));
    }
    
    /// <summary>
    /// Finds the first descendent of a given type that matches the given condition, or null if not found
    /// </summary>
    public static T FindDescendant<T>(this Model model, Predicate<T> condition) where T : Model
    {
        return model.GetDescendants<T>().FirstOrDefault(m => m != null && condition(m));
    }
}