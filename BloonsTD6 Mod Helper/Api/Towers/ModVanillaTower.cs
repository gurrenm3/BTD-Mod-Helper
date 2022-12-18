using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;

namespace BTD_Mod_Helper.Api.Towers;

public abstract partial class ModVanillaTower
{
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
    public override IEnumerable<TowerModel> GetAffected(GameModel gameModel)
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
    // TODO fix for enum
}