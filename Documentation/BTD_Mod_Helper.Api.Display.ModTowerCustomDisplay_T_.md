#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModTowerCustomDisplay<T> Class

A convenient generic class for applying a ModTowerCustomDisplay to a ModTower

```csharp
public abstract class ModTowerCustomDisplay<T> : BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay
    where T : BTD_Mod_Helper.Api.Towers.ModTower
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; [ModTowerDisplay](BTD_Mod_Helper.Api.Display.ModTowerDisplay.md 'BTD_Mod_Helper.Api.Display.ModTowerDisplay') &#129106; [ModTowerCustomDisplay](BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay.md 'BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay') &#129106; ModTowerCustomDisplay<T>
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay_T_.Tower'></a>

## ModTowerCustomDisplay<T>.Tower Property

The ModTower that this ModDisplay is used for

```csharp
public override BTD_Mod_Helper.Api.Towers.ModTower Tower { get; }
```

#### Property Value
[ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower')