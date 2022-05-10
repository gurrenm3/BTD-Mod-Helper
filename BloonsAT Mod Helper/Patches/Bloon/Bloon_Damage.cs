using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage))]
    internal class Bloon_Damage
    {
        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance, float amount, DamageType damageType,
            Projectile projectile,  DamageDistributionMethod distributeToChildren,
            Tower damageBy, bool allowTransform )
        {
            MelonMain.DoPatchMethods(mod =>
            {
                mod.PostBloonDamaged(__instance, amount, damageType, projectile, 
                    distributeToChildren, damageBy, allowTransform);
            });
        }
    }
}