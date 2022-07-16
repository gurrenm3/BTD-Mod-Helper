#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## TowerExt Class

Extensions for Towers

```csharp
public static class TowerExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TowerExt
### Methods

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetDisplayNode(thisAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.GetDisplayNode(this Tower) Method

Return the DisplayNode for this Tower

```csharp
public static Assets.Scripts.Simulation.Display.DisplayNode GetDisplayNode(this Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetDisplayNode(thisAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

#### Returns
[Assets.Scripts.Simulation.Display.DisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Display.DisplayNode 'Assets.Scripts.Simulation.Display.DisplayNode')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetFactory(thisAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.GetFactory(this Tower) Method

Return the Factory that creates Towers

```csharp
public static Assets.Scripts.Simulation.Factory.Factory<Assets.Scripts.Simulation.Towers.Tower> GetFactory(this Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetFactory(thisAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

#### Returns
[Assets.Scripts.Simulation.Factory.Factory&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Factory.Factory-1 'Assets.Scripts.Simulation.Factory.Factory`1')[Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Factory.Factory-1 'Assets.Scripts.Simulation.Factory.Factory`1')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetMonkeyAnimController(thisAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.GetMonkeyAnimController(this Tower) Method

Get the MonkeyAnimationController for this Tower. Needed to modify 3D models

```csharp
public static Assets.Scripts.Unity.Display.Animation.MonkeyAnimationController GetMonkeyAnimController(this Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetMonkeyAnimController(thisAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

#### Returns
[Assets.Scripts.Unity.Display.Animation.MonkeyAnimationController](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.Animation.MonkeyAnimationController 'Assets.Scripts.Unity.Display.Animation.MonkeyAnimationController')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetTowerToSim(thisAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.GetTowerToSim(this Tower) Method

Return the TowerToSimulation for this specific Tower

```csharp
public static Assets.Scripts.Unity.Bridge.TowerToSimulation GetTowerToSim(this Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetTowerToSim(thisAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

#### Returns
[Assets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Bridge.TowerToSimulation 'Assets.Scripts.Unity.Bridge.TowerToSimulation')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetUnityDisplayNode(thisAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.GetUnityDisplayNode(this Tower) Method

Return the UnityDisplayNode for this Tower. Is apart of DisplayNode. Needed to modify sprites

```csharp
public static Assets.Scripts.Unity.Display.UnityDisplayNode GetUnityDisplayNode(this Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetUnityDisplayNode(thisAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

#### Returns
[Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.TowerExt.SellTower(thisAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.SellTower(this Tower) Method

Sell this tower

```csharp
public static void SellTower(this Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.SellTower(thisAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.Extensions.TowerExt.SetTowerModel(thisAssets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Towers.TowerModel)'></a>

## TowerExt.SetTowerModel(this Tower, TowerModel) Method

Change TowerModel to a different one. Will update display

```csharp
public static void SetTowerModel(this Assets.Scripts.Simulation.Towers.Tower tower, Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.SetTowerModel(thisAssets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Towers.TowerModel).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

The Simulation Tower

<a name='BTD_Mod_Helper.Extensions.TowerExt.SetTowerModel(thisAssets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

TowerModel to change to