using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.UpdatedModel))]
internal class Bloon_UpdatedModel
{
    [HarmonyPostfix]
    internal static void Postfix(Bloon __instance, Model modelToUse)
    {
        ModHelper.PerformHook(mod => mod.OnBloonModelUpdated(__instance, modelToUse));
    }
}