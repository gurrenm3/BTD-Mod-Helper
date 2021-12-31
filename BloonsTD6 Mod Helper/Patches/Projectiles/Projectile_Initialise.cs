using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers.Projectiles;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Projectiles
{
    [HarmonyPatch(typeof(Projectile), nameof(Projectile.Initialise))]
    internal class Projectile_Initialise
    {
        [HarmonyPostfix]
        internal static void Postfix(Projectile __instance, Entity target, Model modelToUse)
        {
            ModHelper.PerformHook(mod => mod.OnProjectileCreated(__instance, target, modelToUse));
            ModHelper.PerformHook(mod => mod.OnProjectileModelChanged(__instance, modelToUse));
        }
    }
}