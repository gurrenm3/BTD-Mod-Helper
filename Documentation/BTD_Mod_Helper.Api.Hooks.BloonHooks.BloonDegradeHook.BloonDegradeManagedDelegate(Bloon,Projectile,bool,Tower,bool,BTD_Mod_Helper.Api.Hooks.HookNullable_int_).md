#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Hooks.BloonHooks](README.md#BTD_Mod_Helper.Api.Hooks.BloonHooks 'BTD_Mod_Helper.Api.Hooks.BloonHooks').[BloonDegradeHook](BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.md 'BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook')

## BloonDegradeHook.BloonDegradeManagedDelegate(Bloon, Projectile, bool, Tower, bool, HookNullable<int>) Delegate

Delegate matching the managed signature for processing Bloon damage

```csharp
public delegate bool BloonDegradeHook.BloonDegradeManagedDelegate(ref Bloon @this, ref Projectile projectile, ref bool createEffect, ref Tower tower, ref bool blockSpawnChildren, ref BTD_Mod_Helper.Api.Hooks.HookNullable<int> powerActivatedByPlayerId);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeManagedDelegate(Bloon,Projectile,bool,Tower,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).this'></a>

`this` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeManagedDelegate(Bloon,Projectile,bool,Tower,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeManagedDelegate(Bloon,Projectile,bool,Tower,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).createEffect'></a>

`createEffect` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeManagedDelegate(Bloon,Projectile,bool,Tower,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeManagedDelegate(Bloon,Projectile,bool,Tower,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).blockSpawnChildren'></a>

`blockSpawnChildren` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeManagedDelegate(Bloon,Projectile,bool,Tower,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).powerActivatedByPlayerId'></a>

`powerActivatedByPlayerId` [BTD_Mod_Helper.Api.Hooks.HookNullable&lt;](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Returns false if further processing should be stopped, otherwise, true