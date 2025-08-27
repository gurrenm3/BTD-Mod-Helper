using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Artifacts;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for ItemArtifactModels
/// </summary>
public static partial class ArtifactModelBehaviorExt
{
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static bool HasBehavior<T>(this ItemArtifactModel model) where T : Model => 
        ModelBehaviorExt.HasBehavior<T>(model);
            
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model,out T)" />
    public static bool HasBehavior<T>(this ItemArtifactModel model, [NotNullWhen(true)] out T behavior) where T : Model =>
        ModelBehaviorExt.HasBehavior<T>(model, out behavior);
        
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model,string,out T)" />
    public static bool HasBehavior<T>(this ItemArtifactModel model, string nameContains, [NotNullWhen(true)] out T behavior) where T : Model =>
        ModelBehaviorExt.HasBehavior<T>(model, nameContains, out behavior);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static T GetBehavior<T>(this ItemArtifactModel model) where T : Model => 
        ModelBehaviorExt.GetBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model,int)" />
    public static T GetBehavior<T>(this ItemArtifactModel model, int index) where T : Model =>
        ModelBehaviorExt.GetBehavior<T>(model, index);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model,string)" />
    public static T GetBehavior<T>(this ItemArtifactModel model, string nameContains) where T : Model =>
        ModelBehaviorExt.GetBehavior<T>(model, nameContains);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehaviors{T}" />
    public static List<T> GetBehaviors<T>(this ItemArtifactModel model) where T : Model =>
        ModelBehaviorExt.GetBehaviors<T>(model).ToList();

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior(Il2CppAssets.Scripts.Models.Model,Il2CppAssets.Scripts.Models.Model)" />
    public static void AddBehavior<T>(this ItemArtifactModel model, T behavior) where T : Model => 
        ModelBehaviorExt.AddBehavior(model, behavior);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static void RemoveBehavior<T>(this ItemArtifactModel model) where T : Model => 
        ModelBehaviorExt.RemoveBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior" />
    public static void RemoveBehavior<T>(this ItemArtifactModel model, T behavior) where T : Model => 
        ModelBehaviorExt.RemoveBehavior(model, behavior);
    
    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model,int)" />
    public static void RemoveBehavior<T>(this ItemArtifactModel model, int index) where T : Model =>
        ModelBehaviorExt.RemoveBehavior<T>(model, index);
    
    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model,string)" />
    public static void RemoveBehavior<T>(this ItemArtifactModel model, string nameContains) where T : Model =>
        ModelBehaviorExt.RemoveBehavior<T>(model, nameContains);
    
    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    public static void RemoveBehaviors<T>(this ItemArtifactModel model) where T : Model => 
        ModelBehaviorExt.RemoveBehaviors<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    public static void RemoveBehaviors(this ItemArtifactModel model) => 
        ModelBehaviorExt.RemoveBehaviors(model);

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior(Il2CppAssets.Scripts.Models.Model,BTD_Mod_Helper.Api.Helpers.ModelHelper)"/>
    public static void AddBehavior(this ItemArtifactModel model, ModelHelper behavior) => 
        ModelBehaviorExt.AddBehavior(model, behavior);
}