#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## PowerModelBehaviorExt Class

Extensions for PowerModels

```csharp
public static class PowerModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PowerModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior(thisPowerModel,BTD_Mod_Helper.Api.Helpers.ModelHelper)'></a>

## PowerModelBehaviorExt.AddBehavior(this PowerModel, ModelHelper) Method

Adds a wrapped behavior from a ModelHelper to this tower

```csharp
public static void AddBehavior(this PowerModel model, BTD_Mod_Helper.Api.Helpers.ModelHelper behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior(thisPowerModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior(thisPowerModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).behavior'></a>

`behavior` [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisPowerModel,T)'></a>

## PowerModelBehaviorExt.AddBehavior<T>(this PowerModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this PowerModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisPowerModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisPowerModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisPowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisPowerModel,T).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior<T>(this PowerModel, T).T')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel,int)'></a>

## PowerModelBehaviorExt.GetBehavior<T>(this PowerModel, int) Method

Return the index'th Behavior of type T, or null

```csharp
public static T GetBehavior<T>(this PowerModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel,int).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel,int).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior<T>(this PowerModel, int).T')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel,string)'></a>

## PowerModelBehaviorExt.GetBehavior<T>(this PowerModel, string) Method

Return the first Behavior of type T whose name contains the given string, or null

```csharp
public static T GetBehavior<T>(this PowerModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel,string).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel,string).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior<T>(this PowerModel, string).T')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel)'></a>

## PowerModelBehaviorExt.GetBehavior<T>(this PowerModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this PowerModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior_T_(thisPowerModel).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehavior<T>(this PowerModel).T')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisPowerModel)'></a>

## PowerModelBehaviorExt.GetBehaviors<T>(this PowerModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this PowerModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisPowerModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisPowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisPowerModel).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors<T>(this PowerModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,string,T)'></a>

## PowerModelBehaviorExt.HasBehavior<T>(this PowerModel, string, T) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasBehavior<T>(this PowerModel model, string nameContains, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,string,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,string,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,string,T).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,string,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,string,T).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior<T>(this PowerModel, string, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,string)'></a>

## PowerModelBehaviorExt.HasBehavior<T>(this PowerModel, string) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasBehavior<T>(this PowerModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,string).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,T)'></a>

## PowerModelBehaviorExt.HasBehavior<T>(this PowerModel, T) Method

Check if this has a specific Behavior and return it

```csharp
public static bool HasBehavior<T>(this PowerModel model, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel,T).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior<T>(this PowerModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel)'></a>

## PowerModelBehaviorExt.HasBehavior<T>(this PowerModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this PowerModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.HasBehavior_T_(thisPowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,int)'></a>

## PowerModelBehaviorExt.RemoveBehavior<T>(this PowerModel, int) Method

Remove the index'th Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this PowerModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,int).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,string)'></a>

## PowerModelBehaviorExt.RemoveBehavior<T>(this PowerModel, string) Method

Remove the first Behavior of Type T whose name contains a certain string

```csharp
public static void RemoveBehavior<T>(this PowerModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,string).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,T)'></a>

## PowerModelBehaviorExt.RemoveBehavior<T>(this PowerModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this PowerModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel,T).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior<T>(this PowerModel, T).T')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel)'></a>

## PowerModelBehaviorExt.RemoveBehavior<T>(this PowerModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this PowerModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisPowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehaviors(thisPowerModel)'></a>

## PowerModelBehaviorExt.RemoveBehaviors(this PowerModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors(this PowerModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehaviors(thisPowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehaviors_T_(thisPowerModel)'></a>

## PowerModelBehaviorExt.RemoveBehaviors<T>(this PowerModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this PowerModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehaviors_T_(thisPowerModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehaviors_T_(thisPowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')