using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
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
    public static List<ProjectileModel> GetAllProjectiles(this AttackModel attackModel)
    {
        return attackModel.GetDescendants<ProjectileModel>().ToList();
    }

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
}