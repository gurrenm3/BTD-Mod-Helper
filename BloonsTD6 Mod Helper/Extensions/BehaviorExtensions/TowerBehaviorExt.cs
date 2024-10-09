using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Objects;
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
    public static bool HasTowerBehavior<T>(this Tower tower) where T : TowerBehavior =>
        tower.towerBehaviors.HasItemsOfType<ITowerBehavior, T>();
    
    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    public static bool HasTowerBehavior<T>(this Tower tower, out T item) where T : TowerBehavior =>
        tower.towerBehaviors.HasItemsOfType<ITowerBehavior, T>(out item);

    /// <summary>
    /// Return the first Behavior of type T
    /// </summary>
    public static T GetTowerBehavior<T>(this Tower tower) where T : TowerBehavior =>
        tower.towerBehaviors.GetItemOfType<ITowerBehavior, T>();

    /// <summary>
    /// Return all Behaviors of type T
    /// </summary>
    public static List<T> GetTowerBehaviors<T>(this Tower tower) where T : TowerBehavior =>
        tower.towerBehaviors.GetItemsOfType<ITowerBehavior, T>();

    /// <summary>
    /// Add a Behavior to this
    /// </summary>
    public static void AddTowerBehavior<T>(this Tower tower, T behavior) where T : TowerBehavior
    {
        tower.towerBehaviors.Add(behavior.Cast<ITowerBehavior>());
    }

    /// <summary>
    /// Remove the first Behavior of Type T
    /// </summary>
    public static void RemoveTowerBehavior<T>(this Tower tower) where T : TowerBehavior
    {
        tower.towerBehaviors = tower.towerBehaviors.RemoveItemOfType<ITowerBehavior, T>();
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
        tower.towerBehaviors = tower.towerBehaviors.RemoveItemsOfType<ITowerBehavior, T>();
    }
}