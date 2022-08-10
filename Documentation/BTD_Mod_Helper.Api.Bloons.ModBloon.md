#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Bloons](README.md#BTD_Mod_Helper.Api.Bloons 'BTD_Mod_Helper.Api.Bloons')

## ModBloon Class

Class for adding in a new Bloon to the game

```csharp
public abstract class ModBloon : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModBloon

Derived  
&#8627; [ModBloon&lt;T&gt;](BTD_Mod_Helper.Api.Bloons.ModBloon_T_.md 'BTD_Mod_Helper.Api.Bloons.ModBloon<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.BaseBloon'></a>

## ModBloon.BaseBloon Property

The Bloon in the game that this should copy from as a base. Use BloonType.[Name]

```csharp
public abstract string BaseBloon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.Camo'></a>

## ModBloon.Camo Property

Add the necessary properties to make this a Camo Bloon

```csharp
public virtual bool Camo { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.DamageStates'></a>

## ModBloon.DamageStates Property

The list of displays to use as DamageStates for this Bloon

```csharp
public virtual System.Collections.Generic.IEnumerable<string> DamageStates { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.Fortified'></a>

## ModBloon.Fortified Property

Add the necessary properties to make this a Fortified Bloon

```csharp
public virtual bool Fortified { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.Icon'></a>

## ModBloon.Icon Property

The Icon for the Bloon within the UI, by default looking for the same name as the file

```csharp
public virtual string Icon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.IconReference'></a>

## ModBloon.IconReference Property

If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference

```csharp
public virtual Assets.Scripts.Utils.SpriteReference IconReference { get; }
```

#### Property Value
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.KeepBaseId'></a>

## ModBloon.KeepBaseId Property

Set this to true if you're making another version of the BaseBloon, like a Fortified Red Bloon

```csharp
public virtual bool KeepBaseId { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.PixelsPerUnit'></a>

## ModBloon.PixelsPerUnit Property

For 2D bloons, the ratio between pixels and display units. Higher number -> smaller Bloon.

```csharp
public virtual float PixelsPerUnit { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.Regrow'></a>

## ModBloon.Regrow Property

Add the necessary properties to make this a Regrow Bloon

```csharp
public virtual bool Regrow { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.RegrowRate'></a>

## ModBloon.RegrowRate Property

The regrow rate

```csharp
public virtual float RegrowRate { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.RegrowsTo'></a>

## ModBloon.RegrowsTo Property

The ID of the bloon that this should regrow into

```csharp
public virtual string RegrowsTo { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.Scale'></a>

## ModBloon.Scale Property

For bloons with UseIconAsDisplay, the scale for the texture to use

```csharp
public virtual float Scale { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.UseIconAsDisplay'></a>

## ModBloon.UseIconAsDisplay Property

Whether this Bloon should use its Icon as its display

```csharp
public virtual bool UseIconAsDisplay { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.ModifyBaseBloonModel(Assets.Scripts.Models.Bloons.BloonModel)'></a>

## ModBloon.ModifyBaseBloonModel(BloonModel) Method

Apply your custom modifications to the base bloon

```csharp
public abstract void ModifyBaseBloonModel(Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModBloon.ModifyBaseBloonModel(Assets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')