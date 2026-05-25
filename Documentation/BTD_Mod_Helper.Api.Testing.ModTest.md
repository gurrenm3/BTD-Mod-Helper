#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Testing](README.md#BTD_Mod_Helper.Api.Testing 'BTD_Mod_Helper.Api.Testing')

## ModTest Class

Defines a test task for a mod

```csharp
public abstract class ModTest : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModTest

Derived  
&#8627; [ModContentDefaultTest&lt;T&gt;](BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.md 'BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<T>')
### Fields

<a name='BTD_Mod_Helper.Api.Testing.ModTest.DefaultDifficulty'></a>

## ModTest.DefaultDifficulty Field

Default difficulty to use

```csharp
public static readonly string DefaultDifficulty;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.DefaultMap'></a>

## ModTest.DefaultMap Field

Default map to use

```csharp
public static readonly string DefaultMap;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.DefaultMode'></a>

## ModTest.DefaultMode Field

Default mode to use

```csharp
public static readonly string DefaultMode;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Bridge'></a>

## ModTest.Bridge Property

The current UnityToSimulation, either from the Simulation Test [Environment](BTD_Mod_Helper.Api.Testing.ModTest.md#BTD_Mod_Helper.Api.Testing.ModTest.Environment 'BTD_Mod_Helper.Api.Testing.ModTest.Environment') or the current game

```csharp
public UnityToSimulation Bridge { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Completed'></a>

## ModTest.Completed Property

Whether the current run of this test has completed

```csharp
public bool Completed { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Environment'></a>

## ModTest.Environment Property

Current SimulationTestEnvironment. Use [SetupSimEnvironment(Action&lt;SimulationTest&gt;)](BTD_Mod_Helper.Api.Testing.ModTest.md#BTD_Mod_Helper.Api.Testing.ModTest.SetupSimEnvironment(System.Action_SimulationTest_) 'BTD_Mod_Helper.Api.Testing.ModTest.SetupSimEnvironment(System.Action<SimulationTest>)') to set it up, and [DisposeSimEnvironment()](BTD_Mod_Helper.Api.Testing.ModTest.md#BTD_Mod_Helper.Api.Testing.ModTest.DisposeSimEnvironment() 'BTD_Mod_Helper.Api.Testing.ModTest.DisposeSimEnvironment()') to dispose

```csharp
public SimulationTestEnvironment Environment { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.SimulationTests.SimulationTestEnvironment](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.SimulationTests.SimulationTestEnvironment 'Il2CppAssets.Scripts.SimulationTests.SimulationTestEnvironment')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Exception'></a>

## ModTest.Exception Property

Exception that happened in the most recent run of this test, if any

```csharp
public System.Exception Exception { get; set; }
```

#### Property Value
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Failed'></a>

## ModTest.Failed Property

Whether the most recent run of this test failed to complete successfully

```csharp
public bool Failed { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.IsAvailable'></a>

## ModTest.IsAvailable Property

Whether this test is available for purposes like running every test added by a mod

```csharp
public virtual bool IsAvailable { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Suceeded'></a>

## ModTest.Suceeded Property

Whether the most recent run of this test completed successfully

```csharp
public bool Suceeded { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Assert(bool,string)'></a>

## ModTest.Assert(bool, string) Method

Throws an [BTD_Mod_Helper.Api.Testing.ModTest.AssertException](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Testing.ModTest.AssertException 'BTD_Mod_Helper.Api.Testing.ModTest.AssertException') if the given condition is not true

```csharp
public void Assert(bool condition, string message="");
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Assert(bool,string).condition'></a>

`condition` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Condition that must be true for the test to continue

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Assert(bool,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertComponentExists_T_(string,string)'></a>

## ModTest.AssertComponentExists<T>(string, string) Method

Throws an [BTD_Mod_Helper.Api.Testing.ModTest.AssertException](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Testing.ModTest.AssertException 'BTD_Mod_Helper.Api.Testing.ModTest.AssertException') if no [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') of type [T](BTD_Mod_Helper.Api.Testing.ModTest.md#BTD_Mod_Helper.Api.Testing.ModTest.AssertComponentExists_T_(string,string).T 'BTD_Mod_Helper.Api.Testing.ModTest.AssertComponentExists<T>(string, string).T')  
with the given name can be found within any currently loaded scene

```csharp
public T AssertComponentExists<T>(string name, string message="")
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertComponentExists_T_(string,string).T'></a>

`T`

Component type to search for
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertComponentExists_T_(string,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of the GameObject the component should be attached to

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertComponentExists_T_(string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

#### Returns
[T](BTD_Mod_Helper.Api.Testing.ModTest.md#BTD_Mod_Helper.Api.Testing.ModTest.AssertComponentExists_T_(string,string).T 'BTD_Mod_Helper.Api.Testing.ModTest.AssertComponentExists<T>(string, string).T')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertEquals(object,object,string)'></a>

## ModTest.AssertEquals(object, object, string) Method

Throws an [BTD_Mod_Helper.Api.Testing.ModTest.AssertException](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Testing.ModTest.AssertException 'BTD_Mod_Helper.Api.Testing.ModTest.AssertException') if the two given objects are not equal

```csharp
public void AssertEquals(object o1, object o2, string message="");
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertEquals(object,object,string).o1'></a>

`o1` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

First object to compare

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertEquals(object,object,string).o2'></a>

`o2` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Second object to compare

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertEquals(object,object,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertNotNull_T_(T,string)'></a>

## ModTest.AssertNotNull<T>(T, string) Method

Throws an [BTD_Mod_Helper.Api.Testing.ModTest.AssertException](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Testing.ModTest.AssertException 'BTD_Mod_Helper.Api.Testing.ModTest.AssertException') if the given object is null

```csharp
public T AssertNotNull<T>(T obj, string message="");
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertNotNull_T_(T,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertNotNull_T_(T,string).obj'></a>

`obj` [T](BTD_Mod_Helper.Api.Testing.ModTest.md#BTD_Mod_Helper.Api.Testing.ModTest.AssertNotNull_T_(T,string).T 'BTD_Mod_Helper.Api.Testing.ModTest.AssertNotNull<T>(T, string).T')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertNotNull_T_(T,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

#### Returns
[T](BTD_Mod_Helper.Api.Testing.ModTest.md#BTD_Mod_Helper.Api.Testing.ModTest.AssertNotNull_T_(T,string).T 'BTD_Mod_Helper.Api.Testing.ModTest.AssertNotNull<T>(T, string).T')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertThrows(System.Action,string)'></a>

## ModTest.AssertThrows(Action, string) Method

Throws an [BTD_Mod_Helper.Api.Testing.ModTest.AssertException](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Testing.ModTest.AssertException 'BTD_Mod_Helper.Api.Testing.ModTest.AssertException') if the given action does not throw an exception

```csharp
public void AssertThrows(System.Action action, string message="");
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertThrows(System.Action,string).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

Action that is expected to throw

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertThrows(System.Action,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertThrows_T_(System.Action,string)'></a>

## ModTest.AssertThrows<T>(Action, string) Method

Throws an [BTD_Mod_Helper.Api.Testing.ModTest.AssertException](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Testing.ModTest.AssertException 'BTD_Mod_Helper.Api.Testing.ModTest.AssertException') if the given action does not throw an exception of type [T](BTD_Mod_Helper.Api.Testing.ModTest.md#BTD_Mod_Helper.Api.Testing.ModTest.AssertThrows_T_(System.Action,string).T 'BTD_Mod_Helper.Api.Testing.ModTest.AssertThrows<T>(System.Action, string).T')

```csharp
public void AssertThrows<T>(System.Action action, string message="");
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertThrows_T_(System.Action,string).T'></a>

`T`

Type of exception that the action is expected to throw
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertThrows_T_(System.Action,string).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

Action that is expected to throw

<a name='BTD_Mod_Helper.Api.Testing.ModTest.AssertThrows_T_(System.Action,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

<a name='BTD_Mod_Helper.Api.Testing.ModTest.CreateTowerAt(UnityToSimulation,Vector2,TowerModel,bool,bool,int)'></a>

## ModTest.CreateTowerAt(UnityToSimulation, Vector2, TowerModel, bool, bool, int) Method

Helper to create a tower model at a specific location. Ignores placement/inventory checks and cost

```csharp
public static TowerToSimulation CreateTowerAt(UnityToSimulation bridge, Vector2 at, TowerModel towerModel, bool ignoreInventoryChecks=true, bool ignorePlacementChecks=true, int costOverride=-1);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.CreateTowerAt(UnityToSimulation,Vector2,TowerModel,bool,bool,int).bridge'></a>

`bridge` [Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')

UnityToSimulation

<a name='BTD_Mod_Helper.Api.Testing.ModTest.CreateTowerAt(UnityToSimulation,Vector2,TowerModel,bool,bool,int).at'></a>

`at` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

tower coordinates

<a name='BTD_Mod_Helper.Api.Testing.ModTest.CreateTowerAt(UnityToSimulation,Vector2,TowerModel,bool,bool,int).towerModel'></a>

`towerModel` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

TowerModel to use

<a name='BTD_Mod_Helper.Api.Testing.ModTest.CreateTowerAt(UnityToSimulation,Vector2,TowerModel,bool,bool,int).ignoreInventoryChecks'></a>

`ignoreInventoryChecks` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

place regardless of TowerInventory restrictions

<a name='BTD_Mod_Helper.Api.Testing.ModTest.CreateTowerAt(UnityToSimulation,Vector2,TowerModel,bool,bool,int).ignorePlacementChecks'></a>

`ignorePlacementChecks` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

place regardless of placement restrictions

<a name='BTD_Mod_Helper.Api.Testing.ModTest.CreateTowerAt(UnityToSimulation,Vector2,TowerModel,bool,bool,int).costOverride'></a>

`costOverride` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

override purchase cost, -1 to not override (default

#### Returns
[Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')  
Created TowerToSimulation

<a name='BTD_Mod_Helper.Api.Testing.ModTest.DisposeSimEnvironment()'></a>

## ModTest.DisposeSimEnvironment() Method

Tears down the current [Environment](BTD_Mod_Helper.Api.Testing.ModTest.md#BTD_Mod_Helper.Api.Testing.ModTest.Environment 'BTD_Mod_Helper.Api.Testing.ModTest.Environment')

```csharp
public void DisposeSimEnvironment();
```

<a name='BTD_Mod_Helper.Api.Testing.ModTest.EnsureOnMainMenuWithNoPopUps()'></a>

## ModTest.EnsureOnMainMenuWithNoPopUps() Method

Ensures that the game is on the main menu screen with no popups before continuing

```csharp
public System.Collections.IEnumerator EnsureOnMainMenuWithNoPopUps();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Fail(string)'></a>

## ModTest.Fail(string) Method

Unconditionally fails the test with the given message

```csharp
public void Fail(string message="");
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Fail(string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

<a name='BTD_Mod_Helper.Api.Testing.ModTest.LoadIntoGame(InGameData)'></a>

## ModTest.LoadIntoGame(InGameData) Method

Loads the game into a real match of BTD6

```csharp
public System.Collections.IEnumerator LoadIntoGame(InGameData inGameData=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.LoadIntoGame(InGameData).inGameData'></a>

`inGameData` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGameData](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGameData 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGameData')

specifics about game type

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.RunTest()'></a>

## ModTest.RunTest() Method

Runs the test coroutine

```csharp
public System.Collections.IEnumerator RunTest();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.SetupSimEnvironment(System.Action_SimulationTest_)'></a>

## ModTest.SetupSimEnvironment(Action<SimulationTest>) Method

Sets up a [Il2CppAssets.Scripts.SimulationTests.SimulationTestEnvironment](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.SimulationTests.SimulationTestEnvironment 'Il2CppAssets.Scripts.SimulationTests.SimulationTestEnvironment') to use for test, storing it at [Environment](BTD_Mod_Helper.Api.Testing.ModTest.md#BTD_Mod_Helper.Api.Testing.ModTest.Environment 'BTD_Mod_Helper.Api.Testing.ModTest.Environment')  
Used for testing matches without actually starting a real game

```csharp
public System.Collections.IEnumerator SetupSimEnvironment(System.Action<SimulationTest> setupTest=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.SetupSimEnvironment(System.Action_SimulationTest_).setupTest'></a>

`setupTest` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2Cpp.SimulationTest](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.SimulationTest 'Il2Cpp.SimulationTest')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Test()'></a>

## ModTest.Test() Method

Primary test coroutine

```csharp
public abstract System.Collections.IEnumerator Test();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Throw(System.Exception)'></a>

## ModTest.Throw(Exception) Method

Records and throws the given exception, causing the test to fail

```csharp
public void Throw(System.Exception e);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Throw(System.Exception).e'></a>

`e` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Timeout(object,float)'></a>

## ModTest.Timeout(object, float) Method

Wraps a coroutine so that the test will fail if it does not complete within the given time

```csharp
public System.Collections.IEnumerator Timeout(object coroutine, float seconds);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Timeout(object,float).coroutine'></a>

`coroutine` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Coroutine (managed or Il2Cpp) or yield value to run with a timeout

<a name='BTD_Mod_Helper.Api.Testing.ModTest.Timeout(object,float).seconds'></a>

`seconds` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Maximum number of seconds the coroutine is allowed to run for

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,ObjectId,int)'></a>

## ModTest.UpgradeTower(UnityToSimulation, ObjectId, int) Method

Upgrades a tower on a specified path

```csharp
public static bool UpgradeTower(UnityToSimulation bridge, ObjectId tower, int path);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,ObjectId,int).bridge'></a>

`bridge` [Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')

UnityToSimulation bridge

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,ObjectId,int).tower'></a>

`tower` [Il2CppAssets.Scripts.ObjectId](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.ObjectId 'Il2CppAssets.Scripts.ObjectId')

The tower to upgrade

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,ObjectId,int).path'></a>

`path` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The upgrade path index

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,Tower,int)'></a>

## ModTest.UpgradeTower(UnityToSimulation, Tower, int) Method

Upgrades a tower on a specified path

```csharp
public static bool UpgradeTower(UnityToSimulation bridge, Tower tower, int path);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,Tower,int).bridge'></a>

`bridge` [Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')

UnityToSimulation bridge

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,Tower,int).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

The tower to upgrade

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,Tower,int).path'></a>

`path` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The upgrade path index

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,TowerToSimulation,int)'></a>

## ModTest.UpgradeTower(UnityToSimulation, TowerToSimulation, int) Method

Upgrades a tower on a specified path

```csharp
public static bool UpgradeTower(UnityToSimulation bridge, TowerToSimulation tower, int path);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,TowerToSimulation,int).bridge'></a>

`bridge` [Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')

UnityToSimulation bridge

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,TowerToSimulation,int).tower'></a>

`tower` [Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')

The tower to upgrade

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTower(UnityToSimulation,TowerToSimulation,int).path'></a>

`path` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The upgrade path index

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTowerParagon(UnityToSimulation,ObjectId)'></a>

## ModTest.UpgradeTowerParagon(UnityToSimulation, ObjectId) Method

Upgrades a tower to being a paragon

```csharp
public static bool UpgradeTowerParagon(UnityToSimulation bridge, ObjectId tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTowerParagon(UnityToSimulation,ObjectId).bridge'></a>

`bridge` [Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')

UnityToSimulation bridge

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTowerParagon(UnityToSimulation,ObjectId).tower'></a>

`tower` [Il2CppAssets.Scripts.ObjectId](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.ObjectId 'Il2CppAssets.Scripts.ObjectId')

The tower to upgrade

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTowerParagon(UnityToSimulation,Tower)'></a>

## ModTest.UpgradeTowerParagon(UnityToSimulation, Tower) Method

Upgrades a tower to being a paragon

```csharp
public static bool UpgradeTowerParagon(UnityToSimulation bridge, Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTowerParagon(UnityToSimulation,Tower).bridge'></a>

`bridge` [Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')

UnityToSimulation bridge

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTowerParagon(UnityToSimulation,Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

The tower to upgrade

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTowerParagon(UnityToSimulation,TowerToSimulation)'></a>

## ModTest.UpgradeTowerParagon(UnityToSimulation, TowerToSimulation) Method

Upgrades a tower to being a paragon

```csharp
public static bool UpgradeTowerParagon(UnityToSimulation bridge, TowerToSimulation tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTowerParagon(UnityToSimulation,TowerToSimulation).bridge'></a>

`bridge` [Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')

UnityToSimulation bridge

<a name='BTD_Mod_Helper.Api.Testing.ModTest.UpgradeTowerParagon(UnityToSimulation,TowerToSimulation).tower'></a>

`tower` [Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')

The tower to upgrade

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')