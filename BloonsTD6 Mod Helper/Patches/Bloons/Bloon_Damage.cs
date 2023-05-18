using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;

namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage))]
internal class Bloon_Damage
{
    [HarmonyPostfix]
    internal static void Postfix(Bloon __instance, float totalAmount, Projectile projectile,
        bool distributeToChildren, bool overrideDistributeBlocker, bool createEffect,
        Tower tower, BloonProperties immuneBloonProperties,
        bool canDestroyProjectile = true, bool ignoreNonTargetable = false,
        bool blockSpawnChildren = false, bool ignoreInvunerable = false)
    {
        if (ModBoss.Cache.TryGetValue(__instance.bloonModel.id, out var boss))
        {
            boss.OnDamage(__instance, totalAmount);
        }
    }
}