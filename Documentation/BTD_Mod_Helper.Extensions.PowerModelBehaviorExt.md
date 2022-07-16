#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## PowerModelBehaviorExt Class

Behavior extensions for PowerModels

```csharp
public static class PowerModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PowerModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel,T)'></a>

## PowerModelBehaviorExt.AddBehavior<T>(this PowerModel, T) Method

(Cross-Game compatible) Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this Assets.Scripts.Models.Powers.PowerModel model, T behavior)
    where T : Assets.Scripts.Models.Powers.PowerBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel,T).model'></a>

`model` [Assets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Powers.PowerModel 'Assets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel,T).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior<T>(this Assets.Scripts.Models.Powers.PowerModel, T).T')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel)'></a>

## PowerModelBehaviorExt.GetBehavior<T>(this PowerModel) Method

(Cross-Game compatible) Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this Assets.Scripts.Models.Powers.PowerModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel).model'></a>

`model` [Assets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Powers.PowerModel 'Assets.Scripts.Models.Powers.PowerModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior<T>(this Assets.Scripts.Models.Powers.PowerModel).T')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Powers.PowerModel)'></a>

## PowerModelBehaviorExt.GetBehaviors<T>(this PowerModel) Method

(Cross-Game compatible) Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this Assets.Scripts.Models.Powers.PowerModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Powers.PowerModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Powers.PowerModel).model'></a>

`model` [Assets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Powers.PowerModel 'Assets.Scripts.Models.Powers.PowerModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Powers.PowerModel).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors<T>(this Assets.Scripts.Models.Powers.PowerModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel)'></a>

## PowerModelBehaviorExt.HasBehavior<T>(this PowerModel) Method

(Cross-Game compatible) Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this Assets.Scripts.Models.Powers.PowerModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel).model'></a>

`model` [Assets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Powers.PowerModel 'Assets.Scripts.Models.Powers.PowerModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel)'></a>

## PowerModelBehaviorExt.RemoveBehavior<T>(this PowerModel) Method

(Cross-Game compatible) Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Powers.PowerModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel).model'></a>

`model` [Assets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Powers.PowerModel 'Assets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel,T)'></a>

## PowerModelBehaviorExt.RemoveBehavior<T>(this PowerModel, T) Method

(Cross-Game compatible) Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Powers.PowerModel model, T behavior)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel,T).model'></a>

`model` [Assets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Powers.PowerModel 'Assets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Powers.PowerModel,T).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior<T>(this Assets.Scripts.Models.Powers.PowerModel, T).T')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Powers.PowerModel)'></a>

## PowerModelBehaviorExt.RemoveBehaviors<T>(this PowerModel) Method

(Cross-Game compatible) Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this Assets.Scripts.Models.Powers.PowerModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Powers.PowerModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Powers.PowerModel).model'></a>

`model` [Assets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Powers.PowerModel 'Assets.Scripts.Models.Powers.PowerModel')