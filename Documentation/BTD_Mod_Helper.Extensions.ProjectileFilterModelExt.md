#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ProjectileFilterModelExt Class

Extensions for ProjectileFilterModels

```csharp
public static class ProjectileFilterModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ProjectileFilterModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.AddFilter(thisProjectileFilterModel,BTD_Mod_Helper.Api.Helpers.ModelHelper)'></a>

## ProjectileFilterModelExt.AddFilter(this ProjectileFilterModel, ModelHelper) Method

Adds a wrapped behavior from a ModelHelper to this tower

```csharp
public static void AddFilter(this ProjectileFilterModel model, BTD_Mod_Helper.Api.Helpers.ModelHelper behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.AddFilter(thisProjectileFilterModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.AddFilter(thisProjectileFilterModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).behavior'></a>

`behavior` [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.AddFilter_T_(thisProjectileFilterModel,T)'></a>

## ProjectileFilterModelExt.AddFilter<T>(this ProjectileFilterModel, T) Method

Add a Behavior to this model

```csharp
public static void AddFilter<T>(this ProjectileFilterModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.AddFilter_T_(thisProjectileFilterModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.AddFilter_T_(thisProjectileFilterModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.AddFilter_T_(thisProjectileFilterModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.md#BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.AddFilter_T_(thisProjectileFilterModel,T).T 'BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.AddFilter<T>(this ProjectileFilterModel, T).T')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel,int)'></a>

## ProjectileFilterModelExt.GetFilter<T>(this ProjectileFilterModel, int) Method

Return the index'th Behavior of type T, or null

```csharp
public static T GetFilter<T>(this ProjectileFilterModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel,int).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.md#BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel,int).T 'BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter<T>(this ProjectileFilterModel, int).T')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel,string)'></a>

## ProjectileFilterModelExt.GetFilter<T>(this ProjectileFilterModel, string) Method

Return the first Behavior of type T whose name contains the given string, or null

```csharp
public static T GetFilter<T>(this ProjectileFilterModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel,string).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.md#BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel,string).T 'BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter<T>(this ProjectileFilterModel, string).T')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel)'></a>

## ProjectileFilterModelExt.GetFilter<T>(this ProjectileFilterModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetFilter<T>(this ProjectileFilterModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.md#BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter_T_(thisProjectileFilterModel).T 'BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilter<T>(this ProjectileFilterModel).T')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilters_T_(thisProjectileFilterModel)'></a>

## ProjectileFilterModelExt.GetFilters<T>(this ProjectileFilterModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetFilters<T>(this ProjectileFilterModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilters_T_(thisProjectileFilterModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilters_T_(thisProjectileFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.md#BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilters_T_(thisProjectileFilterModel).T 'BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.GetFilters<T>(this ProjectileFilterModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,string,T)'></a>

## ProjectileFilterModelExt.HasFilter<T>(this ProjectileFilterModel, string, T) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasFilter<T>(this ProjectileFilterModel model, string nameContains, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,string,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,string,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,string,T).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,string,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.md#BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,string,T).T 'BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter<T>(this ProjectileFilterModel, string, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,string)'></a>

## ProjectileFilterModelExt.HasFilter<T>(this ProjectileFilterModel, string) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasFilter<T>(this ProjectileFilterModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,string).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,T)'></a>

## ProjectileFilterModelExt.HasFilter<T>(this ProjectileFilterModel, T) Method

Check if this has a specific Behavior and return it

```csharp
public static bool HasFilter<T>(this ProjectileFilterModel model, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.md#BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel,T).T 'BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter<T>(this ProjectileFilterModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel)'></a>

## ProjectileFilterModelExt.HasFilter<T>(this ProjectileFilterModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasFilter<T>(this ProjectileFilterModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.HasFilter_T_(thisProjectileFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter(thisProjectileFilterModel)'></a>

## ProjectileFilterModelExt.RemoveFilter(this ProjectileFilterModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveFilter(this ProjectileFilterModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter(thisProjectileFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,int)'></a>

## ProjectileFilterModelExt.RemoveFilter<T>(this ProjectileFilterModel, int) Method

Remove the index'th Behavior of Type T

```csharp
public static void RemoveFilter<T>(this ProjectileFilterModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,int).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,string)'></a>

## ProjectileFilterModelExt.RemoveFilter<T>(this ProjectileFilterModel, string) Method

Remove the first Behavior of Type T whose name contains a certain string

```csharp
public static void RemoveFilter<T>(this ProjectileFilterModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,string).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,T)'></a>

## ProjectileFilterModelExt.RemoveFilter<T>(this ProjectileFilterModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveFilter<T>(this ProjectileFilterModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.md#BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel,T).T 'BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter<T>(this ProjectileFilterModel, T).T')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel)'></a>

## ProjectileFilterModelExt.RemoveFilter<T>(this ProjectileFilterModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveFilter<T>(this ProjectileFilterModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilter_T_(thisProjectileFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilters_T_(thisProjectileFilterModel)'></a>

## ProjectileFilterModelExt.RemoveFilters<T>(this ProjectileFilterModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveFilters<T>(this ProjectileFilterModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilters_T_(thisProjectileFilterModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileFilterModelExt.RemoveFilters_T_(thisProjectileFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')