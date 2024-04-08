using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppNinjaKiwi.Common.ResourceUtils;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// Class with helper methods for TowerModels / ModTowers
/// <br />
/// Mostly used internally
/// </summary>
public static class ModTowerHelper
{
    // Cache of all added TowerModel.name => TowerModel
    internal static readonly Dictionary<string, TowerModel> TowerCache = new();

    // Cache of TowerModel.name => ModTower 
    internal static readonly Dictionary<string, ModTower> ModTowerCache = new();

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
                towers.RemoveAll(model => towerModels.Exists(towerModel => model.name == towerModel?.name));
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
        var towerModel = modTower.GetDefaultTowerModel(tiers).Duplicate();
        towerModel.name = modTower.TowerId(tiers);

        // add the names to applied upgrades
        towerModel.appliedUpgrades = modTower.AllUpgrades
            .Where(modUpgrade => tiers[modUpgrade.Path] >= modUpgrade.Tier)
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

                if (modTowerTiers.Exists(t => t.SequenceEqual(newTiers)))
                {
                    var modUpgrade = modTower.Upgrades[i][newTiers[i] - 1];
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

        var modUpgrades = modTower.GetUpgradesForTiers(towerModel.tiers);

        foreach (var modUpgrade in modUpgrades)
        {
            try
            {
                modUpgrade.EarlyApplyUpgrade(towerModel);
            }
            catch (Exception)
            {
                ModHelper.Error(
                    $"Failed to EarlyApplyUpgrade {modUpgrade.Name} to TowerModel {towerModel.name}");
                throw;
            }
        }

        foreach (var modUpgrade in modUpgrades)
        {
            try
            {
                modUpgrade.ApplyUpgrade(towerModel);
            }
            catch (Exception)
            {
                ModHelper.Error(
                    $"Failed to ApplyUpgrade {modUpgrade.Name} to TowerModel {towerModel.name}");
                throw;
            }
        }

        foreach (var modUpgrade in modUpgrades)
        {
            try
            {
                modUpgrade.LateApplyUpgrade(towerModel);
            }
            catch (Exception)
            {
                ModHelper.Error(
                    $"Failed to LateApplyUpgrade {modUpgrade.Name} to TowerModel {towerModel.name}");
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
            var display = new ModDisplay2DImpl(modTower.mod, towerModel.name, textureName, scale,
                displayCategory: DisplayCategory.Tower);
            display.Apply(towerModel);
        }
        else if (modTower.displays
                     .Where(display => display.UseForTower(towerModel.tiers) && display.ParagonDisplayIndex <= 0)
                     .MaxBy(display => display.Id) is { } modTowerDisplay)
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
                    .MaxBy(display => display.ParagonDisplayIndex);
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
                new HeroDetailsModel(modHero.Id, index, 20, 1, 0, 0, 0, false);
            Game.instance.model.AddHeroDetails(heroDetailsModel, index);

            var skinsData = GameData.Instance.skinsData;
            var skinsByName = skinsData.SkinList.items.ToDictionary(data => data.name, data => data);
            var skinData = modHero.CreateDefaultSkin(skinsByName);
            skinsData.AddSkins(new[] {skinData});
        }
    }


    /// <summary>
    /// Creates and returns an empty TowerModel
    /// </summary>
    public static TowerModel CreateTowerModel(string name, string baseId = null, TowerSet towerSet = TowerSet.None)
    {
        var sprite = Il2CppSystem.Nullable<SpriteReference>.Unbox(ModContent.CreateSpriteReference(""));
        var display = ModContent.CreatePrefabReference("");
        return new TowerModel(name, baseId ?? name, towerSet, display, icon: sprite, portrait: sprite, instaIcon: sprite,
            emoteSpriteSmall: sprite, emoteSpriteLarge: sprite, secondarySelectionMenu: display);
    }
}