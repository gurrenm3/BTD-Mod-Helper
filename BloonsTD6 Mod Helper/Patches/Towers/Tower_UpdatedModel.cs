using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Towers;
using Harmony;

namespace BTD_Mod_Helper.Patches.Towers
{
    [HarmonyPatch(typeof(Tower), nameof(Tower.UpdatedModel))]
    internal class Tower_UpdatedModel
    {
        [HarmonyPostfix]
        internal static void Postfix(Tower __instance, Model modelToUse)
        {
            MelonMain.DoPatchMethods(mod => mod.OnTowerModelChanged(__instance, modelToUse));
        }
    }
}