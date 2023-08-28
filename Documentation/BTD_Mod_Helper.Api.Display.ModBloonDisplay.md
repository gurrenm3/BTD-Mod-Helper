#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModBloonDisplay Class

A ModDisplay that will automatically apply to a ModBloon

```csharp
public abstract class ModBloonDisplay : BTD_Mod_Helper.Api.Display.ModDisplay
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; ModBloonDisplay

Derived  
&#8627; [ModBloonCustomDisplay](BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay.md 'BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay')  
&#8627; [ModBloonDisplay&lt;T&gt;](BTD_Mod_Helper.Api.Display.ModBloonDisplay_T_.md 'BTD_Mod_Helper.Api.Display.ModBloonDisplay<T>')  
&#8627; [ModBossTierDisplay](BTD_Mod_Helper.Api.Display.ModBossTierDisplay.md 'BTD_Mod_Helper.Api.Display.ModBossTierDisplay')
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

How damaged the Bloon is, higher numbers = use when more damaged

```csharp
public virtual int Damage { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Display.ModBloonDisplay.DisplayCategory'></a>

## ModBloonDisplay.DisplayCategory Property

The DisplayCategory to use for the DisplayModel

```csharp
public override DisplayCategory DisplayCategory { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayCategory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayCategory 'Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayCategory')
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