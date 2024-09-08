#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Bloons](README.md#BTD_Mod_Helper.Api.Bloons 'BTD_Mod_Helper.Api.Bloons')

## ModBloon<T> Class

Class for a ModBloon which has a different ModBloon as its base

```csharp
public abstract class ModBloon<T> : BTD_Mod_Helper.Api.Bloons.ModBloon
    where T : BTD_Mod_Helper.Api.Bloons.ModBloon
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon') &#129106; ModBloon<T>
### Properties

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon_T_.BaseBloon'></a>

## ModBloon<T>.BaseBloon Property

The BaseBloon is the same as its base's

```csharp
public sealed override string BaseBloon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon_T_.BaseModBloon'></a>

## ModBloon<T>.BaseModBloon Property

The ModBloon that this is based off of, or null if not based on a ModBloon

```csharp
protected sealed override BTD_Mod_Helper.Api.Bloons.ModBloon BaseModBloon { get; }
```

#### Property Value
[ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon_T_.KeepBaseId'></a>

## ModBloon<T>.KeepBaseId Property

Set this to true if you're making another version of the BaseBloon, like a Fortified Red Bloon

```csharp
public override bool KeepBaseId { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')