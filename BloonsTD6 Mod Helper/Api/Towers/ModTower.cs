using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
namespace BTD_Mod_Helper.Api.Towers;

public abstract partial class ModTower
{
    /// <summary>
    /// Defines whether / how this ModTower has a Paragon
    /// </summary>
    public virtual ParagonMode ParagonMode => ParagonMode.None;

    internal TowerModel BaseTowerModel => Game.instance.model.GetTowerFromId(BaseTower);
    internal UpgradeModel dummyUpgrade;
    internal ModParagonUpgrade paragonUpgrade;
    internal virtual bool ShouldCreateParagon =>
        paragonUpgrade != null &&
        TopPathUpgrades == 5 &&
        MiddlePathUpgrades == 5 &&
        BottomPathUpgrades == 5 &&
        ParagonMode != ParagonMode.None;

    private ModUpgrade[,] upgrades;
    private int[] tierMaxes;

    internal ModUpgrade[,] Upgrades => upgrades ??= new ModUpgrade[UpgradePaths, TierMaxes.Max()];
    internal int[] TierMaxes => tierMaxes ??= new[] {TopPathUpgrades, MiddlePathUpgrades, BottomPathUpgrades};

    /// <summary>
    /// Constructor for ModTower, used implicitly by ModContent.Create
    /// </summary>
    /// <exclude/>
    protected ModTower()
    {
    }

    /// <inheritdoc />
    public override void Register()
    {
        towerModels = ModTowerHelper.AddTower(this);

        foreach (var towerModel in towerModels)
        {
            ModTowerHelper.FinalizeTowerModel(this, towerModel);
        }

        if (!DontAddToShop)
        {
            var index = GetTowerIndex(Game.instance.model.towerSet.ToList());
            if (index >= 0)
            {
                var shopTowerDetailsModel = new ShopTowerDetailsModel(Id, index, 5, 5, 5, -1, 0);
                Game.instance.model.AddTowerDetails(shopTowerDetailsModel, index);
            }
        }

        ModTowerSet?.towers.Add(this);
    }

    /// <summary>
    /// Gets the base 0-0-0 TowerModel for this Tower
    /// <br/>
    /// Starts with the <see cref="BaseTower"/>, modifies its default properties as needed,
    /// then calls <see cref="ModifyBaseTowerModel"/> on it.
    /// </summary>
    /// <returns>The 0-0-0 TowerModel for this Tower</returns>
    internal virtual TowerModel GetDefaultTowerModel()
    {
        var towerModel = !string.IsNullOrEmpty(BaseTower)
            ? BaseTowerModel.MakeCopy(Id)
            : new TowerModel(Id, Id, TowerSet, CreatePrefabReference(""));
        towerModel.name = Id;

        towerModel.appliedUpgrades = new Il2CppStringArray(0);
        towerModel.upgrades = new Il2CppReferenceArray<UpgradePathModel>(0);
        towerModel.towerSet = TowerSet;
        towerModel.cost = Cost;
        towerModel.dontDisplayUpgrades = false;
        towerModel.powerName = null;

        towerModel.tier = 0;
        towerModel.tiers = new[] {0, 0, 0};

        towerModel.mods = DefaultMods
            .Select(s => new ApplyModModel($"{Id}Upgrades", s, ""))
            .ToArray();

        towerModel.GetDescendants<Model>().ForEach(model =>
        {
            model.name = model.name.Replace(BaseTower, Name);
            model._name = model._name.Replace(BaseTower, Name);
        });

        towerModel.instaIcon = IconReference;
        towerModel.portrait = PortraitReference;
        towerModel.icon = IconReference;

        return towerModel;
    }

    /// <summary>
    /// When adding this tower to the shop, gets the index at which to add the tower relative to the existing ones.
    /// <br/>
    /// By default, the tower will be put at the end of the TowerSet category that it's in.
    /// </summary>
    /// <param name="towerSet"></param>
    /// <returns></returns>
    public virtual int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        if (towerSet.LastOrDefault(details => details.GetTower().towerSet == TowerSet) is { } tower)
        {
            return tower.towerIndex + 1;
        }

        return ModTowerSet?.GetTowerStartIndex(towerSet) ?? towerSet.Count;
    }

    internal virtual TowerModel GetBaseParagonModel()
    {
        TowerModel towerModel;
        switch (ParagonMode)
        {
            case ParagonMode.Base000:
                towerModel = ModTowerHelper.CreateTowerModel(this, new[] {0, 0, 0});
                break;
            case ParagonMode.Base555:
                towerModel = ModTowerHelper.CreateTowerModel(this, new[] {5, 5, 5});
                break;
            case ParagonMode.None:
            default:
                return null;
        }

        towerModel.appliedUpgrades = new Il2CppStringArray(6);
        for (var i = 0; i < 5; i++)
        {
            towerModel.appliedUpgrades[i] = Upgrades[0, i].Id;
        }

        return towerModel;
    }


    /// <summary>
    /// Creates an UpgradePathModel for a particular upgrade and new tiers
    /// </summary>
    /// <param name="modUpgrade">The upgrade</param>
    /// <param name="newTiers">The new desired tiers of the tower</param>
    /// <returns></returns>
    public virtual UpgradePathModel GetUpgradePathModel(ModUpgrade modUpgrade, int[] newTiers) =>
        new(modUpgrade.Id, TowerId(newTiers));


    /// <summary>
    /// Allows you to override how many possible Upgrade pips it should show as being possible for a tower to get 
    /// </summary>
    /// <param name="tower">The TowerToSimulation</param>
    /// <param name="path">What path this is for</param>
    /// <param name="defaultMax">The default maximum</param>
    /// <returns>The new maximum amount of upgrade pips, or null for no change</returns>
    public virtual int? MaxUpgradePips(TowerToSimulation tower, int path, int defaultMax) => null;

    /// <summary>
    /// Allows you to override whether an UpgradePath should be closed or not for a tower
    /// </summary>
    /// <param name="tower">The TowerToSimulation</param>
    /// <param name="path">What path this is for</param>
    /// <param name="defaultClosed">Whether it'd be naturally closed or not</param>
    /// <returns>Whether the upgrade path should be closed, or null for no change</returns>
    public virtual bool? IsUpgradePathClosed(TowerToSimulation tower, int path, bool defaultClosed) => null;
}

/// <summary>
/// A convenient generic class for specifying the ModTowerSet that a ModTower uses
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ModTower<T> : ModTower where T : ModTowerSet
{
    internal override ModTowerSet ModTowerSet => GetInstance<T>();

    /// <summary>
    /// The custom tower set that this ModTower uses
    /// </summary>
    public sealed override TowerSet TowerSet => TowerSet.None;
}

/// <summary>
/// Defines the Paragon behavior for a ModTower
/// </summary>
public enum ParagonMode
{
    /// <summary>
    /// Don't generate a Paragon
    /// </summary>
    None,

    /// <summary>
    /// Generate a Paragon by applying the ModParagonUpgrade to the 000 version of the tower
    /// </summary>
    Base000,

    /// <summary>
    /// Generate a Paragon by applying the ModParagonUpgrade to the 555 version of the tower
    /// </summary>
    Base555,
}
