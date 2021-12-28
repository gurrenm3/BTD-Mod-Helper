using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using NinjaKiwi.Common;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// ModContent class for modifying all TowerModels that have a given upgrade applied to them
    /// </summary>
    public abstract class ModVanillaUpgrade : ModVanillaContent
    {
        /// <summary>
        /// The id of the Upgrade that this should modify all TowerModels that use
        /// <br/>
        /// Use UpgradeType.[upgrade]
        /// </summary>
        public abstract string UpgradeId { get; }

        /// <inheritdoc />
        public override void Register()
        {
            base.Register();
            
            var upgradeModel = Game.instance.model.GetUpgrade(UpgradeId);
            
            if (!string.IsNullOrEmpty(DisplayName))
            {
                LocalizationManager.Instance.textTable[UpgradeId] = DisplayName;
            }

            if (!string.IsNullOrEmpty(Description))
            {
                LocalizationManager.Instance.textTable[UpgradeId + " Description"] = Description;
            }

            if (Cost >= 0)
            {
                upgradeModel.cost = Cost;
            }
            
            Apply(upgradeModel);
        }

        /// <summary>
        /// Change the UpgradeModel for this upgrade
        /// </summary>
        /// <param name="upgradeModel"></param>
        public virtual void Apply(UpgradeModel upgradeModel)
        {
            
        }

        public override IEnumerable<TowerModel> GetAffectedTowers(GameModel gameModel)
        {
            return gameModel.towers.Where(model => model.appliedUpgrades.Contains(UpgradeId));
        }
    }
}