using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(Tower), nameof(Tower.UpdatedModel))]
internal class Tower_UpdatedModel {
    [HarmonyPostfix]
    internal static void Postfix(Tower __instance, Model modelToUse) {
        ModHelper.PerformHook(mod => mod.OnTowerModelChanged(__instance, modelToUse));
    }
}