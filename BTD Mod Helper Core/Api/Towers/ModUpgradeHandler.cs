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
        internal static readonly List<ModUpgrade> ModUpgrades = new List<ModUpgrade>();

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
                    Game.instance.GetLocalizationManager().textTable[modUpgrade.Id] = modUpgrade.DisplayName;
                    Game.instance.GetLocalizationManager().textTable[modUpgrade.Id + " Description"] = modUpgrade.Description;
                    ModUpgrades.Add(modUpgrade);
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