﻿using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Pets;
using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for PetModels
/// </summary>
public static class PetModelBehaviorExt
{
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Assets.Scripts.Models.Model)"/>
    public static bool HasBehavior<T>(this PetModel model) where T : Model
    {
        return ModelBehaviorExt.HasBehavior<T>(model);
    }

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Assets.Scripts.Models.Model)"/>
    public static T? GetBehavior<T>(this PetModel model) where T : Model
    {
        return ModelBehaviorExt.GetBehavior<T>(model);
    }

    /// <inheritdoc cref="ModelBehaviorExt.GetBehaviors{T}"/>
    public static List<T> GetBehaviors<T>(this PetModel model) where T : Model
    {
        return ModelBehaviorExt.GetBehaviors<T>(model).ToList();
    }

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior"/>
    public static void AddBehavior<T>(this PetModel model, T behavior) where T : PetBehaviorModel
    {
        ModelBehaviorExt.AddBehavior(model, behavior);
    }

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Assets.Scripts.Models.Model)"/>
    public static void RemoveBehavior<T>(this PetModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior<T>(model);
    }

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior"/>
    public static void RemoveBehavior<T>(this PetModel model, T behavior) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior(model, behavior);
    }
        
    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}"/>
    public static void RemoveBehaviors<T>(this PetModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehaviors<T>(model);
    }
}