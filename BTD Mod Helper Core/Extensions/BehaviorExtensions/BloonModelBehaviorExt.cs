using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class BloonModelBehaviorExt
    {
        public static bool HasBehavior<T>(this BloonModel model) where T : Model
        {
            return model.behaviors.HasItemsOfType<Model, T>();
        }

        public static T GetBehavior<T>(this BloonModel model) where T : Model
        {
            return model.behaviors.GetItemOfType<Model, T>();
        }

        public static List<T> GetBehaviors<T>(this BloonModel model) where T : Model
        {
            return model.behaviors.GetItemsOfType<Model, T>();
        }

        public static void AddBehavior<T>(this BloonModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.AddTo(behavior);
        }

        public static void RemoveBehavior<T>(this BloonModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemOfType<Model, T>();
        }

        public static void RemoveBehavior<T>(this BloonModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItem(behavior);
        }

        public static void RemoveBehaviors<T>(this BloonModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemsOfType<Model, T>();
        }
    }
}
