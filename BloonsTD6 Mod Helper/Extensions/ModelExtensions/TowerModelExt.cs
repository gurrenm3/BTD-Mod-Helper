using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.RightMenu;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class TowerModelExt
    {
        /// <summary>
        /// Not Tested. Use to set the maximum allowed number of this tower
        /// </summary>
        public static void SetMaxAmount(this TowerModel towerModel, int max)
        {
            towerModel.GetTowerDetailsModel().towerCount = max;
            Il2CppSystem.Collections.Generic.List<TowerDetailsModel> details = Game.instance?.model.GetAllTowerDetails();
            InGame.instance.GetTowerInventory().SetTowerMaxes(details);
        }

        /// <summary>
        /// Return all TowerDetailModels that share a base id with this towerModel
        /// </summary>
        public static TowerDetailsModel GetTowerDetailsModel(this TowerModel towerModel)
        {
            return Game.instance?.model?.GetAllTowerDetails()?.FirstOrDefault(tower => tower.towerId == towerModel.GetBaseId());
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
        public static int? GetIndex(this TowerModel towerModel)
        {
            List<TowerDetailsModel> allTowers = Game.instance.model.towerSet.ToList();
            TowerDetailsModel detail = allTowers.FirstOrDefault(towerDetail => towerDetail.towerId == towerModel.GetBaseId());
            return allTowers.IndexOf(detail);
        }

        /// <summary>
        /// Return the current upgrade level of a specific path
        /// </summary>
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
            return Game.instance?.GetBtd6Player()?.HasUnlockedHero(towerModel.GetBaseId());
        }

        /// <summary>
        /// Has a specific upgrade for this TowerModel been unlocked already?
        /// </summary>
        /// <param name="path">Upgrade path</param>
        /// <param name="tier">Tier of upgrade</param>
        public static bool? IsUpgradeUnlocked(this TowerModel towerModel, int path, int tier)
        {
            UpgradeModel upgradeModel = towerModel.GetUpgrade(path, tier);
            return Game.instance?.GetBtd6Player()?.HasUpgrade(upgradeModel?.name);
        }

        /// <summary>
        /// Check if a specific upgrade path is being used/ has any upgrades applied to it
        /// </summary>
        /// <param name="path">Upgrade path to check</param>
        public static bool IsUpgradePathUsed(this TowerModel towerModel, int path)
        {
            UpgradeModel result = towerModel.GetAppliedUpgrades().FirstOrDefault(upgrade => upgrade.path == path);
            return result != null;
        }

        /// <summary>
        /// Check if an upgrade has been applied
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tier"></param>
        public static bool HasUpgrade(this TowerModel towerModel, int path, int tier)
        {
            return HasUpgrade(towerModel, towerModel.GetUpgrade(path, tier));
        }

        /// <summary>
        /// Check if an upgrade has been applied
        /// </summary>
        /// <param name="upgradeModel"></param>
        /// <returns></returns>
        public static bool HasUpgrade(this TowerModel towerModel, UpgradeModel upgradeModel)
        {
            return towerModel.GetAppliedUpgrades().Contains(upgradeModel);
        }

        /// <summary>
        /// Return all UpgradeModels that are currently applied to this TowerModel
        /// </summary>
        public static List<UpgradeModel> GetAppliedUpgrades(this TowerModel towerModel)
        {
            List<UpgradeModel> appliedUpgrades = new List<UpgradeModel>();

            foreach (string upgrade in towerModel.appliedUpgrades)
                appliedUpgrades.Add(Game.instance?.model?.upgradesByName[upgrade]);

            return appliedUpgrades;
        }

        /// <summary>
        /// Return the UpgradeModel for a specific upgrade path/tier
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tier"></param>
        public static UpgradeModel GetUpgrade(this TowerModel towerModel, int path, int tier)
        {
            if (path < 0 || tier < 0)
                return null;

            int tier1 = (path == 0) ? tier : 0;
            int tier2 = (path == 1) ? tier : 0;
            int tier3 = (path == 2) ? tier : 0;

            
            TowerModel tempTower = Game.instance?.model?.GetTower(towerModel.GetBaseId(), tier1, tier2, tier3);
            if (tempTower is null)
                return null;

            const int offset = 1;
            List<UpgradeModel> appliedUpgrades = tempTower.GetAppliedUpgrades();
            UpgradeModel results = appliedUpgrades.FirstOrDefault(model => model.path == path && model.tier == (tier - offset));

            return null;
        }

        /// <summary>
        /// If this TowerModel is a Hero, return the HeroModel behavior
        /// </summary>
        /// <param name="towerModel"></param>
        /// <returns></returns>
        public static HeroModel GetHeroModel(this TowerModel towerModel)
        {
            return towerModel.GetBehavior<HeroModel>();
        }

        /// <summary>
        /// Make a new TowerModel based off of this one
        /// </summary>
        /// <param name="towerModel"></param>
        /// <param name="copyName">The new name for this TowerModel</param>
        /// <returns></returns>
        public static TowerModel MakeCopy(this TowerModel towerModel, string copyName)
        {
            var duplicate = towerModel.Duplicate();
            duplicate.baseId = copyName;
            duplicate.name = copyName;
            duplicate._name = copyName;
            return duplicate;
        }
    }
}