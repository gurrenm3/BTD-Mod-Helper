using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using Harmony;

namespace BTD_Mod_Helper.Patches.Towers
{
    [HarmonyPatch(typeof(Tower), nameof(Tower.Initialise))]
    internal class Tower_Initialise
    {
        [HarmonyPostfix]
        internal static void Postfix(Tower __instance, Entity target, Model modelToUse)
        {
            __instance.display = __instance.entity.displayBehaviorCache; // This is a bugfix

            MelonMain.DoPatchMethods(mod => mod.OnTowerCreated(__instance, target, modelToUse));
        }
    }






}