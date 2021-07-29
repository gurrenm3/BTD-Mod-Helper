using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Projectiles
{
    [HarmonyPatch(typeof(Projectile), nameof(Projectile.Initialise))]
    internal class Projectile_Initialise
    {
        [HarmonyPostfix]
        internal static void Postfix(Projectile __instance, Entity target, Model modelToUse)
        {
            MelonMain.DoPatchMethods(mod => mod.OnProjectileCreated(__instance, target, modelToUse));
        }
    }
}