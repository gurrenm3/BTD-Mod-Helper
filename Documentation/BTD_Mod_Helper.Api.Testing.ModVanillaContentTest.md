#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Testing](README.md#BTD_Mod_Helper.Api.Testing 'BTD_Mod_Helper.Api.Testing')

## ModVanillaContentTest Class

Tests the ModVanillaContent within a mod

```csharp
public class ModVanillaContentTest : BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<BTD_Mod_Helper.Api.Towers.ModVanillaContent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModTest](BTD_Mod_Helper.Api.Testing.ModTest.md 'BTD_Mod_Helper.Api.Testing.ModTest') &#129106; [BTD_Mod_Helper.Api.Testing.ModContentDefaultTest&lt;](BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.md 'BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<T>')[ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent')[&gt;](BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.md 'BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<T>') &#129106; ModVanillaContentTest
### Properties

<a name='BTD_Mod_Helper.Api.Testing.ModVanillaContentTest.OneTestToRuleThemAll'></a>

## ModVanillaContentTest.OneTestToRuleThemAll Property

Tests all the ModContent of this type within a single test instead of individually

```csharp
public override bool OneTestToRuleThemAll { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Testing.ModVanillaContentTest.Test()'></a>

## ModVanillaContentTest.Test() Method

Primary test coroutine

```csharp
public override System.Collections.IEnumerator Test();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')