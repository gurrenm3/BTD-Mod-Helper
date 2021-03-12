using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using System.Collections.Generic;
using System.Linq;


#if BloonsTD6
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Unity;
#elif BloonsAT
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
#endif


namespace BTD_Mod_Helper.Extensions
{
    public static class AttackModelExt
    {
        /// <summary>
        /// Add a weapon to this Attack Model
        /// </summary>
        /// <param name="weaponToAdd">Weapon to add</param>
        public static void AddWeapon(this AttackModel attackModel, WeaponModel weaponToAdd) =>
            attackModel.weapons = attackModel.weapons.AddTo(weaponToAdd);

        // Thanks to doombubbles for creating this
        /// <summary>
        /// Recursively get all ProjectileModels for this attack model and all of it's weapons
        /// </summary>
        /// <param name="attackModel"></param>
        /// <returns></returns>
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
                    if (projectileField.GetValue(behavior) is ProjectileModel projectileModel)
                    {
                        allProjectiles.Add(projectileModel);
                        allProjectiles.AddRange(GetSubProjectiles(projectileModel.behaviors));
                    }

                    // changed to newer syntax. Will remove old version once confirmed working
                    /*var projectileModel = projectileField.GetValue(behavior).Cast<ProjectileModel>();
                    if (projectileModel != null)
                    {
                        allProjectiles.Add(projectileModel);
                        allProjectiles.AddRange(GetSubProjectiles(projectileModel.behaviors));
                    }*/
                }
            }
            return allProjectiles;
        }
    }
}