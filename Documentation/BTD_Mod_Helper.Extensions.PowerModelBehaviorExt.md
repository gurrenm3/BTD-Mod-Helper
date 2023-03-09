#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## PowerModelBehaviorExt Class

Behavior extensions for PowerModels

```csharp
public static class PowerModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PowerModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisPowerModel,T)'></a>

## PowerModelBehaviorExt.AddBehavior<T>(this PowerModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this PowerModel model, T behavior)
    where T : PowerBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisPowerModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisPowerModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisPowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisPowerModel,T).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior<T>(this PowerModel, T).T')

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