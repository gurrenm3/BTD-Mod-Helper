#if BloonsTD6
using System;
using System.Collections.Generic;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// Handles loading and keeping track of ModUpgrades
    /// </summary>
    public static class ModUpgradeHandler
    {
        // Cache of UpgradeModel.name => ModUpgrade
        internal static readonly Dictionary<string, ModUpgrade> ModUpgradeCache = new Dictionary<string, ModUpgrade>();

        internal static void LoadUpgrades(List<ModUpgrade> modUpgrades)
        {
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

                if (modUpgrade is ModParagonUpgrade modParagonUpgrade)
                {
                    modUpgrade.Tower.paragonUpgrade = modParagonUpgrade;
                }
                else
                {
                    try
                    {
                        modUpgrade.Tower.upgrades[modUpgrade.Path, modUpgrade.Tier - 1] = modUpgrade;
                    }
                    catch (Exception e)
                    {
                        MelonLogger.Error("Failed to assign ModUpgrade " + modUpgrade.Name + " to ModTower's upgrades");
                        MelonLogger.Error(e);
                        MelonLogger.Error(
                            "Double check that the Tower loaded and all Path and Tier values are correct");
                        continue;
                    }
                }

                try
                {
                    Game.instance.model.AddUpgrade(upgradeModel);
                    var localizationManager = Game.instance.GetLocalizationManager();
                    localizationManager.textTable[modUpgrade.Id] = modUpgrade.DisplayName;
                    localizationManager.textTable[modUpgrade.Id + " Description"] = modUpgrade.Description;
                    localizationManager.textTable[modUpgrade.DisplayName + " Description"] = modUpgrade.Description;

                    if (modUpgrade.NeedsConfirmation)
                    {
                        localizationManager.textTable[modUpgrade.Id + " Title"] = modUpgrade.ConfirmationTitle;
                        localizationManager.textTable[modUpgrade.Id + " Body"] = modUpgrade.ConfirmationBody;
                    }

                    if (modUpgrade is ModHeroLevel modHeroLevel)
                    {
                        if (modHeroLevel.AbilityName != null)
                        {
                            localizationManager.textTable[modHeroLevel.AbilityName + " Ability"] = modHeroLevel.AbilityName;
                        }
                        
                        if (modHeroLevel.AbilityDescription != null)
                        {
                            localizationManager.textTable[modHeroLevel.AbilityName + " Ability Description"] = modHeroLevel.AbilityDescription;
                        }
                    }

                    ModUpgradeCache[upgradeModel.name] = modUpgrade;
                }
                catch (Exception e)
                {
                    MelonLogger.Error("General error in loading ModUpgrade " + modUpgrade.Name);
                    MelonLogger.Error(e);
                }
            }
        }
    }
}
#endif