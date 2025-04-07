#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Hooks.BloonHooks](README.md#BTD_Mod_Helper.Api.Hooks.BloonHooks 'BTD_Mod_Helper.Api.Hooks.BloonHooks')

## BloonDegradeHook Class

Provides a mod hook for intercepting the behavior of the Bloon.Degrade method

```csharp
public class BloonDegradeHook : BTD_Mod_Helper.Api.Hooks.ModHook<BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeDelegate, BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeManagedDelegate>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [BTD_Mod_Helper.Api.Hooks.ModHook&lt;](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>')[BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeDelegate](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeDelegate 'BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeDelegate')[,](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>')[BloonDegradeManagedDelegate(Bloon, Projectile, bool, Tower, bool, HookNullable&lt;int&gt;)](BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeManagedDelegate(Bloon,Projectile,bool,Tower,bool,BTD_Mod_Helper.Api.Hooks.HookNullable_int_).md 'BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeManagedDelegate(Bloon, Projectile, bool, Tower, bool, BTD_Mod_Helper.Api.Hooks.HookNullable<int>)')[&gt;](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>') &#129106; BloonDegradeHook
### Properties

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.HookMethod'></a>

## BloonDegradeHook.HookMethod Property

Gets the unmanaged hook method that intercepts Bloon.Degrade

```csharp
protected override BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeDelegate HookMethod { get; }
```

#### Property Value
[BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeDelegate](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeDelegate 'BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.BloonDegradeDelegate')

<a name='BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.TargetMethod'></a>

## BloonDegradeHook.TargetMethod Property

Gets the target method info, the Bloon.Degrade method

```csharp
protected override System.Reflection.MethodInfo TargetMethod { get; }
```

#### Property Value
[System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')