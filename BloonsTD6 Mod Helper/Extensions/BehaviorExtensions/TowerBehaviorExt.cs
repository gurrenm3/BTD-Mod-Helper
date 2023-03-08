using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Towers;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Behavior extensions for Towers
/// </summary>
public static class TowerBehaviorExt
{
    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    public static bool HasTowerBehavior<T>(this Tower tower) where T : TowerBehavior
    {
        return tower.towerBehaviors.HasItemsOfType<TowerBehavior, T>();
    }

    /// <summary>
    /// Return the first Behavior of type T
    /// </summary>
    public static T GetTowerBehavior<T>(this Tower tower) where T : TowerBehavior
    {
        return tower.towerBehaviors.GetItemOfType<TowerBehavior, T>();
    }

    /// <summary>
    /// Return all Behaviors of type T
    /// </summary>
    public static List<T> GetTowerBehaviors<T>(this Tower tower) where T : TowerBehavior
    {
        return tower.towerBehaviors.GetItemsOfType<TowerBehavior, T>();
    }

    /// <summary>
    /// Add a Behavior to this
    /// </summary>
    public static void AddTowerBehavior<T>(this Tower tower, T behavior) where T : TowerBehavior
    {
        tower.towerBehaviors.Add(behavior);
    }

    /// <summary>
    /// Remove the first Behavior of Type T
    /// </summary>
    public static void RemoveTowerBehavior<T>(this Tower tower) where T : TowerBehavior
    {
        tower.towerBehaviors = tower.towerBehaviors.RemoveItemOfType<TowerBehavior, T>();
    }

    /// <summary>
    /// Remove the first Behavior of type T
    /// </summary>
    public static void RemoveTowerBehavior<T>(this Tower tower, T behavior) where T : TowerBehavior
    {
        tower.towerBehaviors = tower.towerBehaviors.RemoveItem(behavior);
    }

    /// <summary>
    /// Remove all Behaviors of type T
    /// </summary>
    public static void RemoveTowerBehaviors<T>(this Tower tower) where T : TowerBehavior
    {
        tower.towerBehaviors = tower.towerBehaviors.RemoveItemsOfType<TowerBehavior, T>();
    }
}