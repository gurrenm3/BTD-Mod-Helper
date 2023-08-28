#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## EmissionModelBehaviorExt Class

Extensions for EmissionModels

```csharp
public static class EmissionModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EmissionModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.AddBehavior_T_(thisEmissionModel,T)'></a>

## EmissionModelBehaviorExt.AddBehavior<T>(this EmissionModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this EmissionModel model, T behavior)
    where T : EmissionBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.AddBehavior_T_(thisEmissionModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.AddBehavior_T_(thisEmissionModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.AddBehavior_T_(thisEmissionModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.AddBehavior_T_(thisEmissionModel,T).T 'BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.AddBehavior<T>(this EmissionModel, T).T')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel)'></a>

## EmissionModelBehaviorExt.GetBehavior<T>(this EmissionModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this EmissionModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel).T 'BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior<T>(this EmissionModel).T')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehaviors_T_(thisEmissionModel)'></a>

## EmissionModelBehaviorExt.GetBehaviors<T>(this EmissionModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this EmissionModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehaviors_T_(thisEmissionModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehaviors_T_(thisEmissionModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehaviors_T_(thisEmissionModel).T 'BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehaviors<T>(this EmissionModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel)'></a>

## EmissionModelBehaviorExt.HasBehavior<T>(this EmissionModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this EmissionModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,T)'></a>

## EmissionModelBehaviorExt.RemoveBehavior<T>(this EmissionModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this EmissionModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,T).T 'BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior<T>(this EmissionModel, T).T')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel)'></a>

## EmissionModelBehaviorExt.RemoveBehavior<T>(this EmissionModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this EmissionModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehaviors_T_(thisEmissionModel)'></a>

## EmissionModelBehaviorExt.RemoveBehaviors<T>(this EmissionModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this EmissionModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehaviors_T_(thisEmissionModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehaviors_T_(thisEmissionModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')