using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;
using Enumerable = System.Linq.Enumerable;

#if BloonsTD6
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Powers;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Mutators;
using Assets.Scripts.Models.Towers.Pets;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Props;
using Assets.Scripts.Models.Towers.Weapons;
#endif


namespace BTD_Mod_Helper.Extensions
{
    /// <summary>
    /// Extensions for dealing with the behaviors of Models
    /// </summary>
    internal static class ModelBehaviorExt
    {
        /// <summary>
        /// Gets the behaviors of a model. If the model does not have a behaviors field, then this returns null.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IEnumerable<Model> GetBehaviors(this Model model)
        {
#if BloonsTD6
            if (model.IsType(out AbilityModel abilityModel))
                return abilityModel.behaviors ?? Enumerable.Empty<Model>();
            if (model.IsType(out ProjectileModel projectileModel))
                return projectileModel.behaviors ?? Enumerable.Empty<Model>();
            if (model.IsType(out TowerModel towerModel))
                return towerModel.behaviors ?? Enumerable.Empty<Model>();
            if (model.IsType(out BloonModel bloonModel))
                return bloonModel.behaviors ?? Enumerable.Empty<Model>();
            if (model.IsType(out AttackModel attackModel))
                return attackModel.behaviors ?? Enumerable.Empty<Model>();
            if (model.IsType(out PropModel propModel))
                return propModel.behaviors ?? Enumerable.Empty<Model>();

            if (model.IsType(out WeaponModel weaponModel))
                return weaponModel.behaviors.CastAll<WeaponBehaviorModel, Model>() ?? Enumerable.Empty<Model>();
            if (model.IsType(out PowerModel powerModel))
                return powerModel.behaviors.CastAll<PowerBehaviorModel, Model>() ?? Enumerable.Empty<Model>();
            if (model.IsType(out EmissionModel emissionModel))
                return emissionModel.behaviors.CastAll<EmissionBehaviorModel, Model>() ?? Enumerable.Empty<Model>();
            if (model.IsType(out AirUnitModel airUnitModel))
                return airUnitModel.behaviors.CastAll<TowerBehaviorModel, Model>() ?? Enumerable.Empty<Model>();
            if (model.IsType(out PetModel petModel))
                return petModel.behaviors.CastAll<PetBehaviorModel, Model>() ?? Enumerable.Empty<Model>();

            if (model.IsType(out AddBehaviorToTowerMutatorModel addModel))
                return addModel.behaviors.CastAll<TowerBehaviorModel, Model>() ?? Enumerable.Empty<Model>();
            if (model.IsType(out AddBehaviorToTowerSupportModel addModel2))
                return addModel2.behaviors.CastAll<TowerBehaviorModel, Model>() ?? Enumerable.Empty<Model>();
            if (model.IsType(out AddBehaviorToBloonInZoneModel addModel3))
                return addModel3.behaviors.CastAll<BloonBehaviorModel, Model>() ?? Enumerable.Empty<Model>();
            if (model.IsType(out AddBehaviorToBloonModel addModel4))
                return addModel4.behaviors.CastAll<BloonBehaviorModel, Model>() ?? Enumerable.Empty<Model>();
            if (model.IsType(out AddbehaviorToWeaponModel addModel5))
                return addModel5.behaviors.CastAll<WeaponBehaviorModel, Model>() ?? Enumerable.Empty<Model>();
#endif

            ModHelper.Warning($"Type {model.GetIl2CppType().Name} does not have behaviors");

            return null!;
        }

        /// <summary>
        /// Sets the behaviors of a model to the specified IEnumerable of behaviors
        /// </summary>
        /// <param name="model">The model</param>
        /// <param name="behaviors">The new behaviors</param>
        /// <param name="handleDependents">Whether this should handle adding and removing dependents itself</param>
        public static void SetBehaviors(this Model model, IEnumerable<Model> behaviors, bool handleDependents = true)
        {
            var il2CppReferenceArray = behaviors.ToIl2CppReferenceArray();

            var children = model.GetBehaviors();
            if (children != null && handleDependents)
            {
                foreach (var child in children)
                {
                    model.RemoveChildDependant(child);
                }

                foreach (var behavior in il2CppReferenceArray)
                {
                    model.AddChildDependant(behavior);
                }
            }

#if BloonsTD6
            if (model.IsType(out AbilityModel abilityModel))
                abilityModel.behaviors = il2CppReferenceArray;
            else if (model.IsType(out ProjectileModel projectileModel))
                projectileModel.behaviors = il2CppReferenceArray;
            else if (model.IsType(out TowerModel towerModel))
                towerModel.behaviors = il2CppReferenceArray;
            else if (model.IsType(out BloonModel bloonModel))
                bloonModel.behaviors = il2CppReferenceArray;
            else if (model.IsType(out AttackModel attackModel))
                attackModel.behaviors = il2CppReferenceArray;
            else if (model.IsType(out PropModel propModel))
                propModel.behaviors = il2CppReferenceArray;

            else if (model.IsType(out WeaponModel weaponModel))
                weaponModel.behaviors = il2CppReferenceArray.DuplicateAs<Model, WeaponBehaviorModel>();
            else if (model.IsType(out PowerModel powerModel))
                powerModel.behaviors = il2CppReferenceArray.DuplicateAs<Model, PowerBehaviorModel>();
            else if (model.IsType(out EmissionModel emissionModel))
                emissionModel.behaviors = il2CppReferenceArray.DuplicateAs<Model, EmissionBehaviorModel>();
            else if (model.IsType(out AirUnitModel airUnitModel))
                airUnitModel.behaviors = il2CppReferenceArray.DuplicateAs<Model, TowerBehaviorModel>();
            else if (model.IsType(out PetModel petModel))
                petModel.behaviors = il2CppReferenceArray.DuplicateAs<Model, PetBehaviorModel>();

            else if (model.IsType(out AddBehaviorToTowerMutatorModel addModel))
                addModel.behaviors = il2CppReferenceArray.DuplicateAs<Model, TowerBehaviorModel>();
            else if (model.IsType(out AddBehaviorToTowerSupportModel addModel2))
                addModel2.behaviors = il2CppReferenceArray.DuplicateAs<Model, TowerBehaviorModel>();
            else if (model.IsType(out AddBehaviorToBloonInZoneModel addModel3))
                addModel3.behaviors = il2CppReferenceArray.DuplicateAs<Model, BloonBehaviorModel>();
            else if (model.IsType(out AddBehaviorToBloonModel addModel4))
                addModel4.behaviors = il2CppReferenceArray.DuplicateAs<Model, BloonBehaviorModel>();
            else if (model.IsType(out AddbehaviorToWeaponModel addModel5))
                addModel5.behaviors = il2CppReferenceArray.DuplicateAs<Model, WeaponBehaviorModel>();
#endif
            
        }

        /// <summary>
        /// (Cross-Game compatible) Check if this has a specific Behavior
        /// </summary>
        /// <typeparam name="T">The Behavior you're checking for</typeparam>
        public static bool HasBehavior<T>(this Model model) where T : Model
        {
            return model.GetBehaviors().Any(b => b.IsType<T>());
        }

        /// <summary>
        /// (Cross-Game compatible) Check if this has a specific Behavior and return it
        /// </summary>
        /// <typeparam name="T">The Behavior you're checking for</typeparam>
        public static bool HasBehavior<T>(this Model model, out T behavior) where T : Model
        {
            behavior = model.GetBehavior<T>()!;
            return behavior != null;
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first Behavior of type T, or null if there isn't one
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        public static T GetBehavior<T>(this Model model) where T : Model
        {
            return model.GetBehaviors().FirstOrDefault(m => m.IsType<T>())?.Cast<T>();
        }

        /// <summary>
        /// (Cross-Game compatible) Return the index'th Behavior of type T, or null
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        public static T GetBehavior<T>(this Model model, int index) where T : Model
        {
            return model.GetBehaviors<T>().Skip(index).FirstOrDefault();
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first Behavior of type T whose name contains the given string, or null
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        public static T GetBehavior<T>(this Model model, string nameContains) where T : Model
        {
            return model.GetBehaviors<T>()?.FirstOrDefault(m => m.name.Contains(nameContains));
        }

        /// <summary>
        /// (Cross-Game compatible) Return all Behaviors of type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want</typeparam>
        public static IEnumerable<T> GetBehaviors<T>(this Model model) where T : Model
        {
            return model.GetBehaviors().Select(b => b?.TryCast<T>()).Where(b => b != null)!;
        }

        /// <summary>
        /// (Cross-Game compatible) Add a Behavior to this model
        /// </summary>
        public static void AddBehavior(this Model model, Model behavior)
        {
            var behaviors = model.GetBehaviors();
            if (behaviors != null)
            {
                model.SetBehaviors(behaviors.Append(behavior), false);
                model.AddChildDependant(behavior);
            }
        }

        /// <summary>
        /// (Cross-Game compatible) Remove the first Behavior of Type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        public static void RemoveBehavior<T>(this Model model) where T : Model
        {
            if (model.HasBehavior(out T behavior))
            {
                model.RemoveBehavior(behavior);
            }
        }

        /// <summary>
        /// (Cross-Game compatible) Remove the index'th Behavior of Type T
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        public static void RemoveBehavior<T>(this Model model, int index) where T : Model
        {
            var behavior = model.GetBehavior<T>(index);
            if (behavior != null)
            {
                model.RemoveBehavior(behavior);
            }
        }

        /// <summary>
        /// (Cross-Game compatible) Remove the first Behavior of Type T whose name contains a certain string
        /// </summary>
        /// <typeparam name="T">The Behavior you want to remove</typeparam>
        public static void RemoveBehavior<T>(this Model model, string nameContains) where T : Model
        {
            var behavior = model.GetBehavior<T>(nameContains);
            if (behavior != null)
            {
                model.RemoveBehavior(behavior);
            }
        }

        /// <summary>
        /// (Cross-Game compatible) Removes a specific behavior from a tower
        /// </summary>
        public static void RemoveBehavior(this Model model, Model behavior)
        {
            var behaviors = model.GetBehaviors();
            if (behaviors != null)
            {
                model.SetBehaviors(behaviors.Where(b => b?.Equals(behavior) != true), false);
                model.RemoveChildDependant(behavior);
            }
        }

        /// <summary>
        /// (Cross-Game compatible) Remove all Behaviors of type T
        /// </summary>
        public static void RemoveBehaviors<T>(this Model model) where T : Model
        {
            var behaviors = model.GetBehaviors();
            if (behaviors != null)
            {
                model.SetBehaviors(behaviors.Where(b => !b.IsType<T>()));
            }
        }
    }
}