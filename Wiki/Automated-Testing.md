**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as explained on this wiki.**

Mod Helper adds some features to enable easier automated testing of mod projects. This can be particularly helpful since BTD6 is an actively developed game where mods will break often, so being able to check if your mod stills works as expected after an update with only 1 click is handy.

Using Mod Helper's `ModContent` classes like `ModTower` will automatically register some tests for you, [see below for more details on that](#default-modcontent-tests). For making your own tests, see the following:

# [ModTest](/docs/BTD_Mod_Helper.Api.Testing.ModTest)

A ModTest is a coroutine-based test case that runs inside BTD6.
You can use them to sanity-check that your mod's content loads, that custom towers can be placed/upgraded, that a custom game mode starts, and so on.
Tests can be invoked manually from the in-game console (`test <ModName-TestName>`, or `test mod <ModName>` to run all tests for a mod)
or using the "BloonsTD6 (Tests)" launch profile from your IDE to run them in the background.

## Required Methods

`Test()`: The test coroutine. `yield return` Unity yield instructions, other coroutines, or any of the helper coroutines on `ModTest` to drive the game forward.
Use one of the `Assert*` helpers to fail. Any other **console error** that gets triggered during the course of the Test being run will be considered a Test failure, but not console warnings.

## Common Overrides

`IsAvailable`: Whether the test is considered for "run every test added by a mod" sweeps. Defaults to true, useful for skipping tests that should only run in certain configurations.

## Asserts

All assertion failures throw an `AssertException` that is caught by `RunTest()` and surfaced as `Exception` / `Failed`. Each takes an optional `message` shown on failure.

- `Assert(bool condition, string message = "")`
- `AssertEquals(object o1, object o2, string message = "")`
- `AssertNotNull<T>(T obj, string message = "")` — also *returns* `obj` so you can chain (`var x = AssertNotNull(GetX())`)
- `AssertThrows(Action action)` / `AssertThrows<T>(Action action)` — succeeds only if the action throws (an exception of type `T`)
- `AssertComponentExists<T>(string name)` — searches every loaded scene's root GameObjects for a `T` Component on a GameObject with the given name; returns the found component
- `Fail(string message = "")` — unconditional failure
- `Throw(Exception e)` — records and rethrows; rarely needed directly

## Helpers

`Timeout(object coroutine, float seconds)`: Wraps a managed *or* Il2Cpp coroutine (or any yield value) and asserts it completes within the given number of seconds. Wrap anything that can hang the game.

`EnsureOnMainMenuWithNoPopUps()`: Returns to the main menu from wherever the game currently is (in-game, title screen, popups open) before continuing. Almost every test should start with this.

`LoadIntoGame(InGameData inGameData = null)`: Starts a real match. With no argument it uses `DefaultMap` / `DefaultDifficulty` / `DefaultMode` (`Tutorial` / `Medium` / `Sandbox`) and reuses whatever's already set on `InGameData.Editable`. Pass an `InGameData` to specify map/mode/difficulty.

`SetupSimEnvironment(Action<SimulationTest> setupTest = null)` / `DisposeSimEnvironment()`: Spins up a `SimulationTestEnvironment` — a faster, headless simulation that doesn't go through the full game UI. Once set up, `Environment` is populated and `Bridge` automatically routes to it.

`Bridge`: The active `UnityToSimulation` — points at `Environment.simulation` if a sim environment is up, otherwise the live `UnityToSimulation.Current`.

`CreateTowerAt(bridge, position, towerModel, …)`: Static helper that places a tower while bypassing inventory / placement / cost checks by default. Returns the created `TowerToSimulation` (or `null` on failure).

`UpgradeTower(bridge, tower, path)`: Static helper that upgrades a tower one step along the given path. Returns the success flag.

`UpgradeTowerParagon(bridge, tower)`: Static helper that triggers a paragon upgrade.

`Environment`: The current `SimulationTestEnvironment` (or `null`).

## Example

This is a reformatted version of what the base test for a ModTower does: place down the tower and try upgrading it all the way, once for each path, and then try upgrading it to be a paragon if applicable.

```cs
public class ModTowerTest : ModTest
{
    private ModTower Tower => GetInstance<MyModTower>()
  
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

            towers.Add(tower);

            foreach (var upgrade in Tower.Upgrades[path].Values)
            {
                if (tower.Def.appliedUpgrades.Contains(upgrade.Id)) continue;

                Assert(UpgradeTower(Bridge, tower, path), $"Failed to upgrade tower with {upgrade.Id}");
            }
        }

        if (Tower.ParagonMode != ParagonMode.None && towers.Count == 3)
        {
            Assert(UpgradeTowerParagon(Bridge, towers.First()));
        }
    }
}
```

# Default ModContent Tests

For most kinds of `ModContent`, Mod Helper ships a generic [ModContentDefaultTest&lt;T&gt;](/docs/BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_) that auto-generates some ModTests

| Subclass                                                                        | Default behaviour                                                                                                    |
|---------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------|
| [ModTowerTest](/docs/BTD_Mod_Helper.Api.Testing.ModTowerTest)                   | Places one of your tower and walks every upgrade on every path. Paragons get paragon-upgraded too.                   |
| [ModBloonTest](/docs/BTD_Mod_Helper.Api.Testing.ModBloonTest)                   | Spawns one of your bloon and destroys it.                                                                            |
| [ModRoundSetTest](/docs/BTD_Mod_Helper.Api.Testing.ModRoundSetTest)             | Forces the round set, loads in, asserts the model picked up the override.                                            |
| [ModDisplayTest](/docs/BTD_Mod_Helper.Api.Testing.ModDisplayTest)               | One sweep across every `ModDisplay` you've registered, calling `SpawnEffect` to test the `ModifyDisplayNode` method. |
| [ModGameModeTest](/docs/BTD_Mod_Helper.Api.Testing.ModGameModeTest)             | Loads into a game using the mode.                                                                                    |
| [ModVanillaContentTest](/docs/BTD_Mod_Helper.Api.Testing.ModVanillaContentTest) | Creates each vanilla tower / spawns each vanilla bloon that any of your `ModVanillaContent` changes.                 |

If you want to suppress a default test for a particular piece of content, set `UseDefaultTest => false` on that one. To customize the per-type test, subclass the relevant `ModXTest` and override the methods you care about.

# Running tests

**From inside the game**: open the Mod Helper console and use:

- `test <ModName-TestName>` — run a single test by name
- `test mod <ModName>` — run every test added by a mod

**From outside the game**: the launch profile `BloonsTD6 (Tests)` in a mod's `Properties/launchSettings.json` is preconfigured to run all of a mod's tests with `-batchmode --modhelper.run -q test mod $(ProjectName)`.

# Tips

- `EnsureOnMainMenuWithNoPopUps()` then `LoadIntoGame()` is a common way to start a test.
- Wrap any operation that could plausibly stall in `Timeout(..., seconds)` so a buggy yield doesn't keep the test running forever.
- Prefer `SetupSimEnvironment` over `LoadIntoGame` for fast unit-style checks where you want manual control over how the Simulation processes
- Always pair `SetupSimEnvironment` with `DisposeSimEnvironment` (typically at the end of `Test()`) to avoid leaking sim state between tests.
