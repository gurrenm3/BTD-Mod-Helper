#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AttackFilterModelExt Class

Extensions for AttackFilterModels

```csharp
public static class AttackFilterModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AttackFilterModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.AddFilter(thisAttackFilterModel,BTD_Mod_Helper.Api.Helpers.ModelHelper)'></a>

## AttackFilterModelExt.AddFilter(this AttackFilterModel, ModelHelper) Method

Adds a wrapped behavior from a ModelHelper to this tower

```csharp
public static void AddFilter(this AttackFilterModel model, BTD_Mod_Helper.Api.Helpers.ModelHelper behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.AddFilter(thisAttackFilterModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.AddFilter(thisAttackFilterModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).behavior'></a>

`behavior` [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.AddFilter_T_(thisAttackFilterModel,T)'></a>

## AttackFilterModelExt.AddFilter<T>(this AttackFilterModel, T) Method

Add a Behavior to this model

```csharp
public static void AddFilter<T>(this AttackFilterModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.AddFilter_T_(thisAttackFilterModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.AddFilter_T_(thisAttackFilterModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.AddFilter_T_(thisAttackFilterModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackFilterModelExt.md#BTD_Mod_Helper.Extensions.AttackFilterModelExt.AddFilter_T_(thisAttackFilterModel,T).T 'BTD_Mod_Helper.Extensions.AttackFilterModelExt.AddFilter<T>(this AttackFilterModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel,int)'></a>

## AttackFilterModelExt.GetFilter<T>(this AttackFilterModel, int) Method

Return the index'th Behavior of type T, or null

```csharp
public static T GetFilter<T>(this AttackFilterModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel,int).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.AttackFilterModelExt.md#BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel,int).T 'BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter<T>(this AttackFilterModel, int).T')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel,string)'></a>

## AttackFilterModelExt.GetFilter<T>(this AttackFilterModel, string) Method

Return the first Behavior of type T whose name contains the given string, or null

```csharp
public static T GetFilter<T>(this AttackFilterModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel,string).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.AttackFilterModelExt.md#BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel,string).T 'BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter<T>(this AttackFilterModel, string).T')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel)'></a>

## AttackFilterModelExt.GetFilter<T>(this AttackFilterModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetFilter<T>(this AttackFilterModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.AttackFilterModelExt.md#BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter_T_(thisAttackFilterModel).T 'BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilter<T>(this AttackFilterModel).T')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilters_T_(thisAttackFilterModel)'></a>

## AttackFilterModelExt.GetFilters<T>(this AttackFilterModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetFilters<T>(this AttackFilterModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilters_T_(thisAttackFilterModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilters_T_(thisAttackFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.AttackFilterModelExt.md#BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilters_T_(thisAttackFilterModel).T 'BTD_Mod_Helper.Extensions.AttackFilterModelExt.GetFilters<T>(this AttackFilterModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,string,T)'></a>

## AttackFilterModelExt.HasFilter<T>(this AttackFilterModel, string, T) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasFilter<T>(this AttackFilterModel model, string nameContains, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,string,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,string,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,string,T).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,string,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackFilterModelExt.md#BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,string,T).T 'BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter<T>(this AttackFilterModel, string, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,string)'></a>

## AttackFilterModelExt.HasFilter<T>(this AttackFilterModel, string) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasFilter<T>(this AttackFilterModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,string).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,T)'></a>

## AttackFilterModelExt.HasFilter<T>(this AttackFilterModel, T) Method

Check if this has a specific Behavior and return it

```csharp
public static bool HasFilter<T>(this AttackFilterModel model, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackFilterModelExt.md#BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel,T).T 'BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter<T>(this AttackFilterModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel)'></a>

## AttackFilterModelExt.HasFilter<T>(this AttackFilterModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasFilter<T>(this AttackFilterModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.HasFilter_T_(thisAttackFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter(thisAttackFilterModel)'></a>

## AttackFilterModelExt.RemoveFilter(this AttackFilterModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveFilter(this AttackFilterModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter(thisAttackFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,int)'></a>

## AttackFilterModelExt.RemoveFilter<T>(this AttackFilterModel, int) Method

Remove the index'th Behavior of Type T

```csharp
public static void RemoveFilter<T>(this AttackFilterModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,int).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,string)'></a>

## AttackFilterModelExt.RemoveFilter<T>(this AttackFilterModel, string) Method

Remove the first Behavior of Type T whose name contains a certain string

```csharp
public static void RemoveFilter<T>(this AttackFilterModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,string).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,T)'></a>

## AttackFilterModelExt.RemoveFilter<T>(this AttackFilterModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveFilter<T>(this AttackFilterModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackFilterModelExt.md#BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel,T).T 'BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter<T>(this AttackFilterModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel)'></a>

## AttackFilterModelExt.RemoveFilter<T>(this AttackFilterModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveFilter<T>(this AttackFilterModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilter_T_(thisAttackFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilters_T_(thisAttackFilterModel)'></a>

## AttackFilterModelExt.RemoveFilters<T>(this AttackFilterModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveFilters<T>(this AttackFilterModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilters_T_(thisAttackFilterModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackFilterModelExt.RemoveFilters_T_(thisAttackFilterModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')