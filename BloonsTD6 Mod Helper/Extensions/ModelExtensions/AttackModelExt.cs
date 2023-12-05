using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for AttackModels
/// </summary>
public static class AttackModelExt
{
    /// <summary>
    /// Add a weapon to this Attack Model
    /// </summary>
    /// <param name="attackModel">this</param>
    /// <param name="weaponToAdd">Weapon to add</param>
    public static void AddWeapon(this AttackModel attackModel, WeaponModel weaponToAdd)
    {
        attackModel.weapons = attackModel.weapons.AddTo(weaponToAdd);
        attackModel.AddChildDependant(weaponToAdd);
    }

    /// <summary>
    /// Remove a weapon from this Attack Model
    /// </summary>
    /// <param name="attackModel">this</param>
    /// <param name="weaponToRemove">Weapon to remove</param>
    public static void RemoveWeapon(this AttackModel attackModel, WeaponModel weaponToRemove)
    {
        attackModel.weapons = attackModel.weapons.RemoveItem(weaponToRemove);
        attackModel.RemoveChildDependant(weaponToRemove);
    }

    /// <summary>
    /// Sets the weapon at the given index (default 0) of this attack model to be the given one.
    /// </summary>
    /// <param name="attackModel">this</param>
    /// <param name="weaponModel">Weapon to add</param>
    /// <param name="index">Index within weapons array</param>
    /// <exception cref="ArgumentException"> thrown when index &#60; 0</exception>
    public static void SetWeapon(this AttackModel attackModel, WeaponModel weaponModel, int index = 0)
    {
        if (attackModel.weapons == null)
        {
            attackModel.weapons = new[] {weaponModel};
        }
        else if (index >= attackModel.weapons.Length)
        {
            attackModel.weapons = attackModel.weapons.AddTo(weaponModel);
        }
        else if (index < 0)
        {
            throw new ArgumentException("Index can't be negative");
        }
        else
        {
            attackModel.RemoveChildDependant(attackModel.weapons[index]);
            attackModel.weapons[index] = weaponModel;
        }
        attackModel.AddChildDependant(weaponModel);
    }

    /// <summary>
    /// Recursively get all ProjectileModels for this attack model and all of it's weapons
    /// </summary>
    /// <param name="attackModel"></param>
    /// <returns></returns>
    [Obsolete("Use GetDescendants<ProjectileModel>() instead")]
    public static List<ProjectileModel> GetAllProjectiles(this AttackModel attackModel) =>
        attackModel.GetDescendants<ProjectileModel>().ToList();

    /// <summary>
    /// Applies the given ModDisplay to the index'th (or first) DisplayModel in the behaviors of the AttackModel.
    /// <br />
    /// If there are no DisplayModels, then this does nothing
    /// </summary>
    /// <param name="attackModel"></param>
    /// <param name="index"></param>
    /// <typeparam name="T"></typeparam>
    public static void ApplyDisplay<T>(this AttackModel attackModel, int index = 0) where T : ModDisplay
    {
        var displayModels = attackModel.GetBehaviors<DisplayModel>().ToList();
        if (displayModels.Count > 0 && index >= 0 && index < displayModels.Count)
        {
            //var display = displayModels[index];
            displayModels[index].ApplyDisplay<T>();
        }
    }
    /// <summary>
    /// Adds a new filter to this projectile model
    /// </summary>
    public static void AddFilter(this AttackModel attack, FilterModel filter)
    {
        if (attack.HasBehavior(out AttackFilterModel attackFilter))
        {
            attackFilter.filters = attackFilter.filters.AddTo(filter);
            attackFilter.AddChildDependant(filter);
        }
        else
        {
            attack.AddBehavior(new AttackFilterModel("", new[] {filter}));
        }
    }

    /// <summary>
    /// Removes a specific filter from this attack model
    /// </summary>
    public static void RemoveFilter(this AttackModel attack, FilterModel filter)
    {
        if (attack.HasBehavior(out AttackFilterModel attackFilter))
        {
            attackFilter.RemoveChildDependant(filter);
            attackFilter.filters = attackFilter.filters.Where(f => f != filter).ToArray();
        }
    }

    /// <summary>
    /// Removes the first filter of a given type from this attack model
    /// </summary>
    public static void RemoveFilter<T>(this AttackModel attack) where T : FilterModel
    {
        if (attack.HasBehavior(out AttackFilterModel attackFilter))
        {
            var filter = attackFilter.filters.OfIl2CppType<T>().FirstOrDefault();
            if (filter != null)
            {
                attackFilter.RemoveChildDependant(filter);
                attackFilter.filters = attackFilter.filters.RemoveItem(filter);
            }
        }
    }
}