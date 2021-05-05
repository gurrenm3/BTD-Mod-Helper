using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Behaviors;
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
            if (__instance._display is null) // This is a bugfix for BTD6. Untested but may also be a bug in BATTD
            {
                var behavior = __instance.entity.GetBehavior<DisplayBehavior>();
                if (behavior != null)
                    __instance._display = behavior;
            }
            
            MelonMain.DoPatchMethods(mod => mod.OnTowerCreated(__instance, target, modelToUse));
        }
    }
}