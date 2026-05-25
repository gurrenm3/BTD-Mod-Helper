#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Testing](README.md#BTD_Mod_Helper.Api.Testing 'BTD_Mod_Helper.Api.Testing')

## ModContentDefaultTest<T> Class

A default [ModTest](BTD_Mod_Helper.Api.Testing.ModTest.md 'BTD_Mod_Helper.Api.Testing.ModTest') for a particular kind of [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')

```csharp
public abstract class ModContentDefaultTest<T> : BTD_Mod_Helper.Api.Testing.ModTest
    where T : BTD_Mod_Helper.Api.ModContent, BTD_Mod_Helper.Api.Testing.IHasDefaultTest
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.T'></a>

`T`

ModContent type

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModTest](BTD_Mod_Helper.Api.Testing.ModTest.md 'BTD_Mod_Helper.Api.Testing.ModTest') &#129106; ModContentDefaultTest<T>

Derived  
&#8627; [ModBloonTest](BTD_Mod_Helper.Api.Testing.ModBloonTest.md 'BTD_Mod_Helper.Api.Testing.ModBloonTest')  
&#8627; [ModDisplayTest](BTD_Mod_Helper.Api.Testing.ModDisplayTest.md 'BTD_Mod_Helper.Api.Testing.ModDisplayTest')  
&#8627; [ModGameModeTest](BTD_Mod_Helper.Api.Testing.ModGameModeTest.md 'BTD_Mod_Helper.Api.Testing.ModGameModeTest')  
&#8627; [ModRoundSetTest](BTD_Mod_Helper.Api.Testing.ModRoundSetTest.md 'BTD_Mod_Helper.Api.Testing.ModRoundSetTest')  
&#8627; [ModTowerTest](BTD_Mod_Helper.Api.Testing.ModTowerTest.md 'BTD_Mod_Helper.Api.Testing.ModTowerTest')  
&#8627; [ModVanillaContentTest](BTD_Mod_Helper.Api.Testing.ModVanillaContentTest.md 'BTD_Mod_Helper.Api.Testing.ModVanillaContentTest')
### Properties

<a name='BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.AllContent'></a>

## ModContentDefaultTest<T>.AllContent Property

All the ModContent of this type to test

```csharp
public T[] AllContent { get; set; }
```

#### Property Value
[T](BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.md#BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.T 'BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<T>.T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.Content'></a>

## ModContentDefaultTest<T>.Content Property

The ModContent that this is a test for

```csharp
public T Content { get; set; }
```

#### Property Value
[T](BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.md#BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.T 'BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<T>.T')

<a name='BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.IsAvailable'></a>

## ModContentDefaultTest<T>.IsAvailable Property

Whether this test is available for purposes like running every test added by a mod

```csharp
public override bool IsAvailable { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.Name'></a>

## ModContentDefaultTest<T>.Name Property

The name that will be at the end of the ID for this ModContent, by default the class name

```csharp
public override string Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.OneTestToRuleThemAll'></a>

## ModContentDefaultTest<T>.OneTestToRuleThemAll Property

Tests all the ModContent of this type within a single test instead of individually

```csharp
public virtual bool OneTestToRuleThemAll { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')