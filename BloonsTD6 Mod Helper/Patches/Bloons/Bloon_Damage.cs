namespace BTD_Mod_Helper.Patches.Bloons;

/*[HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage), typeof(float), typeof(Il2CppStringArray), typeof(Projectile),
    typeof(bool), typeof(bool), typeof(bool), typeof(Tower), typeof(bool), typeof(Il2CppStringArray),
    typeof(bool), typeof(bool))]
internal class Bloon_Damage
{
    [HarmonyPostfix]
    internal static void Postfix(Bloon __instance, float totalAmount, Projectile projectile, 
        bool distributeToChildren, bool overrideDistributeBlocker, bool createEffect, 
        Tower tower, BloonProperties immuneBloonProperties, 
        bool canDestroyProjectile = true, bool ignoreNonTargetable = false,
        bool blockSpawnChildren = false, bool ignoreInvunerable = false)
    {
        ModHelper.PerformHook(mod =>
        {
            mod.PostBloonDamaged(__instance, totalAmount, projectile, distributeToChildren,
                overrideDistributeBlocker, createEffect, tower, immuneBloonProperties,
                ignoreNonTargetable, blockSpawnChildren, canDestroyProjectile);
        });
    }
}*/