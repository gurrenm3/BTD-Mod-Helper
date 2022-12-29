#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## TowerExt Class

Extensions for Towers

```csharp
public static class TowerExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TowerExt
### Methods

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetDisplayNode(thisTower)'></a>

## TowerExt.GetDisplayNode(this Tower) Method

Return the DisplayNode for this Tower

```csharp
public static DisplayNode GetDisplayNode(this Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetDisplayNode(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[Il2CppAssets.Scripts.Simulation.Display.DisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Display.DisplayNode 'Il2CppAssets.Scripts.Simulation.Display.DisplayNode')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetFactory(thisTower)'></a>

## TowerExt.GetFactory(this Tower) Method

Return the Factory that creates Towers

```csharp
public static Factory<Tower> GetFactory(this Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetFactory(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[Il2CppAssets.Scripts.Simulation.Factory.Factory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Factory.Factory 'Il2CppAssets.Scripts.Simulation.Factory.Factory')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetMonkeyAnimController(thisTower)'></a>

## TowerExt.GetMonkeyAnimController(this Tower) Method

Get the MonkeyAnimationController for this Tower. Needed to modify 3D models

```csharp
public static MonkeyAnimationController GetMonkeyAnimController(this Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetMonkeyAnimController(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[Il2CppAssets.Scripts.Unity.Display.Animation.MonkeyAnimationController](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.Animation.MonkeyAnimationController 'Il2CppAssets.Scripts.Unity.Display.Animation.MonkeyAnimationController')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetTowersInRange(thisTower)'></a>

## TowerExt.GetTowersInRange(this Tower) Method

Gets all other towers that are in range of this tower not including itself

```csharp
public static System.Collections.Generic.IEnumerable<Tower> GetTowersInRange(this Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetTowersInRange(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetTowerToSim(thisTower)'></a>

## TowerExt.GetTowerToSim(this Tower) Method

Return the TowerToSimulation for this specific Tower

```csharp
public static TowerToSimulation GetTowerToSim(this Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetTowerToSim(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetUnityDisplayNode(thisTower)'></a>

## TowerExt.GetUnityDisplayNode(this Tower) Method

Return the UnityDisplayNode for this Tower. Is apart of DisplayNode. Needed to modify sprites

```csharp
public static UnityDisplayNode GetUnityDisplayNode(this Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetUnityDisplayNode(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.TowerExt.SellTower(thisTower)'></a>

## TowerExt.SellTower(this Tower) Method

Sell this tower

```csharp
public static void SellTower(this Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.SellTower(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.Extensions.TowerExt.SetTowerModel(thisTower,TowerModel)'></a>

## TowerExt.SetTowerModel(this Tower, TowerModel) Method

Change TowerModel to a different one. Will update display

```csharp
public static void SetTowerModel(this Tower tower, TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.SetTowerModel(thisTower,TowerModel).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

The Simulation Tower

<a name='BTD_Mod_Helper.Extensions.TowerExt.SetTowerModel(thisTower,TowerModel).towerModel'></a>

`towerModel` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

TowerModel to change to