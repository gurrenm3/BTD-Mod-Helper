using System.Collections;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.UI.Modded;
namespace BTD_Mod_Helper.Api.Testing;

/// <summary>
/// Runs a set of default tests for a ModRoundSet
/// </summary>
public class ModRoundSetTest : ModContentDefaultTest<ModRoundSet>
{
    /// <inheritdoc />
    public override IEnumerator Test()
    {
        yield return EnsureOnMainMenuWithNoPopUps();

        var prev = RoundSetChanger.RoundSetOverride;
        RoundSetChanger.RoundSetOverride = Content.Id;

        yield return LoadIntoGame();

        AssertEquals(Bridge.Model.roundSet.name, Content.Id);

        RoundSetChanger.RoundSetOverride = prev;
    }
}

/// <inheritdoc />
public abstract class ModRoundSetTest<T> : ModRoundSetTest where T : ModRoundSet
{
    /// <inheritdoc />
    protected ModRoundSetTest()
    {
        Content = GetInstance<T>();
    }
}