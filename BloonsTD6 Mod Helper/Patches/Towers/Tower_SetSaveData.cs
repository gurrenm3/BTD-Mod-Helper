using Assets.Scripts.Models;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Towers
{

    [HarmonyPatch(typeof(Tower), nameof(Tower.SetSaveData))]
    internal class Tower_SetSaveData
    {
        [HarmonyPostfix]
        internal static void Postfix(Tower __instance, TowerSaveDataModel towerData)
        {
            MelonMain.DoPatchMethods(mod => mod.OnTowerLoaded(__instance, towerData));
        }
    }






}