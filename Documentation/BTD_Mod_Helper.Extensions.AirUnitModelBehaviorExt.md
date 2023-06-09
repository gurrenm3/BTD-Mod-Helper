#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AirUnitModelBehaviorExt Class

Behavior extensions for AirUnitModels

```csharp
public static class AirUnitModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AirUnitModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.AddBehavior_T_(thisAirUnitModel,T)'></a>

## AirUnitModelBehaviorExt.AddBehavior<T>(this AirUnitModel, T) Method

Add a Behavior to this

```csharp
public static void AddBehavior<T>(this AirUnitModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.AddBehavior_T_(thisAirUnitModel,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.AddBehavior_T_(thisAirUnitModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel')

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.AddBehavior_T_(thisAirUnitModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.AddBehavior_T_(thisAirUnitModel,T).T 'BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.AddBehavior<T>(this AirUnitModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.GetBehavior_T_(thisAirUnitModel)'></a>

## AirUnitModelBehaviorExt.GetBehavior<T>(this AirUnitModel) Method

Return the first Behavior of type T

```csharp
public static T GetBehavior<T>(this AirUnitModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.GetBehavior_T_(thisAirUnitModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.GetBehavior_T_(thisAirUnitModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.GetBehavior_T_(thisAirUnitModel).T 'BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.GetBehavior<T>(this AirUnitModel).T')

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.GetBehaviors_T_(thisAirUnitModel)'></a>

## AirUnitModelBehaviorExt.GetBehaviors<T>(this AirUnitModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this AirUnitModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.GetBehaviors_T_(thisAirUnitModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.GetBehaviors_T_(thisAirUnitModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.GetBehaviors_T_(thisAirUnitModel).T 'BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.GetBehaviors<T>(this AirUnitModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.HasBehavior_T_(thisAirUnitModel,T)'></a>

## AirUnitModelBehaviorExt.HasBehavior<T>(this AirUnitModel, T) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this AirUnitModel model, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.HasBehavior_T_(thisAirUnitModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.HasBehavior_T_(thisAirUnitModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel')

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.HasBehavior_T_(thisAirUnitModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.HasBehavior_T_(thisAirUnitModel,T).T 'BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.HasBehavior<T>(this AirUnitModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.HasBehavior_T_(thisAirUnitModel)'></a>

## AirUnitModelBehaviorExt.HasBehavior<T>(this AirUnitModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this AirUnitModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.HasBehavior_T_(thisAirUnitModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.HasBehavior_T_(thisAirUnitModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehavior_T_(thisAirUnitModel,T)'></a>

## AirUnitModelBehaviorExt.RemoveBehavior<T>(this AirUnitModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this AirUnitModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehavior_T_(thisAirUnitModel,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehavior_T_(thisAirUnitModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel')

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehavior_T_(thisAirUnitModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehavior_T_(thisAirUnitModel,T).T 'BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehavior<T>(this AirUnitModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehavior_T_(thisAirUnitModel)'></a>

## AirUnitModelBehaviorExt.RemoveBehavior<T>(this AirUnitModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this AirUnitModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehavior_T_(thisAirUnitModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehavior_T_(thisAirUnitModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel')

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehaviors_T_(thisAirUnitModel)'></a>

## AirUnitModelBehaviorExt.RemoveBehaviors<T>(this AirUnitModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this AirUnitModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehaviors_T_(thisAirUnitModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AirUnitModelBehaviorExt.RemoveBehaviors_T_(thisAirUnitModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.AirUnitModel')