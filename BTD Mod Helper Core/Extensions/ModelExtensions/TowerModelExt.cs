using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

#if BloonsTD6
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Weapons;
#elif BloonsAT
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
#endif

namespace BTD_Mod_Helper.Extensions
{
    public static partial class TowerModelExt
    {
        /// <summary>
        /// Has player already unlocked this TowerModel
        /// </summary>
        public static bool? IsTowerUnlocked(this TowerModel towerModel)
        {
#if BloonsTD6
            return Game.instance?.GetBtd6Player()?.HasUnlockedTower(towerModel.baseId);
#elif BloonsAT
            Game.instance.GetAdventureTimePlayer().HasUnlockedTower(towerModel.baseType.ToString());
#endif
            return null;
        }

        /// <summary>
        /// Get all TowerToSimulations with this TowerModel
        /// </summary>
        public static List<TowerToSimulation> GetTowerSims(this TowerModel towerModel)
        {
            var towers = InGame.instance?.GetTowerSims();
            var desiredTowers = towers.Where(towerSim => towerSim.GetSimTower().towerModel.name == towerModel.name).ToList();
            return desiredTowers;
        }

        /// <summary>
        /// Get all AbilityModel behaviors from this tower, if it has any
        /// </summary>
        public static List<AbilityModel> GetAbilites(this TowerModel towerModel)
        {
            return towerModel.GetBehaviors<AbilityModel>();
        }
        
        /// <summary>
        /// Get a specific Ability of the tower. By default will get the first ability
        /// </summary>
        public static AbilityModel GetAbility(this TowerModel towerModel)
        {
            return towerModel.GetAbilites().FirstOrDefault();
        }
        
        /// <summary>
        /// Get a specific Ability of the tower.
        /// </summary>
        /// <param name="index">Index of the ability you want.</param>
        public static AbilityModel GetAbility(this TowerModel towerModel, int index)
        {
            return towerModel.GetAbilites()[index];
        }

        /// <summary>
        /// Get all AttackModel behaviors for this TowerModel
        /// </summary>
        public static List<AttackModel> GetAttackModels(this TowerModel towerModel)
        {
            return towerModel.GetBehaviors<AttackModel>();
        }

        /// <summary>
        /// Gets the first AttackModel from this TowerModel, if it has one
        /// </summary>
        public static AttackModel GetAttackModel(this TowerModel towerModel)
        {
            return towerModel.GetAttackModels().FirstOrDefault();
        }

        /// <summary>
        /// Get one of the AttackModels from this TowerModel. By default will give the first AttackModel
        /// </summary>
        /// <param name="index">Index of the AttackModel you want</param>
        public static AttackModel GetAttackModel(this TowerModel towerModel, int index)
        {
            return towerModel.GetAttackModels()[index];
        }
        
        /// <summary>
        /// Recursively get every WeaponModels this TowerModel has
        /// </summary>
        public static List<WeaponModel> GetWeapons(this TowerModel towerModel)
        {
            List<AttackModel> attackModels = towerModel.GetAttackModels();
            if (attackModels is null)
                return null;

            if (!attackModels.Any())
                return new List<WeaponModel>();

            List<WeaponModel> weaponModels = new List<WeaponModel>();
            foreach (AttackModel attackModel in attackModels)
            {
                Il2CppReferenceArray<WeaponModel> weapons = attackModel.weapons;
                if (weapons != null)
                    weaponModels.AddRange(weapons);
            }

            return weaponModels;
        }

        /// <summary>
        /// Get one of the WeaponModels this TowerModel has. By default will return the first one
        /// </summary>
        /// <param name="index">Index of WeaponModel that you want</param>
        public static WeaponModel GetWeapon(this TowerModel towerModel, int index)
        {
            return towerModel.GetWeapons()[index];
        }
        
        /// <summary>
        /// Gets the first WeaponModel this TowerModel has, if it has one.
        /// </summary>
        public static WeaponModel GetWeapon(this TowerModel towerModel)
        {
            return towerModel.GetWeapons().FirstOrDefault();
        }

        // Thanks to doombubbles for creating this
        /// <summary>
        /// Get every ProjectileModels this TowerModel has
        /// </summary>
        public static List<ProjectileModel> GetAllProjectiles(this TowerModel towerModel)
        {
            List<ProjectileModel> allProjectiles = new List<ProjectileModel>();
            foreach (AttackModel attackModel in towerModel.GetAttackModels())
            {
                allProjectiles.AddRange(attackModel.GetAllProjectiles());
            }

            return allProjectiles;
        }
    }
}