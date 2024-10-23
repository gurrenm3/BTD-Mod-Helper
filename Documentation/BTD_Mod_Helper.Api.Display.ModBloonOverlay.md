#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModBloonOverlay Class

A special ModDisplay for Bloon Overlays. Handles automatically loading different instances of itself for each BloonOverlayClass

```csharp
public abstract class ModBloonOverlay : BTD_Mod_Helper.Api.Display.ModDisplay
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; ModBloonOverlay
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModBloonOverlay.AllOverlayTypes'></a>

## ModBloonOverlay.AllOverlayTypes Property

Quick getter for all overlays

```csharp
protected static SerializableDictionary<string,BloonOverlayScriptable> AllOverlayTypes { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.SerializableDictionary](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.SerializableDictionary 'Il2CppNinjaKiwi.Common.SerializableDictionary')

<a name='BTD_Mod_Helper.Api.Display.ModBloonOverlay.BaseDisplay'></a>

## ModBloonOverlay.BaseDisplay Property

<inheritdoc/><br/>  
            If [BaseOverlay](BTD_Mod_Helper.Api.Display.ModBloonOverlay.md#BTD_Mod_Helper.Api.Display.ModBloonOverlay.BaseOverlay 'BTD_Mod_Helper.Api.Display.ModBloonOverlay.BaseOverlay') is defined, will automatically get the correct display for each OverlayClass from there

```csharp
public override string BaseDisplay { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBloonOverlay.BaseOverlay'></a>

## ModBloonOverlay.BaseOverlay Property

The base Bloon Overlay to copy from.  
<br/>  
These come from the [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorWithOverlayModel.overlayType](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorWithOverlayModel.overlayType 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorWithOverlayModel.overlayType') fields of certain projectile behavior models  
<br/>  
To not copy from any Base Overlay, override this to be null/empty and modify [BaseDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md#BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplay 'BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplay') or [BaseDisplayReference](BTD_Mod_Helper.Api.Display.ModDisplay.md#BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplayReference 'BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplayReference') instead

```csharp
public virtual string BaseOverlay { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBloonOverlay.BaseOverlayClass'></a>

## ModBloonOverlay.BaseOverlayClass Property

Lets you control which BloonOverlayClass from the BaseOverlay is used for each BloonOverlayClass of your custom overlay.  
By default, uses the same [OverlayClass](BTD_Mod_Helper.Api.Display.ModBloonOverlay.md#BTD_Mod_Helper.Api.Display.ModBloonOverlay.OverlayClass 'BTD_Mod_Helper.Api.Display.ModBloonOverlay.OverlayClass') as the base.  
<br/><example>  
To make the non regrow bloons use the same overlays as the regrow bloons  
<code>  
public override BloonOverlayClass BaseOverlayClass =&gt; OverlayClass switch  
{  
    BloonOverlayClass.Red =&gt; BloonOverlayClass.RedRegrow,  
    BloonOverlayClass.Blue =&gt; BloonOverlayClass.BlueRegrow,  
    BloonOverlayClass.Green =&gt; BloonOverlayClass.GreenRegrow,  
    BloonOverlayClass.Yellow =&gt; BloonOverlayClass.YellowRegrow,  
    BloonOverlayClass.Pink =&gt; BloonOverlayClass.PinkRegrow,  
    BloonOverlayClass.White =&gt; BloonOverlayClass.WhiteRegrow,  
    _ =&gt; OverlayClass  
};  
</code></example>

```csharp
public virtual BloonOverlayClass BaseOverlayClass { get; }
```

#### Property Value
[Il2Cpp.BloonOverlayClass](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.BloonOverlayClass 'Il2Cpp.BloonOverlayClass')

<a name='BTD_Mod_Helper.Api.Display.ModBloonOverlay.BloonOverlayClasses'></a>

## ModBloonOverlay.BloonOverlayClasses Property

Full list of BloonOverlayClasses to try to load this overlay for, defaults to all of them

```csharp
public virtual System.Collections.Generic.IEnumerable<BloonOverlayClass> BloonOverlayClasses { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2Cpp.BloonOverlayClass](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.BloonOverlayClass 'Il2Cpp.BloonOverlayClass')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.Display.ModBloonOverlay.DisplayLayer'></a>

## ModBloonOverlay.DisplayLayer Property

The [Il2CppAssets.Scripts.Data.Bloons.BloonOverlayScriptable.displayLayer](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Data.Bloons.BloonOverlayScriptable.displayLayer 'Il2CppAssets.Scripts.Data.Bloons.BloonOverlayScriptable.displayLayer') of the overlay

```csharp
public virtual int DisplayLayer { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Display.ModBloonOverlay.OverlayClass'></a>

## ModBloonOverlay.OverlayClass Property

The overlay class that this is for

```csharp
public BloonOverlayClass OverlayClass { get; set; }
```

#### Property Value
[Il2Cpp.BloonOverlayClass](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.BloonOverlayClass 'Il2Cpp.BloonOverlayClass')

<a name='BTD_Mod_Helper.Api.Display.ModBloonOverlay.OverlayType'></a>

## ModBloonOverlay.OverlayType Property

Which overlay type this Overlay uses

```csharp
public string OverlayType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBloonOverlay.WorksOnCurrentMelonLoader'></a>

## ModBloonOverlay.WorksOnCurrentMelonLoader Property

Whether the current MelonLoader version will support registering a BloonOverlay

```csharp
public static bool WorksOnCurrentMelonLoader { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Display.ModBloonOverlay.Apply(ProjectileBehaviorWithOverlayModel)'></a>

## ModBloonOverlay.Apply(ProjectileBehaviorWithOverlayModel) Method

Applies this overlay to a projectile behavior model

```csharp
public virtual void Apply(ProjectileBehaviorWithOverlayModel projectileBehaviorWithOverlayModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModBloonOverlay.Apply(ProjectileBehaviorWithOverlayModel).projectileBehaviorWithOverlayModel'></a>

`projectileBehaviorWithOverlayModel` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorWithOverlayModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorWithOverlayModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorWithOverlayModel')

model to add to