#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModTest Class

Defines a test task for a mod

```csharp
public abstract class ModTest : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModTest
### Properties

<a name='BTD_Mod_Helper.Api.ModTest.Completed'></a>

## ModTest.Completed Property

Whether the current run of this test has completed

```csharp
public bool Completed { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModTest.Exception'></a>

## ModTest.Exception Property

Exception that happened in the most recent run of this test, if any

```csharp
public System.Exception Exception { get; set; }
```

#### Property Value
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='BTD_Mod_Helper.Api.ModTest.Failed'></a>

## ModTest.Failed Property

Whether the most recent run of this test failed to complete successfully

```csharp
public bool Failed { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModTest.Suceeded'></a>

## ModTest.Suceeded Property

Whether the most recent run of this test completed successfully

```csharp
public bool Suceeded { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.ModTest.Assert(bool,string)'></a>

## ModTest.Assert(bool, string) Method

Throws an [BTD_Mod_Helper.Api.ModTest.AssertException](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.ModTest.AssertException 'BTD_Mod_Helper.Api.ModTest.AssertException') if the given condition is not true

```csharp
public void Assert(bool condition, string message="");
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModTest.Assert(bool,string).condition'></a>

`condition` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Condition that must be true for the test to continue

<a name='BTD_Mod_Helper.Api.ModTest.Assert(bool,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

<a name='BTD_Mod_Helper.Api.ModTest.AssertComponentExists_T_(string,string)'></a>

## ModTest.AssertComponentExists<T>(string, string) Method

Throws an [BTD_Mod_Helper.Api.ModTest.AssertException](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.ModTest.AssertException 'BTD_Mod_Helper.Api.ModTest.AssertException') if no [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') of type [T](BTD_Mod_Helper.Api.ModTest.md#BTD_Mod_Helper.Api.ModTest.AssertComponentExists_T_(string,string).T 'BTD_Mod_Helper.Api.ModTest.AssertComponentExists<T>(string, string).T')  
with the given name can be found within any currently loaded scene

```csharp
public T AssertComponentExists<T>(string name, string message="")
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModTest.AssertComponentExists_T_(string,string).T'></a>

`T`

Component type to search for
#### Parameters

<a name='BTD_Mod_Helper.Api.ModTest.AssertComponentExists_T_(string,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of the GameObject the component should be attached to

<a name='BTD_Mod_Helper.Api.ModTest.AssertComponentExists_T_(string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

#### Returns
[T](BTD_Mod_Helper.Api.ModTest.md#BTD_Mod_Helper.Api.ModTest.AssertComponentExists_T_(string,string).T 'BTD_Mod_Helper.Api.ModTest.AssertComponentExists<T>(string, string).T')

<a name='BTD_Mod_Helper.Api.ModTest.AssertEquals(object,object,string)'></a>

## ModTest.AssertEquals(object, object, string) Method

Throws an [BTD_Mod_Helper.Api.ModTest.AssertException](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.ModTest.AssertException 'BTD_Mod_Helper.Api.ModTest.AssertException') if the two given objects are not equal

```csharp
public void AssertEquals(object o1, object o2, string message="");
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModTest.AssertEquals(object,object,string).o1'></a>

`o1` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

First object to compare

<a name='BTD_Mod_Helper.Api.ModTest.AssertEquals(object,object,string).o2'></a>

`o2` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Second object to compare

<a name='BTD_Mod_Helper.Api.ModTest.AssertEquals(object,object,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

<a name='BTD_Mod_Helper.Api.ModTest.AssertThrows(System.Action,string)'></a>

## ModTest.AssertThrows(Action, string) Method

Throws an [BTD_Mod_Helper.Api.ModTest.AssertException](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.ModTest.AssertException 'BTD_Mod_Helper.Api.ModTest.AssertException') if the given action does not throw an exception

```csharp
public void AssertThrows(System.Action action, string message="");
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModTest.AssertThrows(System.Action,string).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

Action that is expected to throw

<a name='BTD_Mod_Helper.Api.ModTest.AssertThrows(System.Action,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

<a name='BTD_Mod_Helper.Api.ModTest.AssertThrows_T_(System.Action,string)'></a>

## ModTest.AssertThrows<T>(Action, string) Method

Throws an [BTD_Mod_Helper.Api.ModTest.AssertException](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.ModTest.AssertException 'BTD_Mod_Helper.Api.ModTest.AssertException') if the given action does not throw an exception of type [T](BTD_Mod_Helper.Api.ModTest.md#BTD_Mod_Helper.Api.ModTest.AssertThrows_T_(System.Action,string).T 'BTD_Mod_Helper.Api.ModTest.AssertThrows<T>(System.Action, string).T')

```csharp
public void AssertThrows<T>(System.Action action, string message="");
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModTest.AssertThrows_T_(System.Action,string).T'></a>

`T`

Type of exception that the action is expected to throw
#### Parameters

<a name='BTD_Mod_Helper.Api.ModTest.AssertThrows_T_(System.Action,string).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

Action that is expected to throw

<a name='BTD_Mod_Helper.Api.ModTest.AssertThrows_T_(System.Action,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

<a name='BTD_Mod_Helper.Api.ModTest.EnsureOnMainMenuWithNoPopUps()'></a>

## ModTest.EnsureOnMainMenuWithNoPopUps() Method

Ensures that the game is on the main menu screen with no popups before continuing

```csharp
public System.Collections.IEnumerator EnsureOnMainMenuWithNoPopUps();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.ModTest.Fail(string)'></a>

## ModTest.Fail(string) Method

Unconditionally fails the test with the given message

```csharp
public void Fail(string message="");
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModTest.Fail(string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional message describing the failure

<a name='BTD_Mod_Helper.Api.ModTest.LoadIntoGame(InGameData)'></a>

## ModTest.LoadIntoGame(InGameData) Method

Loads the game into a real match of BTD6

```csharp
public System.Collections.IEnumerator LoadIntoGame(InGameData inGameData);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModTest.LoadIntoGame(InGameData).inGameData'></a>

`inGameData` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGameData](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGameData 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGameData')

specifics about game type

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.ModTest.RunTest()'></a>

## ModTest.RunTest() Method

Runs the test coroutine

```csharp
public System.Collections.IEnumerator RunTest();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.ModTest.Test()'></a>

## ModTest.Test() Method

Primary test coroutine

```csharp
public abstract System.Collections.IEnumerator Test();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.ModTest.Throw(System.Exception)'></a>

## ModTest.Throw(Exception) Method

Records and throws the given exception, causing the test to fail

```csharp
public void Throw(System.Exception e);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModTest.Throw(System.Exception).e'></a>

`e` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='BTD_Mod_Helper.Api.ModTest.Timeout(object,float)'></a>

## ModTest.Timeout(object, float) Method

Wraps a coroutine so that the test will fail if it does not complete within the given time

```csharp
public System.Collections.IEnumerator Timeout(object coroutine, float seconds);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModTest.Timeout(object,float).coroutine'></a>

`coroutine` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Coroutine (managed or Il2Cpp) or yield value to run with a timeout

<a name='BTD_Mod_Helper.Api.ModTest.Timeout(object,float).seconds'></a>

`seconds` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Maximum number of seconds the coroutine is allowed to run for

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')