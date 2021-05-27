#if BloonsTD6
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Localization;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;
using Harmony;
using MelonLoader;

namespace BTD_Mod_Helper.Api.Towers
{
    internal class ModTowerHandler
    {
        internal static readonly List<ModTower> ModTowers = new List<ModTower>();
        internal static readonly List<ModUpgrade> ModUpgrades = new List<ModUpgrade>();
        
        internal static readonly Dictionary<string, TowerModel> TowerCache = new Dictionary<string, TowerModel>();
        
        internal static void LoadTowersAndUpgrades(BloonsMod mod)
        {
            var modUpgrades = GetModUpgrades(mod);
            var modTowers = GetModTowers(mod);
            
            foreach (var modUpgrade in modUpgrades)
            {
                UpgradeModel upgradeModel;
                try
                {
                    upgradeModel = modUpgrade.GetUpgradeModel();
                }
                catch (Exception e)
                {
                    MelonLogger.Error("Failed to create UpgradeModel for ModUpgrade " + modUpgrade.Name);
                    MelonLogger.Error(e);
                    continue;
                }

                try
                {
                    modUpgrade.Tower.upgrades[modUpgrade.Path, modUpgrade.Tier - 1] = modUpgrade;
                }
                catch (Exception e)
                {
                    MelonLogger.Error("Failed to assign ModUpgrade " + modUpgrade.Name + " to ModTower's upgrades");
                    MelonLogger.Error(e);
                    MelonLogger.Error("Double check that the Tower loaded and all Path and Tier values are correct");
                    continue;
                }

                try
                {
                    Game.instance.model.AddUpgrade(upgradeModel);
                    LocalizationManager.instance.textTable[modUpgrade.Id] = modUpgrade.DisplayName;
                    LocalizationManager.instance.textTable[modUpgrade.Id + " Description"] = modUpgrade.Description;
                    ModUpgrades.Add(modUpgrade);
                }
                catch (Exception e)
                {
                    MelonLogger.Error("General error in loading ModUpgrade " + modUpgrade.Name);
                    MelonLogger.Error(e);
                }
                
            }

            foreach (var modTower in modTowers)
            {
                try
                {
                    AddTower(modTower);
                }
                catch (Exception e)
                {
                    MelonLogger.Error("Failed to add the ModTower " + modTower.Name + " to the game");
                    MelonLogger.Error(e);
                }
                
                try
                {
                    LocalizationManager.instance.textTable[modTower.Id] = modTower.DisplayName;
                    LocalizationManager.instance.textTable[modTower.Id + " Description"] = modTower.Description;
                    ModTowers.Add(modTower);
                }
                catch (Exception e)
                {
                    MelonLogger.Error("General error in loading ModTower " + modTower.Name);
                    MelonLogger.Error(e);
                }
            }
        }

        internal static object Create(Type type, BloonsMod mod)
        {
            try
            {
                if (!ModContent.Instances.ContainsKey(type))
                {
                    var instance = (ModContent) Activator.CreateInstance(type);
                    instance.mod = mod;
                    ModContent.Instances[type] = instance;
                }
                    
                return ModContent.Instances[type];
            }
            catch (Exception e)
            {
                MelonLogger.Error("Failed to instantiate " + type.Name);
                MelonLogger.Error(e);
                MelonLogger.Error("Did you mess with the constructor?");
                return null;
            }
        }

        internal static List<ModUpgrade> GetModUpgrades(BloonsMod mod)
        {
            return mod.Assembly.GetTypes()
                .Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(ModUpgrade)))
                .Select(type => (ModUpgrade) Create(type, mod))
                .Where(upgrade => upgrade != null).ToList();
        }

        internal static List<ModTower> GetModTowers(BloonsMod mod)
        {
            return mod.Assembly.GetTypes()
                .Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(ModTower)))
                .Select(type => (ModTower) Create(type, mod))
                .Where(tower => tower != null).ToList();
        }

        internal static TowerModel CreateTowerModel(ModTower modTower, int[] tiers)
        {
            TowerModel towerModel;
            try
            {
                towerModel = modTower.GetBaseTowerModel().Duplicate();
                towerModel.tiers = tiers;
                towerModel.tier = tiers.Max();
            
                if (tiers.Sum() > 0)
                {
                    towerModel.AddTiersToName();
                }
            }
            catch (Exception)
            {
                MelonLogger.Error($"Failed to get base TowerModel for ModTower {modTower.Name}");
                throw;
            }

            // add the names to applied upgrades
            try
            {
                towerModel.appliedUpgrades = modTower.upgrades.Cast<ModUpgrade>()
                    .Where(modUpgrade => modUpgrade != null && tiers[modUpgrade.Path] >= modUpgrade.Tier)
                    .Select(modUpgrade => modUpgrade.Id)
                    .ToArray();
            }
            catch (Exception)
            {
                MelonLogger.Error($"Failed to add appliedUpgrades info to TowerModel {towerModel.name}");
                throw;
            }
            
            // add the upgrade path models
            try
            {
                for (var i = 0; i <= 2; i++)
                {
                    var tierMax = modTower.tierMaxes[i];
                    if (tiers[i] < tierMax)
                    {
                        var newTiers = tiers.Duplicate();
                        newTiers[i]++;
                        if (newTiers.Min() == 0) // no triple cross-pathed towers (yet...)
                        {
                            var modUpgrade = modTower.upgrades[i, newTiers[i] - 1];

                            var upgradePathModel = new UpgradePathModel(modUpgrade.Id,
                                $"{towerModel.baseId}-{newTiers.Printed()}", newTiers.Count(t => t > 0), newTiers.Max());
                            towerModel.upgrades = towerModel.upgrades.AddTo(upgradePathModel);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MelonLogger.Error($"Failed to add the UpgradePathModels for TowerModel {towerModel.name}");
                throw;
            }

            // set the tower's portrait
            try
            {
                var portraitUpgrade = modTower.upgrades.Cast<ModUpgrade>()
                    .Where(modUpgrade => modUpgrade != null && tiers[modUpgrade.Path] >= modUpgrade.Tier)
                    .OrderByDescending(modUpgrade => modUpgrade.Tier)
                    .ThenByDescending(modUpgrade => modUpgrade.Path % 2)
                    .ThenBy(modUpgrade => modUpgrade.Path)
                    .FirstOrDefault();
                if (portraitUpgrade != null)
                {
                    var sprite = ModContent.GetSpriteReference(modTower.mod, portraitUpgrade.Portrait);
                    if (sprite != null)
                    {
                        towerModel.portrait = sprite;
                    }
                }
            }
            catch (Exception)
            {
                MelonLogger.Error($"Failed to set the Portrait of TowerModel {towerModel.name}");
                throw;
            }
            
            // set the tower's display model


            try
            {
                modTower.ModifyBaseTowerModel(towerModel);
            }
            catch (Exception)
            {
                MelonLogger.Error("Failed to modify TowerModel ");
                throw;
            }
            
            // actually apply the upgrades
            try
            {
                foreach (var modUpgrade in modTower.upgrades.Cast<ModUpgrade>()
                    .Where(modUpgrade => modUpgrade != null && tiers[modUpgrade.Path] >= modUpgrade.Tier)
                    .OrderByDescending(modUpgrade => modUpgrade.Priority)
                    .ThenBy(modUpgrade => modUpgrade.Path)
                    .ThenBy(modUpgrade => modUpgrade.Tier))
                {
                    try
                    {
                        modUpgrade.ApplyUpgrade(towerModel);
                    }
                    catch (Exception)
                    {
                        MelonLogger.Error($"Failed to apply ModUpgrade {modUpgrade.Name} to TowerModel {towerModel.name}");
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                MelonLogger.Error($"Failed to apply upgrades for TowerModel {towerModel.name}");
                throw;
            }

            //FileIOUtil.SaveObject($"Towers\\{towerModel.name}.json", towerModel);
            return towerModel;
        }

        internal static void AddTower(ModTower modTower)
        {
            var towerModels = new List<TowerModel>();
            foreach (var tiers in modTower.TowerTiers())
            {
                try
                {
                    towerModels.Add(CreateTowerModel(modTower, tiers));
                }
                catch (Exception e)
                {
                    MelonLogger.Error($"Failed to create {tiers.Printed()} TowerModel for ModTower {modTower.Name}");
                    MelonLogger.Error(e);
                    throw;
                }
            }
            
            foreach (var towerModel in towerModels)
            {
                try
                {
                    Game.instance.model.AddTowerToGame(towerModel);
                }
                catch (Exception e)
                {
                    MelonLogger.Error($"Failed to add TowerModel {towerModel.name} to the game");
                    MelonLogger.Error(e);
                }
            }

            try
            {
                var shopTowerDetailsModel = new ShopTowerDetailsModel(modTower.Id, -1, 5, 5, 5, -1, 0, null);
                Game.instance.model.AddTowerToGame(shopTowerDetailsModel, modTower.TowerSet);
            }
            catch (Exception e)
            {
                MelonLogger.Error($"Failed to add ModTower {modTower.Name} to the shop");
                MelonLogger.Error(e);
                throw;
            }
        }
    }
}
#endif