using System;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Effects;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Other miscellaneous extensions for various Model classes
/// </summary>
public static class MiscModelExt
{
    /// <summary>
    /// Applies the given ModDisplay to this effect
    /// </summary>
    public static void ApplyDisplay<T>(this EffectModel effectModel) where T : ModDisplay, new()
    {
        ModContent.GetInstance<T>().Apply(effectModel);
    }

    /// <summary>
    /// Applies the given ModDisplay to this asset path
    /// </summary>
    public static void ApplyDisplay<T>(this AssetPathModel effectModel) where T : ModDisplay, new()
    {
        ModContent.GetInstance<T>().Apply(effectModel);
    }

    /// <summary>
    /// Gets the damageMultiplier field for a DamageModifierModel
    /// </summary>
    [Obsolete("Now a real method on damage modifiers")]
    public static float GetDamageMult(this DamageModifierModel model, Bloon bloon)
    {
        var before = 1f;

        if (model.Is(out DamageModifierForTagModel tag))
        {
            before = tag.damageAddative;
            tag.damageAddative = tag.damageMultiplier;
        }

        if (model.Is(out DamageModifierForBloonTypeModel bloonType))
        {
            before = bloonType.damageAdditive;
            bloonType.damageAdditive = bloonType.damageMultiplier;
        }

        if (model.Is(out DamageModifierForBloonStateModel bloonState))
        {
            before = bloonState.damageAdditive;
            bloonState.damageAdditive = bloonState.damageMultiplier;
        }

        var result = model.GetDamageAdditive(bloon);

        if (model.Is(out tag))
        {
            tag.damageAddative = before;
        }

        if (model.Is(out bloonType))
        {
            bloonType.damageAdditive = before;
        }

        if (model.Is(out bloonState))
        {
            bloonState.damageAdditive = before;
        }

        return result;
    }

    /// <summary>
    /// Updates the <see cref="ParallelEmissionModel.offsetStart"/> to be consistent with the
    /// <see cref="ParallelEmissionModel.count"/> and <see cref="ParallelEmissionModel.spreadLength"/>
    /// </summary>
    public static void UpdateOffset(this ParallelEmissionModel parallelEmissionModel)
    {
        parallelEmissionModel.offsetStart = (1 - parallelEmissionModel.count) * parallelEmissionModel.spreadLength * 0.5f;
    }

    /// <summary>
    /// Applies the given ModBloonOverlay to this behavior
    /// </summary>
    public static void ApplyOverlay<T>(this ProjectileBehaviorWithOverlayModel projectileBehaviorWithOverlayModel) where T : ModBloonOverlay, new()
    {
        ModContent.GetInstance<T>().Apply(projectileBehaviorWithOverlayModel);
    }
}