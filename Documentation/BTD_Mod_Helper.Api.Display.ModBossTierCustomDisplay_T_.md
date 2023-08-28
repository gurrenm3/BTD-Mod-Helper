#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModBossTierCustomDisplay<T> Class

A ModCustomDisplay that will automatically apply to a ModBloon

```csharp
public abstract class ModBossTierCustomDisplay<T> : BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay
    where T : BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; [ModBloonDisplay](BTD_Mod_Helper.Api.Display.ModBloonDisplay.md 'BTD_Mod_Helper.Api.Display.ModBloonDisplay') &#129106; [ModBossTierDisplay](BTD_Mod_Helper.Api.Display.ModBossTierDisplay.md 'BTD_Mod_Helper.Api.Display.ModBossTierDisplay') &#129106; [ModBossTierCustomDisplay](BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay.md 'BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay') &#129106; ModBossTierCustomDisplay<T>
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay_T_.Boss'></a>

## ModBossTierCustomDisplay<T>.Boss Property

The ModBloon that this ModDisplay is used for, you can get it by doing ModContent.GetInstance();

```csharp
public sealed override BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss Boss { get; }
```

#### Property Value
[ModBoss](BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.md 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss')