using System.Collections;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Api.Testing;

/// <summary>
/// Runs a set of default tests for a ModGameMode
/// </summary>
public class ModGameModeTest : ModContentDefaultTest<ModGameMode>
{
    /// <inheritdoc />
    public override IEnumerator Test()
    {
        yield return EnsureOnMainMenuWithNoPopUps();

        yield return LoadIntoGame(new InGameData
        {
            selectedMode = Content.Id
        });
    }
}

/// <inheritdoc />
public abstract class ModGameModeTest<T> : ModGameModeTest where T : ModGameMode
{
    /// <inheritdoc />
    protected ModGameModeTest()
    {
        Content = GetInstance<T>();
    }
}