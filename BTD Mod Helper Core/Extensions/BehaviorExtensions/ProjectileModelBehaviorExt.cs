using Assets.Scripts.Models;
using System.Collections.Generic;

#if BloonsTD6
using Assets.Scripts.Models.Towers.Projectiles;
#elif BloonsAT
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
#endif

namespace BTD_Mod_Helper.Extensions
{
    public static class ProjectileModelBehaviorExt
    {
        /// <summary>
        /// (Cross-Game compatible) Check if this has a specific Behavior
        /// </summary>
        /// <typeparam name="T">The Behavior you're checking for</typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool HasBehavior<T>(this ProjectileModel model) where T : Model
        {
            return model.behaviors.HasItemsOfType<Model, T>();
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first Behavior of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T GetBehavior<T>(this ProjectileModel model) where T : Model
        {
            return model.behaviors.GetItemOfType<Model, T>();
        }

        /// <summary>
        /// (Cross-Game compatible) Return all Behaviors of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<T> GetBehaviors<T>(this ProjectileModel model) where T : Model
        {
            return model.behaviors.GetItemsOfType<Model, T>();
        }

        /// <summary>
        /// (Cross-Game compatible) Add a Behavior to this
        /// </summary>
        /// <typeparam name="T">The Behavior you want to add</typeparam>
        /// <param name="model"></param>
        /// <param name="behavior"></param>
        public static void AddBehavior<T>(this ProjectileModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.AddTo(behavior);
        }

        /// <summary>
        /// (Cross-Game compatible) Remove the first Behavior of Type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="model"></param>
        public static void RemoveBehavior<T>(this ProjectileModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemOfType<Model, T>();
        }

        /// <summary>
        /// (Cross-Game compatible) Remove the first Behavior of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="model"></param>
        /// <param name="behavior"></param>
        public static void RemoveBehavior<T>(this ProjectileModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItem(behavior);
        }

        /// <summary>
        /// (Cross-Game compatible) Remove all Behaviors of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="model"></param>
        public static void RemoveBehaviors<T>(this ProjectileModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemsOfType<Model, T>();
        }
    }
}
