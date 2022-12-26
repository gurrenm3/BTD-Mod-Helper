#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## PowerModelBehaviorExt Class

Behavior extensions for PowerModels

```csharp
public static class PowerModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PowerModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel,T)'></a>

## PowerModelBehaviorExt.AddBehavior<T>(this PowerModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this Il2CppAssets.Scripts.Models.Powers.PowerModel model, T behavior)
    where T : Il2CppAssets.Scripts.Models.Powers.PowerBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel,T).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.AddBehavior<T>(this Il2CppAssets.Scripts.Models.Powers.PowerModel, T).T')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel)'></a>

## PowerModelBehaviorExt.GetBehaviors<T>(this PowerModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this Il2CppAssets.Scripts.Models.Powers.PowerModel model)
    where T : Il2CppAssets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.GetBehaviors<T>(this Il2CppAssets.Scripts.Models.Powers.PowerModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel,T)'></a>

## PowerModelBehaviorExt.RemoveBehavior<T>(this PowerModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this Il2CppAssets.Scripts.Models.Powers.PowerModel model, T behavior)
    where T : Il2CppAssets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel,T).T 'BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehavior<T>(this Il2CppAssets.Scripts.Models.Powers.PowerModel, T).T')

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehaviors_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel)'></a>

## PowerModelBehaviorExt.RemoveBehaviors<T>(this PowerModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this Il2CppAssets.Scripts.Models.Powers.PowerModel model)
    where T : Il2CppAssets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehaviors_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PowerModelBehaviorExt.RemoveBehaviors_T_(thisIl2CppAssets.Scripts.Models.Powers.PowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Powers.PowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Powers.PowerModel 'Il2CppAssets.Scripts.Models.Powers.PowerModel')