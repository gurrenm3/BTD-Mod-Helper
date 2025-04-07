#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Hooks.BloonHooks](README.md#BTD_Mod_Helper.Api.Hooks.BloonHooks 'BTD_Mod_Helper.Api.Hooks.BloonHooks').[BloonDamageHook](BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.md 'BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook')

## BloonDamageHook.BloonDamageManagedDelegate(Bloon, float, Projectile, bool, bool, bool, Tower, BloonProperties, BloonProperties, bool, bool, bool, bool, HookNullable<int>) Delegate

Delegate matching the managed signature for processing Bloon damage

```csharp
public delegate bool BloonDamageHook.BloonDamageManagedDelegate(ref Bloon @this, ref float totalAmount, ref Projectile projectile, ref bool distributeToChildren, ref bool overrideDistributeBlocker, ref bool createEffect, ref Tower tower, ref BloonProperties immuneBloonProperties, ref BloonProperties originalImmuneBloonProperties, ref bool canDestroyProjectile, ref bool ignoreNonTargetable, ref bool blockSpawnChildren, ref bool ignoreInvunerable, ref BTD_Mod_Helper.Api.Hooks.HookNullable<int> powerActivatedByPlayerId);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).this'></a>

`this` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).totalAmount'></a>

`totalAmount` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).distributeToChildren'></a>

`distributeToChildren` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).overrideDistributeBlocker'></a>

`overrideDistributeBlocker` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).createEffect'></a>

`createEffect` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).immuneBloonProperties'></a>

`immuneBloonProperties` [Il2Cpp.BloonProperties](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.BloonProperties 'Il2Cpp.BloonProperties')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).originalImmuneBloonProperties'></a>

`originalImmuneBloonProperties` [Il2Cpp.BloonProperties](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.BloonProperties 'Il2Cpp.BloonProperties')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).canDestroyProjectile'></a>

`canDestroyProjectile` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).ignoreNonTargetable'></a>

`ignoreNonTargetable` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).blockSpawnChildren'></a>

`blockSpawnChildren` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).ignoreInvunerable'></a>

`ignoreInvunerable` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).powerActivatedByPlayerId'></a>

`powerActivatedByPlayerId` [BTD_Mod_Helper.Api.Hooks.HookNullable&lt;](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Returns false if further processing should be stopped, otherwise, true