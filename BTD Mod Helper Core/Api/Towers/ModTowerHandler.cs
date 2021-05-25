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
                LocalizationManager.instance.textTable[modUpgrade.Id] = modUpgrade.DisplayName;
                LocalizationManager.instance.textTable[modUpgrade.Id + " Description"] = modUpgrade.Description;
                Game.instance.model.AddUpgrade(modUpgrade.GetUpgradeModel());
                modUpgrade.Tower.upgrades[modUpgrade.Path, modUpgrade.Tier - 1] = modUpgrade;
                ModUpgrades.Add(modUpgrade);
            }

            foreach (var modTower in modTowers)
            {
                LocalizationManager.instance.textTable[modTower.Id] = modTower.DisplayName;
                LocalizationManager.instance.textTable[modTower.Id + " Description"] = modTower.Description;
                AddTower(modTower);
                ModTowers.Add(modTower);
            }
        }

        internal static object Create(Type type, BloonsMod mod)
        {
            if (!ModContent.Instances.ContainsKey(type))
            {
                var instance = (ModContent) Activator.CreateInstance(type);
                instance.mod = mod;
                ModContent.Instances[type] = instance;
            }
                    
            return ModContent.Instances[type];
        }

        internal static List<ModUpgrade> GetModUpgrades(BloonsMod mod)
        {
            return mod.Assembly.GetTypes()
                .Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(ModUpgrade)))
                .Select(type => (ModUpgrade) Create(type, mod)).ToList();
        }

        internal static List<ModTower> GetModTowers(BloonsMod mod)
        {
            return mod.Assembly.GetTypes()
                .Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(ModTower)))
                .Select(type => (ModTower) Create(type, mod)).ToList();
        }

        internal static TowerModel CreateTowerModel(ModTower modTower, int[] tiers)
        {
            var towerModel = modTower.GetBaseTowerModel().Duplicate();
            towerModel.tiers = tiers;
            towerModel.tier = tiers.Max();
            
            if (tiers.Sum() > 0)
            {
                towerModel.AddTiersToName();
            }

            // add the names to applied upgrades
            towerModel.appliedUpgrades = modTower.upgrades.Cast<ModUpgrade>()
                .Where(modUpgrade => modUpgrade != null && tiers[modUpgrade.Path] >= modUpgrade.Tier)
                .Select(modUpgrade => modUpgrade.Id)
                .ToArray();

            // add the upgrade path models
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

            // set the tower's portrait
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
            
            // set the tower's display model

            
            
            modTower.ModifyBaseTowerModel(towerModel);
            
            // actually apply the upgrades
            foreach (var modUpgrade in modTower.upgrades.Cast<ModUpgrade>()
                .Where(modUpgrade => modUpgrade != null && tiers[modUpgrade.Path] >= modUpgrade.Tier)
                .OrderByDescending(modUpgrade => modUpgrade.Priority)
                .ThenBy(modUpgrade => modUpgrade.Path)
                .ThenBy(modUpgrade => modUpgrade.Tier))
            {
                modUpgrade.ApplyUpgrade(towerModel);
            }

            FileIOUtil.SaveObject($"Towers\\{towerModel.name}.json", towerModel);
            return towerModel;
        }

        internal static void AddTower(ModTower modTower)
        {
            foreach (var tiers in modTower.TowerTiers())
            {
                var towerModel = CreateTowerModel(modTower, tiers);
                Game.instance.model.AddTowerToGame(towerModel);
            }

            var shopTowerDetailsModel = new ShopTowerDetailsModel(modTower.Id, -1, 5, 5, 5, -1, 0, null);

            Game.instance.model.AddTowerToGame(shopTowerDetailsModel, modTower.TowerSet);
        }
    }
}
#endif