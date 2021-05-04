using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Objects;
using BTD_Mod_Helper.Api.Builders;
using BTD_Mod_Helper.Patches;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class GameModelExt
    {
        /// <summary>
        /// Add a TowerModel to the game.
        /// </summary>
        /// <param name="towerModel">TowerModel to add</param>
        /// <param name="towerDetailsModel">Optionally add a TowerDetailsModel for your towerModel</param>
        public static void AddTowerToGame(this GameModel model, TowerModel towerModel, TowerDetailsModel towerDetailsModel = null)
        {
            model.towers = model.towers.AddTo(towerModel);

            if (towerDetailsModel != null)
                model.towerSet = model.towerSet.AddTo(towerDetailsModel);
        }

        /// <summary>
        /// Get the instance of the API's BloonModelBuilder. Used to create custom bloon types and add them to the game
        /// </summary>
        public static BloonModelBuilder GetBloonModelBuilder(this GameModel model)
        {
            return BloonModelBuilder.Instance;
        }

        /// <summary>
        /// Get all TowerDetailModels
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<TowerDetailsModel> GetAllTowerDetails(this GameModel model)
        {
            return TowerInventory_Init.allTowers;
        }

        /// <summary>
        /// Get all ShopTowerDetailModels
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<ShopTowerDetailsModel> GetAllShopTowerDetails(this GameModel model)
        {
            Il2CppSystem.Collections.Generic.List<TowerDetailsModel> towerDetails = model.GetAllTowerDetails();
            Il2CppSystem.Collections.Generic.List<TowerDetailsModel> results = towerDetails.Where(detail => detail.GetShopTowerDetails() != null);
            return results.DuplicateAs<TowerDetailsModel, ShopTowerDetailsModel>();
        }

        /// <summary>
        /// Get all TowerModels with a specific base id
        /// </summary>
        /// <param name="towerBaseId">The base id all towers should share. Example: "DartMonkey"</param>
        public static List<TowerModel> GetTowerModels(this GameModel model, string towerBaseId)
        {
            return model.towers?.Where(t => t.baseId == towerBaseId).ToList();
        }

        /// <summary>
        /// Get TowerModel from it's TowerType and it's upgrades
        /// </summary>
        /// <param name="towerType">Type of tower you want</param>
        /// <param name="path1">Number of upgrades in first path</param>
        /// <param name="path2">Number of upgrades in second path</param>
        /// <param name="path3">Number of upgrades in third path</param>
        /// <returns></returns>
        public static TowerModel GetTowerModel(this GameModel model, TowerType towerType, int path1 = 0, int path2 = 0, int path3 = 0)
        {
            return model.GetTower(towerType.ToString(), path1, path2, path3);
        }

        /// <summary>
        /// Create a BloonEmissionModel from a bloonModel
        /// </summary>
        /// <param name="bloonModel">The bloon model that these bloons should be</param>
        /// <param name="number">Number of Bloons in this emission</param>
        /// <param name="spacing">Space between each bloon in this emission</param>
        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissions(this GameModel model, BloonModel bloonModel, int number, float spacing)
        {
            return model.CreateBloonEmissions(bloonModel.name, number, spacing);
        }

        /// <summary>
        /// Create a BloonEmissionModel from a bloon's name
        /// </summary>
        /// <param name="bloonName">Name of bloon. Example: "Red"</param>
        /// <param name="number">Number of Bloons in this emission</param>
        /// <param name="spacing">Space between each bloon in this emission</param>
        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissions(this GameModel model, string bloonName, int number, float spacing)
        {
            List<BloonEmissionModel> bloonEmissionModels = new List<BloonEmissionModel>();

            for (int i = 0; i < number; i++)
                bloonEmissionModels.Add(model.CreateBloonEmission(bloonName, time: spacing * i));

            return bloonEmissionModels.ToIl2CppReferenceArray();
        }

        /// <summary>
        /// Create a single BloonEmission
        /// </summary>
        /// <param name="bloonName">Name of this bloon. Example: "Red"</param>
        /// <param name="time">Time the bloon should be spawned</param>
        public static BloonEmissionModel CreateBloonEmission(this GameModel model, string bloonName, float time)
        {
            return new BloonEmissionModel("", time, bloonName);
        }

        /// <summary>
        /// Create a single BloonEmission
        /// </summary>
        /// <param name="bloonName">Name of this bloon. Example: "Red"</param>
        /// <param name="time">Time the bloon should be spawned</param>
        /// <param name="chargedMutators"></param>
        /// <param name="behaviorMutators"></param>
        public static BloonEmissionModel CreateBloonEmission(this GameModel model, string bloonName, float time,
           Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator> chargedMutators, Il2CppSystem.Collections.Generic.List<BehaviorMutator> behaviorMutators)
        {
            //return new BloonEmissionModel("", time, bloonName, chargedMutators, behaviorMutators); // removed in update 25.0
            return new BloonEmissionModel("", time, bloonName);
        }

        public static BloonGroupModel CreateBloonGroup(this GameModel model, string bloonName, float startTime, float spacing, int count)
        {
            float endTime = startTime + (spacing * count);
            return new BloonGroupModel("", bloonName, startTime, endTime, count);
        }

        /// <summary>
        /// Get all AttackModels from every TowerModel in the game
        /// </summary>
        public static List<AttackModel> GetAllAttackModels(this GameModel model)
        {
            List<AttackModel> attackModels = new List<AttackModel>();
            Il2CppReferenceArray<TowerModel> towers = model.towers;

            foreach (TowerModel tower in towers)
            {
                List<AttackModel> attacks = tower.GetAttackModels();
                if (attacks != null && attacks.Any())
                    attackModels.AddRange(attacks);
            }

            return attackModels;
        }

        /// <summary>
        /// Get all WeaponModels from every AttackModel in the game
        /// </summary>
        public static List<WeaponModel> GetAllWeaponModels(this GameModel model)
        {
            List<WeaponModel> weaponModels = new List<WeaponModel>();
            List<AttackModel> attackModels = model.GetAllAttackModels();

            foreach (AttackModel attackModel in attackModels)
            {
                Il2CppReferenceArray<WeaponModel> weapons = attackModel.weapons;
                if (weapons != null && weapons.Any())
                    weaponModels.AddRange(weapons);
            }

            return weaponModels;
        }

        /// <summary>
        /// Get all ProjectileModels from every TowerModel in the game
        /// </summary>
        public static List<ProjectileModel> GetAllProjectileModels(this GameModel model)
        {
            List<ProjectileModel> projectileModels = new List<ProjectileModel>();
            Il2CppReferenceArray<TowerModel> towerModels = model.towers;

            foreach (TowerModel towerModel in towerModels)
                projectileModels.AddRange(towerModel.GetAllProjectiles());

            return projectileModels;
        }

        /// <summary>
        /// Get all AbilityModels from every TowerModel in the game
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<AbilityModel> GetAllAbilityModels(this GameModel model)
        {
            List<AbilityModel> abilityModels = new List<AbilityModel>();
            Il2CppReferenceArray<TowerModel> towers = model.towers;

            foreach (TowerModel tower in towers)
            {
                List<AbilityModel> abilities = tower.GetAbilites();
                if (abilities != null && abilities.Any())
                    abilityModels.AddRange(abilities);
            }

            return abilityModels;
        }

        /// <summary>
        /// Get all TowerModels that have at least one AbilityModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<TowerModel> GetTowerModelsWithAbilities(this GameModel model)
        {
            return model.towers.Where(t => t.GetAbilites() != null).ToList();
        }

        public static void AddUpgrade(this GameModel model, UpgradeModel upgradeModel)
        {
            model.upgrades = model.upgrades.AddTo(upgradeModel);
            model.upgradesByName.Add(upgradeModel.name, upgradeModel);
        }

        public static void AddUpgrades(this GameModel model, List<UpgradeModel> upgradeModels)
        {
            model.upgrades = model.upgrades.AddTo(upgradeModels);
            upgradeModels.ForEach(upgrade => model.upgradesByName.Add(upgrade.name, upgrade));
        }

        public static void AddUpgrades(this GameModel model, UpgradeModel[] upgradeModels)
        {
            model.upgrades = model.upgrades.AddTo(upgradeModels);
            System.Array.ForEach(upgradeModels, upgrade => model.upgradesByName.Add(upgrade.name, upgrade));
        }
    }
}