﻿using Assets.Scripts.Models;
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

namespace BTD_Mod_Helper.Extensions
{
    public static partial class GameModelExt
    {
        /// <summary>
        /// Returns whether or not any TowerModels in <see cref="GameModel.towers"/> have <paramref name="towerId"/>
        /// in it's name
        /// </summary>
        /// <param name="model"></param>
        /// <param name="towerId"></param>
        /// <returns></returns>
        public static bool DoesTowerModelExist(this GameModel model, string towerId)
        {
            return model.towers.Any(item => item.name.Contains(towerId));
        }

        /// <summary>
        /// Returns whether or not any TowerDetailsModels in <see cref="GameModel.towerSet"/> have <paramref name="towerId"/>
        /// in it's name
        /// </summary>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="towerId"></param>
        /// <returns></returns>
        public static bool DoesTowerDetailsExist(this GameModel model, string towerId)
        {
            return model.towerSet.Any(item => item.name.Contains(towerId));
        }

        /// <summary>
        /// Add a TowerModel to the game.
        /// <br/>
        /// Using this method is preferable than modifying the GameModel's towers list manually, as this does more things
        /// to more fully integrate the tower within the game
        /// </summary>
        /// <param name="towerModel">TowerModel to add</param>
        /// <param name="towerDetailsModel">Optionally add a TowerDetailsModel for your towerModel</param>
        public static void AddTowerToGame(this GameModel model, TowerModel towerModel, TowerDetailsModel towerDetailsModel = null)
        {
            model.towers = model.towers.AddTo(towerModel);
            model.AddChildDependant(towerModel);

            ModTowerHelper.TowerCache[towerModel.name] = towerModel;

            if (towerDetailsModel != null)
            {
                model.AddTowerDetails(towerDetailsModel, towerModel.towerSet);
            }

            // MelonLogger.Msg($"Added towerModel {towerModel.name} to the game");
        }
        
        /// <summary>
        /// Add multiple TowerModels to the game more efficiently than calling the single method repeatedly.
        /// </summary>
        public static void AddTowersToGame(this GameModel model, IEnumerable<TowerModel> towerModels)
        {
            var array = towerModels.ToArray();
            var towersLength = model.towers.Length;
            var newArray = new Il2CppReferenceArray<TowerModel>(towersLength + array.Length);
            for (var i = 0; i < towersLength; i++)
            {
                newArray[i] = model.towers[i];
            }

            for (var i = 0; i < array.Length; i++)
            {
                newArray[i + towersLength] = array[i];
            }

            model.towers = newArray;
            
            foreach (var towerModel in array)
            {
                model.AddChildDependant(towerModel);
                ModTowerHelper.TowerCache[towerModel.name] = towerModel;
            }
        }
        

        /// <summary>
        /// Adds a tower 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="towerDetailsModel"></param>
        public static void AddTowerDetails(this GameModel model, TowerDetailsModel towerDetailsModel)
        {
            AddTowerDetails(model, towerDetailsModel, "");
        }

        /// <summary>
        /// Adds a TowerDetailsModel to the GameModel's TowerSet, taking into account what set of towers it's a part of
        /// <br/>
        /// For example, a new custom Primary tower would be added right at the end of the primary towers,
        /// and right before the start of the military towers
        /// </summary>
        /// <param name="model">The GameModel</param>
        /// <param name="towerDetailsModel">The TowerDetailsModel to be added</param>
        /// <param name="set">The TowerSet of the tower to be added</param>
        public static void AddTowerDetails(this GameModel model, TowerDetailsModel towerDetailsModel, string set)
        {
            var towerSet = model.towerSet.ToList();
            var index = towerSet.Count;
            if (!string.IsNullOrEmpty(set))
            {
                var lastOfSet = towerSet.LastOrDefault(tdm => tdm.GetTower().towerSet == set);
                if (lastOfSet != default)
                {
                    index = towerSet.IndexOf(lastOfSet) + 1;
                }
            }
            AddTowerDetails(model, towerDetailsModel, index);
        }

        /// <summary>
        /// Adds a TowerDetailsModel to the GameModel's TowerSet at a particular index
        /// </summary>
        /// <param name="model"></param>
        /// <param name="towerDetailsModel"></param>
        /// <param name="index"></param>
        public static void AddTowerDetails(this GameModel model, TowerDetailsModel towerDetailsModel, int index)
        {
            var towerSet = model.towerSet.ToList();
            if (index < 0)
            {
                index = 0;
            } else if (index > towerSet.Count)
            {
                index = towerSet.Count;
            }
            towerSet.Insert(index, towerDetailsModel);
            model.towerSet = towerSet.ToArray();
            
            for (var i = 0; i < model.towerSet.Count; i++)
            {
                model.towerSet[i].towerIndex = i;
            }

            var towerList = TowerType.towers.ToList();
            towerList.Insert(index, towerDetailsModel.towerId);
            TowerType.towers = towerList.ToArray();
        }
        
        /// <summary>
        /// Adds a HeroDetailsModel to the GameModel's HeroSet at a particular index
        /// </summary>
        /// <param name="model"></param>
        /// <param name="heroDetailsModel"></param>
        /// <param name="index"></param>
        public static void AddHeroDetails(this GameModel model, HeroDetailsModel heroDetailsModel, int index)
        {
            var heroSet = model.heroSet.ToList();
            if (index < 0)
            {
                index = 0;
            } else if (index > heroSet.Count)
            {
                index = heroSet.Count;
            }
            heroSet.Insert(index, heroDetailsModel);
            model.heroSet = heroSet.ToArray();
            
            for (var i = 0; i < model.heroSet.Count; i++)
            {
                model.heroSet[i].towerIndex = i;
            }

            
            var towersIndex = index + model.towerSet.Count;
            if (towersIndex <= TowerType.towers.Count)
            {
                var towerList = TowerType.towers.ToList();
                towerList.Insert(towersIndex, heroDetailsModel.towerId);
                TowerType.towers = towerList.ToArray();
            }
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
                List<AbilityModel> abilities = tower.GetAbilities();
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
            return model.towers.Where(t => t.GetAbilities() != null).ToList();
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

        /// <summary>
        /// Returns the first TowerDetailsModel in <see cref="GameModel.towerSet"/> that has a towerId of
        /// <paramref name="towerDetailsName"/>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="towerDetailsName">The <see cref="TowerDetailsModel.towerId"/> you are searching for</param>
        /// <returns>The first TowerDetailsModel found, otherwise returns null</returns>
        public static TowerDetailsModel GetTowerDetails(this GameModel model, string towerDetailsName)
        {
            return model.towerSet.FirstOrDefault(tower => tower.towerId == towerDetailsName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="set"></param>
        /// <returns>The total cost of the KnowledgeSet if <paramref name="set"/> is valid, otherwise returns -1</returns>
        /*public static int GetKnowledgeSetTotal(this GameModel model, string set)
        {

        }*/
    }
}