using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Towers
{

    [HarmonyPatch(typeof(Tower), nameof(Tower.UnHighlight))]
    internal class Tower_UnHighlight
    {
        [HarmonyPostfix]
        internal static void Postfix(Tower __instance)
        {
            MelonMain.DoPatchMethods(mod => mod.OnTowerDeselected(__instance));
        }
    }






}