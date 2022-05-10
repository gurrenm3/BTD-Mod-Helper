using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Behaviors;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(Tower), nameof(Tower.Initialise))]
internal class Tower_Initialise
{
    [HarmonyPostfix]
    internal static void Postfix(Tower __instance, Entity target, Model modelToUse)
    {
        // This is a bugfix. Doing this makes the display behavior more accessible. I added extra checks for redundency
        if (__instance.display is null)
        {
            if (__instance.entity.displayBehaviorCache is null)
                __instance.entity.displayBehaviorCache = __instance.entity.GetBehavior<DisplayBehavior>();

            if (__instance.entity.displayBehaviorCache != null)
                __instance.display = __instance.entity.displayBehaviorCache;
        }
        // end of bugfix


        ModHelper.PerformHook(mod => mod.OnTowerCreated(__instance, target, modelToUse));
        ModHelper.PerformHook(mod => mod.OnTowerModelChanged(__instance, modelToUse));
    }
}