using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Bloons;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.UpdatedModel))]
    internal class Bloon_UpdatedModel
    {
        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance, Model modelToUse)
        {
            MelonMain.DoPatchMethods(mod => mod.OnBloonModelUpdated(__instance, modelToUse));
        }
    }
}