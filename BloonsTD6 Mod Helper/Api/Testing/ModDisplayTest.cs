using System.Collections;
using BTD_Mod_Helper.Api.Display;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using Vector3 = Il2CppAssets.Scripts.Simulation.SMath.Vector3;
namespace BTD_Mod_Helper.Api.Testing;

/// <summary>
/// Runs a set of default tests for ModDisplays
/// </summary>
public class ModDisplayTest : ModContentDefaultTest<ModDisplay>
{
    /// <inheritdoc />
    public override bool OneTestToRuleThemAll => true;

    /// <inheritdoc />
    public override IEnumerator Test()
    {
        yield return EnsureOnMainMenuWithNoPopUps();

        yield return LoadIntoGame();

        foreach (var modDisplay in AllContent)
        {
            AssertNotNull(Bridge.Simulation.SpawnEffect(new PrefabReference(modDisplay.Id), Vector3.zero, lifespan: 1));
            yield return null;
        }

        yield return new WaitForSeconds(1);
    }
}