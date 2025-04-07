using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppInterop.Runtime;
using static BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook;

namespace BTD_Mod_Helper.Api.Hooks.BloonHooks;

/// <summary>
/// Provides a mod hook for intercepting the behavior of the Bloon.Degrade method
/// </summary>
public class BloonDegradeHook : ModHook<BloonDegradeDelegate, BloonDegradeManagedDelegate>
{
    /// <summary>
    /// Delegate matching the unmanaged signature for Bloon damage
    /// </summary>
    /// <exclude/>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void BloonDegradeDelegate(nint @this, nint projectile, byte createEffect,
        nint tower, byte blockSpawnChildren, HookNullable<int> powerActivatedByPlayerId, nint methodInfo);

    /// <summary>
    /// Delegate matching the managed signature for processing Bloon damage
    /// </summary>
    /// <returns>
    /// Returns false if further processing should be stopped, otherwise, true
    /// </returns>
    /// <exclude/>
    public delegate bool BloonDegradeManagedDelegate(ref Bloon @this, ref Projectile projectile, ref bool createEffect,
        ref Tower tower, ref bool blockSpawnChildren, ref HookNullable<int> powerActivatedByPlayerId);

    /// <summary>
    /// Gets the unmanaged hook method that intercepts Bloon.Degrade
    /// </summary>
    protected override BloonDegradeDelegate HookMethod => BloonDegrade;

    /// <summary>
    /// Gets the target method info, the Bloon.Degrade method
    /// </summary>
    protected override MethodInfo TargetMethod => AccessTools.Method(typeof(Bloon), nameof(Bloon.Degrade));

    private void BloonDegrade(nint @this, nint projectile, byte createEffect,
        nint tower, byte blockSpawnChildren, HookNullable<int> powerActivatedByPlayerId, nint methodInfo)
    {
        MethodInfo = methodInfo;

        var bloonValue = IL2CPP.PointerToValueGeneric<Bloon>(@this, false, false);
        var projectileValue = IL2CPP.PointerToValueGeneric<Projectile>(projectile, false, false);
        var createEffectBool = createEffect > 0;

        var towerValue = IL2CPP.PointerToValueGeneric<Tower>(tower, false, false);

        var blockSpawnChildrenBool = blockSpawnChildren > 0;

        var stopEarly = false;

        foreach (var (_, value) in PrefixList.OrderByDescending(prefix => prefix.Key))
        {
            foreach (var BloonDegradeManagedDelegate in value)
            {
                stopEarly |= !BloonDegradeManagedDelegate(ref bloonValue, ref projectileValue, ref createEffectBool,
                    ref towerValue, ref blockSpawnChildrenBool, ref powerActivatedByPlayerId);
                if (stopEarly)
                    return;
            }
        }

        _ = CallOriginalMethod(bloonValue?.Pointer, projectileValue?.Pointer, GetBoolValue(createEffectBool),
            towerValue?.Pointer, GetBoolValue(blockSpawnChildrenBool), powerActivatedByPlayerId);

        foreach (var (_, value) in PostfixList.OrderByDescending(postfix => postfix.Key))
        {
            foreach (var BloonDegradeManagedDelegate in value)
            {
                stopEarly |= !BloonDegradeManagedDelegate(ref bloonValue, ref projectileValue, ref createEffectBool,
                    ref towerValue, ref blockSpawnChildrenBool, ref powerActivatedByPlayerId);
                if (stopEarly)
                    return;
            }
        }
    }
}