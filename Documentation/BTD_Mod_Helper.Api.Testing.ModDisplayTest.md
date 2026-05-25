#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Testing](README.md#BTD_Mod_Helper.Api.Testing 'BTD_Mod_Helper.Api.Testing')

## ModDisplayTest Class

Runs a set of default tests for ModDisplays

```csharp
public class ModDisplayTest : BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<BTD_Mod_Helper.Api.Display.ModDisplay>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModTest](BTD_Mod_Helper.Api.Testing.ModTest.md 'BTD_Mod_Helper.Api.Testing.ModTest') &#129106; [BTD_Mod_Helper.Api.Testing.ModContentDefaultTest&lt;](BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.md 'BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<T>')[ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay')[&gt;](BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.md 'BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<T>') &#129106; ModDisplayTest
### Properties

<a name='BTD_Mod_Helper.Api.Testing.ModDisplayTest.OneTestToRuleThemAll'></a>

## ModDisplayTest.OneTestToRuleThemAll Property

Tests all the ModContent of this type within a single test instead of individually

```csharp
public override bool OneTestToRuleThemAll { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Testing.ModDisplayTest.Test()'></a>

## ModDisplayTest.Test() Method

Primary test coroutine

```csharp
public override System.Collections.IEnumerator Test();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')