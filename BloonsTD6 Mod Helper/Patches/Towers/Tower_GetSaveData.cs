using Assets.Scripts.Models;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using Harmony;

namespace BTD_Mod_Helper.Patches.Towers
{

    [HarmonyPatch(typeof(Tower), nameof(Tower.GetSaveData))]
    internal class Tower_GetSaveData
    {
        [HarmonyPostfix]
        internal static void Postfix(Tower __instance, TowerSaveDataModel __result)
        {
            MelonMain.DoPatchMethods(mod => mod.OnTowerSaved(__instance, __result));
        }
    }






}