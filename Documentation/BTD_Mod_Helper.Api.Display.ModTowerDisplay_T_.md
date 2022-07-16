#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Display](index.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModTowerDisplay<T> Class

A convenient generic class for applying a ModTowerDisplay to a ModTower

```csharp
public abstract class ModTowerDisplay<T> : BTD_Mod_Helper.Api.Display.ModTowerDisplay
    where T : BTD_Mod_Helper.Api.Towers.ModTower
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; [ModTowerDisplay](BTD_Mod_Helper.Api.Display.ModTowerDisplay.md 'BTD_Mod_Helper.Api.Display.ModTowerDisplay') &#129106; ModTowerDisplay<T>
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay_T_.Tower'></a>

## ModTowerDisplay<T>.Tower Property

The ModTower that this ModDisplay is used for

```csharp
public override BTD_Mod_Helper.Api.Towers.ModTower Tower { get; }
```

#### Property Value
[ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower')