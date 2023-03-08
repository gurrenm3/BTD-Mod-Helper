using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Behavior extensions for AirUnitModels
/// </summary>
public static class AirUnitModelBehaviorExt
{
    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public static bool HasBehavior<T>(this AirUnitModel model) where T : Model
    {
        return ModelBehaviorExt.HasBehavior<T>(model);
    }

    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    /// <param name="model"></param>
    /// <param name="behavior"></param>
    /// <returns></returns>
    public static bool HasBehavior<T>(this AirUnitModel model, out T behavior) where T : Model
    {
        return ModelBehaviorExt.HasBehavior(model, out behavior);
    }

    /// <summary>
    /// Return the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public static T GetBehavior<T>(this AirUnitModel model) where T : Model
    {
        return ModelBehaviorExt.GetBehavior<T>(model);
    }

    /// <summary>
    /// Return all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public static List<T> GetBehaviors<T>(this AirUnitModel model) where T : Model
    {
        return ModelBehaviorExt.GetBehaviors<T>(model).ToList();
    }

    /// <summary>
    /// Add a Behavior to this
    /// </summary>
    /// <typeparam name="T">The Behavior you want to add</typeparam>
    /// <param name="model"></param>
    /// <param name="behavior"></param>
    public static void AddBehavior<T>(this AirUnitModel model, T behavior) where T : Model
    {
        ModelBehaviorExt.AddBehavior(model, behavior);
    }

    /// <summary>
    /// Remove the first Behavior of Type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="model"></param>
    public static void RemoveBehavior<T>(this AirUnitModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior<T>(model);
    }

    /// <summary>
    /// Removes a specific behavior from a tower
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="model"></param>
    /// <param name="behavior"></param>
    public static void RemoveBehavior<T>(this AirUnitModel model, T behavior) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior(model, behavior);
    }

    /// <summary>
    /// Remove all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="model"></param>
    public static void RemoveBehaviors<T>(this AirUnitModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehaviors<T>(model);
    }
}
