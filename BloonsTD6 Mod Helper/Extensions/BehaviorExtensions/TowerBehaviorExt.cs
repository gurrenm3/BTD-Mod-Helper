using Assets.Scripts.Simulation.Towers;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class TowerBehaviorExt
    {
        /// <summary>
        /// Check if this has a specific Behavior
        /// </summary>
        /// <typeparam name="T">The Behavior you're checking for</typeparam>
        /// <param name="tower"></param>
        /// <returns></returns>
        public static bool HasTowerBehavior<T>(this Tower tower) where T : TowerBehavior
        {
            return tower.towerBehaviors.HasItemsOfType<TowerBehavior, T>();
        }

        /// <summary>
        /// Return the first Behavior of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T GetTowerBehavior<T>(this Tower tower) where T : TowerBehavior
        {
            return tower.towerBehaviors.GetItemOfType<TowerBehavior, T>();
        }

        /// <summary>
        /// Return all Behaviors of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<T> GetTowerBehaviors<T>(this Tower tower) where T : TowerBehavior
        {
            return tower.towerBehaviors.GetItemsOfType<TowerBehavior, T>();
        }

        /// <summary>
        /// Add a Behavior to this
        /// </summary>
        /// <typeparam name="T">The Behavior you want to add</typeparam>
        /// <param name="model"></param>
        /// <param name="behavior"></param>
        public static void AddTowerBehavior<T>(this Tower tower, T behavior) where T : TowerBehavior
        {
            tower.towerBehaviors.Add(behavior);
        }

        /// <summary>
        /// Remove the first Behavior of Type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="model"></param>
        public static void RemoveTowerBehavior<T>(this Tower tower) where T : TowerBehavior
        {
            tower.towerBehaviors = tower.towerBehaviors.RemoveItemOfType<TowerBehavior, T>();
        }

        /// <summary>
        /// Remove the first Behavior of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="model"></param>
        /// <param name="behavior"></param>
        public static void RemoveTowerBehavior<T>(this Tower tower, T behavior) where T : TowerBehavior
        {
            tower.towerBehaviors = tower.towerBehaviors.RemoveItem(behavior);
        }

        /// <summary>
        /// Remove all Behaviors of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        /// <param name="model"></param>
        public static void RemoveTowerBehaviors<T>(this Tower tower) where T : TowerBehavior
        {
            tower.towerBehaviors = tower.towerBehaviors.RemoveItemsOfType<TowerBehavior, T>();
        }
    }
}
