#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModBloonCustomDisplay<T> Class

A ModCustomDisplay that will automatically apply to a ModBloon

```csharp
public abstract class ModBloonCustomDisplay<T> : BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay
    where T : BTD_Mod_Helper.Api.Bloons.ModBloon
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; [ModBloonDisplay](BTD_Mod_Helper.Api.Display.ModBloonDisplay.md 'BTD_Mod_Helper.Api.Display.ModBloonDisplay') &#129106; [ModBloonCustomDisplay](BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay.md 'BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay') &#129106; ModBloonCustomDisplay<T>
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay_T_.Bloon'></a>

## ModBloonCustomDisplay<T>.Bloon Property

The ModBloon that this ModDisplay is used for

```csharp
public sealed override BTD_Mod_Helper.Api.Bloons.ModBloon Bloon { get; }
```

#### Property Value
[ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon')