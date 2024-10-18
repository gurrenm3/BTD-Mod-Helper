using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Initialise))]
internal class Bloon_Initialize
{
    [HarmonyPrefix]
    internal static bool Prefix(Bloon __instance, Model modelToUse) => true;

    [HarmonyPostfix]
    internal static void Postfix(Bloon __instance, Model modelToUse)
    {
        ModHelper.PerformHook(mod => mod.OnBloonCreated(__instance));
        ModHelper.PerformHook(mod => mod.OnBloonModelUpdated(__instance, modelToUse));
    }
}