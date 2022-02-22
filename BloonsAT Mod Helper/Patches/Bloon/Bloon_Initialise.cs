using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Initialise))]
    internal class Bloon_Initialise
    {
        [HarmonyPrefix]
        internal static bool Prefix(Bloon __instance, Model modelToUse)
        {
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance)
        {
            MelonMain.DoPatchMethods(mod =>
            {
                mod.OnBloonCreated(__instance);
            });
        }
    }
}