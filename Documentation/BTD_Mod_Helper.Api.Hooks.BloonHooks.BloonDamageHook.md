#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Hooks.BloonHooks](README.md#BTD_Mod_Helper.Api.Hooks.BloonHooks 'BTD_Mod_Helper.Api.Hooks.BloonHooks')

## BloonDamageHook Class

Provides a mod hook for intercepting the behavior of the Bloon.Damage method

```csharp
public class BloonDamageHook : BTD_Mod_Helper.Api.Hooks.ModHook<BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageDelegate, BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [BTD_Mod_Helper.Api.Hooks.ModHook&lt;](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>')[BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageDelegate](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageDelegate 'BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageDelegate')[,](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>')[BloonDamageManagedDelegate(Bloon, float, Projectile, bool, bool, bool, Tower, BloonProperties, BloonProperties, bool, bool, bool, bool, HookNullable&lt;int&gt;)](BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,BloonProperties,bool,bool,bool,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).md 'BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageManagedDelegate(Bloon, float, Projectile, bool, bool, bool, Tower, BloonProperties, BloonProperties, bool, bool, bool, bool, BTD_Mod_Helper.Api.Hooks.HookNullable<int>)')[&gt;](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>') &#129106; BloonDamageHook
### Properties

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.HookMethod'></a>

## BloonDamageHook.HookMethod Property

Gets the unmanaged hook method that intercepts Bloon.Damage

```csharp
protected override BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageDelegate HookMethod { get; }
```

#### Property Value
[BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageDelegate](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageDelegate 'BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.BloonDamageDelegate')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.TargetMethod'></a>

## BloonDamageHook.TargetMethod Property

Gets the target method info, the Bloon.Damage method

```csharp
protected override System.Reflection.MethodInfo TargetMethod { get; }
```

#### Property Value
[System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')