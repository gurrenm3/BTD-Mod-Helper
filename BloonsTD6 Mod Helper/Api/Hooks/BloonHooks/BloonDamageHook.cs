using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppInterop.Runtime;

using static BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook;

namespace BTD_Mod_Helper.Api.Hooks.BloonHooks;
/// <summary>
/// Provides a mod hook for intercepting the behavior of the Bloon.Damage method
/// </summary>
public class BloonDamageHook : ModHook<BloonDamageDelegate, BloonDamageManagedDelegate> {
    /// <summary>
    /// Delegate matching the unmanaged signature for Bloon damage.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void BloonDamageDelegate(nint @this, float totalAmount, nint projectile,
        byte distributeToChildren, byte overrideDistributeBlocker, byte createEffect, nint tower,
        int immuneBloonProperties, int originalImmuneBloonProperties, byte canDestroyProjectile,
        byte ignoreNonTargetable, byte blockSpawnChildren, byte ignoreInvunerable,
        HookNullable<int> powerActivatedByPlayerId, nint methodInfo);

    /// <summary>
    /// Delegate matching the managed signature for processing Bloon damage
    /// </summary>
    /// <returns>
    /// Returns false if further processing should be stopped, otherwise, true
    /// </returns>
    public delegate bool BloonDamageManagedDelegate(ref Bloon @this, ref float totalAmount, ref Projectile projectile,
        ref bool distributeToChildren, ref bool overrideDistributeBlocker, ref bool createEffect, ref Tower tower,
        ref BloonProperties immuneBloonProperties, ref BloonProperties originalImmuneBloonProperties, ref bool canDestroyProjectile,
        ref bool ignoreNonTargetable, ref bool blockSpawnChildren, ref bool ignoreInvunerable, ref HookNullable<int> powerActivatedByPlayerId);

    /// <summary>
    /// Gets the unmanaged hook method that intercepts Bloon.Damage
    /// </summary>
    protected override BloonDamageDelegate HookMethod => BloonDamage;

    /// <summary>
    /// Gets the target method info, the Bloon.Damage method
    /// </summary>
    protected override MethodInfo TargetMethod => AccessTools.Method(typeof(Bloon), nameof(Bloon.Damage));

    private void BloonDamage(nint @this, float totalAmount, nint projectile, byte distributeToChildren, 
        byte overrideDistributeBlocker, byte createEffect, nint tower, int immuneBloonProperties,
        int originalImmuneBloonProperties, byte canDestroyProjectile, byte ignoreNonTargetable,
        byte blockSpawnChildren, byte ignoreInvunerable, HookNullable<int> powerActivatedByPlayerId, nint methodInfo) {
        MethodInfo = methodInfo;

        var bloonValue = IL2CPP.PointerToValueGeneric<Bloon>(@this, false, false);
        var projectileValue = IL2CPP.PointerToValueGeneric<Projectile>(projectile, false, false);
        var distributeToChildrenBool = distributeToChildren > 0;
        var overrideDistributeBlockerBool = overrideDistributeBlocker > 0;
        var createEffectBool = createEffect > 0;

        var towerValue = IL2CPP.PointerToValueGeneric<Tower>(tower, false, false);

        var immuneBloonPropertiesFlags = (BloonProperties) (immuneBloonProperties + 1) - 1;
        var originalImmuneBloonPropertiesFlags = (BloonProperties) (originalImmuneBloonProperties + 1) - 1;

        var canDestroyProjectileBool = canDestroyProjectile > 0;
        var ignoreNonTargetableBool = ignoreNonTargetable > 0;
        var blockSpawnChildrenBool = blockSpawnChildren > 0;
        var ignoreInvunerableBool = ignoreInvunerable > 0;

        var stopEarly = false;

        foreach (var (_, value) in PrefixList.OrderByDescending(prefix => prefix.Key)) {
            foreach (var bloonDamageManagedDelegate in value) {
                stopEarly |= !bloonDamageManagedDelegate(ref bloonValue, ref totalAmount, ref projectileValue, ref distributeToChildrenBool,
                    ref overrideDistributeBlockerBool, ref createEffectBool, ref towerValue, ref immuneBloonPropertiesFlags,
                    ref originalImmuneBloonPropertiesFlags, ref canDestroyProjectileBool, ref ignoreNonTargetableBool,
                    ref blockSpawnChildrenBool, ref ignoreInvunerableBool, ref powerActivatedByPlayerId);
                if (stopEarly)
                    return;
            }
        } 

        _ = CallOriginalMethod(bloonValue?.Pointer, totalAmount, projectileValue?.Pointer, GetBoolValue(distributeToChildrenBool), GetBoolValue(overrideDistributeBlockerBool),
            GetBoolValue(createEffectBool), towerValue?.Pointer, (int)immuneBloonPropertiesFlags, (int)originalImmuneBloonPropertiesFlags, GetBoolValue(canDestroyProjectileBool),
            GetBoolValue(ignoreNonTargetableBool), GetBoolValue(blockSpawnChildrenBool), GetBoolValue(ignoreInvunerableBool), powerActivatedByPlayerId);

        foreach (var (_, value) in PostfixList.OrderByDescending(postfix => postfix.Key)) {
            foreach (var bloonDamageManagedDelegate in value) {
                stopEarly |= !bloonDamageManagedDelegate(ref bloonValue, ref totalAmount, ref projectileValue, ref distributeToChildrenBool,
                    ref overrideDistributeBlockerBool, ref createEffectBool, ref towerValue, ref immuneBloonPropertiesFlags,
                    ref originalImmuneBloonPropertiesFlags, ref canDestroyProjectileBool, ref ignoreNonTargetableBool,
                    ref blockSpawnChildrenBool, ref ignoreInvunerableBool, ref powerActivatedByPlayerId);
                if (stopEarly)
                    return;
            }
        }
    }
}
