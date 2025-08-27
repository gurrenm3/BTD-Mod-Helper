using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for AddBehaviorToBloonModels
/// </summary>
[Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
public static class AddBehaviorToBloonModelExt
{
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    [Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
    public static bool HasBehavior<T>(AddBehaviorToBloonModel model) where T : Model =>
        ModelBehaviorExt.HasBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    [Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
    public static T GetBehavior<T>(AddBehaviorToBloonModel model) where T : Model =>
        ModelBehaviorExt.GetBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model,int)" />
    [Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
    public static T GetBehavior<T>(AddBehaviorToBloonModel model, int index) where T : Model =>
        ModelBehaviorExt.GetBehavior<T>(model, index);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model,string)" />
    [Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
    public static T GetBehavior<T>(AddBehaviorToBloonModel model, string nameContains) where T : Model =>
        ModelBehaviorExt.GetBehavior<T>(model, nameContains);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehaviors{T}" />
    [Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
    public static List<T> GetBehaviors<T>(AddBehaviorToBloonModel model) where T : Model =>
        ModelBehaviorExt.GetBehaviors<T>(model).ToList();

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior(Il2CppAssets.Scripts.Models.Model,Il2CppAssets.Scripts.Models.Model)" />
    [Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
    public static void AddBehavior<T>(AddBehaviorToBloonModel model, T behavior) where T : BloonBehaviorModel =>
        ModelBehaviorExt.AddBehavior(model, behavior);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    [Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
    public static void RemoveBehavior<T>(AddBehaviorToBloonModel model) where T : Model =>
        ModelBehaviorExt.RemoveBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior" />
    [Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
    public static void RemoveBehavior<T>(AddBehaviorToBloonModel model, T behavior) where T : Model =>
        ModelBehaviorExt.RemoveBehavior(model, behavior);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    [Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
    public static void RemoveBehaviors<T>(AddBehaviorToBloonModel model) where T : Model =>
        ModelBehaviorExt.RemoveBehaviors<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    [Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
    public static void RemoveBehaviors(AddBehaviorToBloonModel model) => ModelBehaviorExt.RemoveBehaviors(model);

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior(Il2CppAssets.Scripts.Models.Model,BTD_Mod_Helper.Api.Helpers.ModelHelper)"/>
    [Obsolete("Use AddBehaviorToBloonModelBehaviorExt")]
    public static void AddBehavior(AddBehaviorToBloonModel model, ModelHelper behavior) =>
        ModelBehaviorExt.AddBehavior(model, behavior);
}