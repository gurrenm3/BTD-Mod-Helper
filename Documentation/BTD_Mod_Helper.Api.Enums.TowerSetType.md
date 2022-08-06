#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Enums](README.md#BTD_Mod_Helper.Api.Enums 'BTD_Mod_Helper.Api.Enums')

## TowerSetType Class

Enum-like class for the different tower set types

```csharp
public static class TowerSetType
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TowerSetType
### Fields

<a name='BTD_Mod_Helper.Api.Enums.TowerSetType.Magic'></a>

## TowerSetType.Magic Field

The magic set of towers

```csharp
public const string Magic = "Magic";
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Enums.TowerSetType.Military'></a>

## TowerSetType.Military Field

The military set of towers

```csharp
public const string Military = "Military";
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Enums.TowerSetType.Primary'></a>

## TowerSetType.Primary Field

The primary set of towers

```csharp
public const string Primary = "Primary";
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Enums.TowerSetType.Support'></a>

## TowerSetType.Support Field

The support set of towers

```csharp
public const string Support = "Support";
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='BTD_Mod_Helper.Api.Enums.TowerSetType.All'></a>

## TowerSetType.All Property

Enumeration of all (vanilla) tower sets

```csharp
public static System.Collections.Generic.IEnumerable<string> All { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
### Methods

<a name='BTD_Mod_Helper.Api.Enums.TowerSetType.Custom_T_()'></a>

## TowerSetType.Custom<T>() Method

Gets the ID to use for a custom tower set

```csharp
public static string Custom<T>()
    where T : BTD_Mod_Helper.Api.Towers.ModTowerSet;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Enums.TowerSetType.Custom_T_().T'></a>

`T`

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')