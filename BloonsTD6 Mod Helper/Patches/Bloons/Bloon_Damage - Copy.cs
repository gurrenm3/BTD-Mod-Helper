using System;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Projectiles;
using BTD_Mod_Helper.Api;
using HarmonyLib;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage))]
    internal class Bloon_Damage
    {

        /*[HarmonyPostfix]
        internal static void Postfix(Bloon __instance, float totalAmount, Projectile projectile, 
            bool distributeToChildren, bool overrideDistributeBlocker, bool createEffect, Tower tower, 
            BloonProperties immuneBloonProperties, bool canDestroyProjectile, bool ignoreNonTargetable, 
            bool blockSpawnChildren)
        {
            MelonMain.DoPatchMethods(mod =>
            {
                mod.PostBloonDamaged(__instance, totalAmount, projectile,
                distributeToChildren, overrideDistributeBlocker, createEffect, tower,
                immuneBloonProperties, canDestroyProjectile, ignoreNonTargetable,
                blockSpawnChildren);
            });
        }*/
    }
}