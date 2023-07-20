using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;
namespace BTD_Mod_Helper.Patches.Sim;

/// <summary>
/// A reimplementation of this method in a way that actually takes into account the multiplier fields of damage models
/// </summary>
[HarmonyPatch(typeof(Damage), nameof(Damage.Collide))]
internal static class Damage_Collide
{
    [HarmonyPrefix]
    private static bool Prefix(Damage __instance, Bloon bloon)
    {
        var projectileModel = __instance.projectile.projectileModel;

        if (!projectileModel.hasDamageModifiers) return true;

        var damageModel = __instance.damageModel;

        var totalAdd = 0f;
        var totalMult = 1f;
        var addOverMax = 0f;
        var multOverMax = 1f;

        var search = __instance.entity.GetBehaviorsFast<DamageModifier>();
        var enumerator = search.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var damageModifier = enumerator.found.Cast<DamageModifier>();

            var add = damageModifier.GetDamageAdditive(bloon);

            var mult = 1f;

            if (damageModifier.model.Is(out DamageModifierModel damageModifierModel))
            {
                mult = damageModifierModel.GetDamageMult(bloon);
                if (mult <= 0)
                {
                    mult = 1;
                }
            }

            if (damageModifier.GetMaxDamageOverride())
            {
                addOverMax += add;
                multOverMax *= mult;
            }
            else
            {
                totalAdd += add;
                totalMult *= mult;
            }
        }
        search.Dispose();

        var total = (damageModel.CapDamage((damageModel.damage + totalAdd) * totalMult) + addOverMax) * multOverMax;

        bloon.Damage(total, __instance.projectile, damageModel.distributeToChildren,
            damageModel.overrideDistributeBlocker, damageModel.createPopEffect, __instance.projectile.emittedBy,
            damageModel.immuneBloonProperties, true, projectileModel.ignoreNonTargetable);

        return false;
    }
}