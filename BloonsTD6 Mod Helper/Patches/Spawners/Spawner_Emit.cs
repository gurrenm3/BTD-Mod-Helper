using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Track;
namespace BTD_Mod_Helper.Patches.Spawners;

[HarmonyPatch(typeof(Spawner), nameof(Spawner.Emit))]
internal static class Spawner_Emit
{
    [HarmonyPrefix]
    private static bool Prefix(ref Spawner __instance, ref BloonModel bloon, ref int roundNumber, ref int emissionIndex, ref float startingDist, ref Bloon __result)
    {
        var result = true;
        var unref__instance = __instance;
        var unrefbloon = bloon;
        var unrefroundNumber = roundNumber;
        var unrefemissionIndex = emissionIndex;
        var unrefstartingDist = startingDist;
        var unref__result = __result;
        ModHelper.PerformAdvancedModHook(mod=> result &= mod.PreBloonEmitted(ref unref__instance, ref unrefbloon, ref unrefroundNumber, ref unrefemissionIndex, ref unrefstartingDist, ref unref__result));
        __instance = unref__instance;
        bloon = unrefbloon;
        roundNumber = unrefroundNumber;
        emissionIndex = unrefemissionIndex;
        startingDist = unrefstartingDist;
        __result = unref__result;
        return result;
    }
    [HarmonyPostfix]
    private static void Postfix(Spawner __instance, BloonModel bloon, int roundNumber, int emissionIndex, float startingDist, ref Bloon __result)
    {
        var unref__result = __result;
        ModHelper.PerformAdvancedModHook(mod => mod.PostBloonEmitted(__instance, bloon, roundNumber, emissionIndex, startingDist, ref unref__result));
        __result = unref__result;
    }
}