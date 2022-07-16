#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AbilityModelBehaviorExt Class

Extensions for AbilityModels

```csharp
public static class AbilityModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AbilityModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel,T)'></a>

## AbilityModelBehaviorExt.AddBehavior<T>(this AbilityModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel model, T behavior)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel,T).model'></a>

`model` [Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel,T).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior<T>(this Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel)'></a>

## AbilityModelBehaviorExt.GetBehavior<T>(this AbilityModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior<T>(this Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).T')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel)'></a>

## AbilityModelBehaviorExt.GetBehaviors<T>(this AbilityModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehaviors<T>(this Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel)'></a>

## AbilityModelBehaviorExt.HasBehavior<T>(this AbilityModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel)'></a>

## AbilityModelBehaviorExt.RemoveBehavior<T>(this AbilityModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel,T)'></a>

## AbilityModelBehaviorExt.RemoveBehavior<T>(this AbilityModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel model, T behavior)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel,T).model'></a>

`model` [Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel,T).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior<T>(this Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel)'></a>

## AbilityModelBehaviorExt.RemoveBehaviors<T>(this AbilityModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')