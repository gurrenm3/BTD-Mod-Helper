#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModDisplay2D Class

Mod Display specifically set up to be a 2d image

```csharp
public abstract class ModDisplay2D : BTD_Mod_Helper.Api.Display.ModDisplay
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; ModDisplay2D
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModDisplay2D.BaseDisplay'></a>

## ModDisplay2D.BaseDisplay Property

The GUID of the display to copy this ModDisplay off of

```csharp
public sealed override string BaseDisplay { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay2D.TextureName'></a>

## ModDisplay2D.TextureName Property

The file name (no .png) from your mod that you want to use as the 2d texture

```csharp
protected abstract string TextureName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.Display.ModDisplay2D.Apply(Assets.Scripts.Models.Towers.TowerModel)'></a>

## ModDisplay2D.Apply(TowerModel) Method

Applies this ModDisplay to a given TowerModel

```csharp
public override void Apply(Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay2D.Apply(Assets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay2D.ModifyDisplayNode(Assets.Scripts.Unity.Display.UnityDisplayNode)'></a>

## ModDisplay2D.ModifyDisplayNode(UnityDisplayNode) Method

Alters the UnityDisplayNode that was copied from the one used by [BaseDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md#BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplay 'BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplay')

```csharp
public override void ModifyDisplayNode(Assets.Scripts.Unity.Display.UnityDisplayNode node);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay2D.ModifyDisplayNode(Assets.Scripts.Unity.Display.UnityDisplayNode).node'></a>

`node` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

The prototype unity display node