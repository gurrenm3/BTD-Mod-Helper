using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;

namespace BTD_Mod_Helper.Extensions
{
    public static class TowerDetailsModelExt
    {
        /// <summary>
        /// Returns if this TowerDetailModel is actually for a Hero
        /// </summary>
        public static bool IsHero(this TowerDetailsModel towerDetailsModel)
        {
            return towerDetailsModel is HeroDetailsModel;

            // old method of checking. Will remove once confirmed working
            /*HeroDetailsModel heroDetailsModel = towerDetailsModel.TryCast<HeroDetailsModel>();
            bool isHero = heroDetailsModel != null;
            return isHero;*/
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
    }
}