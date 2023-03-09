using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for AbilityModels
/// </summary>
public static class AbilityModelBehaviorExt
{
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model)"/>
    public static bool HasBehavior<T>(this AbilityModel model) where T : Model
    {
        return ModelBehaviorExt.HasBehavior<T>(model);
    }

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model)"/>
    public static T GetBehavior<T>(this AbilityModel model) where T : Model
    {
        return ModelBehaviorExt.GetBehavior<T>(model);
    }

    /// <inheritdoc cref="ModelBehaviorExt.GetBehaviors{T}"/>
    public static List<T> GetBehaviors<T>(this AbilityModel model) where T : Model
    {
        return ModelBehaviorExt.GetBehaviors<T>(model).ToList();
    }

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior"/>
    public static void AddBehavior<T>(this AbilityModel model, T behavior) where T : Model
    {
        ModelBehaviorExt.AddBehavior(model, behavior);
    }

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model)"/>
    public static void RemoveBehavior<T>(this AbilityModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior<T>(model);
    }

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior"/>
    public static void RemoveBehavior<T>(this AbilityModel model, T behavior) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior(model, behavior);
    }

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}"/>
    public static void RemoveBehaviors<T>(this AbilityModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehaviors<T>(model);
    }
}