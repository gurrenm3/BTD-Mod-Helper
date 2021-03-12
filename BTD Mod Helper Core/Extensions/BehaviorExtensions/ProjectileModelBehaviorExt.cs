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
        public static bool HasBehavior<T>(this ProjectileModel model) where T : Model
        {
            return model.behaviors.HasItemsOfType<Model, T>();
        }

        public static T GetBehavior<T>(this ProjectileModel model) where T : Model
        {
            return model.behaviors.GetItemOfType<Model, T>();
        }

        public static List<T> GetBehaviors<T>(this ProjectileModel model) where T : Model
        {
            return model.behaviors.GetItemsOfType<Model, T>();
        }

        public static void AddBehavior<T>(this ProjectileModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.AddTo(behavior);
        }

        public static void RemoveBehavior<T>(this ProjectileModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemOfType<Model, T>();
        }

        public static void RemoveBehavior<T>(this ProjectileModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItem(behavior);
        }

        public static void RemoveBehaviors<T>(this ProjectileModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemsOfType<Model, T>();
        }
    }
}
