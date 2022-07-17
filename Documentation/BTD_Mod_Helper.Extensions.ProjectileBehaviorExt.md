#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ProjectileBehaviorExt Class

Behavior extensions for projectiles

```csharp
public static class ProjectileBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ProjectileBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.AddProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile,T)'></a>

## ProjectileBehaviorExt.AddProjectileBehavior<T>(this Projectile, T) Method

Add a Behavior to this

```csharp
public static void AddProjectileBehavior<T>(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile, T behavior)
    where T : Assets.Scripts.Simulation.Towers.Projectiles.ProjectileBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.AddProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.AddProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile,T).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.AddProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.md#BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.AddProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile,T).T 'BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.AddProjectileBehavior<T>(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile, T).T')

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.GetProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## ProjectileBehaviorExt.GetProjectileBehavior<T>(this Projectile) Method

Return the first Behavior of type T

```csharp
public static T GetProjectileBehavior<T>(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile)
    where T : Assets.Scripts.Simulation.Towers.Projectiles.ProjectileBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.GetProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.GetProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

#### Returns
[T](BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.md#BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.GetProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).T 'BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.GetProjectileBehavior<T>(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile).T')

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.GetProjectileBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## ProjectileBehaviorExt.GetProjectileBehaviors<T>(this Projectile) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetProjectileBehaviors<T>(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile)
    where T : Assets.Scripts.Simulation.Towers.Projectiles.ProjectileBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.GetProjectileBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.GetProjectileBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.md#BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.GetProjectileBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).T 'BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.GetProjectileBehaviors<T>(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.HasProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## ProjectileBehaviorExt.HasProjectileBehavior<T>(this Projectile) Method

Check if this has a specific Behavior

```csharp
public static bool HasProjectileBehavior<T>(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile)
    where T : Assets.Scripts.Simulation.Towers.Projectiles.ProjectileBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.HasProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.HasProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## ProjectileBehaviorExt.RemoveProjectileBehavior<T>(this Projectile) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveProjectileBehavior<T>(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile)
    where T : Assets.Scripts.Simulation.Towers.Projectiles.ProjectileBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile,T)'></a>

## ProjectileBehaviorExt.RemoveProjectileBehavior<T>(this Projectile, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveProjectileBehavior<T>(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile, T behavior)
    where T : Assets.Scripts.Simulation.Towers.Projectiles.ProjectileBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile,T).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.md#BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehavior_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile,T).T 'BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehavior<T>(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile, T).T')

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## ProjectileBehaviorExt.RemoveProjectileBehaviors<T>(this Projectile) Method

Remove all Behaviors of type T

```csharp
public static void RemoveProjectileBehaviors<T>(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile)
    where T : Assets.Scripts.Simulation.Towers.Projectiles.ProjectileBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileBehaviorExt.RemoveProjectileBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')