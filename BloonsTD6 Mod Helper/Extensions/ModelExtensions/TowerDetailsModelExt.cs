﻿using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;

namespace BTD_Mod_Helper.Extensions
{
    public static class TowerDetailsModelExt
    {
        public static int GetIndex(this TowerDetailsModel towerDetailsModel)
        {
            var towers = Game.instance.model.towerSet;
            if (towers is null)
                return -1;

            for (int i = 0; i < towers.Count; i++)
            {
                if (towers[i].name == towerDetailsModel.name)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Returns if this TowerDetailModel is actually for a Hero
        /// </summary>
        public static bool IsHero(this TowerDetailsModel towerDetailsModel)
        {
            HeroDetailsModel heroDetailsModel = towerDetailsModel.TryCast<HeroDetailsModel>();
            bool isHero = heroDetailsModel != null;
            return isHero;
        }

        /// <summary>
        /// Get the TowerPurchaseButton that is used to buy this specific TowerDetailModel
        /// </summary>
        public static TowerPurchaseButton GetTowerPurchaseButton(this TowerDetailsModel towerDetailsModel)
        {
            Assets.Scripts.Models.Towers.TowerModel towerModel = Game.instance.model.GetTower(towerDetailsModel.towerId);
            return towerModel.GetTowerPurchaseButton();
        }

        /// <summary>
        /// Get the ShopTowerDetails for this TowerDetailModel
        /// </summary>
        public static ShopTowerDetailsModel GetShopTowerDetails(this TowerDetailsModel towerDetailsModel)
        {
            return towerDetailsModel.TryCast<ShopTowerDetailsModel>();
        }

        public static TowerDetailsModel MakeCopy(this TowerDetailsModel towerDetailsModel, string newName, bool addToGame = false)
        {
            return towerDetailsModel.MakeCopy(newName, towerDetailsModel.towerIndex, addToGame);
        }

        public static TowerDetailsModel MakeCopy(this TowerDetailsModel towerDetailsModel, string newName, int newTowerIndex, bool addToGame =false)
        {
            var duplicate = towerDetailsModel.Duplicate();
            duplicate.towerId = newName;
            duplicate.SetName(newName);
            duplicate.towerIndex = newTowerIndex;

            if (addToGame)
                Game.instance.model.AddTowerDetails(duplicate);

            return duplicate;
        }

        /// <summary>
        /// Sets the name of this TowerDetailsModel, following the naming convention of ofther TowerDetailModels.
        /// Example, using "NewMonkey" will set the name to "TowerDetailsModel_NewMonkey"
        /// </summary>
        /// <param name="towerDetailsModel"></param>
        /// <param name="newName"></param>
        public static void SetName(this TowerDetailsModel towerDetailsModel, string newName)
        {
            towerDetailsModel.name = string.Concat(towerDetailsModel.GetIl2CppType().Name, "_", newName);
        }

        //needs more work
        /*public static bool HasPlayerUnlocked(this TowerDetailsModel towerDetailsModel)
        {
            var towerModel = Game.instance.model.GetTower(towerDetailsModel.towerId);
            return towerModel.IsTowerUnlocked().Value;
        }*/



        // this would be helpful but might not use it because it requires user in game
        /*public static void SetCount(this TowerDetailsModel towerDetailsModel, int count)
        {
            towerDetailsModel.towerCount = count;
            var details = Game.instance?.model.towerSet.ToIl2CppList();
            //var details = Game.instance?.GetTowerDetailModels().TryCast<Il2CppSystem.Collections.Generic.List<TowerDetailsModel>>();
            InGame.instance?.GetTowerInventory(1).SetTowerMaxes(details);
        }*/

        public static TowerModel GetTower(this TowerDetailsModel towerDetailsModel)
        {
            return Game.instance.model.GetTowerWithName(towerDetailsModel.towerId);
        }
        
    }
}