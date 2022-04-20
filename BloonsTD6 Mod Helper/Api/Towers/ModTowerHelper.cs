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
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api.Towers
{
    internal static partial class ModTowerHelper
    {
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
                    ModHelper.Error($"Failed to create {tiers.Printed()} TowerModel for ModTower {modTower.Name}");
                    ModHelper.Error(e);
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
                    ModHelper.Log($"Failed to create Paragon for {modTower.DisplayName}");
                    ModHelper.Error(e);
                }
            }

            foreach (var towerModel in towerModels)
            {
                try
                {
                    Game.instance.model.AddTowerToGame(towerModel);
                    ModTowerCache[towerModel.name] = modTower;
                }
                catch (Exception e)
                {
                    ModHelper.Error($"Failed to add TowerModel {towerModel.name} to the game");
                    ModHelper.Error(e);
                }
            }

            modTower.dummyUpgrade =
                new UpgradeModel(modTower.Id, modTower.Cost, 0, modTower.PortraitReference, 0, 0, 0, "", "");
            Game.instance.model.AddUpgrade(modTower.dummyUpgrade);

            return towerModels;
        }

        internal static TowerModel CreateTowerModel(ModTower modTower, int[] tiers)
        {
            TowerModel towerModel;
            try
            {
                towerModel = modTower.GetDefaultTowerModel().Duplicate();
                towerModel.tiers = tiers;
                towerModel.tier = tiers.Max();
                towerModel.name = modTower.TowerId(tiers);
            }
            catch (Exception)
            {
                ModHelper.Error($"Failed to get base TowerModel for ModTower {modTower.Name}");
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
                ModHelper.Error($"Failed to add appliedUpgrades info to TowerModel {towerModel.name}");
                throw;
            }

            // add the upgrade path models
            try
            {
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
            }
            catch (Exception)
            {
                ModHelper.Error($"Failed to add the UpgradePathModels for TowerModel {towerModel.name}");
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
                ModHelper.Error($"Failed to add the Paragon Upgrade for TowerModel {towerModel.name}");
                throw;
            }

            // set the tower's portrait
            try
            {
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
            }
            catch (Exception)
            {
                ModHelper.Error($"Failed to set the Portrait of TowerModel {towerModel.name}");
                throw;
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
            try
            {
                modTower.ModifyBaseTowerModel(towerModel);
            }
            catch (Exception)
            {
                ModHelper.Error($"Failed to modify TowerModel {towerModel.name}");
                throw;
            }

            // actually apply the upgrades
            try
            {
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
            }
            catch (Exception)
            {
                ModHelper.Error($"Failed to apply upgrades for TowerModel {towerModel.name}");
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
                    ResourceHandler.ScalesFor2dModels[guid] = modTower.PixelsPerUnit;
                }
                catch (Exception)
                {
                    ModHelper.Error($"Failed to load 2d display for TowerModel {towerModel.name}");
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
                        modTowerDisplay.ApplyToTower(towerModel);
                    }
                }
                catch (Exception)
                {
                    ModHelper.Error($"Failed to load ModTowerDisplay for TowerModel {towerModel.name}");
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

                var skinModel = new HeroSkinModel(modHero.Id, modHero.ButtonReference, modHero.ButtonReference,
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
}
