using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using NinjaKiwi.Common;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// ModContent class for modifying all TowerModels for a given Tower
    /// </summary>
    public abstract class ModVanillaTower : ModVanillaContent
    {
        /// <summary>
        /// The base id of the Tower that this should modify all TowerModels of
        /// <br/>
        /// Use TowerType.[tower]
        /// </summary>
        public abstract string TowerId { get; }

        /// <summary>
        /// Change the name of it when it's plural
        /// </summary>
        public virtual string DisplayNamePlural => null;

        /// <summary>
        /// Change the TowerSet that this tower is part of. Also handles moving its place within the shop.
        /// </summary>
        public virtual string TowerSet => null;

        internal override void PostRegister()
        {
            var affectedTowers = GetAffectedTowers(Game.instance.model).ToList();
            if (!string.IsNullOrEmpty(TowerSet))
            {
                foreach (var affectedTower in affectedTowers)
                {
                    affectedTower.towerSet = TowerSet;
                }

                var towerSet = Enumerable.ToList(Game.instance.model.towerSet);
                var towerDetailsModel = towerSet.First(model => model.towerId == TowerId);
                towerSet.Remove(towerDetailsModel);
                Game.instance.model.towerSet = towerSet.ToArray();

                var towers = Game.towers.ToList();
                towers.RemoveAll(s => s == TowerId);
                Game.towers = towers.ToArray();

                Game.instance.model.AddTowerDetails(towerDetailsModel, TowerSet);
            }

            if (Cost >= 0)
            {
                foreach (var affectedTower in affectedTowers)
                {
                    affectedTower.cost = Cost;
                }
            }

            if (!string.IsNullOrEmpty(DisplayName))
            {
                LocalizationManager.Instance.textTable[TowerId] = DisplayName;
                LocalizationManager.Instance.textTable[TowerId + "s"] = DisplayNamePlural ?? DisplayName + "s";
            }

            if (!string.IsNullOrEmpty(Description))
            {
                LocalizationManager.Instance.textTable[TowerId + " Description"] = Description;
            }
        }

        internal override IEnumerable<TowerModel> GetAffectedTowers(GameModel gameModel)
        {
            return gameModel.GetTowersWithBaseId(TowerId);
        }
    }

    /// <summary>
    /// Helper class for changing a vanilla tower to be part of a modded tower set
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ModVanillaTower<T> : ModVanillaTower where T : ModTowerSet
    {
        /// <inheritdoc />
        public sealed override string TowerSet => ModContent.TowerSet<T>();
    }
}