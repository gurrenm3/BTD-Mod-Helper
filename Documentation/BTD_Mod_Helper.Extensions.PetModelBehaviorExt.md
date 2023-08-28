#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## PetModelBehaviorExt Class

Extensions for PetModels

```csharp
public static class PetModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PetModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior_T_(thisPetModel,T)'></a>

## PetModelBehaviorExt.AddBehavior<T>(this PetModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this PetModel model, T behavior)
    where T : PetBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior_T_(thisPetModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior_T_(thisPetModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Pets.PetModel 'Il2CppAssets.Scripts.Models.Towers.Pets.PetModel')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior_T_(thisPetModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PetModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior_T_(thisPetModel,T).T 'BTD_Mod_Helper.Extensions.PetModelBehaviorExt.AddBehavior<T>(this PetModel, T).T')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehavior_T_(thisPetModel)'></a>

## PetModelBehaviorExt.GetBehavior<T>(this PetModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this PetModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehavior_T_(thisPetModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehavior_T_(thisPetModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Pets.PetModel 'Il2CppAssets.Scripts.Models.Towers.Pets.PetModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.PetModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehavior_T_(thisPetModel).T 'BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehavior<T>(this PetModel).T')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehaviors_T_(thisPetModel)'></a>

## PetModelBehaviorExt.GetBehaviors<T>(this PetModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this PetModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehaviors_T_(thisPetModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehaviors_T_(thisPetModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Pets.PetModel 'Il2CppAssets.Scripts.Models.Towers.Pets.PetModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.PetModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehaviors_T_(thisPetModel).T 'BTD_Mod_Helper.Extensions.PetModelBehaviorExt.GetBehaviors<T>(this PetModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.HasBehavior_T_(thisPetModel)'></a>

## PetModelBehaviorExt.HasBehavior<T>(this PetModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this PetModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.HasBehavior_T_(thisPetModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.HasBehavior_T_(thisPetModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Pets.PetModel 'Il2CppAssets.Scripts.Models.Towers.Pets.PetModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisPetModel,T)'></a>

## PetModelBehaviorExt.RemoveBehavior<T>(this PetModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this PetModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisPetModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisPetModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Pets.PetModel 'Il2CppAssets.Scripts.Models.Towers.Pets.PetModel')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisPetModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PetModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisPetModel,T).T 'BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior<T>(this PetModel, T).T')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisPetModel)'></a>

## PetModelBehaviorExt.RemoveBehavior<T>(this PetModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this PetModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisPetModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehavior_T_(thisPetModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Pets.PetModel 'Il2CppAssets.Scripts.Models.Towers.Pets.PetModel')

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehaviors_T_(thisPetModel)'></a>

## PetModelBehaviorExt.RemoveBehaviors<T>(this PetModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this PetModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehaviors_T_(thisPetModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PetModelBehaviorExt.RemoveBehaviors_T_(thisPetModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Pets.PetModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Pets.PetModel 'Il2CppAssets.Scripts.Models.Towers.Pets.PetModel')