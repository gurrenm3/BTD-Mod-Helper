using Assets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.OnDestroy))]
    internal class Bloon_OnDestroy_Patch
    {
        [HarmonyPrefix]
        internal static bool Prefix(Bloon __instance)
        {
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance)
        {
            MelonMain.DoPatchMethods(mod =>
            {
                mod.OnBloonDestroy(__instance);
            });
        }
    }
}