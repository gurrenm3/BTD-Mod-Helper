#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## TowerModelBehaviorExt Class

Behavior extensions for TowerModels

```csharp
public static class TowerModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TowerModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T)'></a>

## TowerModelBehaviorExt.AddBehavior<T>(this TowerModel, T) Method

(Cross-Game compatible) Add a Behavior to this

```csharp
public static void AddBehavior<T>(this Assets.Scripts.Models.Towers.TowerModel model, T behavior)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).model'></a>

`model` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior<T>(this Assets.Scripts.Models.Towers.TowerModel, T).T')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelBehaviorExt.GetBehavior<T>(this TowerModel) Method

(Cross-Game compatible) Return the first Behavior of type T

```csharp
public static T GetBehavior<T>(this Assets.Scripts.Models.Towers.TowerModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel).model'></a>

`model` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior<T>(this Assets.Scripts.Models.Towers.TowerModel).T')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelBehaviorExt.GetBehaviors<T>(this TowerModel) Method

(Cross-Game compatible) Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this Assets.Scripts.Models.Towers.TowerModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.TowerModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.TowerModel).model'></a>

`model` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.TowerModel).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehaviors<T>(this Assets.Scripts.Models.Towers.TowerModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelBehaviorExt.HasBehavior<T>(this TowerModel) Method

(Cross-Game compatible) Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this Assets.Scripts.Models.Towers.TowerModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel).model'></a>

`model` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T)'></a>

## TowerModelBehaviorExt.HasBehavior<T>(this TowerModel, T) Method

(Cross-Game compatible) Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this Assets.Scripts.Models.Towers.TowerModel model, out T behavior)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).model'></a>

`model` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior<T>(this Assets.Scripts.Models.Towers.TowerModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelBehaviorExt.RemoveBehavior<T>(this TowerModel) Method

(Cross-Game compatible) Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Towers.TowerModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel).model'></a>

`model` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T)'></a>

## TowerModelBehaviorExt.RemoveBehavior<T>(this TowerModel, T) Method

(Cross-Game compatible) Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Towers.TowerModel model, T behavior)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).model'></a>

`model` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.TowerModel,T).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior<T>(this Assets.Scripts.Models.Towers.TowerModel, T).T')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelBehaviorExt.RemoveBehaviors<T>(this TowerModel) Method

(Cross-Game compatible) Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this Assets.Scripts.Models.Towers.TowerModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.TowerModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.TowerModel).model'></a>

`model` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')