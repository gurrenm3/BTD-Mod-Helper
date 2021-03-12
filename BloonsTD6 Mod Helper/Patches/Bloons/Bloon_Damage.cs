using System;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Projectiles;
using BTD_Mod_Helper.Api;
using Harmony;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage), typeof(float), typeof(Il2CppStringArray), typeof(Projectile),
        typeof(bool), typeof(bool), typeof(bool), typeof(Tower), typeof(bool), typeof(Il2CppStringArray),
        typeof(bool), typeof(bool))]
    internal class Bloon_Damage
    {

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance, float totalAmount, Il2CppStringArray types,
            Projectile projectile, bool distributeToChildren, bool overrideDistributeBlocker, bool createEffect,
            Tower tower, Il2CppStringArray ignoreImmunityForBloonTypes, bool ignoreNonTargetable = false,
            bool blockSpawnChildren = false, bool canDestroyProjectile = true)
        {
            MelonMain.DoPatchMethods(mod =>
            {
                mod.PostBloonDamaged(__instance, totalAmount, types, projectile, distributeToChildren,
                    overrideDistributeBlocker, createEffect, tower, ignoreImmunityForBloonTypes,
                    ignoreNonTargetable, blockSpawnChildren, canDestroyProjectile);
            });
        }
    }
}