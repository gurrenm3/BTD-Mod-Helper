using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Data;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using Nullable = Il2CppSystem.Nullable;

namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// Class with helper methods for TowerModels / ModTowers
/// <br/>
/// Mostly used internally
/// </summary>
public static partial class ModTowerHelper
{
    internal static List<TowerModel> AddTower(ModTower modTower)
    {
        // Create all tower models
        var towerModels = modTower
            .TowerTiers()
            .Select(tiers => CreateTowerModel(modTower, tiers))
            .ToList();

        // Create the paragon model
        if (modTower.ShouldCreateParagon)
        {
            towerModels.Add(CreateParagonModel(modTower));
        }


        // Add each tower model
        try
        {
            Game.instance.model.AddTowersToGame(towerModels);
        }
        finally
        {
            modTower.rollbackActions.Push(() =>
            {
                var towers = Game.instance.model.towers.ToList();
                towers.RemoveAll(model => towerModels.Any(towerModel => model.name == towerModel?.name));
                Game.instance.model.towers = towers.ToIl2CppReferenceArray();

                foreach (var towerModel in towerModels)
                {
                    Game.instance.model.RemoveChildDependant(towerModel);
                    TowerCache.Remove(towerModel.name);
                }
            });
        }

        try
        {
            foreach (var towerModel in towerModels)
            {
                ModTowerCache[towerModel.name] = modTower;
            }
        }
        finally
        {
            modTower.rollbackActions.Push(() =>
            {
                foreach (var towerModel in towerModels)
                {
                    ModTowerCache.Remove(towerModel.name);
                }
            });
        }

        modTower.dummyUpgrade =
            new UpgradeModel(modTower.Id, modTower.Cost, 0, modTower.PortraitReference, 0, 0, 0, "", "");
        Game.instance.model.AddUpgrade(modTower.dummyUpgrade);

        return towerModels;
    }

    internal static TowerModel CreateTowerModel(ModTower modTower, int[] tiers)
    {
        var towerModel = modTower.GetDefaultTowerModel().Duplicate();
        towerModel.tiers = tiers;
        towerModel.tier = tiers.Max();
        towerModel.name = modTower.TowerId(tiers);

        // add the names to applied upgrades
        towerModel.appliedUpgrades = modTower.Upgrades.Cast<ModUpgrade>()
            .Where(modUpgrade => modUpgrade != null && tiers[modUpgrade.Path] >= modUpgrade.Tier)
            .Select(modUpgrade => modUpgrade.Id)
            .ToArray();

        // add the upgrade path models
        var towerTiers = modTower.TowerTiers();

        var modTowerTiers = towerTiers.ToList();
        for (var i = 0; i < modTower.UpgradePaths; i++)
        {
            var tierMax = modTower.TierMaxes[i];
            if (tiers[i] < tierMax)
            {
                var newTiers = tiers.Duplicate();
                newTiers[i]++;
                if (modTower is ModHero && tiers.Sum() == 0)
                {
                    newTiers[i]++; // level 1 heroes are classified as tier 0 for whatever reason
                }

                if (modTowerTiers.Any(t => t.SequenceEqual(newTiers)))
                {
                    var modUpgrade = modTower.Upgrades[i, newTiers[i] - 1];
                    if (modUpgrade == null)
                    {
                        ModHelper.Warning($"{modTower.Name} has missing upgrade in path {i} tier {newTiers[i] - 1}");
                    }
                    var upgradePathModel = modTower.GetUpgradePathModel(modUpgrade, newTiers);
                    towerModel.upgrades = towerModel.upgrades.AddTo(upgradePathModel);
                }
            }
        }

        // maybe add the paragon upgrade
        if (modTower.ShouldCreateParagon && tiers.Any(i => i == 5))
        {
            towerModel.paragonUpgrade =
                new UpgradePathModel(modTower.paragonUpgrade.Id, $"{towerModel.baseId}-Paragon");
        }

        // set the tower's portrait
        towerModel.portrait = modTower.GetPortraitReferenceForTiers(tiers);

        return towerModel;
    }

    internal static TowerModel CreateParagonModel(ModTower modTower)
    {
        var towerModel = modTower.GetBaseParagonModel();

        towerModel.tier = 6;
        towerModel.isParagon = true;
        towerModel.upgrades = new Il2CppReferenceArray<UpgradePathModel>(0);
        towerModel.paragonUpgrade = null;
        towerModel.name = $"{towerModel.baseId}-Paragon";
        towerModel.isBakable = false;
        towerModel.appliedUpgrades[5] = modTower.paragonUpgrade.Id;

        var sprite = modTower.paragonUpgrade.PortraitReference;
        if (sprite is not null)
        {
            towerModel.portrait = sprite;
        }

        return towerModel;
    }

    internal static void FinalizeTowerModel(ModTower modTower, TowerModel towerModel)
    {
        // do their base tower modifications
        modTower.ModifyBaseTowerModel(towerModel);

        // actually apply the upgrades

        foreach (var modUpgrade in modTower.Upgrades.Cast<ModUpgrade>()
                     .Where(modUpgrade =>
                         modUpgrade != null && towerModel.tiers[modUpgrade.Path] >= modUpgrade.Tier)
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
                ModHelper.Error(
                    $"Failed to apply ModUpgrade {modUpgrade.Name} to TowerModel {towerModel.name}");
                throw;
            }
        }

        towerModel.GenerateDescendentNames();

        if (modTower.ShouldCreateParagon && towerModel.isParagon)
        {
            towerModel.tiers = new[] {6, 0, 0};
        }

        // set the tower's display model
        if (modTower.Use2DModel)
        {
            var textureName = modTower.Get2DTexture(towerModel.tiers);
            var scale = modTower.Get2DScale(towerModel.tiers);
            var display = new ModDisplay2DImpl(modTower.mod, towerModel.name, textureName, scale);
            display.Apply(towerModel);
        }
        else if (modTower.displays
                     .Where(display => display.UseForTower(towerModel.tiers) && display.ParagonDisplayIndex <= 0)
                     .OrderByDescending(display => display.Id)
                     .FirstOrDefault() is { } modTowerDisplay)
        {
            modTowerDisplay.ApplyToTower(towerModel);
        }

        // last paragon stuff
        if (modTower.ShouldCreateParagon && towerModel.isParagon)
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
                var modTowerDisplay = modTower.displays
                    .Where(display => display.UseForTower(towerModel.tiers) && index >= display.ParagonDisplayIndex)
                    .OrderByDescending(display => display.ParagonDisplayIndex)
                    .FirstOrDefault();
                if (modTowerDisplay != default)
                {
                    displayDegreePath.assetPath = ModContent.CreatePrefabReference(modTowerDisplay.Id);
                }
            }

            towerModel.behaviors = towerModel.behaviors.AddTo(paragonModel);

            try
            {
                modTower.paragonUpgrade.ApplyUpgrade(towerModel);
            }
            catch (Exception)
            {
                ModHelper.Error(
                    $"Failed to apply ModParagonUpgrade {modTower.paragonUpgrade.Name} to TowerModel {towerModel.name}");
                throw;
            }
        }
    }

    internal static void FinalizeHero(ModHero modHero)
    {
        var index = modHero.GetHeroIndex(Game.instance.model.heroSet
            .Select(model => model.Cast<HeroDetailsModel>()).ToList());
        if (index >= 0)
        {
            var heroDetailsModel =
                new HeroDetailsModel(modHero.Id, index, 20, 1, 0, 0, 0, null, false);
            Game.instance.model.AddHeroDetails(heroDetailsModel, index);

            var skinsData = GameData.Instance.skinsData;
            var skinsByName = skinsData.SkinList.items.ToDictionary(data => data.name, data => data);
            var skinData = modHero.CreateDefaultSkin(skinsByName);
            skinsData.AddSkins(new[] {skinData});
        }
    }
}