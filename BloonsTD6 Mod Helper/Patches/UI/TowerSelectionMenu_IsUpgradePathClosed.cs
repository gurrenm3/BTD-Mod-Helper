﻿using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(TowerSelectionMenu), nameof(TowerSelectionMenu.IsUpgradePathClosed))]
    internal class TowerSelectionMenu_IsUpgradePathClosed
    {
        [HarmonyPostfix]
        internal static void Postfix(TowerSelectionMenu __instance, int path, ref bool __result)
        {
            var tower = __instance.selectedTower.tower;
            if (tower.GetUpgrade(path)?.GetModUpgrade() is ModUpgrade modUpgrade && modUpgrade.RestrictUpgrading(tower))
            {
                __result = true;
            }
        }
    }
}