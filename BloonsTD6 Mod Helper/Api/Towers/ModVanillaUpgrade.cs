using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;

namespace BTD_Mod_Helper.Api.Towers;

public abstract partial class ModVanillaUpgrade
{
    /// <inheritdoc />
    public override void Register()
    {
        base.Register();

        var upgradeModel = Game.instance.model.GetUpgrade(UpgradeId);

        var localizationMgr = Game.instance.GetLocalizationManager();
        if (!string.IsNullOrEmpty(DisplayName))
        {
            localizationMgr.GetTextTable()[UpgradeId] = DisplayName;
        }

        if (!string.IsNullOrEmpty(Description))
        {
            localizationMgr.GetTextTable()[UpgradeId + " Description"] = Description;
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

    /// <inheritdoc />
    public override IEnumerable<TowerModel> GetAffected(GameModel gameModel)
    {
        return gameModel.towers.Where(model => model.appliedUpgrades.Contains(UpgradeId));
    }
}