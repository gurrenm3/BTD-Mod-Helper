using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using Harmony;

namespace BTD_Mod_Helper.Patches.Towers
{

    [HarmonyPatch(typeof(Tower), nameof(Tower.Destroy))]
    internal class Tower_Destroy
    {
        [HarmonyPostfix]
        internal static void Postfix(Tower __instance)
        {
            MelonMain.DoPatchMethods(mod => mod.OnTowerDestroyed(__instance));
        }
    }






}