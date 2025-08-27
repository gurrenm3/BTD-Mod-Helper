#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## BloonModelBehaviorExt Class

Extensions for BloonModels

```csharp
public static class BloonModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BloonModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior(thisBloonModel,BTD_Mod_Helper.Api.Helpers.ModelHelper)'></a>

## BloonModelBehaviorExt.AddBehavior(this BloonModel, ModelHelper) Method

Adds a wrapped behavior from a ModelHelper to this tower

```csharp
public static void AddBehavior(this BloonModel model, BTD_Mod_Helper.Api.Helpers.ModelHelper behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior(thisBloonModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior(thisBloonModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).behavior'></a>

`behavior` [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior_T_(thisBloonModel,T)'></a>

## BloonModelBehaviorExt.AddBehavior<T>(this BloonModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this BloonModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior_T_(thisBloonModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior_T_(thisBloonModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior_T_(thisBloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior_T_(thisBloonModel,T).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.AddBehavior<T>(this BloonModel, T).T')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel,int)'></a>

## BloonModelBehaviorExt.GetBehavior<T>(this BloonModel, int) Method

Return the index'th Behavior of type T, or null

```csharp
public static T GetBehavior<T>(this BloonModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel,int).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel,int).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior<T>(this BloonModel, int).T')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel,string)'></a>

## BloonModelBehaviorExt.GetBehavior<T>(this BloonModel, string) Method

Return the first Behavior of type T whose name contains the given string, or null

```csharp
public static T GetBehavior<T>(this BloonModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel,string).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel,string).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior<T>(this BloonModel, string).T')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel)'></a>

## BloonModelBehaviorExt.GetBehavior<T>(this BloonModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this BloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior_T_(thisBloonModel).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehavior<T>(this BloonModel).T')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehaviors_T_(thisBloonModel)'></a>

## BloonModelBehaviorExt.GetBehaviors<T>(this BloonModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this BloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehaviors_T_(thisBloonModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehaviors_T_(thisBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehaviors_T_(thisBloonModel).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.GetBehaviors<T>(this BloonModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel,string,T)'></a>

## BloonModelBehaviorExt.HasBehavior<T>(this BloonModel, string, T) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasBehavior<T>(this BloonModel model, string nameContains, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel,string,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel,string,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel,string,T).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel,string,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel,string,T).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior<T>(this BloonModel, string, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel,T)'></a>

## BloonModelBehaviorExt.HasBehavior<T>(this BloonModel, T) Method

Check if this has a specific Behavior and return it

```csharp
public static bool HasBehavior<T>(this BloonModel model, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel,T).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior<T>(this BloonModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel)'></a>

## BloonModelBehaviorExt.HasBehavior<T>(this BloonModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this BloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.HasBehavior_T_(thisBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,int)'></a>

## BloonModelBehaviorExt.RemoveBehavior<T>(this BloonModel, int) Method

Remove the index'th Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this BloonModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,int).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,string)'></a>

## BloonModelBehaviorExt.RemoveBehavior<T>(this BloonModel, string) Method

Remove the first Behavior of Type T whose name contains a certain string

```csharp
public static void RemoveBehavior<T>(this BloonModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,string).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,T)'></a>

## BloonModelBehaviorExt.RemoveBehavior<T>(this BloonModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this BloonModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel,T).T 'BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior<T>(this BloonModel, T).T')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel)'></a>

## BloonModelBehaviorExt.RemoveBehavior<T>(this BloonModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this BloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehavior_T_(thisBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehaviors(thisBloonModel)'></a>

## BloonModelBehaviorExt.RemoveBehaviors(this BloonModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors(this BloonModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehaviors(thisBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehaviors_T_(thisBloonModel)'></a>

## BloonModelBehaviorExt.RemoveBehaviors<T>(this BloonModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this BloonModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehaviors_T_(thisBloonModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelBehaviorExt.RemoveBehaviors_T_(thisBloonModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')