using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Audio;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Skins;
using Assets.Scripts.Models.Skins.Behaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.SMath;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api.Towers;

internal static partial class ModTowerHelper
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
        towerModel.appliedUpgrades = modTower.upgrades.Cast<ModUpgrade>()
            .Where(modUpgrade => modUpgrade != null && tiers[modUpgrade.Path] >= modUpgrade.Tier)
            .Select(modUpgrade => modUpgrade.Id)
            .ToArray();

        // add the upgrade path models
        var towerTiers = modTower.TowerTiers();

        var modTowerTiers = towerTiers.ToList();
        for (var i = 0; i < modTower.UpgradePaths; i++)
        {
            var tierMax = modTower.tierMaxes[i];
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
                    var modUpgrade = modTower.upgrades[i, newTiers[i] - 1];
                    var upgradePathModel = new UpgradePathModel(modUpgrade.Id, modTower.TowerId(newTiers));
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
        var portraitUpgrade = modTower.upgrades.Cast<ModUpgrade>()
            .Where(modUpgrade => modUpgrade != null &&
                                 tiers[modUpgrade.Path] >= modUpgrade.Tier &&
                                 modUpgrade.PortraitReference)
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
        if (sprite != null)
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

        foreach (var modUpgrade in modTower.upgrades.Cast<ModUpgrade>()
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


        if (modTower.ShouldCreateParagon && towerModel.isParagon)
        {
            towerModel.tiers = new[] {6, 0, 0};
        }

        // set the tower's display model
        if (modTower.Use2DModel)
        {
            var name = modTower.Get2DTexture(towerModel.tiers);
            var guid = ModContent.GetTextureGUID(modTower.mod, name);
            towerModel.display = guid;
            towerModel.GetBehavior<DisplayModel>().display = guid;
            towerModel.GetBehavior<DisplayModel>().positionOffset = new Vector3(0, 0, 2f);
            ResourceHandler.ScalesFor2dModels[guid] = modTower.PixelsPerUnit;
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
                    displayDegreePath.assetPath = modTowerDisplay.Id;
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

            var skinModel = new HeroSkinModel(modHero.Id, modHero.ButtonReference, modHero.SquareReference,
                modHero.Id, modHero.Id + " Short Description", modHero.Id + " Description", 0, true,
                new Il2CppReferenceArray<SwapTowerSpriteModel>(0),
                new Il2CppReferenceArray<SwapTowerGraphicModel>(0),
                new Il2CppReferenceArray<SwapTowerSoundModel>(0),
                new Il2CppReferenceArray<SwapTowerOverlayModel>(0), "Quincy",
                new Il2CppReferenceArray<SpriteReference>(new[] {modHero.PortraitReference}),
                new Il2CppStringArray(0), new SoundModel("BlankSoundModel_", ""),
                new SoundModel("BlankSoundModel_", ""));

            Game.instance.model.skins = Game.instance.model.skins.AddTo(skinModel);
        }
    }
}