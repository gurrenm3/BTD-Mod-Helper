using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Behavior extensions for TowerModels
/// </summary>
public static class TowerModelBehaviorExt
{
    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public static bool HasBehavior<T>(this TowerModel model) where T : Model => ModelBehaviorExt.HasBehavior<T>(model);

    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    /// <param name="model"></param>
    /// <param name="behavior"></param>
    /// <returns></returns>
    public static bool HasBehavior<T>(this TowerModel model, out T behavior) where T : Model =>
        ModelBehaviorExt.HasBehavior(model, out behavior);

    /// <summary>
    /// Return the first Behavior of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public static T GetBehavior<T>(this TowerModel model) where T : Model => ModelBehaviorExt.GetBehavior<T>(model);

    /// <summary>
    /// Return all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public static List<T> GetBehaviors<T>(this TowerModel model) where T : Model =>
        ModelBehaviorExt.GetBehaviors<T>(model).ToList();

    /// <summary>
    /// Add a Behavior to this
    /// </summary>
    /// <typeparam name="T">The Behavior you want to add</typeparam>
    /// <param name="model"></param>
    /// <param name="behavior"></param>
    public static void AddBehavior<T>(this TowerModel model, T behavior) where T : Model
    {
        ModelBehaviorExt.AddBehavior(model, behavior);
    }

    /// <summary>
    /// Remove the first Behavior of Type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="model"></param>
    public static void RemoveBehavior<T>(this TowerModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior<T>(model);
    }

    /// <summary>
    /// Removes a specific behavior from a tower
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="model"></param>
    /// <param name="behavior"></param>
    public static void RemoveBehavior<T>(this TowerModel model, T behavior) where T : Model
    {
        ModelBehaviorExt.RemoveBehavior(model, behavior);
    }

    /// <summary>
    /// Remove all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want to remove</typeparam>
    /// <param name="model"></param>
    public static void RemoveBehaviors<T>(this TowerModel model) where T : Model
    {
        ModelBehaviorExt.RemoveBehaviors<T>(model);
    }

    /// <summary>
    /// Adds a wrapped behavior from a ModelHelper to this tower
    /// </summary>
    public static void AddBehavior(this TowerModel model, ModelHelper behavior)
    {
        ModelBehaviorExt.AddBehavior(model, behavior.Model);
    }
}