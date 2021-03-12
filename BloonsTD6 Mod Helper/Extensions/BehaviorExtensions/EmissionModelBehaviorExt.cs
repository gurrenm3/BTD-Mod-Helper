using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class EmissionModelBehaviorExt
    {
        public static bool HasBehavior<T>(this EmissionModel model) where T : Model
        {
            return model.behaviors.HasItemsOfType<EmissionBehaviorModel, T>();
        }

        public static T GetBehavior<T>(this EmissionModel model) where T : Model
        {
            return model.behaviors.GetItemOfType<EmissionBehaviorModel, T>();
        }

        public static List<T> GetBehaviors<T>(this EmissionModel model) where T : Model
        {
            return model.behaviors.GetItemsOfType<EmissionBehaviorModel, T>();
        }

        public static void AddBehavior<T>(this EmissionModel model, T behavior) where T : EmissionBehaviorModel
        {
            model.behaviors = model.behaviors.AddTo(behavior);
        }

        public static void RemoveBehavior<T>(this EmissionModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemOfType<EmissionBehaviorModel, T>();
        }

        public static void RemoveBehavior<T>(this EmissionModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItem(behavior);
        }

        public static void RemoveBehaviors<T>(this EmissionModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemsOfType<EmissionBehaviorModel, T>();
        }
    }
}
