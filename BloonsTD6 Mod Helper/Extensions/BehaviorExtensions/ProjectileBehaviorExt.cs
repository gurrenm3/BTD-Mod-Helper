﻿using Assets.Scripts.Simulation.Towers.Projectiles;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class ProjectileBehaviorExt
    {
        /// <summary>
        /// Check if this has a specific Behavior
        /// </summary>
        /// <typeparam name="T">The Behavior you're checking for</typeparam>
        /// <param name="attack"></param>
        /// <returns></returns>
        public static bool HasProjectileBehavior<T>(this Projectile projectile) where T : ProjectileBehavior
        {
            return projectile.projectileBehaviors.HasItemsOfType<ProjectileBehavior, T>();
        }

        /// <summary>
        /// Return the first Behavior of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        /// <param name="attack"></param>
        /// <returns></returns>
        public static T GetProjectileBehavior<T>(this Projectile projectile) where T : ProjectileBehavior
        {
            return projectile.projectileBehaviors.GetItemOfType<ProjectileBehavior, T>();
        }

        /// <summary>
        /// Return all Behaviors of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        /// <param name="attack"></param>
        /// <returns></returns>
        public static List<T> GetProjectileBehaviors<T>(this Projectile projectile) where T : ProjectileBehavior
        {
            return projectile.projectileBehaviors.GetItemsOfType<ProjectileBehavior, T>();
        }

        /// <summary>
        /// Add a Behavior to this
        /// </summary>
        /// <typeparam name="T">The Behavior you want to add</typeparam>
        /// <param name="attack"></param>
        /// <param name="behavior"></param>
        public static void AddProjectileBehavior<T>(this Projectile projectile, T behavior) where T : ProjectileBehavior
        {
            projectile.projectileBehaviors.Add(behavior);
        }

        /// <summary>
        /// Remove the first Behavior of Type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="attack"></param>
        public static void RemoveProjectileBehavior<T>(this Projectile projectile) where T : ProjectileBehavior
        {
            projectile.projectileBehaviors = projectile.projectileBehaviors.RemoveItemOfType<ProjectileBehavior, T>();
        }

        /// <summary>
        /// Remove the first Behavior of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="attack"></param>
        /// <param name="behavior"></param>
        public static void RemoveProjectileBehavior<T>(this Projectile projectile, T behavior) where T : ProjectileBehavior
        {
            projectile.projectileBehaviors = projectile.projectileBehaviors.RemoveItem(behavior);
        }

        /// <summary>
        /// Remove all Behaviors of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="attack"></param>
        public static void RemoveProjectileBehaviors<T>(this Projectile projectile) where T : ProjectileBehavior
        {
            projectile.projectileBehaviors = projectile.projectileBehaviors.RemoveItemsOfType<ProjectileBehavior, T>();
        }
    }
}
