using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class AbilityModelBehaviorExt
    {
        public static bool HasBehavior<T>(this AbilityModel model) where T : AbilityBehaviorModel
        {
            return model.behaviors.HasItemsOfType<AbilityBehaviorModel, T>();
        }

        public static T GetBehavior<T>(this AbilityModel model) where T : AbilityBehaviorModel
        {
            return model.behaviors.GetItemOfType<AbilityBehaviorModel, T>();
        }

        public static List<T> GetBehaviors<T>(this AbilityModel model) where T : AbilityBehaviorModel
        {
            return model.behaviors.GetItemsOfType<AbilityBehaviorModel, T>();
        }

        public static void AddBehavior<T>(this AbilityModel model, T behavior) where T : AbilityBehaviorModel
        {
            model.behaviors = model.behaviors.AddTo(behavior);
        }

        public static void RemoveBehavior<T>(this AbilityModel model) where T : AbilityBehaviorModel
        {
            model.behaviors = model.behaviors.RemoveItemOfType<AbilityBehaviorModel, T>();
        }

        public static void RemoveBehavior<T>(this AbilityModel model, T behavior) where T : AbilityBehaviorModel
        {
            model.behaviors = model.behaviors.RemoveItem(behavior);
        }

        public static void RemoveBehaviors<T>(this AbilityModel model) where T : AbilityBehaviorModel
        {
            model.behaviors = model.behaviors.RemoveItemsOfType<AbilityBehaviorModel, T>();
        }
    }
}
