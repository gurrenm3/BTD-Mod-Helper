using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Objects;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class EntityBehaviorExt
    {
        public static bool HasBehavior<T>(this Entity entity) where T : Model
        {
            return entity.behaviors.HasItemsOfType<RootBehavior, T>();
        }

        public static T GetBehavior<T>(this Entity entity) where T : Model
        {
            return entity.behaviors.GetItemOfType<RootBehavior, T>();
        }

        public static List<T> GetBehaviors<T>(this Entity entity) where T : Model
        {
            return entity.behaviors.GetItemsOfType<RootBehavior, T>();
        }

        public static void AddBehavior<T>(this Entity entity, T behavior) where T : Model
        {
            entity.behaviors = entity.behaviors.AddTo<RootBehavior, T>(behavior);
        }

        public static void RemoveBehavior<T>(this Entity entity) where T : Model
        {
            entity.behaviors = entity.behaviors.RemoveItemOfType<RootBehavior, T>();
        }

        public static void RemoveBehavior<T>(this Entity entity, T behavior) where T : Model
        {
            entity.behaviors = entity.behaviors.RemoveItem<RootBehavior, T>(behavior);
        }

        public static void RemoveBehaviors<T>(this Entity entity) where T : Model
        {
            entity.behaviors = entity.behaviors.RemoveItemsOfType<RootBehavior, T>();
        }
    }
}
