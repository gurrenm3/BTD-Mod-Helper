using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
namespace BTD_Mod_Helper.Patches.Projectiles;

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