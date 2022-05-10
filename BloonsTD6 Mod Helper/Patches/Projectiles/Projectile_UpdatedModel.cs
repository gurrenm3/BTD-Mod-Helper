﻿using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Towers.Projectiles;

namespace BTD_Mod_Helper.Patches.Projectiles;

[HarmonyPatch(typeof(Projectile), nameof(Projectile.UpdatedModel))]
internal class Projectile_UpdatedModel
{
    [HarmonyPostfix]
    internal static void Postfix(Projectile __instance, Model modelToUse)
    {
        ModHelper.PerformHook(mod => mod.OnProjectileModelChanged(__instance, modelToUse));
    }
}