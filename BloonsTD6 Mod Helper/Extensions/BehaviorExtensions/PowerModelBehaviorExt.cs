﻿using Assets.Scripts.Models;
using Assets.Scripts.Models.Powers;
using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Behavior extensions for PowerModels
/// </summary>
public static class PowerModelBehaviorExt
{
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Assets.Scripts.Models.Model)"/>
    public static bool HasBehavior<T>(this PowerModel model) where T : Model
    {
        return ModelBehaviorExt.HasBehavior<T>(model);
    }

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Assets.Scripts.Models.Model)"/>
    public static T? GetBehavior<T>(this PowerModel model) where T : Model
    {
        return ModelBehaviorExt.GetBehavior<T>(model);
    }

    /// <inheritdoc cref="ModelBehaviorExt.GetBehaviors{T}"/>
    public static List<T> GetBehaviors<T>(this PowerModel model) where T : Model
    {
        return ModelBehaviorExt.GetBehaviors<T>(model).ToList();
    }

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior"/>
    public static void AddBehavior<T>(this PowerModel model, T behavior) where T : PowerBehaviorModel
    {
        ModelBehaviorExt.AddBehavior(model, behavior);
    }

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Assets.Scripts.Models.Model)"/>
    public static void RemoveBehavior<T>(this PowerModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior<T>(model);
    }
        
    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior"/>
    public static void RemoveBehavior<T>(this PowerModel model, T behavior) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior(model, behavior);
    }

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}"/>
    public static void RemoveBehaviors<T>(this PowerModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehaviors<T>(model);
    }
}