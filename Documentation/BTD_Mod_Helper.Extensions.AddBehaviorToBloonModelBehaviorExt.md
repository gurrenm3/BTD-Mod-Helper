#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AddBehaviorToBloonModelBehaviorExt Class

Extensions for AddBehaviorToBloonModels

```csharp
public static class AddBehaviorToBloonModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AddBehaviorToBloonModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.AddBehavior(thisAddBehaviorToBloonModel,BTD_Mod_Helper.Api.Helpers.ModelHelper)'></a>

## AddBehaviorToBloonModelBehaviorExt.AddBehavior(this AddBehaviorToBloonModel, ModelHelper) Method

Adds a wrapped behavior from a ModelHelper to this tower

```csharp
public static void AddBehavior(this AddBehaviorToBloonModel model, BTD_Mod_Helper.Api.Helpers.ModelHelper behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.AddBehavior(thisAddBehaviorToBloonModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.AddBehavior(thisAddBehaviorToBloonModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).behavior'></a>

`behavior` [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.AddBehavior_T_(thisAddBehaviorToBloonModel,T)'></a>

## AddBehaviorToBloonModelBehaviorExt.AddBehavior<T>(this AddBehaviorToBloonModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this AddBehaviorToBloonModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.AddBehavior_T_(thisAddBehaviorToBloonModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.AddBehavior_T_(thisAddBehaviorToBloonModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.AddBehavior_T_(thisAddBehaviorToBloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.AddBehavior_T_(thisAddBehaviorToBloonModel,T).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.AddBehavior<T>(this AddBehaviorToBloonModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelBehaviorExt.GetBehavior<T>(this AddBehaviorToBloonModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this AddBehaviorToBloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior<T>(this AddBehaviorToBloonModel).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel,int)'></a>

## AddBehaviorToBloonModelBehaviorExt.GetBehavior<T>(this AddBehaviorToBloonModel, int) Method

Return the index'th Behavior of type T, or null

```csharp
public static T GetBehavior<T>(this AddBehaviorToBloonModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel,int).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel,int).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior<T>(this AddBehaviorToBloonModel, int).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel,string)'></a>

## AddBehaviorToBloonModelBehaviorExt.GetBehavior<T>(this AddBehaviorToBloonModel, string) Method

Return the first Behavior of type T whose name contains the given string, or null

```csharp
public static T GetBehavior<T>(this AddBehaviorToBloonModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel,string).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior_T_(thisAddBehaviorToBloonModel,string).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehavior<T>(this AddBehaviorToBloonModel, string).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehaviors_T_(thisAddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelBehaviorExt.GetBehaviors<T>(this AddBehaviorToBloonModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this AddBehaviorToBloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehaviors_T_(thisAddBehaviorToBloonModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehaviors_T_(thisAddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehaviors_T_(thisAddBehaviorToBloonModel).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.GetBehaviors<T>(this AddBehaviorToBloonModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelBehaviorExt.HasBehavior<T>(this AddBehaviorToBloonModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this AddBehaviorToBloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel,string,T)'></a>

## AddBehaviorToBloonModelBehaviorExt.HasBehavior<T>(this AddBehaviorToBloonModel, string, T) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasBehavior<T>(this AddBehaviorToBloonModel model, string nameContains, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel,string,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel,string,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel,string,T).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel,string,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel,string,T).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior<T>(this AddBehaviorToBloonModel, string, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel,T)'></a>

## AddBehaviorToBloonModelBehaviorExt.HasBehavior<T>(this AddBehaviorToBloonModel, T) Method

Check if this has a specific Behavior and return it

```csharp
public static bool HasBehavior<T>(this AddBehaviorToBloonModel model, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior_T_(thisAddBehaviorToBloonModel,T).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.HasBehavior<T>(this AddBehaviorToBloonModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelBehaviorExt.RemoveBehavior<T>(this AddBehaviorToBloonModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this AddBehaviorToBloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,int)'></a>

## AddBehaviorToBloonModelBehaviorExt.RemoveBehavior<T>(this AddBehaviorToBloonModel, int) Method

Remove the index'th Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this AddBehaviorToBloonModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,int).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,string)'></a>

## AddBehaviorToBloonModelBehaviorExt.RemoveBehavior<T>(this AddBehaviorToBloonModel, string) Method

Remove the first Behavior of Type T whose name contains a certain string

```csharp
public static void RemoveBehavior<T>(this AddBehaviorToBloonModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,string).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,T)'></a>

## AddBehaviorToBloonModelBehaviorExt.RemoveBehavior<T>(this AddBehaviorToBloonModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this AddBehaviorToBloonModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior_T_(thisAddBehaviorToBloonModel,T).T 'BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehavior<T>(this AddBehaviorToBloonModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehaviors(thisAddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelBehaviorExt.RemoveBehaviors(this AddBehaviorToBloonModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors(this AddBehaviorToBloonModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehaviors(thisAddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehaviors_T_(thisAddBehaviorToBloonModel)'></a>

## AddBehaviorToBloonModelBehaviorExt.RemoveBehaviors<T>(this AddBehaviorToBloonModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this AddBehaviorToBloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehaviors_T_(thisAddBehaviorToBloonModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AddBehaviorToBloonModelBehaviorExt.RemoveBehaviors_T_(thisAddBehaviorToBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel')