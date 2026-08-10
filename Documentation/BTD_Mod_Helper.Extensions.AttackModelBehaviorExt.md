#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AttackModelBehaviorExt Class

Extensions for AttackModels

```csharp
public static class AttackModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AttackModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior(thisAttackModel,BTD_Mod_Helper.Api.Helpers.ModelHelper)'></a>

## AttackModelBehaviorExt.AddBehavior(this AttackModel, ModelHelper) Method

Adds a wrapped behavior from a ModelHelper to this tower

```csharp
public static void AddBehavior(this AttackModel model, BTD_Mod_Helper.Api.Helpers.ModelHelper behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior(thisAttackModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior(thisAttackModel,BTD_Mod_Helper.Api.Helpers.ModelHelper).behavior'></a>

`behavior` [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior_T_(thisAttackModel,T)'></a>

## AttackModelBehaviorExt.AddBehavior<T>(this AttackModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this AttackModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior_T_(thisAttackModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior_T_(thisAttackModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior_T_(thisAttackModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior_T_(thisAttackModel,T).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior<T>(this AttackModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel)'></a>

## AttackModelBehaviorExt.GetBehavior<T>(this AttackModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this AttackModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior<T>(this AttackModel).T')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel,int)'></a>

## AttackModelBehaviorExt.GetBehavior<T>(this AttackModel, int) Method

Return the index'th Behavior of type T, or null

```csharp
public static T GetBehavior<T>(this AttackModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel,int).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel,int).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior<T>(this AttackModel, int).T')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel,string)'></a>

## AttackModelBehaviorExt.GetBehavior<T>(this AttackModel, string) Method

Return the first Behavior of type T whose name contains the given string, or null

```csharp
public static T GetBehavior<T>(this AttackModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel,string).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel,string).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior<T>(this AttackModel, string).T')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehaviors_T_(thisAttackModel)'></a>

## AttackModelBehaviorExt.GetBehaviors<T>(this AttackModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this AttackModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehaviors_T_(thisAttackModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehaviors_T_(thisAttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehaviors_T_(thisAttackModel).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehaviors<T>(this AttackModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel)'></a>

## AttackModelBehaviorExt.HasBehavior<T>(this AttackModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this AttackModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,string)'></a>

## AttackModelBehaviorExt.HasBehavior<T>(this AttackModel, string) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasBehavior<T>(this AttackModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,string).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,string,T)'></a>

## AttackModelBehaviorExt.HasBehavior<T>(this AttackModel, string, T) Method

Check if this has a specific named Behavior and return it

```csharp
public static bool HasBehavior<T>(this AttackModel model, string nameContains, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,string,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,string,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,string,T).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,string,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,string,T).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior<T>(this AttackModel, string, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,T)'></a>

## AttackModelBehaviorExt.HasBehavior<T>(this AttackModel, T) Method

Check if this has a specific Behavior and return it

```csharp
public static bool HasBehavior<T>(this AttackModel model, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel,T).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior<T>(this AttackModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel)'></a>

## AttackModelBehaviorExt.RemoveBehavior<T>(this AttackModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this AttackModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,int)'></a>

## AttackModelBehaviorExt.RemoveBehavior<T>(this AttackModel, int) Method

Remove the index'th Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this AttackModel model, int index)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,int).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,string)'></a>

## AttackModelBehaviorExt.RemoveBehavior<T>(this AttackModel, string) Method

Remove the first Behavior of Type T whose name contains a certain string

```csharp
public static void RemoveBehavior<T>(this AttackModel model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,string).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,T)'></a>

## AttackModelBehaviorExt.RemoveBehavior<T>(this AttackModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this AttackModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,T).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior<T>(this AttackModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehaviors(thisAttackModel)'></a>

## AttackModelBehaviorExt.RemoveBehaviors(this AttackModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors(this AttackModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehaviors(thisAttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehaviors_T_(thisAttackModel)'></a>

## AttackModelBehaviorExt.RemoveBehaviors<T>(this AttackModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this AttackModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehaviors_T_(thisAttackModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehaviors_T_(thisAttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')