﻿using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Behavior extensions for BloonModels
/// </summary>
public static class BloonModelBehaviorExt
{
    /// <summary>
    /// (Cross-Game compatible) Check if this has a specific Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public static bool HasBehavior<T>(this BloonModel model) where T : Model
    {
        return ModelBehaviorExt.HasBehavior<T>(model);
    }

    /// <summary>
    /// (Cross-Game compatible) Return the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public static T? GetBehavior<T>(this BloonModel model) where T : Model
    {
        return ModelBehaviorExt.GetBehavior<T>(model);
    }

    /// <summary>
    /// (Cross-Game compatible) Return all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public static List<T> GetBehaviors<T>(this BloonModel model) where T : Model
    {
        return ModelBehaviorExt.GetBehaviors<T>(model).ToList();
    }

    /// <summary>
    /// (Cross-Game compatible) Add a Behavior to this
    /// </summary>
    /// <typeparam name="T">The Behavior you want to add</typeparam>
    /// <param name="model"></param>
    /// <param name="behavior"></param>
    public static void AddBehavior<T>(this BloonModel model, T behavior) where T : Model
    {
        ModelBehaviorExt.AddBehavior(model, behavior);
    }

    /// <summary>
    /// (Cross-Game compatible) Remove the first Behavior of Type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="model"></param>
    public static void RemoveBehavior<T>(this BloonModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior<T>(model);
    }

    /// <summary>
    /// (Cross-Game compatible) Remove the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="model"></param>
    /// <param name="behavior"></param>
    public static void RemoveBehavior<T>(this BloonModel model, T behavior) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior(model, behavior);
    }

    /// <summary>
    /// (Cross-Game compatible) Remove all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="model"></param>
    public static void RemoveBehaviors<T>(this BloonModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehaviors<T>(model);
    }
}