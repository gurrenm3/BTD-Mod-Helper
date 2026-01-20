using System;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers.Emissions;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Behavior extensions for Emissions
/// </summary>
public static class EmissionBehaviorExt
{
    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    /// <param name="emission"></param>
    /// <returns></returns>
    public static bool HasEmissionBehavior<T>(this Emission emission) where T : RootBehavior =>
        emission.createdBehaviors.HasItemsOfType<RootBehavior, T>();

    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    /// <param name="emission"></param>
    /// <param name="item">The returned item, if it exists</param>
    /// <returns></returns>
    public static bool HasEmissionBehavior<T>(this Emission emission, out T item) where T : RootBehavior
    {
        item = emission.GetEmissionBehavior<T>();
        return item != null;
    }

    /// <summary>
    /// Return the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="emission"></param>
    /// <returns></returns>
    public static T GetEmissionBehavior<T>(this Emission emission) where T : RootBehavior =>
        emission.createdBehaviors.GetItemOfType<RootBehavior, T>();

    /// <summary>
    /// Return all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="emission"></param>
    /// <returns></returns>
    public static Il2CppSystem.Collections.Generic.List<T> GetEmissionBehaviors<T>(this Emission emission)
        where T : RootBehavior =>
        emission.createdBehaviors.GetItemsOfType<RootBehavior, T>();

    /// <summary>
    /// Add a Behavior to this
    /// </summary>
    /// <typeparam name="T">The Behavior you want to add</typeparam>
    /// <param name="emission"></param>
    /// <param name="behavior"></param>
    public static void AddEmissionBehavior<T>(this Emission emission, T behavior) where T : RootBehavior
    {
        emission.createdBehaviors.Add(behavior);
    }

    /// <summary>
    /// Remove the first Behavior of Type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="emission"></param>
    public static void RemoveEmissionBehavior<T>(this Emission emission) where T : RootBehavior
    {
        emission.createdBehaviors = emission.createdBehaviors.RemoveItemOfType<RootBehavior, T>();
    }

    /// <summary>
    /// Remove the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="emission"></param>
    /// <param name="behavior"></param>
    public static void RemoveEmissionBehavior<T>(this Emission emission, T behavior) where T : RootBehavior
    {
        emission.createdBehaviors = emission.createdBehaviors.RemoveItem(behavior);
    }

    /// <summary>
    /// Remove all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="emission"></param>
    public static void RemoveEmissionBehaviors<T>(this Emission emission) where T : RootBehavior
    {
        emission.createdBehaviors = emission.createdBehaviors.RemoveItemsOfType<RootBehavior, T>();
    }
}