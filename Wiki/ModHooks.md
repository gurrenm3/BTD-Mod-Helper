## Overview

Advanced users only.

The Mod Hook system enables interception and modification of game methods without extensive boilerplate or conflicts with other modifications. This system combines native hooking and managed delegates (Harmony‑style patching) to inject custom logic before or after the original method invocation.

At its core, the abstract class `ModHook<TNative, TManaged>` (where `TNative` is the unmanaged delegate type and `TManaged` is the managed delegate type) encapsulates:

- **Native Hook Attachment**  
  Utilizes `MelonLoader.NativeUtils.NativeHook<TNative>` to bind your hook to the target method.

- **Hook Management**  
  Maintains two priority‑sorted dictionaries for prefix and postfix hooks to control execution order.

- **Original Method Invocation**  
  Employs the `TrampolineInvoker` (constructed via Expression Trees) to invoke the original method accurately after hook execution.

## Internal Architecture

### Delegate Validation

Before any hook is created, the system verifies that `TNative` is decorated with  
```cs
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
```
If this requirement is not met, an error is logged and the hook setup is aborted.

### Hook Attachment Process

When `AddPrefix(TManaged method)` or `AddPostfix(TManaged method)` is called:

1. **Check Existing Hook**  
   Determines whether a native hook is already attached. If so, adds the prefix/postfix to the dictionary.

2. **Create and Attach Hook**  
   - Retrieves the method pointer from the IL2CPP runtime via  
     `Il2CppInteropUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod`.  
   - Converts the managed delegate to an unmanaged function pointer.  
   - Wraps the original method pointer with the custom delegate and attaches the native hook.

### Original Method Invocation

The `CallOriginalMethod` function uses a precompiled lambda in `TrampolineInvoker` to invoke the original method. This supports:

- **Prefix Hooks** (executed before the original method)  
- **Postfix Hooks** (executed after the original method)  
- **Replacement Hooks** (substituting the original method entirely)

### Hook Priority and Execution Order

Prefix and postfix hooks are stored in separate dictionaries keyed by priority. Hooks with higher priority values execute first, providing precise control over invocation order.

## Concrete Implementations

As of Bloons TD6 v48, the following hook implementations are provided:

- **`BloonDamageHook`**  
  Hooks into the Bloon.Damage method.

- **`BloonDegradeHook`**  
  Hooks into the Bloon.Degrade method.

Both implementations follow this pattern:

1. Convert native pointers to managed objects.  
2. Execute all prefix hooks; abort if any returns `false`.  
3. Invoke the original method via `CallOriginalMethod`.  
4. Execute all postfix hooks; abort if any returns `false`.

## Parameter Passing in Hooks

Hook methods may declare any parameters from the original signature:

- **By Value**  
  Non‑`Il2CppObjectBase` types may be passed by value.

- **By Reference**  
  Use the `ref` keyword to modify parameter values; changes propagate through the hook chain.

*Parameters inheriting from `Il2CppObjectBase` are implicitly passed by reference.*

### Prefix Hooks

Prefix hooks can inspect or adjust incoming parameters. Returning `false` prevents execution of subsequent hooks and the original method.

### Postfix Hooks

Postfix hooks execute after the original method. Modifications to `ref` parameters affect only subsequent postfix hooks, not the outcome of the original method.

## Examples

```cs
[HookTarget(typeof(BloonDamageHook), HookTargetAttribute.EHookType.Prefix)]
[HookPriority(HookPriorityAttribute.HIGHER)]
public static bool DamageHook(Bloon @this, float totalAmount) {
    if (@this != null) {
        MelonLogger.Msg($"Bloon ID {@this.Id} would receive {totalAmount:N0} damage.");
    }
    return false; // Abort further execution, including the original method.
}
```

```cs
[HookTarget(typeof(BloonDamageHook), HookTargetAttribute.EHookType.Postfix)]
public static bool PostDamageHook(Bloon @this, ref float totalAmount, Projectile projectile, ref bool distributeToChildren, 
ref bool overrideDistributeBlocker, ref bool createEffect, Tower tower, BloonProperties immuneBloonProperties, 
BloonProperties originalImmuneBloonProperties, ref bool canDestroyProjectile, ref bool ignoreNonTargetable, ref bool blockSpawnChildren, 
ref bool ignoreInvulnerable, HookNullable<int> powerActivatedByPlayerId) {
    if (@this != null) {
        MelonLogger.Msg($"Bloon ID {@this.Id} received {totalAmount:N0} damage.");
    }
    return true; // Continue execution of remaining hooks.
}
```