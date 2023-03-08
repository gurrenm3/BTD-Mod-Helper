using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Behavior extensions for Weapons
/// </summary>
public static class WeaponBehaviorExt
{
    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    /// <param name="weapon"></param>
    /// <returns></returns>
    public static bool HasWeaponBehavior<T>(this Weapon weapon) where T : WeaponBehavior
    {
        return weapon.weaponBehaviors.HasItemsOfType<WeaponBehavior, T>();
    }

    /// <summary>
    /// Return the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="weapon"></param>
    /// <returns></returns>
    public static T GetWeaponBehavior<T>(this Weapon weapon) where T : WeaponBehavior
    {
        return weapon.weaponBehaviors.GetItemOfType<WeaponBehavior, T>();
    }

    /// <summary>
    /// Return all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="weapon"></param>
    /// <returns></returns>
    public static List<T> GetWeaponBehaviors<T>(this Weapon weapon) where T : WeaponBehavior
    {
        return weapon.weaponBehaviors.GetItemsOfType<WeaponBehavior, T>();
    }

    /// <summary>
    /// Add a Behavior to this
    /// </summary>
    /// <typeparam name="T">The Behavior you want to add</typeparam>
    /// <param name="weapon"></param>
    /// <param name="behavior"></param>
    public static void AddWeaponBehavior<T>(this Weapon weapon, T behavior) where T : WeaponBehavior
    {
        weapon.weaponBehaviors.Add(behavior);
    }

    /// <summary>
    /// Remove the first Behavior of Type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="weapon"></param>
    public static void RemoveWeaponBehavior<T>(this Weapon weapon) where T : WeaponBehavior
    {
        weapon.weaponBehaviors = weapon.weaponBehaviors.RemoveItemOfType<WeaponBehavior, T>();
    }

    /// <summary>
    /// Remove the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="weapon"></param>
    /// <param name="behavior"></param>
    public static void RemoveWeaponBehavior<T>(this Weapon weapon, T behavior) where T : WeaponBehavior
    {
        weapon.weaponBehaviors = weapon.weaponBehaviors.RemoveItem(behavior);
    }

    /// <summary>
    /// Remove all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="weapon"></param>
    public static void RemoveWeaponBehaviors<T>(this Weapon weapon) where T : WeaponBehavior
    {
        weapon.weaponBehaviors = weapon.weaponBehaviors.RemoveItemsOfType<WeaponBehavior, T>();
    }
}