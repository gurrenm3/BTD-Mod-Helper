using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// ModContent class for modifying all TowerModels for a given Tower
/// </summary>
public abstract class ModVanillaTower : ModVanillaContent<TowerModel>
{
    /// <summary>
    /// The base id of the Tower that this should modify all TowerModels of
    /// <br />
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
    public virtual TowerSet TowerSet => TowerSet.None;

    /// <summary>
    /// Changes the base cost
    /// </summary>
    public virtual int Cost => -1;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();

        var affectedTowers = GetAffected(Game.instance.model).ToList();
        if (TowerSet != TowerSet.None)
        {
            foreach (var affectedTower in affectedTowers)
            {
                affectedTower.towerSet = TowerSet;
            }

            var towerSet = Enumerable.ToList(Game.instance.model.towerSet);
            var towerDetailsModel = towerSet.First(model => model.towerId == TowerId);
            towerSet.Remove(towerDetailsModel);
            Game.instance.model.towerSet = towerSet.ToArray();

            var towers = TowerType.towers.ToList();
            towers.RemoveAll(s => s == TowerId);
            TowerType.towers = towers.ToArray();

            Game.instance.model.AddTowerDetails(towerDetailsModel, TowerSet);
        }

        if (Cost >= 0)
        {
            foreach (var affectedTower in affectedTowers)
            {
                affectedTower.cost = Cost;
            }
        }

        var localizationMgr = Game.instance.GetLocalizationManager();
        if (!string.IsNullOrEmpty(DisplayName))
        {
            localizationMgr.textTable[TowerId] = DisplayName;
            localizationMgr.textTable[TowerId + "s"] = DisplayNamePlural ?? DisplayName + "s";
        }

        if (!string.IsNullOrEmpty(Description))
        {
            localizationMgr.textTable[TowerId + " Description"] = Description;
        }
    }

    /// <inheritdoc />
    public override IEnumerable<TowerModel> GetAffected(GameModel gameModel) => gameModel.GetTowersWithBaseId(TowerId);
}

/// <summary>
/// Helper class for changing a vanilla tower to be part of a modded tower set
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ModVanillaTower<T> : ModVanillaTower where T : ModTowerSet
{
    // TODO fix for enum
}