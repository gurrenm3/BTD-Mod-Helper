using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
#if BloonsTD6
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
#elif BloonsAT
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
#endif

namespace BTD_Mod_Helper.Extensions
{
    public static partial class TowerModelExt
    {
        /// <summary>
        /// Get the name of the BaseTower. Will be different from this TowerModel's name if this TowerModel isn't a BaseTower
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
        /// Has player already unlocked this TowerModel
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
        /// Return all TowerToSimulations with this TowerModel
        /// </summary>
        public static List<TowerToSimulation> GetAllTowerToSim(this TowerModel towerModel)
        {
            var towers = InGame.instance.GetAllTowerToSim();
            var desiredTowers = towers.Where(towerSim => towerSim.Def.name == towerModel.name).ToList();
            return desiredTowers;
        }
        
        
        /// <summary>
        /// Return all AbilityModel behaviors from this tower, if it has any
        /// </summary>
        public static List<AbilityModel> GetAbilities(this TowerModel towerModel)
        {
            return towerModel.GetBehaviors<AbilityModel>().ToList();
        }

        /// <summary>
        /// Return the first ability on the tower
        /// </summary>
        public static AbilityModel GetAbility(this TowerModel towerModel)
        {
            return towerModel.GetAbilities().FirstOrDefault();
        }

        /// <summary>
        /// Return a specific Ability of the tower.
        /// </summary>
        /// <param name="towerModel">the TowerModel</param>
        /// <param name="index">Index of the ability you want.</param>
        public static AbilityModel GetAbility(this TowerModel towerModel, int index)
        {
            return towerModel.GetAbilities()[index];
        }

        /// <summary>
        /// Return all AttackModel behaviors for this TowerModel
        /// </summary>
        public static List<AttackModel> GetAttackModels(this TowerModel towerModel)
        {
            return towerModel.GetBehaviors<AttackModel>().ToList();
        }

        /// <summary>
        /// Return the first AttackModel from this TowerModel, if it has one
        /// </summary>
        public static AttackModel GetAttackModel(this TowerModel towerModel)
        {
            return towerModel.GetAttackModels().FirstOrDefault();
        }
        
        /// <summary>
        /// Return the first AttackModel whose name contains the given string
        /// </summary>
        public static AttackModel GetAttackModel(this TowerModel towerModel, string nameContains)
        {
            return towerModel.GetAttackModels().FirstOrDefault(model => model.name.Contains(nameContains));
        }

        /// <summary>
        /// Return one of the AttackModels from this TowerModel. By default will give the first AttackModel
        /// </summary>
        /// <param name="towerModel">The TowerModel</param>
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
            var attackModels = towerModel.GetAttackModels();
            if (attackModels is null)
                return null;

            if (!attackModels.Any())
                return new List<WeaponModel>();

            var weaponModels = new List<WeaponModel>();
            foreach (var attackModel in attackModels)
            {
                var weapons = attackModel.weapons;
                if (weapons != null)
                    weaponModels.AddRange(weapons);
            }

            return weaponModels;
        }

        /// <summary>
        /// Return one of the WeaponModels this TowerModel has. By default will return the first one
        /// </summary>
        /// <param name="towerModel">The TowerModel</param>
        /// <param name="index">Index of WeaponModel that you want</param>
        public static WeaponModel GetWeapon(this TowerModel towerModel, int index)
        {
            return towerModel.GetWeapons()[index];
        }

        /// <summary>
        /// Return the first WeaponModel this TowerModel has, if it has one.
        /// </summary>
        public static WeaponModel GetWeapon(this TowerModel towerModel)
        {
            return towerModel.GetWeapons().FirstOrDefault();
        }

        /// <summary>
        /// Sell every tower that uses this TowerModel
        /// </summary>
        /// <param name="towerModel"></param>
        public static void SellAll(this TowerModel towerModel)
        {
            var towers = InGame.instance.GetTowers(towerModel.name);
            towers.ForEach(tower => InGame.instance.SellTower(tower));
        }

        /// <summary>
        /// Get the TowerId of this TowerModel. Equivalent to towerModel.name
        /// </summary>
        /// <param name="towerModel"></param>
        /// <returns></returns>
        public static string GetTowerId(this TowerModel towerModel)
        {
            return towerModel.name;
        }

        /// <summary>
        /// Duplicate this TowerModel with a unique name. Very useful for making custom TowerModels
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

#if BloonsTD6

        /// <summary>
        /// Applies a given ModDisplay to this TowerModel
        /// </summary>
        /// <typeparam name="T">The type of ModDisplay</typeparam>
        public static void ApplyDisplay<T>(this TowerModel towerModel) where T : ModDisplay
        {
            ModContent.GetInstance<T>().Apply(towerModel);
        }

        /// <summary>
        /// Gets the ModTower associated with this TowerModel
        /// <br/>
        /// If there is no associated ModTower, returns null
        /// </summary>
        /// <returns></returns>
        public static ModTower GetModTower(this TowerModel towerModel)
        {
            return ModTowerHelper.ModTowerCache.TryGetValue(towerModel.name, out var modTower) ? modTower : null;
        }
        
        /// <summary>
        /// Gets the specific ModTower associated with this TowerModel
        /// <br/>
        /// If there is no associated ModTower, returns null
        /// </summary>
        /// <returns></returns>
        public static T GetModTower<T>(this TowerModel towerModel) where T : ModTower
        {
            return (T) GetModTower(towerModel);
        }

        /// <summary>
        /// Increase the range of a tower and all its attacks by the given amount
        /// </summary>
        /// <param name="towerModel"></param>
        /// <param name="rangeIncrease"></param>
        public static void IncreaseRange(this TowerModel towerModel, float rangeIncrease)
        {
            towerModel.range += rangeIncrease;
            foreach (var attackModel in towerModel.GetAttackModels())
            {
                attackModel.range += rangeIncrease;
            }
        }
#endif
    }
}