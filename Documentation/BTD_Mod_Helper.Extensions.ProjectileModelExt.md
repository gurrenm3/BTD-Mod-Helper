#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ProjectileModelExt Class

Extensions for ProjectileModels

```csharp
public static class ProjectileModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ProjectileModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.AddFilter(thisProjectileModel,FilterModel)'></a>

## ProjectileModelExt.AddFilter(this ProjectileModel, FilterModel) Method

Adds a new filter to this projectile model

```csharp
public static void AddFilter(this ProjectileModel projectile, FilterModel filter);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.AddFilter(thisProjectileModel,FilterModel).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.AddFilter(thisProjectileModel,FilterModel).filter'></a>

`filter` [Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel 'Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.ApplyDisplay_T_(thisProjectileModel)'></a>

## ProjectileModelExt.ApplyDisplay<T>(this ProjectileModel) Method

Applies a given ModDisplay to this ProjectileModel

```csharp
public static void ApplyDisplay<T>(this ProjectileModel projectileModel)
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.ApplyDisplay_T_(thisProjectileModel).T'></a>

`T`

The type of ModDisplay
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.ApplyDisplay_T_(thisProjectileModel).projectileModel'></a>

`projectileModel` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.CanHitCamo(thisProjectileModel)'></a>

## ProjectileModelExt.CanHitCamo(this ProjectileModel) Method

Returns whether a projectile is able to hit Camo bloons

```csharp
public static bool CanHitCamo(this ProjectileModel projectileModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.CanHitCamo(thisProjectileModel).projectileModel'></a>

`projectileModel` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.GetDamageModel(thisProjectileModel)'></a>

## ProjectileModelExt.GetDamageModel(this ProjectileModel) Method

Get the DamageModel behavior from the list of behaviors

```csharp
public static DamageModel GetDamageModel(this ProjectileModel projectileModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.GetDamageModel(thisProjectileModel).projectileModel'></a>

`projectileModel` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

#### Returns
[Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.DamageModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.DamageModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.DamageModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.GetProjectileSims(thisProjectileModel)'></a>

## ProjectileModelExt.GetProjectileSims(this ProjectileModel) Method

Get all Projectile Simulations that have this ProjectileModel

```csharp
public static System.Collections.Generic.List<Projectile> GetProjectileSims(this ProjectileModel projectileModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.GetProjectileSims(thisProjectileModel).projectileModel'></a>

`projectileModel` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.RemoveFilter(thisProjectileModel,FilterModel)'></a>

## ProjectileModelExt.RemoveFilter(this ProjectileModel, FilterModel) Method

Adds a new filter to this projectile model

```csharp
public static void RemoveFilter(this ProjectileModel projectile, FilterModel filter);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.RemoveFilter(thisProjectileModel,FilterModel).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.RemoveFilter(thisProjectileModel,FilterModel).filter'></a>

`filter` [Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel 'Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.RemoveFilter_T_(thisProjectileModel)'></a>

## ProjectileModelExt.RemoveFilter<T>(this ProjectileModel) Method

Adds a new filter to this projectile model

```csharp
public static void RemoveFilter<T>(this ProjectileModel projectile)
    where T : FilterModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.RemoveFilter_T_(thisProjectileModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.RemoveFilter_T_(thisProjectileModel).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetDisplay(thisProjectileModel,PrefabReference)'></a>

## ProjectileModelExt.SetDisplay(this ProjectileModel, PrefabReference) Method

Sets the display for this projectile

```csharp
public static void SetDisplay(this ProjectileModel projectileModel, PrefabReference display);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetDisplay(thisProjectileModel,PrefabReference).projectileModel'></a>

`projectileModel` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetDisplay(thisProjectileModel,PrefabReference).display'></a>

`display` [Il2CppAssets.Scripts.Utils.PrefabReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.PrefabReference 'Il2CppAssets.Scripts.Utils.PrefabReference')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetDisplay(thisProjectileModel,string)'></a>

## ProjectileModelExt.SetDisplay(this ProjectileModel, string) Method

Sets the display for this projectile

```csharp
public static void SetDisplay(this ProjectileModel projectileModel, string display);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetDisplay(thisProjectileModel,string).projectileModel'></a>

`projectileModel` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetDisplay(thisProjectileModel,string).display'></a>

`display` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetHitCamo(thisProjectileModel,bool)'></a>

## ProjectileModelExt.SetHitCamo(this ProjectileModel, bool) Method

Makes a projectile model able to see Camo or not

```csharp
public static void SetHitCamo(this ProjectileModel projectileModel, bool canHitCamo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetHitCamo(thisProjectileModel,bool).projectileModel'></a>

`projectileModel` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetHitCamo(thisProjectileModel,bool).canHitCamo'></a>

`canHitCamo` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')