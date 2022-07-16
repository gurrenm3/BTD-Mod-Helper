#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ProjectileModelExt Class

Extensions for ProjectileModels

```csharp
public static class ProjectileModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ProjectileModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel)'></a>

## ProjectileModelExt.ApplyDisplay<T>(this ProjectileModel) Method

Applies a given ModDisplay to this ProjectileModel

```csharp
public static void ApplyDisplay<T>(this Assets.Scripts.Models.Towers.Projectiles.ProjectileModel projectileModel)
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel).T'></a>

`T`

The type of ModDisplay
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel).projectileModel'></a>

`projectileModel` [Assets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Assets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.CanHitCamo(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel)'></a>

## ProjectileModelExt.CanHitCamo(this ProjectileModel) Method

Returns whether a projectile is able to hit Camo bloons

```csharp
public static bool CanHitCamo(this Assets.Scripts.Models.Towers.Projectiles.ProjectileModel projectileModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.CanHitCamo(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel).projectileModel'></a>

`projectileModel` [Assets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Assets.Scripts.Models.Towers.Projectiles.ProjectileModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.GetDamageModel(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel)'></a>

## ProjectileModelExt.GetDamageModel(this ProjectileModel) Method

Get the DamageModel behavior from the list of behaviors

```csharp
public static Assets.Scripts.Models.Towers.Projectiles.Behaviors.DamageModel GetDamageModel(this Assets.Scripts.Models.Towers.Projectiles.ProjectileModel projectileModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.GetDamageModel(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel).projectileModel'></a>

`projectileModel` [Assets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Assets.Scripts.Models.Towers.Projectiles.ProjectileModel')

#### Returns
[Assets.Scripts.Models.Towers.Projectiles.Behaviors.DamageModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.Behaviors.DamageModel 'Assets.Scripts.Models.Towers.Projectiles.Behaviors.DamageModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.GetProjectileSims(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel)'></a>

## ProjectileModelExt.GetProjectileSims(this ProjectileModel) Method

Get all Projectile Simulations that have this ProjectileModel

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Simulation.Towers.Projectiles.Projectile> GetProjectileSims(this Assets.Scripts.Models.Towers.Projectiles.ProjectileModel projectileModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.GetProjectileSims(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel).projectileModel'></a>

`projectileModel` [Assets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Assets.Scripts.Models.Towers.Projectiles.ProjectileModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetHitCamo(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel,bool)'></a>

## ProjectileModelExt.SetHitCamo(this ProjectileModel, bool) Method

Makes a projectile model able to see Camo or not

```csharp
public static void SetHitCamo(this Assets.Scripts.Models.Towers.Projectiles.ProjectileModel projectileModel, bool canHitCamo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetHitCamo(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel,bool).projectileModel'></a>

`projectileModel` [Assets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Assets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Extensions.ProjectileModelExt.SetHitCamo(thisAssets.Scripts.Models.Towers.Projectiles.ProjectileModel,bool).canHitCamo'></a>

`canHitCamo` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')