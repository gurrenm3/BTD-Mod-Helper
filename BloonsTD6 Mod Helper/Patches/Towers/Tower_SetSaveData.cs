﻿using Assets.Scripts.Models.Profile;
using Assets.Scripts.Simulation.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(Tower), nameof(Tower.SetSaveData))]
internal class Tower_SetSaveData
{
    [HarmonyPostfix]
    internal static void Postfix(Tower __instance, TowerSaveDataModel towerData)
    {
        ModHelper.PerformHook(mod => mod.OnTowerLoaded(__instance, towerData));
    }
}