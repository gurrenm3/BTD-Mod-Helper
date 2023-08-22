﻿using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage))]
internal class Bloon_Damage
{
    [HarmonyPostfix]
    internal static void Postfix(Bloon __instance, float totalAmount)
    {
        if (ModBoss.Cache.TryGetValue(__instance.bloonModel.id, out var boss))
        {
            boss.OnDamage(__instance, totalAmount);
        }
    }
}