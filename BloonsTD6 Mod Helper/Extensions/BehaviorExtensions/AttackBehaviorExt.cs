using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Behavior extensions for attacks
/// </summary>
public static class AttackBehaviorExt
{
    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    /// <param name="attack"></param>
    /// <returns></returns>
    public static bool HasAttackBehavior<T>(this Attack attack) where T : AttackBehavior
    {
        return attack.attackBehaviors.HasItemsOfType<AttackBehavior, T>();
    }

    /// <summary>
    /// Return the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="attack"></param>
    /// <returns></returns>
    public static T GetAttackBehavior<T>(this Attack attack) where T : AttackBehavior
    {
        return attack.attackBehaviors.GetItemOfType<AttackBehavior, T>();
    }

    /// <summary>
    /// Return all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="attack"></param>
    /// <returns></returns>
    public static List<T> GetAttackBehaviors<T>(this Attack attack) where T : AttackBehavior
    {
        return attack.attackBehaviors.GetItemsOfType<AttackBehavior, T>();
    }

    /// <summary>
    /// Add a Behavior to this
    /// </summary>
    /// <typeparam name="T">The Behavior you want to add</typeparam>
    /// <param name="attack"></param>
    /// <param name="behavior"></param>
    public static void AddAttackBehavior<T>(this Attack attack, T behavior) where T : AttackBehavior
    {
        attack.attackBehaviors.Add(behavior);
    }

    /// <summary>
    /// Remove the first Behavior of Type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="attack"></param>
    public static void RemoveAttackBehavior<T>(this Attack attack) where T : AttackBehavior
    {
        attack.attackBehaviors = attack.attackBehaviors.RemoveItemOfType<AttackBehavior, T>();
    }

    /// <summary>
    /// Remove the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="attack"></param>
    /// <param name="behavior"></param>
    public static void RemoveAttackBehavior<T>(this Attack attack, T behavior) where T : AttackBehavior
    {
        attack.attackBehaviors = attack.attackBehaviors.RemoveItem(behavior);
    }

    /// <summary>
    /// Remove all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="attack"></param>
    public static void RemoveAttackBehaviors<T>(this Attack attack) where T : AttackBehavior
    {
        attack.attackBehaviors = attack.attackBehaviors.RemoveItemsOfType<AttackBehavior, T>();
    }
}