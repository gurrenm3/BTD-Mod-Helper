using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for TowerModels
/// </summary>
public static class TowerModelExt
{
    /// <summary>
    /// Get the name of the BaseTower. Will be different from this TowerModel's name if this TowerModel isn't a BaseTower
    /// </summary>
    /// <param name="towerModel"></param>
    /// <returns></returns>
    public static string GetBaseId(this TowerModel towerModel) => towerModel.baseId;

    /// <summary>
    /// Has player already unlocked this TowerModel
    /// </summary>
    public static bool? IsTowerUnlocked(this TowerModel towerModel) =>
        Game.instance?.GetBtd6Player()?.HasUnlockedTower(towerModel.GetBaseId());

    /// <summary>
    /// Return all TowerToSimulations with this TowerModel
    /// </summary>
    public static List<TowerToSimulation> GetAllTowerToSim(this TowerModel towerModel)
    {
        var towers = InGame.instance.GetAllTowerToSim();
        var desiredTowers = towers.Where(towerSim => towerSim.Def.name == towerModel.name).ToList();
        return desiredTowers;
    }


    /// <summary>
    /// Return all AbilityModel behaviors from this tower, if it has any
    /// </summary>
    public static List<AbilityModel> GetAbilities(this TowerModel towerModel) =>
        towerModel.GetBehaviors<AbilityModel>().ToList();

    /// <summary>
    /// Return the first ability on the tower
    /// </summary>
    public static AbilityModel GetAbility(this TowerModel towerModel) => towerModel.GetAbilities().FirstOrDefault();

    /// <summary>
    /// Return a specific Ability of the tower.
    /// </summary>
    /// <param name="towerModel">the TowerModel</param>
    /// <param name="index">Index of the ability you want.</param>
    public static AbilityModel GetAbility(this TowerModel towerModel, int index) => towerModel.GetAbilities()[index];

    /// <summary>
    /// Return all AttackModel behaviors for this TowerModel
    /// </summary>
    public static List<AttackModel> GetAttackModels(this TowerModel towerModel) =>
        towerModel.GetBehaviors<AttackModel>().ToList();

    /// <summary>
    /// Return the first AttackModel from this TowerModel, if it has one
    /// </summary>
    public static AttackModel GetAttackModel(this TowerModel towerModel) => towerModel.GetAttackModels().FirstOrDefault();

    /// <summary>
    /// Return the first AttackModel whose name contains the given string
    /// </summary>
    public static AttackModel GetAttackModel(this TowerModel towerModel, string nameContains)
    {
        return towerModel.GetAttackModels().Find(model => model.name.Contains(nameContains));
    }

    /// <summary>
    /// Return one of the AttackModels from this TowerModel. By default will give the first AttackModel
    /// </summary>
    /// <param name="towerModel">The TowerModel</param>
    /// <param name="index">Index of the AttackModel you want</param>
    public static AttackModel GetAttackModel(this TowerModel towerModel, int index) => towerModel.GetAttackModels()[index];

    /// <summary>
    /// Recursively get every WeaponModels this TowerModel has
    /// </summary>
    public static List<WeaponModel> GetWeapons(this TowerModel towerModel)
    {
        var attackModels = towerModel.GetAttackModels();
        if (attackModels is null)
            return null;

        if (!attackModels.Any())
            return new List<WeaponModel>();

        var weaponModels = new List<WeaponModel>();
        foreach (var weapons in attackModels.Select(attackModel => attackModel.weapons).Where(weapons => weapons != null))
        {
            weaponModels.AddRange(weapons);
        }

        return weaponModels;
    }

    /// <summary>
    /// Return one of the WeaponModels this TowerModel has. By default will return the first one
    /// </summary>
    /// <param name="towerModel">The TowerModel</param>
    /// <param name="index">Index of WeaponModel that you want</param>
    public static WeaponModel GetWeapon(this TowerModel towerModel, int index) => towerModel.GetWeapons()[index];

    /// <summary>
    /// Return the first WeaponModel this TowerModel has, if it has one.
    /// </summary>
    public static WeaponModel GetWeapon(this TowerModel towerModel) => towerModel.GetWeapons().FirstOrDefault();

    /// <summary>
    /// Sell every tower that uses this TowerModel
    /// </summary>
    /// <param name="towerModel"></param>
    public static void SellAll(this TowerModel towerModel)
    {
        var towers = InGame.instance.GetTowers(towerModel.name);
        towers.ForEach(tower => InGame.instance.SellTower(tower));
    }

    /// <summary>
    /// Get the TowerId of this TowerModel. Equivalent to towerModel.name
    /// </summary>
    /// <param name="towerModel"></param>
    /// <returns></returns>
    public static string GetTowerId(this TowerModel towerModel) => towerModel.name;

    /// <summary>
    /// Duplicate this TowerModel with a unique name. Very useful for making custom TowerModels
    /// </summary>
    /// <param name="towerModel"></param>
    /// <param name="newTowerId">Set's the new towerId of this copy. By default the baseId will be set to this as well</param>
    /// <returns></returns>
    internal static TowerModel MakeCopyInternal(TowerModel towerModel, string newTowerId)
    {
        var duplicate = towerModel.Duplicate();
        duplicate.name = newTowerId;
        return duplicate;
    }

    /// <summary>
    /// Applies a given ModDisplay to this TowerModel
    /// </summary>
    /// <typeparam name="T">The type of ModDisplay</typeparam>
    public static void ApplyDisplay<T>(this TowerModel towerModel) where T : ModDisplay
    {
        ModContent.GetInstance<T>().Apply(towerModel);
    }

    /// <summary>
    /// Gets the ModTower associated with this TowerModel
    /// <br />
    /// If there is no associated ModTower, returns null
    /// </summary>
    /// <returns></returns>
    public static ModTower GetModTower(this TowerModel towerModel) =>
        ModTowerHelper.ModTowerCache.TryGetValue(towerModel.name, out var modTower) ? modTower : null;

    /// <summary>
    /// Gets the specific ModTower associated with this TowerModel
    /// <br />
    /// If there is no associated ModTower, returns null
    /// </summary>
    /// <returns></returns>
    public static T GetModTower<T>(this TowerModel towerModel) where T : ModTower => (T) GetModTower(towerModel);

    /// <summary>
    /// Increase the range of a tower and all its attacks by the given amount
    /// </summary>
    /// <param name="towerModel"></param>
    /// <param name="rangeIncrease"></param>
    public static void IncreaseRange(this TowerModel towerModel, float rangeIncrease)
    {
        towerModel.range += rangeIncrease;
        foreach (var attackModel in towerModel.GetAttackModels())
        {
            attackModel.range += rangeIncrease;
        }
    }

    /// <summary>
    /// Not Tested. Use to set the maximum allowed number of this tower
    /// </summary>
    public static void SetMaxAmount(this TowerModel towerModel, int max)
    {
        towerModel.GetTowerDetailsModel().towerCount = max;
        var details = Game.instance.model.towerSet;
        InGame.instance.GetTowerInventory()
            .SetTowerMaxes(details.Cast<Il2CppSystem.Collections.Generic.IEnumerable<TowerDetailsModel>>());
    }

    /// <summary>
    /// Return all TowerDetailModels that share a base id with this towerModel
    /// </summary>
    public static TowerDetailsModel GetTowerDetailsModel(this TowerModel towerModel)
    {
        var baseId = towerModel.GetBaseId();
        return Game.instance.model?.GetAllTowerDetails()?.FirstOrDefault(details => details.towerId == baseId);
    }

    /// <summary>
    /// Return the TowerPurchaseButton for this TowerModel.
    /// </summary>
    public static TowerPurchaseButton GetTowerPurchaseButton(this TowerModel towerModel) =>
        ShopMenu.instance.GetTowerButtonFromBaseId(towerModel.GetBaseId());

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
    public static int GetUpgradeLevel(this TowerModel towerModel, int path) => towerModel.tiers[path];

    /// <summary>
    /// If this TowerModel is for a Hero, is this Hero unlocked?
    /// </summary>
    public static bool? IsHeroUnlocked(this TowerModel towerModel) =>
        Game.instance.GetBtd6Player()?.HasUnlockedHero(towerModel.GetBaseId());

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
        var result = towerModel.GetAppliedUpgrades().Find(upgrade => upgrade.path == path);
        return result != null;
    }

    /// <summary>
    /// Check if an upgrade has been applied
    /// </summary>
    public static bool HasUpgrade(this TowerModel towerModel, int path, int tier) =>
        HasUpgrade(towerModel, towerModel.GetUpgrade(path, tier)!);

    /// <summary>
    /// Check if an upgrade has been applied
    /// </summary>
    public static bool HasUpgrade(this TowerModel towerModel, UpgradeModel upgradeModel) =>
        towerModel.GetAppliedUpgrades().Contains(upgradeModel);

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
    public static UpgradeModel GetUpgrade(this TowerModel towerModel, int path, int tier)
    {
        if (path < 0 || tier < 0)
            return null;

        var tier1 = path == 0 ? tier : 0;
        var tier2 = path == 1 ? tier : 0;
        var tier3 = path == 2 ? tier : 0;


        var tempTower = Game.instance.model?.GetTower(towerModel.GetBaseId(), tier1, tier2, tier3);
        if (tempTower is null)
            return null;

        const int offset = 1;
        var appliedUpgrades = tempTower.GetAppliedUpgrades();
        var results =
            appliedUpgrades.Find(model => model.path == path && model.tier == tier - offset);

        return results;
    }

    /// <summary>
    /// If this TowerModel is a Hero, return the HeroModel behavior
    /// </summary>
    public static HeroModel GetHeroModel(this TowerModel towerModel) => towerModel.GetBehavior<HeroModel>();

    /// <summary>
    /// Duplicate this TowerModel with a unique name. Very useful for making custom TowerModels
    /// </summary>
    /// <param name="towerModel"></param>
    /// <param name="newTowerId">Set's the new towerId of this copy. By default the baseId will be set to this as well</param>
    /// <param name="addToGame"></param>
    /// <param name="newBaseId">Specify a new baseId. Set this if you want a baseId other than the newTowerId</param>
    /// <returns></returns>
    public static TowerModel MakeCopy(this TowerModel towerModel, string newTowerId, bool addToGame = false,
        string newBaseId = null)
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
    public static bool HasTiers(this TowerModel towerModel, int tier1 = 0, int tier2 = 0, int tier3 = 0) =>
        towerModel.tiers[0] == tier1 && towerModel.tiers[1] == tier2 && towerModel.tiers[2] == tier3;


    /// <summary>
    /// Sets a TowerModel's tiers
    /// </summary>
    public static void SetTiers(this TowerModel towerModel, int tier1 = 0, int tier2 = 0, int tier3 = 0,
        bool addToTowerName = false)
    {
        towerModel.tiers = new Il2CppStructArray<int>(3)
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

    /// <summary>
    /// Gets the tower set (vanilla or modded) of this tower in the form of a string
    /// </summary>
    /// <param name="towerModel"></param>
    /// <returns></returns>
    public static string GetTowerSet(this TowerModel towerModel) =>
        towerModel.GetModTower()?.ModTowerSet?.Id ?? towerModel.towerSet.ToString();

    /// <summary>
    /// Gets whether a Tower/Hero is a base one added by the vanilla game.
    /// </summary>
    public static bool IsVanillaTower(this TowerModel towerModel) => VanillaSprites.ByName.ContainsKey(towerModel.IsHero()
        ? "HeroIcon" + towerModel.baseId
        : towerModel.baseId.Replace(TowerType.WizardMonkey, "Wizard") + "000");
}