using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.RightMenu;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for TowerModels
/// </summary>
public static partial class TowerModelExt
{
    /// <summary>
    /// Not Tested. Use to set the maximum allowed number of this tower
    /// </summary>
    public static void SetMaxAmount(this TowerModel towerModel, int max)
    {
        towerModel.GetTowerDetailsModel()!.towerCount = max;
        var details = Game.instance.model.towerSet;
        InGame.instance.GetTowerInventory()
            .SetTowerMaxes(details.Cast<Il2CppSystem.Collections.Generic.IEnumerable<TowerDetailsModel>>());
    }

    /// <summary>
    /// Return all TowerDetailModels that share a base id with this towerModel
    /// </summary>
    public static TowerDetailsModel? GetTowerDetailsModel(this TowerModel towerModel)
    {
        var baseId = towerModel.GetBaseId();
        return Game.instance.model?.GetAllTowerDetails()?.FirstOrDefault(details => details.towerId == baseId);
    }

    /// <summary>
    /// Return the TowerPurchaseButton for this TowerModel.
    /// </summary>
    public static TowerPurchaseButton GetTowerPurchaseButton(this TowerModel towerModel)
    {
        return ShopMenu.instance.GetTowerButtonFromBaseId(towerModel.GetBaseId());
    }

    /// <summary>
    /// Return the number position of this TowerModel in the list of all tower models
    /// </summary>
    public static int GetIndex(this TowerModel towerModel)
    {
        //var index = Game.instance?.model?.towers?.IndexOf(towerModel); //old

        var towers = Game.instance.model.towers;
        if (towers is null)
            return -1;

        for (var i = 0; i < towers.Count; i++)
        {
            if (towers[i].name == towerModel.name)
                return i;
        }

        return -1;
    }

    /// <summary>
    /// Return the current upgrade level of a specific path
    /// </summary>
    /// <param name="towerModel">the TowerModel</param>
    /// <param name="path">What tier of upgrade is currently applied to tower</param>
    public static int GetUpgradeLevel(this TowerModel towerModel, int path)
    {
        return towerModel.tiers[path];
    }

    /// <summary>
    /// If this TowerModel is for a Hero, is this Hero unlocked?
    /// </summary>
    public static bool? IsHeroUnlocked(this TowerModel towerModel)
    {
        return Game.instance.GetBtd6Player()?.HasUnlockedHero(towerModel.GetBaseId());
    }

    /// <summary>
    /// Has a specific upgrade for this TowerModel been unlocked already?
    /// </summary>
    /// <param name="towerModel">the TowerModel</param>
    /// <param name="path">Upgrade path</param>
    /// <param name="tier">Tier of upgrade</param>
    public static bool? IsUpgradeUnlocked(this TowerModel towerModel, int path, int tier)
    {
        var upgradeModel = towerModel.GetUpgrade(path, tier);
        return Game.instance.GetBtd6Player()?.HasUpgrade(upgradeModel?.name);
    }

    /// <summary>
    /// Check if a specific upgrade path is being used/ has any upgrades applied to it
    /// </summary>
    /// <param name="towerModel">the TowerModel</param>
    /// <param name="path">Upgrade path to check</param>
    public static bool IsUpgradePathUsed(this TowerModel towerModel, int path)
    {
        var result = towerModel.GetAppliedUpgrades().FirstOrDefault(upgrade => upgrade.path == path);
        return result != null;
    }

    /// <summary>
    /// Check if an upgrade has been applied
    /// </summary>
    public static bool HasUpgrade(this TowerModel towerModel, int path, int tier)
    {
        return HasUpgrade(towerModel, towerModel.GetUpgrade(path, tier)!);
    }

    /// <summary>
    /// Check if an upgrade has been applied
    /// </summary>
    public static bool HasUpgrade(this TowerModel towerModel, UpgradeModel upgradeModel)
    {
        return towerModel.GetAppliedUpgrades().Contains(upgradeModel);
    }

    /// <summary>
    /// Return all UpgradeModels that are currently applied to this TowerModel
    /// </summary>
    public static List<UpgradeModel> GetAppliedUpgrades(this TowerModel towerModel)
    {
        return towerModel.appliedUpgrades.Select(upgrade => Game.instance.model.GetUpgrade(upgrade)).ToList();
    }

    /// <summary>
    /// Return the UpgradeModel for a specific upgrade path/tier
    /// </summary>
    public static UpgradeModel? GetUpgrade(this TowerModel towerModel, int path, int tier)
    {
        if (path < 0 || tier < 0)
            return null;

        var tier1 = (path == 0) ? tier : 0;
        var tier2 = (path == 1) ? tier : 0;
        var tier3 = (path == 2) ? tier : 0;


        var tempTower = Game.instance.model?.GetTower(towerModel.GetBaseId(), tier1, tier2, tier3);
        if (tempTower is null)
            return null;

        const int offset = 1;
        var appliedUpgrades = tempTower.GetAppliedUpgrades();
        var results =
            appliedUpgrades.FirstOrDefault(model => model.path == path && model.tier == (tier - offset));

        return results;
    }

    /// <summary>
    /// If this TowerModel is a Hero, return the HeroModel behavior
    /// </summary>
    public static HeroModel? GetHeroModel(this TowerModel towerModel)
    {
        return towerModel.GetBehavior<HeroModel>();
    }

    /// <summary>
    /// Duplicate this TowerModel with a unique name. Very useful for making custom TowerModels
    /// </summary>
    /// <param name="towerModel"></param>
    /// <param name="newTowerId">Set's the new towerId of this copy. By default the baseId will be set to this as well</param>
    /// <param name="addToGame"></param>
    /// <param name="newBaseId">Specify a new baseId. Set this if you want a baseId other than the newTowerId</param>
    /// <returns></returns>
    public static TowerModel MakeCopy(this TowerModel towerModel, string newTowerId, bool addToGame = false,
        string? newBaseId = null)
    {
        var duplicate = MakeCopyInternal(towerModel, newTowerId);
        duplicate.baseId = string.IsNullOrEmpty(newBaseId) ? newTowerId : newBaseId;
        if (addToGame) Game.instance.model.AddTowerToGame(duplicate);

        return duplicate;
    }

    /// <summary>
    /// Check if this tower has speficif upgrade tiers
    /// </summary>
    /// <param name="towerModel"></param>
    /// <param name="tier1"></param>
    /// <param name="tier2"></param>
    /// <param name="tier3"></param>
    /// <returns></returns>
    public static bool HasTiers(this TowerModel towerModel, int tier1 = 0, int tier2 = 0, int tier3 = 0)
    {
        return (towerModel.tiers[0] == tier1) && (towerModel.tiers[1] == tier2) && (towerModel.tiers[2] == tier3);
    }


    /// <summary>
    /// Sets a TowerModel's tiers
    /// </summary>
    public static void SetTiers(this TowerModel towerModel, int tier1 = 0, int tier2 = 0, int tier3 = 0,
        bool addToTowerName = false)
    {
        towerModel.tiers = new UnhollowerBaseLib.Il2CppStructArray<int>(3)
        {
            [0] = tier1,
            [1] = tier2,
            [2] = tier3
        };

        if (addToTowerName)
            towerModel.AddTiersToName();
    }


    /// <summary>
    /// Format's the tower's name with its tiers
    /// </summary>
    public static void AddTiersToName(this TowerModel towerModel, int tier1, int tier2, int tier3)
    {
        towerModel.name = string.Concat(towerModel.baseId, "-", tier1, tier2, tier3);
    }


    /// <summary>
    /// Format's the tower's name with its tiers
    /// </summary>
    public static void AddTiersToName(this TowerModel towerModel)
    {
        var tiers = towerModel.tiers;
        if (tiers is null)
        {
            towerModel.AddTiersToName(0, 0, 0);
        }
        else
        {
            var tier1 = tiers.Count >= 1 ? tiers[0] : 0;
            var tier2 = tiers.Count >= 2 ? tiers[1] : 0;
            var tier3 = tiers.Count >= 3 ? tiers[2] : 0;

            towerModel.AddTiersToName(tier1, tier2, tier3);
        }
    }
}