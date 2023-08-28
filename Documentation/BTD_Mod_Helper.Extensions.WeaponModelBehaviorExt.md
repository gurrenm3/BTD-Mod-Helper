#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## WeaponModelBehaviorExt Class

Behavior extensions for WeaponModels

```csharp
public static class WeaponModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WeaponModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.AddBehavior_T_(thisWeaponModel,T)'></a>

## WeaponModelBehaviorExt.AddBehavior<T>(this WeaponModel, T) Method

Add a Behavior to this

```csharp
public static void AddBehavior<T>(this WeaponModel model, T behavior)
    where T : WeaponBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.AddBehavior_T_(thisWeaponModel,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.AddBehavior_T_(thisWeaponModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.AddBehavior_T_(thisWeaponModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.AddBehavior_T_(thisWeaponModel,T).T 'BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.AddBehavior<T>(this WeaponModel, T).T')

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.GetBehavior_T_(thisWeaponModel)'></a>

## WeaponModelBehaviorExt.GetBehavior<T>(this WeaponModel) Method

Return the first Behavior of type T

```csharp
public static T GetBehavior<T>(this WeaponModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.GetBehavior_T_(thisWeaponModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.GetBehavior_T_(thisWeaponModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.GetBehavior_T_(thisWeaponModel).T 'BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.GetBehavior<T>(this WeaponModel).T')

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.GetBehaviors_T_(thisWeaponModel)'></a>

## WeaponModelBehaviorExt.GetBehaviors<T>(this WeaponModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this WeaponModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.GetBehaviors_T_(thisWeaponModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.GetBehaviors_T_(thisWeaponModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.GetBehaviors_T_(thisWeaponModel).T 'BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.GetBehaviors<T>(this WeaponModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.HasBehavior_T_(thisWeaponModel)'></a>

## WeaponModelBehaviorExt.HasBehavior<T>(this WeaponModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this WeaponModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.HasBehavior_T_(thisWeaponModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.HasBehavior_T_(thisWeaponModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehavior_T_(thisWeaponModel,T)'></a>

## WeaponModelBehaviorExt.RemoveBehavior<T>(this WeaponModel, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveBehavior<T>(this WeaponModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehavior_T_(thisWeaponModel,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehavior_T_(thisWeaponModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehavior_T_(thisWeaponModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehavior_T_(thisWeaponModel,T).T 'BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehavior<T>(this WeaponModel, T).T')

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehavior_T_(thisWeaponModel)'></a>

## WeaponModelBehaviorExt.RemoveBehavior<T>(this WeaponModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this WeaponModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehavior_T_(thisWeaponModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehavior_T_(thisWeaponModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehaviors_T_(thisWeaponModel)'></a>

## WeaponModelBehaviorExt.RemoveBehaviors<T>(this WeaponModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this WeaponModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehaviors_T_(thisWeaponModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelBehaviorExt.RemoveBehaviors_T_(thisWeaponModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')