#if BloonsTD6
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.SMath;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api.Towers
{
    internal static class ModTowerHandler
    {
        internal static readonly List<ModTower> ModTowers = new List<ModTower>();

        internal static readonly Dictionary<string, TowerModel> TowerCache = new Dictionary<string, TowerModel>();

        internal static readonly Dictionary<string, float> Tower2DScales = new Dictionary<string, float>();

        internal static readonly Dictionary<string, ModTower> ModTowersCache = new Dictionary<string, ModTower>();

        internal static void LoadTowers(List<ModTower> modTowers)
        {
            var towerModels = new Dictionary<ModTower, List<TowerModel>>();
            foreach (var modTower in modTowers)
            {
                try
                {
                    towerModels[modTower] = AddTower(modTower);
                }
                catch (Exception e)
                {
                    MelonLogger.Error("Failed to add the ModTower " + modTower.Name + " to the game");
                    MelonLogger.Error(e);
                }
            }

            foreach (var modTower in modTowers)
            {
                try
                {
                    foreach (var towerModel in towerModels[modTower])
                    {
                        FinalizeTowerModel(modTower, towerModel);
                    }
                }
                catch (Exception e)
                {
                    MelonLogger.Error("Failed to finalize ModTower " + modTower.Name);
                    MelonLogger.Error(e);
                }
            }

            foreach (var modTower in modTowers)
            {
                try
                {
                    Game.instance.GetLocalizationManager().textTable[modTower.Id] = modTower.DisplayName;
                    Game.instance.GetLocalizationManager().textTable[modTower.Id + " Description"] =
                        modTower.Description;
                    ModTowers.Add(modTower);
                }
                catch (Exception e)
                {
                    MelonLogger.Error("General error in loading ModTower " + modTower.Name);
                    MelonLogger.Error(e);
                }
            }
        }

        internal static List<TowerModel> AddTower(ModTower modTower)
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

            if (modTower.ShouldCreateParagon)
            {
                try
                {
                    towerModels.Add(CreateParagonModel(modTower));
                }
                catch (Exception e)
                {
                    MelonLogger.Msg($"Failed to create Paragon for {modTower.DisplayName}");
                    MelonLogger.Error(e);
                }
            }

            foreach (var towerModel in towerModels)
            {
                try
                {
                    Game.instance.model.AddTowerToGame(towerModel);
                    ModTowersCache[towerModel.name] = modTower;
                }
                catch (Exception e)
                {
                    MelonLogger.Error($"Failed to add TowerModel {towerModel.name} to the game");
                    MelonLogger.Error(e);
                }
            }

            if (!modTower.DontAddToShop)
            {
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

            return towerModels;
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
                var modTowerTiers = modTower.TowerTiers().ToList();
                for (var i = 0; i <= 2; i++)
                {
                    var tierMax = modTower.tierMaxes[i];
                    if (tiers[i] < tierMax)
                    {
                        var newTiers = tiers.Duplicate();
                        newTiers[i]++;
                        if (modTowerTiers.Any(t => t.SequenceEqual(newTiers)))
                        {
                            var modUpgrade = modTower.upgrades[i, newTiers[i] - 1];
                            var upgradePathModel = new UpgradePathModel(modUpgrade.Id,
                                $"{towerModel.baseId}-{newTiers.Printed()}");
                            towerModel.upgrades = towerModel.upgrades.AddTo(upgradePathModel);

                            // the commented code below was broken in update 27.0
                            /*var upgradePathModel = new UpgradePathModel(modUpgrade.Id,
                                $"{towerModel.baseId}-{newTiers.Printed()}", newTiers.Count(t => t > 0), newTiers.Max());
                            towerModel.upgrades = towerModel.upgrades.AddTo(upgradePathModel);*/
                        }
                    }
                }
            }
            catch (Exception)
            {
                MelonLogger.Error($"Failed to add the UpgradePathModels for TowerModel {towerModel.name}");
                throw;
            }

            // maybe add the paragon upgrade
            try
            {
                if (modTower.ShouldCreateParagon && tiers.Any(i => i == 5))
                {
                    towerModel.paragonUpgrade =
                        new UpgradePathModel(modTower.paragonUpgrade.Id, $"{towerModel.baseId}-Paragon");
                }
            }
            catch (Exception)
            {
                MelonLogger.Error($"Failed to add the Paragon Upgrade for TowerModel {towerModel.name}");
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
                    var sprite = portraitUpgrade.PortraitReference;
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

            return towerModel;
        }

        internal static TowerModel CreateParagonModel(ModTower modTower)
        {
            TowerModel towerModel;
            switch (modTower.ParagonMode)
            {
                case ParagonMode.Base000:
                    towerModel = CreateTowerModel(modTower, new[] { 0, 0, 0 });
                    break;
                case ParagonMode.Base555:
                    towerModel = CreateTowerModel(modTower, new[] { 5, 5, 5 });
                    break;
                default:
                    // This shouldn't be happening
                    return null;
            }

            towerModel.tier = 6;
            towerModel.isParagon = true;
            towerModel.upgrades = new Il2CppReferenceArray<UpgradePathModel>(0);
            towerModel.paragonUpgrade = null;
            towerModel.name = $"{towerModel.baseId}-Paragon";
            towerModel.isBakable = false;

            // Real paragons just use the top path applied upgrades it seems
            towerModel.appliedUpgrades = new Il2CppStringArray(6);
            for (var i = 0; i < 5; i++)
            {
                towerModel.appliedUpgrades[i] = modTower.upgrades[0, i].Id;
            }

            towerModel.appliedUpgrades[5] = modTower.paragonUpgrade.Id;

            var sprite = modTower.paragonUpgrade.PortraitReference;
            if (sprite != null)
            {
                towerModel.portrait = sprite;
            }
            
            return towerModel;
        }

        internal static void FinalizeTowerModel(ModTower modTower, TowerModel towerModel)
        {
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
                    .Where(modUpgrade => modUpgrade != null && towerModel.tiers[modUpgrade.Path] >= modUpgrade.Tier)
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
                        MelonLogger.Error(
                            $"Failed to apply ModUpgrade {modUpgrade.Name} to TowerModel {towerModel.name}");
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                MelonLogger.Error($"Failed to apply upgrades for TowerModel {towerModel.name}");
                throw;
            }

            if (modTower.ShouldCreateParagon && towerModel.isParagon)
            {
                towerModel.tiers = new[] { 6, 0, 0 };
            }

            // set the tower's display model
            if (modTower.Use2DModel)
            {
                try
                {
                    var name = modTower.Get2DTexture(towerModel.tiers);
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
                    if (modTower.displays.Where(display =>
                            display.UseForTower(towerModel.tiers) && display.ParagonDisplayIndex <= 0)
                        .OrderByDescending(display => display.Id)
                        .FirstOrDefault() is ModTowerDisplay modTowerDisplay)
                    {
                        modTowerDisplay.Apply(towerModel);
                    }
                }
                catch (Exception)
                {
                    MelonLogger.Error($"Failed to load ModTowerDisplay for TowerModel {towerModel.name}");
                    throw;
                }
            }

            // last paragon stuff
            if (modTower.ShouldCreateParagon && towerModel.isParagon)
            {
                try
                {
                    if (modTower.paragonUpgrade.RemoveAbilities)
                    {
                        towerModel.behaviors = towerModel.behaviors.RemoveItemsOfType<Model, AbilityModel>();
                    }

                    var paragonModel = modTower.paragonUpgrade.ParagonTowerModel.Duplicate();

                    for (var i = 0; i < paragonModel.displayDegreePaths.Count; i++)
                    {
                        var displayDegreePath = paragonModel.displayDegreePaths[i];
                        displayDegreePath.name = $"AssetPathModel_{modTower.paragonUpgrade.GetType().Name}Lvl1";

                        var index = i;
                        var modTowerDisplay = modTower.displays.Where(display =>
                                display.UseForTower(towerModel.tiers) && index >= display.ParagonDisplayIndex)
                            .OrderByDescending(display => display.ParagonDisplayIndex)
                            .FirstOrDefault();
                        if (modTowerDisplay != default)
                        {
                            displayDegreePath.assetPath = modTowerDisplay.Id;
                        }
                    }

                    towerModel.behaviors = towerModel.behaviors.AddTo(paragonModel);

                    modTower.paragonUpgrade.ApplyUpgrade(towerModel);
                }
                catch (Exception)
                {
                    MelonLogger.Error(
                        $"Failed to apply ModParagonUpgrade {modTower.paragonUpgrade.Name} to TowerModel {towerModel.name}");
                    throw;
                }
            }
        }
    }
}
#endif