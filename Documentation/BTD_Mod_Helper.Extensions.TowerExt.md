#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## TowerExt Class

Extensions for Towers

```csharp
public static class TowerExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TowerExt
### Methods

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetDisplayNode(thisIl2CppAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.GetDisplayNode(this Tower) Method

Return the DisplayNode for this Tower

```csharp
public static Il2CppAssets.Scripts.Simulation.Display.DisplayNode GetDisplayNode(this Il2CppAssets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetDisplayNode(thisIl2CppAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[Il2CppAssets.Scripts.Simulation.Display.DisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Display.DisplayNode 'Il2CppAssets.Scripts.Simulation.Display.DisplayNode')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetFactory(thisIl2CppAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.GetFactory(this Tower) Method

Return the Factory that creates Towers

```csharp
public static Il2CppAssets.Scripts.Simulation.Factory.Factory<Il2CppAssets.Scripts.Simulation.Towers.Tower> GetFactory(this Il2CppAssets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetFactory(thisIl2CppAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[Il2CppAssets.Scripts.Simulation.Factory.Factory&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Factory.Factory-1 'Il2CppAssets.Scripts.Simulation.Factory.Factory`1')[Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Factory.Factory-1 'Il2CppAssets.Scripts.Simulation.Factory.Factory`1')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetMonkeyAnimController(thisIl2CppAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.GetMonkeyAnimController(this Tower) Method

Get the MonkeyAnimationController for this Tower. Needed to modify 3D models

```csharp
public static Il2CppAssets.Scripts.Unity.Display.Animation.MonkeyAnimationController GetMonkeyAnimController(this Il2CppAssets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetMonkeyAnimController(thisIl2CppAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[Il2CppAssets.Scripts.Unity.Display.Animation.MonkeyAnimationController](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.Animation.MonkeyAnimationController 'Il2CppAssets.Scripts.Unity.Display.Animation.MonkeyAnimationController')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetTowersInRange(thisIl2CppAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.GetTowersInRange(this Tower) Method

Gets all other towers that are in range of this tower not including itself

```csharp
public static System.Collections.Generic.IEnumerable<Il2CppAssets.Scripts.Simulation.Towers.Tower> GetTowersInRange(this Il2CppAssets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetTowersInRange(thisIl2CppAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetTowerToSim(thisIl2CppAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.GetTowerToSim(this Tower) Method

Return the TowerToSimulation for this specific Tower

```csharp
public static Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation GetTowerToSim(this Il2CppAssets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetTowerToSim(thisIl2CppAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetUnityDisplayNode(thisIl2CppAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.GetUnityDisplayNode(this Tower) Method

Return the UnityDisplayNode for this Tower. Is apart of DisplayNode. Needed to modify sprites

```csharp
public static Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode GetUnityDisplayNode(this Il2CppAssets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.GetUnityDisplayNode(thisIl2CppAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.TowerExt.SellTower(thisIl2CppAssets.Scripts.Simulation.Towers.Tower)'></a>

## TowerExt.SellTower(this Tower) Method

Sell this tower

```csharp
public static void SellTower(this Il2CppAssets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.SellTower(thisIl2CppAssets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.Extensions.TowerExt.SetTowerModel(thisIl2CppAssets.Scripts.Simulation.Towers.Tower,Il2CppAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerExt.SetTowerModel(this Tower, TowerModel) Method

Change TowerModel to a different one. Will update display

```csharp
public static void SetTowerModel(this Il2CppAssets.Scripts.Simulation.Towers.Tower tower, Il2CppAssets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerExt.SetTowerModel(thisIl2CppAssets.Scripts.Simulation.Towers.Tower,Il2CppAssets.Scripts.Models.Towers.TowerModel).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

The Simulation Tower

<a name='BTD_Mod_Helper.Extensions.TowerExt.SetTowerModel(thisIl2CppAssets.Scripts.Simulation.Towers.Tower,Il2CppAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

TowerModel to change to