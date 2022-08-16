using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;

using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api.Towers;

public abstract partial class ModTower {
    /// <summary>
    /// Defines whether / how this ModTower has a Paragon
    /// </summary>
    public virtual ParagonMode ParagonMode => ParagonMode.None;

    internal TowerModel BaseTowerModel => Game.instance.model.GetTowerFromId(BaseTower);
    internal readonly ModUpgrade[,] upgrades;
    internal UpgradeModel dummyUpgrade;
    internal ModParagonUpgrade paragonUpgrade;
    internal virtual bool ShouldCreateParagon =>
        paragonUpgrade != null &&
        TopPathUpgrades == 5 &&
        MiddlePathUpgrades == 5 &&
        BottomPathUpgrades == 5 &&
        ParagonMode != ParagonMode.None;

    /// <summary>
    /// Constructor for ModTower, used implicitly by ModContent.Create
    /// </summary>
    /// <exclude/>
    protected ModTower() {
        Init(out upgrades, out tierMaxes);
    }

    internal void Init(out ModUpgrade[,] u, out int[] t) {
        t = new[] { TopPathUpgrades, MiddlePathUpgrades, BottomPathUpgrades };
        u = new ModUpgrade[UpgradePaths, t.Max()];
    }


    /// <inheritdoc />
    public override void Register() {
        towerModels = ModTowerHelper.AddTower(this);

        foreach (var towerModel in towerModels) {
            ModTowerHelper.FinalizeTowerModel(this, towerModel);
        }

        if (!DontAddToShop) {
            var index = GetTowerIndex(Game.instance.model.towerSet.ToList());
            if (index >= 0) {
                var shopTowerDetailsModel = new ShopTowerDetailsModel(Id, index, 5, 5, 5, -1, 0, null);
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
    internal virtual TowerModel GetDefaultTowerModel() {
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
        towerModel.tiers = new[] { 0, 0, 0 };

        towerModel.mods = DefaultMods
            .Select(s => new ApplyModModel($"{Id}Upgrades", s, ""))
            .ToArray();

        towerModel.GetDescendants<Model>().ForEach(model => {
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
    public virtual int GetTowerIndex(List<TowerDetailsModel> towerSet) {
        return towerSet.LastOrDefault(details => details.GetTower().towerSet == TowerSet) is { } tower
            ? tower.towerIndex + 1
            : ModTowerSet?.GetTowerStartIndex(towerSet) ?? towerSet.Count;
    }

    internal virtual TowerModel GetBaseParagonModel() {
        TowerModel towerModel;
        switch (ParagonMode) {
            case ParagonMode.Base000:
                towerModel = ModTowerHelper.CreateTowerModel(this, new[] { 0, 0, 0 });
                break;
            case ParagonMode.Base555:
                towerModel = ModTowerHelper.CreateTowerModel(this, new[] { 5, 5, 5 });
                break;
            case ParagonMode.None:
            default:
                return null;
        }

        towerModel.appliedUpgrades = new Il2CppStringArray(6);
        for (var i = 0; i < 5; i++) {
            towerModel.appliedUpgrades[i] = upgrades[0, i].Id;
        }

        return towerModel;
    }
}

/// <summary>
/// A convenient generic class for specifying the ModTowerSet that a ModTower uses
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ModTower<T> : ModTower where T : ModTowerSet {
    internal override ModTowerSet ModTowerSet => GetInstance<T>();

    /// <summary>
    /// The custom tower set that this ModTower uses
    /// </summary>
    public sealed override string TowerSet => TowerSet<T>();
}

/// <summary>
/// Defines the Paragon behavior for a ModTower
/// </summary>
public enum ParagonMode {
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