#if BloonsTD6
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.SMath;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Localization;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace BTD_Mod_Helper.Api.Towers
{
    internal static class ModTowerHandler
    {
        internal static readonly List<ModTower> ModTowers = new List<ModTower>();
        
        internal static readonly Dictionary<string, TowerModel> TowerCache = new Dictionary<string, TowerModel>();

        internal static readonly Dictionary<string, float> Tower2DScales = new Dictionary<string, float>();

        internal static void LoadTowers(List<ModTower> modTowers)
        {
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
                        if (newTiers.IsValid()) // no triple cross-pathed towers (yet...)
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
            
            
            if (modTower.Use2DModel)
            {
                try
                {
                    var name = modTower.Get2DTexture(tiers);
                    var guid = ModContent.GetTextureGUID(modTower.mod, name);
                    towerModel.display = guid;
                    towerModel.GetBehavior<DisplayModel>().display = guid;
                    towerModel.GetBehavior<DisplayModel>().positionOffset = new Vector3(0, 0, 2f);
                    Tower2DScales[guid] = modTower.PixelsPerUnit;
                }
                catch (Exception)
                {
                    MelonLogger.Error($"Failed to load 2d display for TowerModel {towerModel.name}");
                    throw;
                }
            }
            else
            {
                try
                {
                    if (modTower.displays.Where(modTowerDisplay => modTowerDisplay.UseForTower(tiers))
                        .OrderByDescending(modTowerDisplay => modTowerDisplay.Id)
                        .FirstOrDefault() is ModTowerDisplay display)
                    {
                        display.Apply(towerModel);
                    }
                }
                catch (Exception)
                {
                    MelonLogger.Error($"Failed to load ModTowerDisplay for TowerModel {towerModel.name}");
                    throw;
                }
            }
            
            

            // do their base tower modifications
            try
            {
                modTower.ModifyBaseTowerModel(towerModel);
            }
            catch (Exception)
            {
                MelonLogger.Error($"Failed to modify TowerModel {towerModel.name}");
                throw;
            }
            
            // actually apply the upgrades
            try
            {
                foreach (var modUpgrade in modTower.upgrades.Cast<ModUpgrade>()
                    .Where(modUpgrade => modUpgrade != null && tiers[modUpgrade.Path] >= modUpgrade.Tier)
                    .OrderByDescending(modUpgrade => modUpgrade.Priority)
                    .ThenBy(modUpgrade => modUpgrade.Tier)
                    .ThenBy(modUpgrade => modUpgrade.Path))
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
                var index = modTower.GetTowerIndex(Game.instance.model.towerSet.ToList());
                if (index >= 0)
                {
                    Game.instance.model.AddTowerDetails(shopTowerDetailsModel, index);
                }
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