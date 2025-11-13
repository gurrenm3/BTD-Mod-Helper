using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Artifacts;
using Il2CppAssets.Scripts.Models.Artifacts.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.MapEditorBehaviors;
using Il2CppAssets.Scripts.Models.Powers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Mutators;
using Il2CppAssets.Scripts.Models.Towers.Pets;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;

namespace BTD_Mod_Helper.Extensions;

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
            return weaponModel.behaviors ?? Enumerable.Empty<Model>();

        if (model.IsType(out PowerModel powerModel))
            return powerModel.behaviors?.OfIl2CppType<PowerBehaviorModel>() ?? [];
        if (model.IsType(out EmissionModel emissionModel))
            return emissionModel.behaviors?.OfIl2CppType<EmissionBehaviorModel>() ?? [];
        if (model.IsType(out AirUnitModel airUnitModel))
            return airUnitModel.behaviors?.OfIl2CppType<TowerBehaviorModel>() ?? [];
        if (model.IsType(out PetModel petModel))
            return petModel.behaviors?.OfIl2CppType<PetBehaviorModel>() ?? [];

        if (model.IsType(out AddBehaviorToTowerMutatorModel addModel))
            return addModel.behaviors?.OfIl2CppType<TowerBehaviorModel>() ?? [];
        if (model.IsType(out AddBehaviorToTowerSupportModel addModel2))
            return addModel2.behaviors?.OfIl2CppType<TowerBehaviorModel>() ?? [];
        if (model.IsType(out AddBehaviorToBloonInZoneModel addModel3))
            return addModel3.behaviors?.OfIl2CppType<BloonBehaviorModel>() ?? [];
        if (model.IsType(out AddBehaviorToBloonModel addModel4))
            return addModel4.behaviors?.OfIl2CppType<BloonBehaviorModel>() ?? [];
        if (model.IsType(out AddbehaviorToWeaponModel addModel5))
            return addModel5.behaviors?.OfIl2CppType<WeaponBehaviorModel>() ?? [];

        if (model.IsType(out ItemArtifactModel itemArtifactModel))
            return itemArtifactModel.artifactBehaviors ?? Enumerable.Empty<Model>();
        if (model.IsType(out BoostArtifactModel boostArtifactModel))
            return boostArtifactModel.artifactBehaviors ?? Enumerable.Empty<Model>();
        if (model.IsType(out MapArtifactModel mapArtifactModel))
            return mapArtifactModel.artifactBehaviors ?? Enumerable.Empty<Model>();

        ModHelper.Warning($"Type {model.GetIl2CppType().Name} does not have behaviors");

        return null;
    }

    /// <summary>
    /// Sets the behaviors of a model to the specified IEnumerable of behaviors
    /// </summary>
    /// <param name="model">The model</param>
    /// <param name="behaviors">The new behaviors</param>
    /// <param name="handleDependents">Whether this should handle adding and removing dependents itself</param>
    public static void SetBehaviors(this Model model, IEnumerable<Model> behaviors, bool handleDependents = true)
    {
        var children = model.GetBehaviors();
        if (children != null && handleDependents)
        {
            model.RemoveChildDependants(children);
        }

        if (model.IsType(out AbilityModel abilityModel))
            abilityModel.behaviors = behaviors.ToIl2CppReferenceArray();
        else if (model.IsType(out ProjectileModel projectileModel))
            projectileModel.behaviors = behaviors.ToIl2CppReferenceArray();
        else if (model.IsType(out TowerModel towerModel))
            towerModel.behaviors = behaviors.ToIl2CppReferenceArray();
        else if (model.IsType(out BloonModel bloonModel))
            bloonModel.behaviors = behaviors.ToIl2CppReferenceArray();
        else if (model.IsType(out AttackModel attackModel))
            attackModel.behaviors = behaviors.ToIl2CppReferenceArray();
        else if (model.IsType(out PropModel propModel))
            propModel.behaviors = behaviors.ToIl2CppReferenceArray();
        else if (model.IsType(out WeaponModel weaponModel))
            weaponModel.behaviors = behaviors.ToIl2CppReferenceArray();

        else if (model.IsType(out PowerModel powerModel))
            powerModel.behaviors = behaviors.OfIl2CppType<PowerBehaviorModel>().ToIl2CppReferenceArray();
        else if (model.IsType(out EmissionModel emissionModel))
            emissionModel.behaviors = behaviors.OfIl2CppType<EmissionBehaviorModel>().ToIl2CppReferenceArray();
        else if (model.IsType(out AirUnitModel airUnitModel))
            airUnitModel.behaviors = behaviors.OfIl2CppType<TowerBehaviorModel>().ToIl2CppReferenceArray();
        else if (model.IsType(out PetModel petModel))
            petModel.behaviors = behaviors.OfIl2CppType<PetBehaviorModel>().ToIl2CppReferenceArray();

        else if (model.IsType(out AddBehaviorToTowerMutatorModel addModel))
            addModel.behaviors = behaviors.OfIl2CppType<TowerBehaviorModel>().ToIl2CppReferenceArray();
        else if (model.IsType(out AddBehaviorToTowerSupportModel addModel2))
            addModel2.behaviors = behaviors.OfIl2CppType<TowerBehaviorModel>().ToIl2CppReferenceArray();
        else if (model.IsType(out AddBehaviorToBloonInZoneModel addModel3))
            addModel3.behaviors = behaviors.OfIl2CppType<BloonBehaviorModel>().ToIl2CppReferenceArray();
        else if (model.IsType(out AddBehaviorToBloonModel addModel4))
            addModel4.behaviors = behaviors.OfIl2CppType<BloonBehaviorModel>().ToIl2CppReferenceArray();
        else if (model.IsType(out AddbehaviorToWeaponModel addModel5))
            addModel5.behaviors = behaviors.OfIl2CppType<WeaponBehaviorModel>().ToIl2CppReferenceArray();

        else if (model.IsType(out ItemArtifactModel itemArtifactModel))
            itemArtifactModel.artifactBehaviors =
                behaviors.OfIl2CppType<ItemArtifactBehaviorModel>().ToIl2CppReferenceArray();
        else if (model.IsType(out BoostArtifactModel boostArtifactModel))
            boostArtifactModel.artifactBehaviors =
                behaviors.OfIl2CppType<BoostArtifactBehaviorModel>().ToIl2CppReferenceArray();
        else if (model.IsType(out MapArtifactModel mapArtifactModel))
            mapArtifactModel.artifactBehaviors = behaviors.OfIl2CppType<MapArtifactBehaviorModel>().ToIl2CppReferenceArray();

        if (handleDependents)
        {
            model.AddChildDependants(model.GetBehaviors());
        }
    }

    /// <summary>
    /// Check if this has a specific Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    public static bool HasBehavior<T>(this Model model) where T : Model =>
        model.GetBehaviors().Any(b => b.Is<T>());

    /// <summary>
    /// Check if this has a specific named Behavior
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    public static bool HasBehavior<T>(this Model model, string nameContains) where T : Model
    {
        var behavior = model.GetBehavior<T>(nameContains);
        return behavior != null;
    }

    /// <summary>
    /// Check if this has a specific Behavior and return it
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    public static bool HasBehavior<T>(this Model model, [NotNullWhen(true)] out T behavior) where T : Model
    {
        behavior = model.GetBehavior<T>();
        return behavior != null;
    }

    /// <summary>
    /// Check if this has a specific named Behavior and return it
    /// </summary>
    /// <typeparam name="T">The Behavior you're checking for</typeparam>
    public static bool HasBehavior<T>(this Model model, string nameContains, [NotNullWhen(true)] out T behavior)
        where T : Model
    {
        behavior = model.GetBehavior<T>(nameContains);
        return behavior != null;
    }

    /// <summary>
    /// Return the first Behavior of type T, or null if there isn't one
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    public static T GetBehavior<T>(this Model model) where T : Model =>
        model.GetBehaviors().FirstOrDefault(m => m.Is<T>())?.Cast<T>();

    /// <summary>
    /// Return the index'th Behavior of type T, or null
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    public static T GetBehavior<T>(this Model model, int index) where T : Model =>
        model.GetBehaviors<T>().Skip(index).FirstOrDefault();

    /// <summary>
    /// Return the first Behavior of type T whose name contains the given string, or null
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    public static T GetBehavior<T>(this Model model, string nameContains) where T : Model =>
        model.GetBehaviors().FirstOrDefault(m => m.Is<T>() && m.name.Contains(nameContains))?.Cast<T>();

    /// <summary>
    /// Return all Behaviors of type T
    /// </summary>
    /// <typeparam name="T">The Behavior you want</typeparam>
    public static IEnumerable<T> GetBehaviors<T>(this Model model) where T : Model =>
        model.GetBehaviors().Select(b => b?.TryCast<T>()).Where(b => b != null);

    /// <summary>
    /// Add a Behavior to this model
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
    /// Remove the first Behavior of Type T
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
    /// Remove the index'th Behavior of Type T
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
    /// Remove the first Behavior of Type T whose name contains a certain string
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
    /// Removes a specific behavior from a tower
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
    /// Remove all Behaviors of type T
    /// </summary>
    public static void RemoveBehaviors<T>(this Model model) where T : Model
    {
        var behaviors = model.GetBehaviors();
        if (behaviors != null)
        {
            model.SetBehaviors(behaviors.Where(b => !b.IsType<T>()));
        }
    }

    /// <summary>
    /// Remove all Behaviors
    /// </summary>
    public static void RemoveBehaviors(this Model model) => model.SetBehaviors([]);

    /// <summary>
    /// Adds a wrapped behavior from a ModelHelper to this tower
    /// </summary>
    public static void AddBehavior(this Model model, ModelHelper behavior) => AddBehavior(model, behavior.Model);
}