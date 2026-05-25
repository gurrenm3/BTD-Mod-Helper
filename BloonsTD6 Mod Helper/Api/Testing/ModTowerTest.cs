using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Testing;

/// <summary>
/// Runs a set of default tests for a ModTower
/// </summary>
public class ModTowerTest : ModContentDefaultTest<ModTower>
{
    private ModTower Tower => Content;

    /// <inheritdoc />
    public override IEnumerator Test()
    {
        yield return EnsureOnMainMenuWithNoPopUps();

        yield return LoadIntoGame();

        var towers = new List<TowerToSimulation>();

        var towerModel = AssertNotNull(Bridge.Model.GetTowerWithName(Tower.Id), $"Failed to find TowerModel {Tower.Id}");

        for (var path = 0; path < 3; path++)
        {
            var tower = AssertNotNull(CreateTowerAt(Bridge, new Vector2(0, 0), towerModel, costOverride: 0),
                $"Failed to create {Tower.Id}");

            yield return PostTowerCreated(tower);

            towers.Add(tower);

            foreach (var upgrade in Tower.Upgrades[path].Values)
            {
                if (tower.Def.appliedUpgrades.Contains(upgrade.Id)) continue;

                Assert(UpgradeTower(Bridge, tower, path), $"Failed to upgrade tower with {upgrade.Id}");

                yield return PostTowerUpgraded(tower, upgrade);
            }
        }

        if (Tower.ParagonMode != ParagonMode.None && towers.Count == 3)
        {
            Assert(UpgradeTowerParagon(Bridge, towers.First()));
        }
    }

    /// <summary>
    /// Hook for any additional testing after creating
    /// </summary>
    public virtual IEnumerator PostTowerCreated(TowerToSimulation tower)
    {
        yield break;
    }

    /// <summary>
    /// Hook for any additional testing after upgrading
    /// </summary>
    public virtual IEnumerator PostTowerUpgraded(TowerToSimulation tower, ModUpgrade modUpgrade)
    {
        yield break;
    }
}

/// <inheritdoc />
public abstract class ModTowerTest<T> : ModTowerTest where T : ModTower
{
    /// <inheritdoc />
    protected ModTowerTest()
    {
        Content = GetInstance<T>();
    }
}