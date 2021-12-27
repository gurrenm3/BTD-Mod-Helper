using System;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.GenericBehaviors;
using BTD_Mod_Helper.Api.Display;


#if BloonsTD6
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Weapons;

#elif BloonsAT
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
#endif


namespace BTD_Mod_Helper.Extensions
{
    /// <summary>
    /// Extensions for AttackModels
    /// </summary>
    public static class AttackModelExt
    {
        /// <summary>
        /// (Cross-Game compatible) Add a weapon to this Attack Model
        /// </summary>
        /// <param name="attackModel"></param>
        /// <param name="weaponToAdd">Weapon to add</param>
        public static void AddWeapon(this AttackModel attackModel, WeaponModel weaponToAdd) =>
            attackModel.weapons = attackModel.weapons.AddTo(weaponToAdd);

        /// <summary>
        /// (Cross-Game compatible) Remove a weapon from this Attack Model
        /// </summary>
        /// <param name="attackModel"></param>
        /// <param name="weaponToRemove"></param>
        public static void RemoveWeapon(this AttackModel attackModel, WeaponModel weaponToRemove) =>
            attackModel.weapons = attackModel.weapons.RemoveItem(weaponToRemove);

        /// <summary>
        /// (Cross-Game compatible) Recursively get all ProjectileModels for this attack model and all of it's weapons
        /// </summary>
        /// <param name="attackModel"></param>
        /// <returns></returns>
        [Obsolete("Use GetDescendants<ProjectileModel>() instead")]
        public static List<ProjectileModel> GetAllProjectiles(this AttackModel attackModel)
        {
            List<ProjectileModel> allProjectiles = new List<ProjectileModel>();
            foreach (var weaponModel in attackModel.weapons)
            {
                if (weaponModel.projectile != null)
                {
                    allProjectiles.Add(weaponModel.projectile);
                    allProjectiles.AddRange(GetSubProjectiles(weaponModel.projectile.behaviors));
                }

                allProjectiles.AddRange(GetSubProjectiles(weaponModel.behaviors));
            }

            allProjectiles.AddRange(GetSubProjectiles(attackModel.behaviors)); //this is new
            return allProjectiles;
        }


        private static List<ProjectileModel> GetSubProjectiles(IEnumerable<Model> behaviors)
        {
            List<ProjectileModel> allProjectiles = new List<ProjectileModel>();

            if (behaviors is null)
                return allProjectiles;

            foreach (var behavior in behaviors)
            {
                var projectileField = behavior.GetIl2CppType().GetField("projectile");
                if (projectileField == null) // this is new
                {
                    projectileField = behavior.GetIl2CppType().GetField("projectileModel");
                }

                if (projectileField != null)
                {
                    if (projectileField.GetValue(behavior).IsType(out ProjectileModel projectileModel))
                    {
                        allProjectiles.Add(projectileModel);
                        allProjectiles.AddRange(GetSubProjectiles(projectileModel.behaviors));
                    }
                }
            }

            return allProjectiles;
        }

        /// <summary>
        /// Applies the given ModDisplay to the index'th (or first) DisplayModel in the behaviors of the AttackModel.
        /// <br/>
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
                displayModels[index].ApplyDisplay<T>();
            }
        }
    }
}