﻿using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Simulation.Towers.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Towers
{
    [HarmonyPatch(typeof(ParagonTower), nameof(ParagonTower.GetDegreeMutator))]
    internal class ParagonTower_GetDegreeMutator
    {
        [HarmonyPostfix]
        internal static void Postfix(ParagonTower __instance, float investment, ParagonTowerModel.PowerDegreeMutator __result)
        {
            if (__instance.tower?.towerModel?.GetModTower() is ModTower modTower && modTower.ShouldCreateParagon)
            {
                modTower.paragonUpgrade?.ModifyPowerDegreeMutator(__result, investment, __result.degree);
            }
        }
    }
}