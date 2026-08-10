#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## TowerModelBehaviorExt Class

Extensions for TowerModels

```csharp
public static class TowerModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TowerModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior(thisTowerModel,BTD_Mod_Helper.Api.Helpers.ModelHelper)'></a>

## TowerModelBehaviorExt.AddBehavior(this TowerModel, ModelHelper) Method

Adds a wrapped behavior from a ModelHelper to this tower

```csharp
public static void AddBehavior(this TowerModel model, BTD_Mod_Helper.Api.Helpers.ModelHelper behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior(thisTowerModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior(thisTowerModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).behavior'></a>

`behavior` [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisTowerModel,T)'></a>

## TowerModelBehaviorExt.AddBehavior<T>(this TowerModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this TowerModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisTowerModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisTowerModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisTowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisTowerModel,T).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior<T>(this TowerModel, T).T')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel)'></a>

## TowerModelBehaviorExt.GetBehavior<T>(this TowerModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this TowerModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior<T>(this TowerModel).T')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel,int)'></a>

## TowerModelBehaviorExt.GetBehavior<T>(this TowerModel, int) Method

Return the index'th Behavior of type T, or null

```csharp
public static T GetBehavior<T>(this TowerModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel,int).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel,int).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior<T>(this TowerModel, int).T')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel,string)'></a>

## TowerModelBehaviorExt.GetBehavior<T>(this TowerModel, string) Method

Return the first Behavior of type T whose name contains the given string, or null

```csharp
public static T GetBehavior<T>(this TowerModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel,string).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel,string).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior<T>(this TowerModel, string).T')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehaviors_T_(thisTowerModel)'></a>

## TowerModelBehaviorExt.GetBehaviors<T>(this TowerModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this TowerModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehaviors_T_(thisTowerModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehaviors_T_(thisTowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehaviors_T_(thisTowerModel).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehaviors<T>(this TowerModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel)'></a>

## TowerModelBehaviorExt.HasBehavior<T>(this TowerModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this TowerModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,string)'></a>

## TowerModelBehaviorExt.HasBehavior<T>(this TowerModel, string) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasBehavior<T>(this TowerModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,string).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,string,T)'></a>

## TowerModelBehaviorExt.HasBehavior<T>(this TowerModel, string, T) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasBehavior<T>(this TowerModel model, string nameContains, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,string,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,string,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,string,T).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,string,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,string,T).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior<T>(this TowerModel, string, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,T)'></a>

## TowerModelBehaviorExt.HasBehavior<T>(this TowerModel, T) Method

Check if this has a specific Behavior and return it

```csharp
public static bool HasBehavior<T>(this TowerModel model, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,T).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior<T>(this TowerModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel)'></a>

## TowerModelBehaviorExt.RemoveBehavior<T>(this TowerModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this TowerModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,int)'></a>

## TowerModelBehaviorExt.RemoveBehavior<T>(this TowerModel, int) Method

Remove the index'th Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this TowerModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,int).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,string)'></a>

## TowerModelBehaviorExt.RemoveBehavior<T>(this TowerModel, string) Method

Remove the first Behavior of Type T whose name contains a certain string

```csharp
public static void RemoveBehavior<T>(this TowerModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,string).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,T)'></a>

## TowerModelBehaviorExt.RemoveBehavior<T>(this TowerModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this TowerModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,T).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior<T>(this TowerModel, T).T')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehaviors(thisTowerModel)'></a>

## TowerModelBehaviorExt.RemoveBehaviors(this TowerModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors(this TowerModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehaviors(thisTowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehaviors_T_(thisTowerModel)'></a>

## TowerModelBehaviorExt.RemoveBehaviors<T>(this TowerModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this TowerModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehaviors_T_(thisTowerModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehaviors_T_(thisTowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')