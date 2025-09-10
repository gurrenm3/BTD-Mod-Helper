using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// ModContent class for modifying all TowerModels that have a given upgrade applied to them
/// </summary>
public abstract class ModVanillaUpgrade : ModVanillaContent<TowerModel>
{
    /// <summary>
    /// Changes the base cost
    /// </summary>
    public virtual int Cost => -1;

    /// <summary>
    /// The id of the Upgrade that this should modify all TowerModels that use
    /// <br />
    /// Use UpgradeType.[upgrade]
    /// </summary>
    public abstract string UpgradeId { get; }

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
        return gameModel.towers.Where(model => model.appliedUpgrades?.Contains(UpgradeId) == true);
    }
}