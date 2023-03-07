#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## TowerModelBehaviorExt Class

Behavior extensions for TowerModels

```csharp
public static class TowerModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TowerModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisTowerModel,T)'></a>

## TowerModelBehaviorExt.AddBehavior<T>(this TowerModel, T) Method

Add a Behavior to this

```csharp
public static void AddBehavior<T>(this TowerModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisTowerModel,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisTowerModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisTowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior_T_(thisTowerModel,T).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.AddBehavior<T>(this TowerModel, T).T')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.GetBehavior_T_(thisTowerModel)'></a>

## TowerModelBehaviorExt.GetBehavior<T>(this TowerModel) Method

Return the first Behavior of type T

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

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.HasBehavior_T_(thisTowerModel,T)'></a>

## TowerModelBehaviorExt.HasBehavior<T>(this TowerModel, T) Method

Check if this has a specific Behavior

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

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.md#BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior_T_(thisTowerModel,T).T 'BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehavior<T>(this TowerModel, T).T')

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

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelBehaviorExt.RemoveBehaviors_T_(thisTowerModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')