#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ProjectileModelBehaviorExt Class

Behavior Extensions for ProjectileModels

```csharp
public static class ProjectileModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ProjectileModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.AddBehavior_T_(thisProjectileModel,T)'></a>

## ProjectileModelBehaviorExt.AddBehavior<T>(this ProjectileModel, T) Method

Add a Behavior to this

```csharp
public static void AddBehavior<T>(this ProjectileModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.AddBehavior_T_(thisProjectileModel,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.AddBehavior_T_(thisProjectileModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.AddBehavior_T_(thisProjectileModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.AddBehavior_T_(thisProjectileModel,T).T 'BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.AddBehavior<T>(this ProjectileModel, T).T')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.GetBehavior_T_(thisProjectileModel)'></a>

## ProjectileModelBehaviorExt.GetBehavior<T>(this ProjectileModel) Method

Return the first Behavior of type T

```csharp
public static T GetBehavior<T>(this ProjectileModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.GetBehavior_T_(thisProjectileModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.GetBehavior_T_(thisProjectileModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.GetBehavior_T_(thisProjectileModel).T 'BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.GetBehavior<T>(this ProjectileModel).T')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.GetBehaviors_T_(thisProjectileModel)'></a>

## ProjectileModelBehaviorExt.GetBehaviors<T>(this ProjectileModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this ProjectileModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.GetBehaviors_T_(thisProjectileModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.GetBehaviors_T_(thisProjectileModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.GetBehaviors_T_(thisProjectileModel).T 'BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.GetBehaviors<T>(this ProjectileModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.HasBehavior_T_(thisProjectileModel,T)'></a>

## ProjectileModelBehaviorExt.HasBehavior<T>(this ProjectileModel, T) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this ProjectileModel model, out T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.HasBehavior_T_(thisProjectileModel,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.HasBehavior_T_(thisProjectileModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.HasBehavior_T_(thisProjectileModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.HasBehavior_T_(thisProjectileModel,T).T 'BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.HasBehavior<T>(this ProjectileModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.HasBehavior_T_(thisProjectileModel)'></a>

## ProjectileModelBehaviorExt.HasBehavior<T>(this ProjectileModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this ProjectileModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.HasBehavior_T_(thisProjectileModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.HasBehavior_T_(thisProjectileModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehavior_T_(thisProjectileModel,T)'></a>

## ProjectileModelBehaviorExt.RemoveBehavior<T>(this ProjectileModel, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveBehavior<T>(this ProjectileModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehavior_T_(thisProjectileModel,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehavior_T_(thisProjectileModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehavior_T_(thisProjectileModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehavior_T_(thisProjectileModel,T).T 'BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehavior<T>(this ProjectileModel, T).T')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehavior_T_(thisProjectileModel)'></a>

## ProjectileModelBehaviorExt.RemoveBehavior<T>(this ProjectileModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this ProjectileModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehavior_T_(thisProjectileModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehavior_T_(thisProjectileModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehaviors_T_(thisProjectileModel)'></a>

## ProjectileModelBehaviorExt.RemoveBehaviors<T>(this ProjectileModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this ProjectileModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehaviors_T_(thisProjectileModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelBehaviorExt.RemoveBehaviors_T_(thisProjectileModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')