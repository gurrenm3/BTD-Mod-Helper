using System;
using System.Collections.Generic;
using HarmonyLib;
using Assets.Scripts.Unity.UI;
using Assets.Scripts.Unity.Towers;
using Assets.Scripts.Models.Towers.TowerGraph.DataModel;
using Assets.Scripts.Models.Towers;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(TowerHelper), nameof(TowerHelper.CreateTowerInGame))]//, new Type[] { typeof(string), typeof(Graph), typeof(int), typeof(string) })]
    internal class TowerHelper_CreateTowerInGame
    {
        [HarmonyPostfix]
        internal static void Postfix(TowerModel __result)
        {
            Api.SessionData.instance.inGameTowerModels.Add(__result);
        }
    }
}
