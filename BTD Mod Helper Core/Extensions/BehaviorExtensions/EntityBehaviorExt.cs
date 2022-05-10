﻿using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Objects;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class EntityBehaviorExt
    {
        /// <summary>
        /// (Cross-Game compatible) Check if this has a specific Behavior
        /// </summary>
        /// <typeparam name="T">The Behavior you're checking for</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool HasBehavior<T>(this Entity entity) where T : Model
        {
            return entity.behaviors.HasItemsOfType<RootBehavior, T>();
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first Behavior of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T GetBehavior<T>(this Entity entity) where T : Model
        {
            return entity.behaviors.First(behavior => behavior.IsType<T>()).Cast<T>();
        }

        /// <summary>
        /// (Cross-Game compatible) Return all Behaviors of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static List<T> GetBehaviors<T>(this Entity entity) where T : Model
        {
            return entity.behaviors.GetItemsOfType<RootBehavior, T>();
        }

        /// <summary>
        /// (Cross-Game compatible) Add a Behavior to this
        /// </summary>
        /// <typeparam name="T">The Behavior you want to add</typeparam>
        /// <param name="entity"></param>
        /// <param name="behavior"></param>
        public static void AddBehavior<T>(this Entity entity, T behavior) where T : Model
        {
            entity.behaviors = entity.behaviors.AddTo(behavior);
        }

        /// <summary>
        /// (Cross-Game compatible) Remove the first Behavior of Type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="entity"></param>
        public static void RemoveBehavior<T>(this Entity entity) where T : Model
        {
            entity.behaviors = entity.behaviors.RemoveItemOfType<RootBehavior, T>();
        }

        /// <summary>
        /// (Cross-Game compatible) Remove the first Behavior of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="entity"></param>
        /// <param name="behavior"></param>
        public static void RemoveBehavior<T>(this Entity entity, T behavior) where T : Model
        {
            entity.behaviors = entity.behaviors.RemoveItem(behavior);
        }

        /// <summary>
        /// (Cross-Game compatible) Remove all Behaviors of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="entity"></param>
        public static void RemoveBehaviors<T>(this Entity entity) where T : Model
        {
            entity.behaviors = entity.behaviors.RemoveItemsOfType<RootBehavior, T>();
        }
    }
}
