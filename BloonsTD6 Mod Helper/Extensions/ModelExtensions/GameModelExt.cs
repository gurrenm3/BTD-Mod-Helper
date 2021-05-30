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
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Unity;
using UnhollowerBaseLib;
using BTD_Mod_Helper.Api.Towers;
using MelonLoader;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class GameModelExt
    {

        public static bool DoesTowerModelExist(this GameModel model, string towerId)
        {
            return model.towers.Any(item => item.name.Contains(towerId));
        }

        public static bool DoesTowerDetailsExist(this GameModel model, string towerId)
        {
            return model.towerSet.Any(item => item.name.Contains(towerId));
        }

        /// <summary>
        /// Add a TowerModel to the game.
        /// </summary>
        /// <param name="towerModel">TowerModel to add</param>
        /// <param name="towerDetailsModel">Optionally add a TowerDetailsModel for your towerModel</param>
        public static void AddTowerToGame(this GameModel model, TowerModel towerModel, TowerDetailsModel towerDetailsModel = null)
        {
            model.towers = model.towers.AddTo(towerModel);
            model.AddChildDependant(towerModel);
            
            ModTowerHandler.TowerCache[towerModel.name] = towerModel;

            if (towerDetailsModel != null)
            {
                model.AddTowerToGame(towerDetailsModel, towerModel.towerSet);
            }

            // MelonLogger.Msg($"Added towerModel {towerModel.name} to the game");
        }

        public static void AddTowerToGame(this GameModel model, TowerDetailsModel towerDetailsModel)
        {
            model.towerSet = model.towerSet.AddTo(towerDetailsModel);
            AddTowerToGame(model, towerDetailsModel, "");
        }

        /// <summary>
        /// Adds a TowerDetailsModel to the GameModel's TowerSet, taking into account what set of towers it's a part of
        /// For example, a new custom Primary tower would be added right at the end of the primary towers,
        /// and right before the start of the military towers
        /// </summary>
        /// <param name="model">The GameModel</param>
        /// <param name="towerDetailsModel">The TowerDetailsModel to be added</param>
        /// <param name="set">The TowerSet of the tower to be added</param>
        public static void AddTowerToGame(this GameModel model, TowerDetailsModel towerDetailsModel, string set)
        {
            if (string.IsNullOrEmpty(set))
            {
                model.towerSet = model.towerSet.AddTo(towerDetailsModel);
            }

            var towerSet = model.towerSet.ToList();
            var lastOfSet = towerSet.LastOrDefault(tdm => model.GetTowerFromId(tdm.towerId).towerSet == set);
            var index = towerSet.Count;
            if (lastOfSet != default)
            {
                index = towerSet.IndexOf(lastOfSet) + 1;
            }
            towerSet.Insert(index, towerDetailsModel);
            
            for (var i = 0; i < towerSet.Count; i++)
            {
                towerSet[i].towerIndex = i;
            }

            model.towerSet = towerSet.ToArray();

            var towerList = Game.towers.ToList();
            towerList.Insert(index, towerDetailsModel.towerId);
            Game.towers = towerList.ToArray();
        }

        /// <summary>
        /// Return all TowerDetailModels
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<TowerDetailsModel> GetAllTowerDetails(this GameModel model)
        {
            return model.towerSet.ToIl2CppList();
        }

        /// <summary>
        /// Return all ShopTowerDetailModels
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<ShopTowerDetailsModel> GetAllShopTowerDetails(this GameModel model)
        {
            Il2CppSystem.Collections.Generic.List<TowerDetailsModel> towerDetails = model.GetAllTowerDetails();
            Il2CppSystem.Collections.Generic.List<TowerDetailsModel> results = towerDetails.Where(detail => detail.GetShopTowerDetails() != null);
            return results.DuplicateAs<TowerDetailsModel, ShopTowerDetailsModel>();
        }

        /// <summary>
        /// Return all TowerModels with a specific base id
        /// </summary>
        /// <param name="towerBaseId">The base id all towers should share. Example: "DartMonkey"</param>
        public static List<TowerModel> GetTowerModels(this GameModel model, string towerBaseId)
        {
            return model.towers?.Where(t => t.baseId == towerBaseId).ToList();
        }

        /// <summary>
        /// Get a TowerModel from model.towers.
        /// NOTE: model.GetTower cannot get custom towers so use this method instead
        /// </summary>
        /// <param name="model"></param>
        /// <param name="towerId"></param>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <param name="path3"></param>
        /// <returns></returns>
        public static TowerModel GetTowerModel(this GameModel model, string towerId, int path1 = 0, int path2 = 0, int path3 = 0)
        {
            return model.towers.FirstOrDefault(t => t.name.Contains(towerId) && t.HasTiers(path1, path2, path3));
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
        /// Return all AttackModels from every TowerModel in the game
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
        /// Return all WeaponModels from every AttackModel in the game
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
        /// Return all ProjectileModels from every TowerModel in the game
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
        /// Return all AbilityModels from every TowerModel in the game
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
        /// Return all TowerModels that have at least one AbilityModel
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
            model.AddChildDependant(upgradeModel);
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

        public static TowerDetailsModel GetTowerDetails(this GameModel model, string towerDetailsName)
        {
            return model.towerSet.FirstOrDefault(tower => tower.towerId == towerDetailsName);
        }
    }
}