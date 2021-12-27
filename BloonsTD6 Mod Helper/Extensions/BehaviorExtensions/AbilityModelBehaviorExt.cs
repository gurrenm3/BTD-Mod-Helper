using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Extensions
{
    public static class AbilityModelBehaviorExt
    {
        public static bool HasBehavior<T>(this AbilityModel model) where T : Model
        {
            return ModelBehaviorExt.HasBehavior<T>(model);
        }

        public static T GetBehavior<T>(this AbilityModel model) where T : Model
        {
            return ModelBehaviorExt.GetBehavior<T>(model);
        }

        public static List<T> GetBehaviors<T>(this AbilityModel model) where T : Model
        {
            return ModelBehaviorExt.GetBehaviors<T>(model).ToList();
        }

        public static void AddBehavior<T>(this AbilityModel model, T behavior) where T : Model
        {
            ModelBehaviorExt.AddBehavior(model, behavior);
        }

        public static void RemoveBehavior<T>(this AbilityModel model) where T : Model
        {
            ModelBehaviorExt.RemoveBehavior<T>(model);
        }

        public static void RemoveBehavior<T>(this AbilityModel model, T behavior) where T : Model
        {
            ModelBehaviorExt.RemoveBehavior(model, behavior);
        }

        public static void RemoveBehaviors<T>(this AbilityModel model) where T : Model
        {
            ModelBehaviorExt.RemoveBehaviors<T>(model);
        }
    }
}
