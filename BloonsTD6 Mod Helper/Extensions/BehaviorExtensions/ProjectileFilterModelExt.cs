using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for ProjectileFilterModels
/// </summary>
public static class ProjectileFilterModelExt
{
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static bool HasFilter<T>(this ProjectileFilterModel model) where T : Model => 
        ModelBehaviorExt.HasBehavior<T>(model);
        
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model,string,out T)" />
    public static bool HasFilter<T>(this ProjectileFilterModel model, string nameContains) where T : Model =>
        ModelBehaviorExt.HasBehavior<T>(model, nameContains);
            
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model,out T)" />
    public static bool HasFilter<T>(this ProjectileFilterModel model, [NotNullWhen(true)] out T behavior) where T : Model =>
        ModelBehaviorExt.HasBehavior<T>(model, out behavior);
        
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model,string,out T)" />
    public static bool HasFilter<T>(this ProjectileFilterModel model, string nameContains, [NotNullWhen(true)] out T behavior) where T : Model =>
        ModelBehaviorExt.HasBehavior<T>(model, nameContains, out behavior);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static T GetFilter<T>(this ProjectileFilterModel model) where T : Model =>
        ModelBehaviorExt.GetBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model,int)" />
    public static T GetFilter<T>(this ProjectileFilterModel model, int index) where T : Model =>
        ModelBehaviorExt.GetBehavior<T>(model, index);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model,string)" />
    public static T GetFilter<T>(this ProjectileFilterModel model, string nameContains) where T : Model =>
        ModelBehaviorExt.GetBehavior<T>(model, nameContains);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehaviors{T}" />
    public static List<T> GetFilters<T>(this ProjectileFilterModel model) where T : Model =>
        ModelBehaviorExt.GetBehaviors<T>(model).ToList();

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior(Il2CppAssets.Scripts.Models.Model,Il2CppAssets.Scripts.Models.Model)" />
    public static void AddFilter<T>(this ProjectileFilterModel model, T behavior) where T : Model =>
        ModelBehaviorExt.AddBehavior(model, behavior);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static void RemoveFilter<T>(this ProjectileFilterModel model) where T : Model =>
        ModelBehaviorExt.RemoveBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior" />
    public static void RemoveFilter<T>(this ProjectileFilterModel model, T behavior) where T : Model =>
        ModelBehaviorExt.RemoveBehavior(model, behavior);
    
    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model,int)" />
    public static void RemoveFilter<T>(this ProjectileFilterModel model, int index) where T : Model =>
        ModelBehaviorExt.RemoveBehavior<T>(model, index);
    
    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model,string)" />
    public static void RemoveFilter<T>(this ProjectileFilterModel model, string nameContains) where T : Model =>
        ModelBehaviorExt.RemoveBehavior<T>(model, nameContains);
    
    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    public static void RemoveFilters<T>(this ProjectileFilterModel model) where T : Model =>
        ModelBehaviorExt.RemoveBehaviors<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    public static void RemoveFilter(this ProjectileFilterModel model) =>
        ModelBehaviorExt.RemoveBehaviors(model);

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior(Il2CppAssets.Scripts.Models.Model,BTD_Mod_Helper.Api.Helpers.ModelHelper)"/>
    public static void AddFilter(this ProjectileFilterModel model, ModelHelper behavior) =>
        ModelBehaviorExt.AddBehavior(model, behavior);
}