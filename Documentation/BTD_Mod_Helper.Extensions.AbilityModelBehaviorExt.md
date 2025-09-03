#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AbilityModelBehaviorExt Class

Extensions for AbilityModels

```csharp
public static class AbilityModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AbilityModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior(thisAbilityModel,BTD_Mod_Helper.Api.Helpers.ModelHelper)'></a>

## AbilityModelBehaviorExt.AddBehavior(this AbilityModel, ModelHelper) Method

Adds a wrapped behavior from a ModelHelper to this tower

```csharp
public static void AddBehavior(this AbilityModel model, BTD_Mod_Helper.Api.Helpers.ModelHelper behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior(thisAbilityModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior(thisAbilityModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).behavior'></a>

`behavior` [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior_T_(thisAbilityModel,T)'></a>

## AbilityModelBehaviorExt.AddBehavior<T>(this AbilityModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this AbilityModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior_T_(thisAbilityModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior_T_(thisAbilityModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior_T_(thisAbilityModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior_T_(thisAbilityModel,T).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.AddBehavior<T>(this AbilityModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel)'></a>

## AbilityModelBehaviorExt.GetBehavior<T>(this AbilityModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this AbilityModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior<T>(this AbilityModel).T')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel,int)'></a>

## AbilityModelBehaviorExt.GetBehavior<T>(this AbilityModel, int) Method

Return the index'th Behavior of type T, or null

```csharp
public static T GetBehavior<T>(this AbilityModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel,int).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel,int).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior<T>(this AbilityModel, int).T')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel,string)'></a>

## AbilityModelBehaviorExt.GetBehavior<T>(this AbilityModel, string) Method

Return the first Behavior of type T whose name contains the given string, or null

```csharp
public static T GetBehavior<T>(this AbilityModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel,string).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior_T_(thisAbilityModel,string).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehavior<T>(this AbilityModel, string).T')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehaviors_T_(thisAbilityModel)'></a>

## AbilityModelBehaviorExt.GetBehaviors<T>(this AbilityModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this AbilityModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehaviors_T_(thisAbilityModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehaviors_T_(thisAbilityModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehaviors_T_(thisAbilityModel).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.GetBehaviors<T>(this AbilityModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel)'></a>

## AbilityModelBehaviorExt.HasBehavior<T>(this AbilityModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this AbilityModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel,string,T)'></a>

## AbilityModelBehaviorExt.HasBehavior<T>(this AbilityModel, string, T) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasBehavior<T>(this AbilityModel model, string nameContains, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel,string,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel,string,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel,string,T).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel,string,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel,string,T).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior<T>(this AbilityModel, string, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel,T)'></a>

## AbilityModelBehaviorExt.HasBehavior<T>(this AbilityModel, T) Method

Check if this has a specific Behavior and return it

```csharp
public static bool HasBehavior<T>(this AbilityModel model, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior_T_(thisAbilityModel,T).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.HasBehavior<T>(this AbilityModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel)'></a>

## AbilityModelBehaviorExt.RemoveBehavior<T>(this AbilityModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this AbilityModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,int)'></a>

## AbilityModelBehaviorExt.RemoveBehavior<T>(this AbilityModel, int) Method

Remove the index'th Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this AbilityModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,int).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,string)'></a>

## AbilityModelBehaviorExt.RemoveBehavior<T>(this AbilityModel, string) Method

Remove the first Behavior of Type T whose name contains a certain string

```csharp
public static void RemoveBehavior<T>(this AbilityModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,string).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,T)'></a>

## AbilityModelBehaviorExt.RemoveBehavior<T>(this AbilityModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this AbilityModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior_T_(thisAbilityModel,T).T 'BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehavior<T>(this AbilityModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehaviors(thisAbilityModel)'></a>

## AbilityModelBehaviorExt.RemoveBehaviors(this AbilityModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors(this AbilityModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehaviors(thisAbilityModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehaviors_T_(thisAbilityModel)'></a>

## AbilityModelBehaviorExt.RemoveBehaviors<T>(this AbilityModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this AbilityModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehaviors_T_(thisAbilityModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelBehaviorExt.RemoveBehaviors_T_(thisAbilityModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')