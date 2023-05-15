using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// Helper class for making a subtower
/// </summary>
public abstract class ModSubTower : ModTower
{
    /// <inheritdoc />
    public override int Cost => 0;

    /// <inheritdoc />
    public sealed override int TopPathUpgrades => 0;
    /// <inheritdoc />
    public sealed override int MiddlePathUpgrades => 0;
    /// <inheritdoc />
    public sealed override int BottomPathUpgrades => 0;

    /// <inheritdoc />
    public sealed override bool DontAddToShop => true;

    /// <inheritdoc />
    protected override int Order => -1;

    internal sealed override TowerModel GetDefaultTowerModel(int[] tiers = null)
    {
        var towerModel = base.GetDefaultTowerModel(tiers);
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireOnParentDestroyedModel("TowerExpireOnParentDestroyedModel_"));
        towerModel.AddBehavior(new CreditPopsToParentTowerModel("CreditPopsToParentTowerModel_"));
        return towerModel;
    }
}

/// <summary>
/// Helper class for making a subtower for a specific other ModTower
/// </summary>
public abstract class ModSubTower<T> : ModSubTower where T : ModTower
{
    /// <inheritdoc />
    protected override int Order => GetOrder() - 1;
    
    /// <inheritdoc />
    public override TowerSet TowerSet => GetInstance<T>().TowerSet;
}