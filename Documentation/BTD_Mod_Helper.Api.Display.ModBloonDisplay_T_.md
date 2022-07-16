#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Display](index.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModBloonDisplay<T> Class

A convenient generic class for applying a ModBloonDisplay to a ModBloon

```csharp
public abstract class ModBloonDisplay<T> : BTD_Mod_Helper.Api.Display.ModBloonDisplay
    where T : BTD_Mod_Helper.Api.Bloons.ModBloon
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Display.ModBloonDisplay_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; [ModBloonDisplay](BTD_Mod_Helper.Api.Display.ModBloonDisplay.md 'BTD_Mod_Helper.Api.Display.ModBloonDisplay') &#129106; ModBloonDisplay<T>
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModBloonDisplay_T_.Bloon'></a>

## ModBloonDisplay<T>.Bloon Property

The ModBloon that this ModDisplay is used for

```csharp
public override BTD_Mod_Helper.Api.Bloons.ModBloon Bloon { get; }
```

#### Property Value
[ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon')