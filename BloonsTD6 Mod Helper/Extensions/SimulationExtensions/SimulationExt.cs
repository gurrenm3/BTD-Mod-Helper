using Il2CppAssets.Scripts.Models.Effects;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Objects;
using Vector3 = Il2CppAssets.Scripts.Simulation.SMath.Vector3;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for <see cref="Simulation"/>
/// </summary>
public static class SimulationExt
{
    /// <summary>
    /// Calls <see cref="Simulation.SpawnEffect"/> with the parameters from an <see cref="EffectModel"/>
    /// </summary>
    public static Entity SpawnEffect(this Simulation simulation, EffectModel effect, Vector3? position = null,
        IRootBehavior root = null)
    {
        return simulation.SpawnEffect(effect.assetId,
            effect.useCenterPosition ? Vector3.zero : position ?? Vector3.zero, 0,
            effect.scale, effect.lifespan, effect.fullscreen, root,
            effect.useTransformPosition, effect.useTransformPosition,
            effect.destroyOnTransformDestroy, effect.alwaysUseAge,
            useRoundTime: effect.useRoundTime);
    }

    /// <summary>
    /// Calls <see cref="Simulation.SpawnEffect"/> with the parameters from an <see cref="EffectModel"/>
    /// </summary>
    public static Entity SpawnEffect(this Simulation simulation, EffectModel effect, Vector3? position = null,
        RootBehavior root = null)
    {
        return simulation.SpawnEffect(effect, position, root.Cast<IRootBehavior>());
    }
}