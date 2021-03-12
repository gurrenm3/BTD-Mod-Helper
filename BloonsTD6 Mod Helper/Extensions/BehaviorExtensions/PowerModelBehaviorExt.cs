using Assets.Scripts.Models;
using Assets.Scripts.Models.Powers;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class PowerModelBehaviorExt
    {
        public static bool HasBehavior<T>(this PowerModel model) where T : Model
        {
            return model.behaviors.HasItemsOfType<PowerBehaviorModel, T>();
        }

        public static T GetBehavior<T>(this PowerModel model) where T : Model
        {
            return model.behaviors.GetItemOfType<PowerBehaviorModel, T>();
        }

        public static List<T> GetBehaviors<T>(this PowerModel model) where T : Model
        {
            return model.behaviors.GetItemsOfType<PowerBehaviorModel, T>();
        }

        public static void AddBehavior<T>(this PowerModel model, T behavior) where T : PowerBehaviorModel
        {
            model.behaviors = model.behaviors.AddTo(behavior);
        }

        public static void RemoveBehavior<T>(this PowerModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemOfType<PowerBehaviorModel, T>();
        }

        public static void RemoveBehavior<T>(this PowerModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItem(behavior);
        }

        public static void RemoveBehaviors<T>(this PowerModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemsOfType<PowerBehaviorModel, T>();
        }
    }
}
