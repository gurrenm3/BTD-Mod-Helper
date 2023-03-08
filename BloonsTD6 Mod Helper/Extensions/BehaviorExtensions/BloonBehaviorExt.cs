using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for getting bloon behaviors
/// </summary>
public static class BloonBehaviorExt
{
    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    /// <param name="bloon"></param>
    /// <returns></returns>
    public static bool HasBloonBehavior<T>(this Bloon bloon) where T : BloonBehavior
    {
        return bloon.bloonBehaviors.HasItemsOfType<BloonBehavior, T>();
    }

    /// <summary>
    /// Return the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="bloon"></param>
    /// <returns></returns>
    public static T GetBloonBehavior<T>(this Bloon bloon) where T : BloonBehavior
    {
        return bloon.bloonBehaviors.GetItemOfType<BloonBehavior, T>();
    }

    /// <summary>
    /// Return all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="bloon"></param>
    /// <returns></returns>
    public static List<T> GetBloonBehaviors<T>(this Bloon bloon) where T : BloonBehavior
    {
        return bloon.bloonBehaviors.GetItemsOfType<BloonBehavior, T>();
    }

    /// <summary>
    /// Add a Behavior to this
    /// </summary>
    /// <typeparam name="T">The Behavior you want to add</typeparam>
    /// <param name="bloon"></param>
    /// <param name="behavior"></param>
    public static void AddBloonBehavior<T>(this Bloon bloon, T behavior) where T : BloonBehavior
    {
        bloon.bloonBehaviors.Add(behavior);
    }

    /// <summary>
    /// Remove the first Behavior of Type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="bloon"></param>
    public static void RemoveBloonBehavior<T>(this Bloon bloon) where T : BloonBehavior
    {
        bloon.bloonBehaviors = bloon.bloonBehaviors.RemoveItemOfType<BloonBehavior, T>();
    }

    /// <summary>
    /// Remove the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="bloon"></param>
    /// <param name="behavior"></param>
    public static void RemoveBloonBehavior<T>(this Bloon bloon, T behavior) where T : BloonBehavior
    {
        bloon.bloonBehaviors = bloon.bloonBehaviors.RemoveItem(behavior);
    }

    /// <summary>
    /// Remove all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="bloon"></param>
    public static void RemoveBloonBehaviors<T>(this Bloon bloon) where T : BloonBehavior
    {
        bloon.bloonBehaviors = bloon.bloonBehaviors.RemoveItemsOfType<BloonBehavior, T>();
    }
}