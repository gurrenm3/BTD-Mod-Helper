using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Commands;
using BTD_Mod_Helper.Api.Commands.Test;
using Il2CppAssets.Scripts.Simulation.Tracking;
using Il2CppAssets.Scripts.SimulationTests;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Defines a test task for a mod
/// </summary>
public abstract class ModTest : ModContent
{
    /// <summary>
    /// Exception that happened in the most recent run of this test, if any
    /// </summary>
    public Exception Exception { get; private set; }

    /// <summary>
    /// Whether the current run of this test has completed
    /// </summary>
    public bool Completed { get; private set; }

    /// <summary>
    /// Whether the most recent run of this test completed successfully
    /// </summary>
    public bool Suceeded => Completed && Exception is null;

    /// <summary>
    /// Whether the most recent run of this test failed to complete successfully
    /// </summary>
    public bool Failed => !Completed || Exception is not null;


    internal class AssertException(string message) : Exception(message);

    /// <summary>
    /// Primary test coroutine
    /// </summary>
    public abstract IEnumerator Test();

    /// <summary>
    /// Runs the test coroutine
    /// </summary>
    public IEnumerator RunTest()
    {
        Exception = null;
        Completed = false;
        var test = Test();
        while (true)
        {
            try
            {
                if (!test.MoveNext()) break;
            }
            catch (Exception e)
            {
                Exception ??= e;
                break;
            }
            yield return test.Current;
        }

        Completed = true;
        if (Exception is null)
        {
            ModHelper.Msg($"{Id} succeeded");
        }
        else
        {
            ModHelper.Error($"{Id} failed");
        }
    }

    /// <inheritdoc />
    public override void Register()
    {
        mod.AddContent(new Cmd(this));
    }

    internal class Cmd(ModTest test) : ModCommand
    {
        public override string Command => test.Name;

        public override string Help => $"Runs {test.Name}";

        public override ModCommand ParentCommand => TestModCommand.TestModCommands[mod];

        public override IEnumerator Execute(Output output)
        {
            yield return test.RunTest();
            output.success = test.Suceeded;
            output.resultText = output.success ? $"{test.Name} succeeded" : $"{test.Name} failed";
        }
    }

    #region Asserts

    /// <summary>
    /// Records and throws the given exception, causing the test to fail
    /// </summary>
    public void Throw(Exception e)
    {
        Exception = e;
        throw e;
    }

    /// <summary>
    /// Throws an <see cref="AssertException"/> if the given condition is not true
    /// </summary>
    /// <param name="condition">Condition that must be true for the test to continue</param>
    /// <param name="message">Optional message describing the failure</param>
    public void Assert(bool condition, string message = "")
    {
        if (!condition)
        {
            Throw(new AssertException(message ?? "Condition was false"));
        }
    }

    /// <summary>
    /// Throws an <see cref="AssertException"/> if the two given objects are not equal
    /// </summary>
    /// <param name="o1">First object to compare</param>
    /// <param name="o2">Second object to compare</param>
    /// <param name="message">Optional message describing the failure</param>
    public void AssertEquals(object o1, object o2, string message = "")
    {
        Assert(Equals(o1, o2), message ?? "Objects are not equal");
    }

    /// <summary>
    /// Throws an <see cref="AssertException"/> if the given action does not throw an exception
    /// </summary>
    /// <param name="action">Action that is expected to throw</param>
    /// <param name="message">Optional message describing the failure</param>
    public void AssertThrows(Action action, string message = "")
    {
        AssertThrows<Exception>(action, message);
    }

    /// <summary>
    /// Throws an <see cref="AssertException"/> if the given action does not throw an exception of type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">Type of exception that the action is expected to throw</typeparam>
    /// <param name="action">Action that is expected to throw</param>
    /// <param name="message">Optional message describing the failure</param>
    public void AssertThrows<T>(Action action, string message = "")
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
            if (e.GetType().IsAssignableTo(typeof(T))) return;
        }

        throw new AssertException(message ?? $"Expected {typeof(T)} was not thrown");
    }

    /// <summary>
    /// Unconditionally fails the test with the given message
    /// </summary>
    /// <param name="message">Optional message describing the failure</param>
    public void Fail(string message = "")
    {
        Assert(false, message ?? "Test failed");
    }

    /// <summary>
    /// Throws an <see cref="AssertException"/> if no <see cref="Component"/> of type <typeparamref name="T"/>
    /// with the given name can be found within any currently loaded scene
    /// </summary>
    /// <typeparam name="T">Component type to search for</typeparam>
    /// <param name="name">Name of the GameObject the component should be attached to</param>
    /// <param name="message">Optional message describing the failure</param>
    public T AssertComponentExists<T>(string name, string message = "") where T : Component
    {
        for (var i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            foreach (var root in scene.GetRootGameObjects())
            {
                if (root.GetComponentInChildrenByName<T>(name).Exists()?.Is(out T t) == true)
                {
                    return t;
                }
            }
        }

        Fail(message ?? $"{typeof(T).Name} {name} does not exist");
        return null;
    }

    #endregion

    #region Helpers

    /// <summary>
    /// Wraps a coroutine so that the test will fail if it does not complete within the given time
    /// </summary>
    /// <param name="coroutine">Coroutine (managed or Il2Cpp) or yield value to run with a timeout</param>
    /// <param name="seconds">Maximum number of seconds the coroutine is allowed to run for</param>
    public IEnumerator Timeout(object coroutine, float seconds)
    {
        var start = DateTimeOffset.Now;
        yield return Timeout(coroutine, seconds, start);
    }

    private IEnumerator Timeout(object current, float seconds, DateTimeOffset start)
    {
        switch (current)
        {
            case IEnumerator coroutine:
            {
                while (true)
                {
                    try
                    {
                        if (!coroutine.MoveNext())
                            break;
                    }
                    catch (Exception e)
                    {
                        Throw(e);
                        break;
                    }

                    yield return Timeout(coroutine.Current, seconds, start);
                    Assert(DateTimeOffset.Now < start.AddSeconds(seconds), "Timeout expired");
                }
                break;
            }
            case Il2CppSystem.Collections.IEnumerator il2cppCoroutine:
            {
                while (true)
                {
                    try
                    {
                        if (!il2cppCoroutine.MoveNext())
                            break;
                    }
                    catch (Exception e)
                    {
                        Throw(e);
                        break;
                    }

                    yield return Timeout(il2cppCoroutine.Current, seconds, start);
                    Assert(DateTimeOffset.Now < start.AddSeconds(seconds), "Timeout expired");
                }
                break;
            }
            default:
                yield return current;
                Assert(DateTimeOffset.Now < start.AddSeconds(seconds), "Timeout expired");
                break;
        }
    }

    /// <summary>
    /// Ensures that the game is on the main menu screen with no popups before continuing
    /// </summary>
    public IEnumerator EnsureOnMainMenuWithNoPopUps()
    {
        if (InGame.instance != null)
        {
            InGame.instance.ReturnToMainMenu().StartCoroutine();
            while (InGame.instance != null)
            {
                yield return null;
            }
        }

        if (MenuManager.instance != null && !string.IsNullOrEmpty(MenuManager.instance.CurrentScene))
        {
            MenuManager.instance.GoToMainMenu();
            while (!MenuManager.instance.GetCurrentMenu().Is<MainMenu>())
            {
                yield return null;
            }
        }
        else
        {
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                foreach (var root in scene.GetRootGameObjects())
                {
                    var titleScreen = root.GetComponentInChildren<TitleScreen>();

                    if (titleScreen != null)
                    {
                        titleScreen.playButtonClicked = true;
                        while (true)
                        {
                            yield return null;

                            if (titleScreen == null &&
                                MenuManager.instance != null &&
                                MenuManager.instance.GetCurrentMenu().Is<MainMenu>())
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        if (PopupScreen.instance != null)
        {
            PopupScreen.instance.HideAllPopups();
        }

        yield return null;
    }

    /// <summary>
    /// Default map to use
    /// </summary>
    public static readonly string DefaultMap = "Tutorial";

    /// <summary>
    /// Default difficulty to use
    /// </summary>
    public static readonly string DefaultDifficulty = "Medium";

    /// <summary>
    /// Default mode to use
    /// </summary>
    public static readonly string DefaultMode = "Sandbox";

    /// <summary>
    /// Loads the game into a real match of BTD6
    /// </summary>
    /// <param name="inGameData">specifics about game type</param>
    public IEnumerator LoadIntoGame(InGameData inGameData = null)
    {
        if (inGameData != null) InGameData._editableInstance = inGameData;

        if (string.IsNullOrEmpty(InGameData.Editable.selectedMap))
            InGameData.Editable.selectedMap = DefaultMap;
        if (string.IsNullOrEmpty(InGameData.Editable.selectedDifficulty))
            InGameData.Editable.selectedDifficulty = DefaultDifficulty;
        if (string.IsNullOrEmpty(InGameData.Editable.selectedMode))
            InGameData.Editable.selectedMode = DefaultMode;

        return Timeout(Il2CppAssets.Scripts.Unity.UI_New.UI.instance.LoadGameEnumerator(), 10);
    }

    /// <summary>
    /// Current SimulationTestEnvironment. Use <see cref="SetupSimEnvironment"/> to set it up, and <see cref="DisposeSimEnvironment"/> to dispose
    /// </summary>
    public SimulationTestEnvironment Environment { get; private set; }

    /// <summary>
    /// Sets up a <see cref="SimulationTestEnvironment"/> to use for tests, storing it at <see cref="Environment"/>
    /// </summary>
    public IEnumerator SetupSimEnvironment(Action<SimulationTest> setupTest = null)
    {
        if (Environment != null) DisposeSimEnvironment();

        var test = ScriptableObject.CreateInstance<SimulationTest>();

        test.map = DefaultMap;
        test.mode = DefaultMode;
        test.difficulty = DefaultDifficulty;

        setupTest?.Invoke(test);

        var loadSim = SimulationTestUtilities.LoadEnvironmentForTest(test);

        while (!loadSim.IsCompleted)
        {
            yield return null;
        }

        if (!loadSim.IsCompletedSuccessfully)
        {
            yield break;
        }

        Environment = loadSim.Result;

        var simEntity = Environment.simulation.Simulation.entity;
        simEntity.RemoveBehavior(simEntity.GetBehavior<AnalyticsTrackerSim>());
        simEntity.RemoveBehavior(simEntity.GetBehavior<AnalyticsTrackerSimManager>());
    }

    /// <summary>
    /// Tears down the current <see cref="Environment"/>
    /// </summary>
    public void DisposeSimEnvironment()
    {
        Environment.Dispose();
        Environment = null;
    }

    #endregion
}