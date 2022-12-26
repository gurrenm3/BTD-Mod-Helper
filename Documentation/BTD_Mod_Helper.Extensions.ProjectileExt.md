#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ProjectileExt Class

Extensions for Projectiles

```csharp
public static class ProjectileExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ProjectileExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetDisplayNode(thisIl2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## ProjectileExt.GetDisplayNode(this Projectile) Method

Get the DisplayNode for this Projectile

```csharp
public static Il2CppAssets.Scripts.Simulation.Display.DisplayNode GetDisplayNode(this Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile projectile);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetDisplayNode(thisIl2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile')

#### Returns
[Il2CppAssets.Scripts.Simulation.Display.DisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Display.DisplayNode 'Il2CppAssets.Scripts.Simulation.Display.DisplayNode')

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetFactory(thisIl2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## ProjectileExt.GetFactory(this Projectile) Method

Return the Factory that creates Projectiles

```csharp
public static Il2CppAssets.Scripts.Simulation.Factory.Factory<Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile> GetFactory(this Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile projectile);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetFactory(thisIl2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile')

#### Returns
[Il2CppAssets.Scripts.Simulation.Factory.Factory&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Factory.Factory-1 'Il2CppAssets.Scripts.Simulation.Factory.Factory`1')[Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Factory.Factory-1 'Il2CppAssets.Scripts.Simulation.Factory.Factory`1')

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetUnityDisplayNode(thisIl2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## ProjectileExt.GetUnityDisplayNode(this Projectile) Method

Get the UnityDisplayNode for this Projectile. Is apart of DisplayNode. Needed to modify sprites

```csharp
public static Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode GetUnityDisplayNode(this Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile projectile);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProjectileExt.GetUnityDisplayNode(thisIl2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile')

#### Returns
[Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')