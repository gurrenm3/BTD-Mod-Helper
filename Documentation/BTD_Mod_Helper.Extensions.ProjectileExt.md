#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ProjectileExt Class

Extensions for Projectiles

```csharp
public static class ProjectileExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ProjectileExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetDisplayNode(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## ProjectileExt.GetDisplayNode(this Projectile) Method

Get the DisplayNode for this Projectile

```csharp
public static Assets.Scripts.Simulation.Display.DisplayNode GetDisplayNode(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetDisplayNode(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

#### Returns
[Assets.Scripts.Simulation.Display.DisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Display.DisplayNode 'Assets.Scripts.Simulation.Display.DisplayNode')

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetFactory(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## ProjectileExt.GetFactory(this Projectile) Method

(Cross-Game compatible) Return the Factory that creates Projectiles

```csharp
public static Assets.Scripts.Simulation.Factory.Factory<Assets.Scripts.Simulation.Towers.Projectiles.Projectile> GetFactory(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetFactory(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

#### Returns
[Assets.Scripts.Simulation.Factory.Factory&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Factory.Factory-1 'Assets.Scripts.Simulation.Factory.Factory`1')[Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Factory.Factory-1 'Assets.Scripts.Simulation.Factory.Factory`1')

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetUnityDisplayNode(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## ProjectileExt.GetUnityDisplayNode(this Projectile) Method

Get the UnityDisplayNode for this Projectile. Is apart of DisplayNode. Needed to modify sprites

```csharp
public static Assets.Scripts.Unity.Display.UnityDisplayNode GetUnityDisplayNode(this Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetUnityDisplayNode(thisAssets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

#### Returns
[Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')