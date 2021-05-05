using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Harmony;

namespace BTD_Mod_Helper.Patches.Projectiles
{

    [HarmonyPatch(typeof(Projectile), nameof(Projectile.UpdatedModel))]
    internal class Projectile_UpdatedModel
    {
        [HarmonyPostfix]
        internal static void Postfix(Projectile __instance, Model modelToUse)
        {
            MelonMain.DoPatchMethods(mod => mod.OnProjectileModelChanged(__instance, modelToUse));
        }
    }
}