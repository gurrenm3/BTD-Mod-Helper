#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## PetModelBehaviorExt Class

Extensions for PetModels

```csharp
public static class PetModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PetModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel,T)'></a>

## PetModelBehaviorExt.AddBehavior<T>(this PetModel, T) Method

(Cross-Game compatible) Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this Assets.Scripts.Models.Towers.Pets.PetModel model, T behavior)
    where T : Assets.Scripts.Models.Towers.Pets.PetBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel,T).model'></a>

`model` [Assets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Pets.PetModel 'Assets.Scripts.Models.Towers.Pets.PetModel')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PetModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel,T).T 'BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior<T>(this Assets.Scripts.Models.Towers.Pets.PetModel, T).T')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel)'></a>

## PetModelBehaviorExt.GetBehavior<T>(this PetModel) Method

(Cross-Game compatible) Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this Assets.Scripts.Models.Towers.Pets.PetModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Pets.PetModel 'Assets.Scripts.Models.Towers.Pets.PetModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.PetModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).T 'BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehavior<T>(this Assets.Scripts.Models.Towers.Pets.PetModel).T')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel)'></a>

## PetModelBehaviorExt.GetBehaviors<T>(this PetModel) Method

(Cross-Game compatible) Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this Assets.Scripts.Models.Towers.Pets.PetModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Pets.PetModel 'Assets.Scripts.Models.Towers.Pets.PetModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.PetModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).T 'BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehaviors<T>(this Assets.Scripts.Models.Towers.Pets.PetModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel)'></a>

## PetModelBehaviorExt.HasBehavior<T>(this PetModel) Method

(Cross-Game compatible) Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this Assets.Scripts.Models.Towers.Pets.PetModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Pets.PetModel 'Assets.Scripts.Models.Towers.Pets.PetModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel)'></a>

## PetModelBehaviorExt.RemoveBehavior<T>(this PetModel) Method

(Cross-Game compatible) Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Towers.Pets.PetModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Pets.PetModel 'Assets.Scripts.Models.Towers.Pets.PetModel')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel,T)'></a>

## PetModelBehaviorExt.RemoveBehavior<T>(this PetModel, T) Method

(Cross-Game compatible) Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Towers.Pets.PetModel model, T behavior)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel,T).model'></a>

`model` [Assets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Pets.PetModel 'Assets.Scripts.Models.Towers.Pets.PetModel')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PetModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel,T).T 'BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior<T>(this Assets.Scripts.Models.Towers.Pets.PetModel, T).T')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel)'></a>

## PetModelBehaviorExt.RemoveBehaviors<T>(this PetModel) Method

(Cross-Game compatible) Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this Assets.Scripts.Models.Towers.Pets.PetModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.Pets.PetModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Pets.PetModel 'Assets.Scripts.Models.Towers.Pets.PetModel')