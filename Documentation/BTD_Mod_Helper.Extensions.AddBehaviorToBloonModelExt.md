#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AddBehaviorToBloonModelExt Class

Extensions for AddBehaviorToBloonModels

```csharp
public static class AddBehaviorToBloonModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AddBehaviorToBloonModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior(AddBehaviorToBloonModel,BTD_Mod_Helper.Api.Helpers.ModelHelper)'></a>

## AddBehaviorToBloonModelExt.AddBehavior(AddBehaviorToBloonModel, ModelHelper) Method

Adds a wrapped behavior from a ModelHelper to this tower

```csharp
public static void AddBehavior(AddBehaviorToBloonModel model, BTD_Mod_Helper.Api.Helpers.ModelHelper behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior(AddBehaviorToBloonModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior(AddBehaviorToBloonModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).behavior'></a>

`behavior` [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior_T_(AddBehaviorToBloonModel,T)'></a>

## AddBehaviorToBloonModelExt.AddBehavior<T>(AddBehaviorToBloonModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(AddBehaviorToBloonModel model, T behavior)
    where T : BloonBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior_T_(AddBehaviorToBloonModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior_T_(AddBehaviorToBloonModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior_T_(AddBehaviorToBloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior_T_(AddBehaviorToBloonModel,T).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.AddBehavior<T>(AddBehaviorToBloonModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelExt.GetBehavior<T>(AddBehaviorToBloonModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(AddBehaviorToBloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior<T>(AddBehaviorToBloonModel).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel,int)'></a>

## AddBehaviorToBloonModelExt.GetBehavior<T>(AddBehaviorToBloonModel, int) Method

Return the index'th Behavior of type T, or null

```csharp
public static T GetBehavior<T>(AddBehaviorToBloonModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel,int).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel,int).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior<T>(AddBehaviorToBloonModel, int).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel,string)'></a>

## AddBehaviorToBloonModelExt.GetBehavior<T>(AddBehaviorToBloonModel, string) Method

Return the first Behavior of type T whose name contains the given string, or null

```csharp
public static T GetBehavior<T>(AddBehaviorToBloonModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel,string).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior_T_(AddBehaviorToBloonModel,string).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehavior<T>(AddBehaviorToBloonModel, string).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehaviors_T_(AddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelExt.GetBehaviors<T>(AddBehaviorToBloonModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(AddBehaviorToBloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehaviors_T_(AddBehaviorToBloonModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehaviors_T_(AddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehaviors_T_(AddBehaviorToBloonModel).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.GetBehaviors<T>(AddBehaviorToBloonModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.HasBehavior_T_(AddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelExt.HasBehavior<T>(AddBehaviorToBloonModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(AddBehaviorToBloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.HasBehavior_T_(AddBehaviorToBloonModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.HasBehavior_T_(AddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(AddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelExt.RemoveBehavior<T>(AddBehaviorToBloonModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(AddBehaviorToBloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(AddBehaviorToBloonModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(AddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(AddBehaviorToBloonModel,T)'></a>

## AddBehaviorToBloonModelExt.RemoveBehavior<T>(AddBehaviorToBloonModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(AddBehaviorToBloonModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(AddBehaviorToBloonModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(AddBehaviorToBloonModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(AddBehaviorToBloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior_T_(AddBehaviorToBloonModel,T).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehavior<T>(AddBehaviorToBloonModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehaviors(AddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelExt.RemoveBehaviors(AddBehaviorToBloonModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors(AddBehaviorToBloonModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehaviors(AddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehaviors_T_(AddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelExt.RemoveBehaviors<T>(AddBehaviorToBloonModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(AddBehaviorToBloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehaviors_T_(AddBehaviorToBloonModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelExt.RemoveBehaviors_T_(AddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')