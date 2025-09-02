#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## EmissionModelBehaviorExt Class

Extensions for EmissionModels

```csharp
public static class EmissionModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EmissionModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.AddBehavior(thisEmissionModel,BTD_Mod_Helper.Api.Helpers.ModelHelper)'></a>

## EmissionModelBehaviorExt.AddBehavior(this EmissionModel, ModelHelper) Method

Adds a wrapped behavior from a ModelHelper to this tower

```csharp
public static void AddBehavior(this EmissionModel model, BTD_Mod_Helper.Api.Helpers.ModelHelper behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.AddBehavior(thisEmissionModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.AddBehavior(thisEmissionModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).behavior'></a>

`behavior` [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.AddBehavior_T_(thisEmissionModel,T)'></a>

## EmissionModelBehaviorExt.AddBehavior<T>(this EmissionModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this EmissionModel model, T behavior)
    where T : Model;
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

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel,int)'></a>

## EmissionModelBehaviorExt.GetBehavior<T>(this EmissionModel, int) Method

Return the index'th Behavior of type T, or null

```csharp
public static T GetBehavior<T>(this EmissionModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel,int).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel,int).T 'BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior<T>(this EmissionModel, int).T')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel,string)'></a>

## EmissionModelBehaviorExt.GetBehavior<T>(this EmissionModel, string) Method

Return the first Behavior of type T whose name contains the given string, or null

```csharp
public static T GetBehavior<T>(this EmissionModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel,string).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior_T_(thisEmissionModel,string).T 'BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.GetBehavior<T>(this EmissionModel, string).T')

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

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel,string,T)'></a>

## EmissionModelBehaviorExt.HasBehavior<T>(this EmissionModel, string, T) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasBehavior<T>(this EmissionModel model, string nameContains, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel,string,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel,string,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel,string,T).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel,string,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel,string,T).T 'BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior<T>(this EmissionModel, string, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel,T)'></a>

## EmissionModelBehaviorExt.HasBehavior<T>(this EmissionModel, T) Method

Check if this has a specific Behavior and return it

```csharp
public static bool HasBehavior<T>(this EmissionModel model, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior_T_(thisEmissionModel,T).T 'BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.HasBehavior<T>(this EmissionModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

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

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,int)'></a>

## EmissionModelBehaviorExt.RemoveBehavior<T>(this EmissionModel, int) Method

Remove the index'th Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this EmissionModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,int).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,string)'></a>

## EmissionModelBehaviorExt.RemoveBehavior<T>(this EmissionModel, string) Method

Remove the first Behavior of Type T whose name contains a certain string

```csharp
public static void RemoveBehavior<T>(this EmissionModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,string).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehavior_T_(thisEmissionModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

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

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehaviors(thisEmissionModel)'></a>

## EmissionModelBehaviorExt.RemoveBehaviors(this EmissionModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors(this EmissionModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionModelBehaviorExt.RemoveBehaviors(thisEmissionModel).model'></a>

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