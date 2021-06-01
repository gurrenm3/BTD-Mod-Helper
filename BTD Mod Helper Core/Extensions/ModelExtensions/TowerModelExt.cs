using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;
using System;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
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
        /// (Cross-Game compatible) Get the name of the BaseTower. Will be different from this TowerModel's name if this TowerModel isn't a BaseTower
        /// </summary>
        /// <param name="towerModel"></param>
        /// <returns></returns>
        public static string GetBaseId(this TowerModel towerModel)
        {
#if BloonsTD6
            return towerModel.baseId;
#elif BloonsAT
            return towerModel.towerParentId;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Has player already unlocked this TowerModel
        /// </summary>
        public static bool? IsTowerUnlocked(this TowerModel towerModel)
        {
#if BloonsTD6
            return Game.instance?.GetBtd6Player()?.HasUnlockedTower(towerModel.GetBaseId());
#elif BloonsAT
            return Game.instance.GetAdventureTimePlayer().HasUnlockedTower(towerModel.GetBaseId());
#endif
        }

        /// <summary>
        /// This is Obsolete, use GetAllTowerToSim instead. (Cross-Game compatible) Return all TowerToSimulations with this TowerModel
        /// </summary>
        [Obsolete]
        public static List<TowerToSimulation> GetTowerSims(this TowerModel towerModel)
        {
            var towers = InGame.instance?.GetAllTowerToSim();
            var desiredTowers = towers.Where(towerSim => towerSim.GetTower().towerModel.name == towerModel.name).ToList();
            return desiredTowers;
        }

        /// <summary>
        /// (Cross-Game compatible) Return all TowerToSimulations with this TowerModel
        /// </summary>
        public static List<TowerToSimulation> GetAllTowerToSim(this TowerModel towerModel)
        {
            var towers = InGame.instance?.GetAllTowerToSim();
            var desiredTowers = towers.Where(towerSim => towerSim.Def.name == towerModel.name).ToList();
            return desiredTowers;
        }

        /// <summary>
        /// (Cross-Game compatible) Return all AbilityModel behaviors from this tower, if it has any
        /// </summary>
        public static List<AbilityModel> GetAbilites(this TowerModel towerModel)
        {
            return towerModel.GetBehaviors<AbilityModel>();
        }

        /// <summary>
        /// (Cross-Game compatible) Return a specific Ability of the tower. By default will get the first ability
        /// </summary>
        public static AbilityModel GetAbility(this TowerModel towerModel)
        {
            return towerModel.GetAbilites().FirstOrDefault();
        }

        /// <summary>
        /// (Cross-Game compatible) Return a specific Ability of the tower.
        /// </summary>
        /// <param name="index">Index of the ability you want.</param>
        public static AbilityModel GetAbility(this TowerModel towerModel, int index)
        {
            return towerModel.GetAbilites()[index];
        }

        /// <summary>
        /// (Cross-Game compatible) Return all AttackModel behaviors for this TowerModel
        /// </summary>
        public static List<AttackModel> GetAttackModels(this TowerModel towerModel)
        {
            return towerModel.GetBehaviors<AttackModel>();
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first AttackModel from this TowerModel, if it has one
        /// </summary>
        public static AttackModel GetAttackModel(this TowerModel towerModel)
        {
            return towerModel.GetAttackModels().FirstOrDefault();
        }

        /// <summary>
        /// (Cross-Game compatible) Return one of the AttackModels from this TowerModel. By default will give the first AttackModel
        /// </summary>
        /// <param name="index">Index of the AttackModel you want</param>
        public static AttackModel GetAttackModel(this TowerModel towerModel, int index)
        {
            return towerModel.GetAttackModels()[index];
        }

        /// <summary>
        /// (Cross-Game compatible) Recursively get every WeaponModels this TowerModel has
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
        /// (Cross-Game compatible) Return one of the WeaponModels this TowerModel has. By default will return the first one
        /// </summary>
        /// <param name="index">Index of WeaponModel that you want</param>
        public static WeaponModel GetWeapon(this TowerModel towerModel, int index)
        {
            return towerModel.GetWeapons()[index];
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first WeaponModel this TowerModel has, if it has one.
        /// </summary>
        public static WeaponModel GetWeapon(this TowerModel towerModel)
        {
            return towerModel.GetWeapons().FirstOrDefault();
        }

        // Thanks to doombubbles for creating this
        /// <summary>
        /// (Cross-Game compatible) Return every ProjectileModels this TowerModel has
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

        /// <summary>
        /// (Cross-Game compatible) Sell every tower that uses this TowerModel
        /// </summary>
        /// <param name="towerModel"></param>
        public static void SellAll(this TowerModel towerModel)
        {
            var towers = InGame.instance.GetTowers(towerModel.name);
            towers.ForEach(tower => InGame.instance.SellTower(tower));
        }

        /// <summary>
        /// (Cross-Game compatible) Get the TowerId of this TowerModel. Equivalent to towerModel.name
        /// </summary>
        /// <param name="towerModel"></param>
        /// <returns></returns>
        public static string GetTowerId(this TowerModel towerModel)
        {
            return towerModel.name;
        }

        /// <summary>
        /// (Cross-Game compatible) Duplicate this TowerModel with a unique name. Very useful for making custom TowerModels
        /// </summary>
        /// <param name="towerModel"></param>
        /// <param name="newTowerId">Set's the new towerId of this copy. By default the baseId will be set to this as well</param>
        /// <returns></returns>
        internal static TowerModel MakeCopyInternal(TowerModel towerModel, string newTowerId)
        {
            var duplicate = towerModel.Duplicate();
            duplicate.name = newTowerId;
            return duplicate;
        }
        
        /// <summary>
        /// Applies a given ModDisplay to this TowerModel
        /// </summary>
        /// <typeparam name="T">The type of ModDisplay</typeparam>
        public static void ApplyDisplay<T>(this TowerModel towerModel) where T : ModDisplay
        {
            ModContent.GetInstance<T>().Apply(towerModel);
        }
    }
}