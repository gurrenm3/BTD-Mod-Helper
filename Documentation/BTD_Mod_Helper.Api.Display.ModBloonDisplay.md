#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Display](index.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModBloonDisplay Class

A ModDisplay that will automatically apply to a ModBloon

```csharp
public abstract class ModBloonDisplay : BTD_Mod_Helper.Api.Display.ModDisplay
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; ModBloonDisplay

Derived  
&#8627; [ModBloonDisplay&lt;T&gt;](BTD_Mod_Helper.Api.Display.ModBloonDisplay_T_.md 'BTD_Mod_Helper.Api.Display.ModBloonDisplay<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModBloonDisplay.Bloon'></a>

## ModBloonDisplay.Bloon Property

The ModBloon that this ModDisplay is used for

```csharp
public abstract BTD_Mod_Helper.Api.Bloons.ModBloon Bloon { get; }
```

#### Property Value
[ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon')

<a name='BTD_Mod_Helper.Api.Display.ModBloonDisplay.Damage'></a>

## ModBloonDisplay.Damage Property

How damaged the Bloon is

```csharp
public virtual int Damage { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Methods

<a name='BTD_Mod_Helper.Api.Display.ModBloonDisplay.GetBloonDisplay(string,int)'></a>

## ModBloonDisplay.GetBloonDisplay(string, int) Method

Gets the display used by the given Bloon, optionally at a particular damage amount

```csharp
protected static string GetBloonDisplay(string bloonId, int damagedAmount=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModBloonDisplay.GetBloonDisplay(string,int).bloonId'></a>

`bloonId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBloonDisplay.GetBloonDisplay(string,int).damagedAmount'></a>

`damagedAmount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBloonDisplay.Register()'></a>

## ModBloonDisplay.Register() Method

(Cross-Game compatible) Registers this ModContent into the game

```csharp
public override void Register();
```