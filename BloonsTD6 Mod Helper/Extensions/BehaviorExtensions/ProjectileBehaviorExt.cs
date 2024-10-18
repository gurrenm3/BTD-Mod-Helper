using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Behavior extensions for projectiles
/// </summary>
public static class ProjectileBehaviorExt
{
    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    public static bool HasProjectileBehavior<T>(this Projectile projectile) where T : ProjectileBehavior =>
        projectile.projectileBehaviors.HasItemsOfType<IProjectileBehavior, T>();
    
    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    public static bool HasProjectileBehavior<T>(this Projectile projectile, out T item) where T : ProjectileBehavior
    {
        item = projectile.GetProjectileBehavior<T>();
        return item != null;
    }

    /// <summary>
    /// Return the first Behavior of type T
    /// </summary>
    public static T GetProjectileBehavior<T>(this Projectile projectile) where T : ProjectileBehavior =>
        projectile.projectileBehaviors.GetItemOfType<IProjectileBehavior, T>();

    /// <summary>
    /// Return all Behaviors of type T
    /// </summary>
    public static List<T> GetProjectileBehaviors<T>(this Projectile projectile) where T : ProjectileBehavior =>
        projectile.projectileBehaviors.GetItemsOfType<IProjectileBehavior, T>();

    /// <summary>
    /// Add a Behavior to this
    /// </summary>
    public static void AddProjectileBehavior<T>(this Projectile projectile, T behavior) where T : ProjectileBehavior
    {
        projectile.projectileBehaviors.Add(behavior.Cast<IProjectileBehavior>());
    }

    /// <summary>
    /// Remove the first Behavior of Type T
    /// </summary>
    public static void RemoveProjectileBehavior<T>(this Projectile projectile) where T : ProjectileBehavior
    {
        projectile.projectileBehaviors = projectile.projectileBehaviors.RemoveItemOfType<IProjectileBehavior, T>();
    }

    /// <summary>
    /// Remove the first Behavior of type T
    /// </summary>
    public static void RemoveProjectileBehavior<T>(this Projectile projectile, T behavior) where T : ProjectileBehavior
    {
        projectile.projectileBehaviors = projectile.projectileBehaviors.RemoveItem(behavior);
    }

    /// <summary>
    /// Remove all Behaviors of type T
    /// </summary>
    public static void RemoveProjectileBehaviors<T>(this Projectile projectile) where T : ProjectileBehavior
    {
        projectile.projectileBehaviors = projectile.projectileBehaviors.RemoveItemsOfType<IProjectileBehavior, T>();
    }
}