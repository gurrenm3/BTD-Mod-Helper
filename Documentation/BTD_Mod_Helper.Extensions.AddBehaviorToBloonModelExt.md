#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AddBehaviorToBloonModelExt Class

Extensions for AddBehaviorToBloonModels

```csharp
public static class AddBehaviorToBloonModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AddBehaviorToBloonModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel,T)'></a>

## AddBehaviorToBloonModelExt.AddBehavior<T>(this AddBehaviorToBloonModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel model, T behavior)
    where T : Assets.Scripts.Models.Bloons.BloonBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel,T).model'></a>

`model` [Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel,T).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior<T>(this Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelExt.GetBehavior<T>(this AddBehaviorToBloonModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior<T>(this Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelExt.GetBehaviors<T>(this AddBehaviorToBloonModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehaviors<T>(this Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelExt.HasBehavior<T>(this AddBehaviorToBloonModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelExt.RemoveBehavior<T>(this AddBehaviorToBloonModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel,T)'></a>

## AddBehaviorToBloonModelExt.RemoveBehavior<T>(this AddBehaviorToBloonModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel model, T behavior)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel,T).model'></a>

`model` [Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel,T).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior<T>(this Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelExt.RemoveBehaviors<T>(this AddBehaviorToBloonModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Assets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')