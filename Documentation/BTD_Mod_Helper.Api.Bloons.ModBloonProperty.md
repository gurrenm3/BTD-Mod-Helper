#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Bloons](README.md#BTD_Mod_Helper.Api.Bloons 'BTD_Mod_Helper.Api.Bloons')

## ModBloonProperty Class

Mod content class for creating [Il2Cpp.BloonProperties](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.BloonProperties 'Il2Cpp.BloonProperties')

```csharp
public abstract class ModBloonProperty : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModBloonProperty
### Properties

<a name='BTD_Mod_Helper.Api.Bloons.ModBloonProperty.BloonPropertyInt'></a>

## ModBloonProperty.BloonPropertyInt Property

Integer value used internally as the enum value

```csharp
public int BloonPropertyInt { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloonProperty.Property'></a>

## ModBloonProperty.Property Property

Enum value for this ModBloonProperty

```csharp
public BloonProperties Property { get; }
```

#### Property Value
[Il2Cpp.BloonProperties](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.BloonProperties 'Il2Cpp.BloonProperties')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloonProperty.RegistrationPriority'></a>

## ModBloonProperty.RegistrationPriority Property

ModBloonProperties should load before ModBloons so no errors occur.

```csharp
protected override float RegistrationPriority { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')
### Methods

<a name='BTD_Mod_Helper.Api.Bloons.ModBloonProperty.Load()'></a>

## ModBloonProperty.Load() Method

ModBloonProperties should only be loaded once

```csharp
public sealed override System.Collections.Generic.IEnumerable<BTD_Mod_Helper.Api.ModContent> Load();
```

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')