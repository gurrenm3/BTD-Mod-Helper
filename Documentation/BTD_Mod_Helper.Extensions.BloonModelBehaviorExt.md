#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## BloonModelBehaviorExt Class

Behavior extensions for BloonModels

```csharp
public static class BloonModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BloonModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel,T)'></a>

## BloonModelBehaviorExt.AddBehavior<T>(this BloonModel, T) Method

(Cross-Game compatible) Add a Behavior to this

```csharp
public static void AddBehavior<T>(this Assets.Scripts.Models.Bloons.BloonModel model, T behavior)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel,T).model'></a>

`model` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel,T).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior<T>(this Assets.Scripts.Models.Bloons.BloonModel, T).T')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelBehaviorExt.GetBehavior<T>(this BloonModel) Method

(Cross-Game compatible) Return the first Behavior of type T

```csharp
public static T GetBehavior<T>(this Assets.Scripts.Models.Bloons.BloonModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel).model'></a>

`model` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior<T>(this Assets.Scripts.Models.Bloons.BloonModel).T')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelBehaviorExt.GetBehaviors<T>(this BloonModel) Method

(Cross-Game compatible) Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this Assets.Scripts.Models.Bloons.BloonModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Bloons.BloonModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Bloons.BloonModel).model'></a>

`model` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Bloons.BloonModel).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehaviors<T>(this Assets.Scripts.Models.Bloons.BloonModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelBehaviorExt.HasBehavior<T>(this BloonModel) Method

(Cross-Game compatible) Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this Assets.Scripts.Models.Bloons.BloonModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel).model'></a>

`model` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelBehaviorExt.RemoveBehavior<T>(this BloonModel) Method

(Cross-Game compatible) Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Bloons.BloonModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel).model'></a>

`model` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel,T)'></a>

## BloonModelBehaviorExt.RemoveBehavior<T>(this BloonModel, T) Method

(Cross-Game compatible) Remove the first Behavior of type T

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Bloons.BloonModel model, T behavior)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel,T).model'></a>

`model` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Bloons.BloonModel,T).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior<T>(this Assets.Scripts.Models.Bloons.BloonModel, T).T')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelBehaviorExt.RemoveBehaviors<T>(this BloonModel) Method

(Cross-Game compatible) Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this Assets.Scripts.Models.Bloons.BloonModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Bloons.BloonModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Bloons.BloonModel).model'></a>

`model` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')