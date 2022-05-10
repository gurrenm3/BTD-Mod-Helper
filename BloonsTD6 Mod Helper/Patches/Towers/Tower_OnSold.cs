﻿using Assets.Scripts.Simulation.Towers;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Towers
{

    [HarmonyPatch(typeof(Tower), nameof(Tower.OnSold))]
    internal class Tower_OnSold
    {
        [HarmonyPostfix]
        internal static void Postfix(Tower __instance, float amount)
        {
            MelonMain.PerformHook(mod => mod.OnTowerSold(__instance, amount));
        }
    }






}