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
    public static bool HasProjectileBehavior<T>(this Projectile projectile) where T : ProjectileBehavior
    {
        return projectile.projectileBehaviors.HasItemsOfType<ProjectileBehavior, T>();
    }

    /// <summary>
    /// Return the first Behavior of type T
    /// </summary>
    public static T GetProjectileBehavior<T>(this Projectile projectile) where T : ProjectileBehavior
    {
        return projectile.projectileBehaviors.GetItemOfType<ProjectileBehavior, T>();
    }

    /// <summary>
    /// Return all Behaviors of type T
    /// </summary>
    public static List<T> GetProjectileBehaviors<T>(this Projectile projectile) where T : ProjectileBehavior
    {
        return projectile.projectileBehaviors.GetItemsOfType<ProjectileBehavior, T>();
    }

    /// <summary>
    /// Add a Behavior to this
    /// </summary>
    public static void AddProjectileBehavior<T>(this Projectile projectile, T behavior) where T : ProjectileBehavior
    {
        projectile.projectileBehaviors.Add(behavior);
    }

    /// <summary>
    /// Remove the first Behavior of Type T
    /// </summary>
    public static void RemoveProjectileBehavior<T>(this Projectile projectile) where T : ProjectileBehavior
    {
        projectile.projectileBehaviors = projectile.projectileBehaviors.RemoveItemOfType<ProjectileBehavior, T>();
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
        projectile.projectileBehaviors = projectile.projectileBehaviors.RemoveItemsOfType<ProjectileBehavior, T>();
    }
}