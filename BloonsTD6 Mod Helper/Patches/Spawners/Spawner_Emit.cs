using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Track;
namespace BTD_Mod_Helper.Patches.Spawners;

[HarmonyPatch(typeof(Spawner), nameof(Spawner.Emit))]
internal static class Spawner_Emit
{
    [HarmonyPostfix]
    private static void Postfix(Spawner __instance, BloonModel bloonModel, int roundNumber, int emissionIndex,
        float startingDist, ref Bloon __result)
    {
        var unref__result = __result;
        ModHelper.PerformHook(mod =>
            mod.OnBloonEmitted(__instance, bloonModel, roundNumber, emissionIndex, startingDist, ref unref__result));
        __result = unref__result;
    }
}