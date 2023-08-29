#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## AmbientMapFXDisplay<T> Class

A convenient generic class for applying a AmbientMapFXDisplay to a ModBoss

```csharp
public abstract class AmbientMapFXDisplay<T> : BTD_Mod_Helper.Api.Display.AmbientMapFXDisplay
    where T : BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Display.AmbientMapFXDisplay_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [AmbientMapFXDisplay](BTD_Mod_Helper.Api.Display.AmbientMapFXDisplay.md 'BTD_Mod_Helper.Api.Display.AmbientMapFXDisplay') &#129106; AmbientMapFXDisplay<T>
### Properties

<a name='BTD_Mod_Helper.Api.Display.AmbientMapFXDisplay_T_.Boss'></a>

## AmbientMapFXDisplay<T>.Boss Property

The ModBoss that this MapFXDisplay is used for

```csharp
public override BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss Boss { get; }
```

#### Property Value
[ModBoss](BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.md 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss')