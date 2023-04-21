using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// Dummy ModTower that can be used to make a Paragon for a base tower.
/// </summary>
public abstract class ModVanillaParagon : ModTower
{
    internal sealed override ModTowerSet ModTowerSet => base.ModTowerSet;

    internal sealed override int UpgradePaths => 0;

    internal override bool ShouldCreateParagon => true;

    /// <summary>
    /// No paragons in shop
    /// </summary>
    public sealed override bool DontAddToShop => true;

    /// <summary>
    /// Not using the custom tower paragon mode
    /// </summary>
    public sealed override ParagonMode ParagonMode => ParagonMode.None;

    /// <summary>
    /// Order doesn't apply here
    /// </summary>
    protected sealed override int Order => base.Order;

    /// <summary>
    /// Same towerSet as base tower
    /// </summary>
    public sealed override TowerSet TowerSet => BaseTowerModel.towerSet;

    /// <summary>
    /// Handled by upgrade cost
    /// </summary>
    public sealed override int Cost => 0;

    /// <summary>
    /// No upgrades for the paragon
    /// </summary>
    public sealed override int TopPathUpgrades => 0;

    /// <summary>
    /// No upgrades for the paragon
    /// </summary>
    public sealed override int MiddlePathUpgrades => 0;

    /// <summary>
    /// No upgrades for the paragon
    /// </summary>
    public sealed override int BottomPathUpgrades => 0;

    /// <summary>
    /// Tower gets modified in the Paragon upgrade
    /// </summary>
    public sealed override void ModifyBaseTowerModel(TowerModel towerModel)
    {
    }

    internal override string TowerId(int[] tiers)
    {
        return BaseTowerModel.baseId + "-Paragon";
    }

    /// <summary>
    /// Doesn't generate any of the tower on its own
    /// </summary>
    /// <returns></returns>
    public sealed override IEnumerable<int[]> TowerTiers()
    {
        return Array.Empty<int[]>();
    }

    /// <summary>
    /// Controlled by the ModParagonUpgrade
    /// </summary>
    public sealed override string Portrait => base.Portrait;
        
    /// <summary>
    /// Controlled by the ModParagonUpgrade
    /// </summary>
    public sealed override string Icon => base.Icon;
        
    /// <summary>
    /// Controlled by the ModParagonUpgrade
    /// </summary>
    public sealed override SpriteReference IconReference => base.IconReference;
        
    /// <summary>
    /// Controlled by the ModParagonUpgrade
    /// </summary>
    public sealed override SpriteReference PortraitReference => base.PortraitReference;

    /// <summary>
    /// Controlled by the ModParagonUpgrade
    /// </summary>
    public override string Description => "";

    /// <summary>
    /// Tower index doesn't apply
    /// </summary>
    /// <param name="towerSet"></param>
    /// <returns></returns>
    public sealed override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return base.GetTowerIndex(towerSet);
    }

    /// <summary>
    /// Name override
    /// </summary>
    public override string Name => BaseTowerModel.baseId;

    internal override TowerModel GetDefaultTowerModel(int[] tiers = null)
    {
        var baseTowerModel = base.GetDefaultTowerModel(tiers);
        baseTowerModel.baseId = BaseTowerModel.baseId;
        return baseTowerModel;
    }

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        AddUpgradesToRealTowers();
    }

    internal void AddUpgradesToRealTowers()
    {
        foreach (var towerModel in Game.instance.model.GetTowersWithBaseId(BaseTowerModel.baseId)
                     .Where(towerModel => towerModel.tier == 5))
        {
            towerModel.paragonUpgrade = new UpgradePathModel(paragonUpgrade.Id, $"{towerModel.baseId}-Paragon");
        }
    }

    internal override TowerModel GetBaseParagonModel()
    {
        var towerModel = GetDefaultTowerModel();
        towerModel.appliedUpgrades = new Il2CppStringArray(6);
        Game.instance.model.GetTower(towerModel.baseId, 5).appliedUpgrades
            .CopyTo(towerModel.appliedUpgrades, 0);
        return towerModel;
    }
}