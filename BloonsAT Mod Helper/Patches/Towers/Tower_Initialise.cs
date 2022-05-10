using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Behaviors;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Towers
{
    [HarmonyPatch(typeof(Tower), nameof(Tower.Initialise))]
    internal class Tower_Initialise
    {
        [HarmonyPostfix]
        internal static void Postfix(Tower __instance, Entity target, Model modelToUse)
        {
            if (__instance._display is null) // This is a bugfix for BTD6. Untested but may also be a bug in BATTD
            {
                __instance._display = __instance.entity.GetBehavior<DisplayBehavior>();
            }
            

            MelonMain.DoPatchMethods(mod => mod.OnTowerCreated(__instance, target, modelToUse));
        }
    }
}