using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using UnityEngine;

namespace BTD_Mod_Helper.Api.Testing;

/// <summary>
/// Tests the ModVanillaContent within a mod
/// </summary>
public class ModVanillaContentTest : ModContentDefaultTest<ModVanillaContent>
{
    /// <inheritdoc />
    public override bool OneTestToRuleThemAll => true;

    /// <inheritdoc />
    public override IEnumerator Test()
    {
        yield return EnsureOnMainMenuWithNoPopUps();

        yield return LoadIntoGame();

        var towerIdsToTest = new HashSet<string>();
        var bloonIdsToTest = new HashSet<string>();

        foreach (var vanillaContent in AllContent)
        {
            if (vanillaContent.AffectBaseGameModel) continue;

            var baseModels = vanillaContent.GetAffectedModels(Game.instance.model).ToArray();

            foreach (var towerModel in baseModels.OfType<TowerModel>())
            {
                towerIdsToTest.Add(towerModel.name);
            }
            foreach (var bloonModel in baseModels.OfType<BloonModel>())
            {
                bloonIdsToTest.Add(bloonModel.name);
            }
        }

        foreach (var towerId in towerIdsToTest)
        {
            var towerModel = AssertNotNull(Bridge.Model.GetTowerWithName(towerId));

            var tower = AssertNotNull(CreateTowerAt(Bridge, new Vector2(0, 0), towerModel, costOverride: 0));

            yield return null;

            tower.Destroy();

            yield return null;
        }

        foreach (var bloonId in bloonIdsToTest)
        {
            var bloonModel = AssertNotNull(Bridge.Model.GetBloon(bloonId));

            var bloon = AssertNotNull(Bridge.Simulation.Map.spawner.Emit(bloonModel, Bridge.GetCurrentRound(), 0));

            yield return null;

            bloon.Destroy();

            yield return null;
        }
    }
}