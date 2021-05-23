#if BloonsTD6
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using Harmony;
using MelonLoader;
using UnityEngine;
using Resources = BTD_Mod_Helper.Properties.Resources;

namespace BTD_Mod_Helper.Api.Towers
{
    public class ModTowerHandler
    {
        internal static readonly IEnumerable<ModTower> ModTowers = new HashSet<ModTower>();
        internal static readonly IEnumerable<ModUpgrade> ModUpgrades = new HashSet<ModUpgrade>();
        
        internal static readonly Dictionary<string, TowerModel> TowerCache = new Dictionary<string, TowerModel>();
        
        internal static void LoadTowersAndUpgrades(BloonsMod mod)
        {
            var modUpgrades = GetModUpgrades(mod);
            var modTowers = GetModTowers(mod);

            foreach (var modUpgrade in modUpgrades)
            {
                Game.instance.model.AddUpgrade(modUpgrade.GetUpgradeModel());
                modUpgrade.Tower.upgrades[modUpgrade.Path, modUpgrade.Tier] = modUpgrade;
                ModUpgrades.Add(modUpgrade);
            }

            foreach (var modTower in modTowers)
            {
                AddAllTowerModels(modTower);
                ModTowers.Add(modTower);
            }
        }


        internal static IEnumerable<ModUpgrade> GetModUpgrades(BloonsMod mod)
        {
            return mod.GetType().Assembly.GetTypes()
                .Where(type => !type.IsAbstract && type.IsPublic && type.IsSubclassOf(typeof(ModUpgrade)))
                .Where(type => type.GetConstructor(Type.EmptyTypes) != null)
                .Select(type =>
                {
                    if (!ModContent.Instances.ContainsKey(type))
                    {
                        var upgrade = (ModUpgrade) Activator.CreateInstance(type);
                        upgrade.mod = mod;
                        ModContent.Instances[type] = upgrade;
                    }
                    
                    return (ModUpgrade) ModContent.Instances[type];
                });
        }

        internal static IEnumerable<ModTower> GetModTowers(BloonsMod mod)
        {
            return mod.GetType().Assembly.GetTypes()
                .Where(type => !type.IsAbstract && type.IsPublic && type.IsSubclassOf(typeof(ModTower)))
                .Where(type => type.GetConstructor(Type.EmptyTypes) != null)
                .Select(type =>
                {
                    if (!ModContent.Instances.ContainsKey(type))
                    {
                        var tower = (ModTower) Activator.CreateInstance(type);
                        tower.mod = mod;
                        ModContent.Instances[type] = tower;
                    }
                    
                    return (ModTower) ModContent.Instances[type];
                });
        }

        internal static TowerModel CreateTowerModel(ModTower modTower, int[] tiers)
        {
            var towerModel = modTower.GetTowerModel();

            towerModel.tiers = tiers;
            towerModel.tier = tiers.Max();
            if (tiers.Sum() > 0)
            {
                towerModel.AddTiersToName();
            }

            // add the names to applied upgrades
            foreach (var modUpgrade in modTower.upgrades)
            {
                if (tiers[modUpgrade.Path] >= modUpgrade.Tier)
                {
                    towerModel.appliedUpgrades = towerModel.appliedUpgrades.Add(modUpgrade.Id).ToArray();
                }
            }

            // add the upgrade path models
            for (var i = 0; i < modTower.tierMaxes.Length; i++)
            {
                var tierMax = modTower.tierMaxes[i];
                if (tiers[i] < tierMax)
                {
                    var newTiers = tiers.Duplicate();
                    newTiers[i]++;
                    if (newTiers.Min() == 0) // no triple cross-pathed towers (yet...)
                    {
                        var modUpgrade = modTower.upgrades[i, tiers[i] + 1];

                        var upgradePathModel = new UpgradePathModel(modUpgrade.Id,
                            $"{towerModel.baseId}-{newTiers.Printed()}", newTiers.Count(t => t > 0), newTiers.Max());
                        towerModel.upgrades = towerModel.upgrades.AddTo(upgradePathModel);
                    }
                }
            }
            
            // actually apply the upgrades
            foreach (var modUpgrade in modTower.upgrades.Cast<ModUpgrade>()
                .OrderByDescending(modUpgrade => modUpgrade.Priority)
                .ThenBy(modUpgrade => 6 * modUpgrade.Path + modUpgrade.Tier))
            {
                if (tiers[modUpgrade.Path] >= modUpgrade.Tier)
                {
                    modUpgrade.ApplyUpgrade(towerModel);
                }
            }

            return towerModel;
        }

        internal static void AddAllTowerModels(ModTower modTower)
        {
            foreach (var tiers in modTower.TowerTiers())
            {
                var towerModel = CreateTowerModel(modTower, tiers);
                Game.instance.model.AddTowerToGame(towerModel);
            }
        }
    }
}
#endif