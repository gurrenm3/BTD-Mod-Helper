#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## TowerBehaviorExt Class

Behavior extensions for Towers

```csharp
public static class TowerBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TowerBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.AddTowerBehavior_T_(thisTower,T)'></a>

## TowerBehaviorExt.AddTowerBehavior<T>(this Tower, T) Method

Add a Behavior to this

```csharp
public static void AddTowerBehavior<T>(this Tower tower, T behavior)
    where T : TowerBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.AddTowerBehavior_T_(thisTower,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.AddTowerBehavior_T_(thisTower,T).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.AddTowerBehavior_T_(thisTower,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.TowerBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerBehaviorExt.AddTowerBehavior_T_(thisTower,T).T 'BTD_Mod_Helper.Extensions.TowerBehaviorExt.AddTowerBehavior<T>(this Tower, T).T')

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.GetTowerBehavior_T_(thisTower)'></a>

## TowerBehaviorExt.GetTowerBehavior<T>(this Tower) Method

Return the first Behavior of type T

```csharp
public static T GetTowerBehavior<T>(this Tower tower)
    where T : TowerBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.GetTowerBehavior_T_(thisTower).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.GetTowerBehavior_T_(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[T](BTD_Mod_Helper.Extensions.TowerBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerBehaviorExt.GetTowerBehavior_T_(thisTower).T 'BTD_Mod_Helper.Extensions.TowerBehaviorExt.GetTowerBehavior<T>(this Tower).T')

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.GetTowerBehaviors_T_(thisTower)'></a>

## TowerBehaviorExt.GetTowerBehaviors<T>(this Tower) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetTowerBehaviors<T>(this Tower tower)
    where T : TowerBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.GetTowerBehaviors_T_(thisTower).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.GetTowerBehaviors_T_(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.TowerBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerBehaviorExt.GetTowerBehaviors_T_(thisTower).T 'BTD_Mod_Helper.Extensions.TowerBehaviorExt.GetTowerBehaviors<T>(this Tower).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.HasTowerBehavior_T_(thisTower)'></a>

## TowerBehaviorExt.HasTowerBehavior<T>(this Tower) Method

Check if this has a specific Behavior

```csharp
public static bool HasTowerBehavior<T>(this Tower tower)
    where T : TowerBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.HasTowerBehavior_T_(thisTower).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.HasTowerBehavior_T_(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehavior_T_(thisTower,T)'></a>

## TowerBehaviorExt.RemoveTowerBehavior<T>(this Tower, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveTowerBehavior<T>(this Tower tower, T behavior)
    where T : TowerBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehavior_T_(thisTower,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehavior_T_(thisTower,T).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehavior_T_(thisTower,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.TowerBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehavior_T_(thisTower,T).T 'BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehavior<T>(this Tower, T).T')

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehavior_T_(thisTower)'></a>

## TowerBehaviorExt.RemoveTowerBehavior<T>(this Tower) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveTowerBehavior<T>(this Tower tower)
    where T : TowerBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehavior_T_(thisTower).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehavior_T_(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehaviors_T_(thisTower)'></a>

## TowerBehaviorExt.RemoveTowerBehaviors<T>(this Tower) Method

Remove all Behaviors of type T

```csharp
public static void RemoveTowerBehaviors<T>(this Tower tower)
    where T : TowerBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehaviors_T_(thisTower).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerBehaviorExt.RemoveTowerBehaviors_T_(thisTower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')