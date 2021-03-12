using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class WeaponModelBehaviorExt
    {
        public static bool HasBehavior<T>(this WeaponModel model) where T : Model
        {
            return model.behaviors.HasItemsOfType<WeaponBehaviorModel, T>();
        }

        public static T GetBehavior<T>(this WeaponModel model) where T : Model
        {
            return model.behaviors.GetItemOfType<WeaponBehaviorModel, T>();
        }

        public static List<T> GetBehaviors<T>(this WeaponModel model) where T : Model
        {
            return model.behaviors.GetItemsOfType<WeaponBehaviorModel, T>();
        }

        public static void AddBehavior<T>(this WeaponModel model, T behavior) where T : WeaponBehaviorModel
        {
            model.behaviors = model.behaviors.AddTo(behavior);
        }

        public static void RemoveBehavior<T>(this WeaponModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemOfType<WeaponBehaviorModel, T>();
        }

        public static void RemoveBehavior<T>(this WeaponModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItem(behavior);
        }

        public static void RemoveBehaviors<T>(this WeaponModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemsOfType<WeaponBehaviorModel, T>();
        }
    }
}
