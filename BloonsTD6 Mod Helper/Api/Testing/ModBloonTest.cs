using System.Collections;
using BTD_Mod_Helper.Api.Bloons;
namespace BTD_Mod_Helper.Api.Testing;

/// <summary>
/// Runs a set of default tests for a ModBloon
/// </summary>
public class ModBloonTest : ModContentDefaultTest<ModBloon>
{
    private ModBloon Bloon => Content;

    /// <inheritdoc />
    public override IEnumerator Test()
    {
        yield return EnsureOnMainMenuWithNoPopUps();

        yield return LoadIntoGame();

        var bloonModel = AssertNotNull(Bridge.Model.GetBloon(Bloon.Id));

        var bloon = AssertNotNull(Bridge.Simulation.Map.spawner.Emit(bloonModel, Bridge.GetCurrentRound(), 0));

        bloon.Destroy();
    }
}

/// <inheritdoc />
public abstract class ModBloonTest<T> : ModBloonTest where T : ModBloon
{
    /// <inheritdoc />
    protected ModBloonTest()
    {
        Content = GetInstance<T>();
    }
}