using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Simulation.Track;
namespace BTD_Mod_Helper.Patches.Spawners;

[HarmonyPatch(typeof(Spawner), nameof(Spawner.AddEmissions))]
internal static class Spawner_AddEmissions
{
    [HarmonyPrefix]
    private static bool Prefix(ref Spawner __instance, ref Il2CppReferenceArray<BloonEmissionModel> newEmissions, ref int spawnRound, int emissionIndexOffset)
    {
        var result = true;
        var unref__instance = __instance;
        var unrefnewEmissions = newEmissions;
        var unrefspawnRound = spawnRound;
        ModHelper.PerformAdvancedModHook(mod=> result &= mod.PreBloonEmissionsAdded(ref unref__instance, ref unrefnewEmissions, ref unrefspawnRound, emissionIndexOffset));
        __instance = unref__instance;
        newEmissions = unrefnewEmissions;
        spawnRound = unrefspawnRound;
        return result;
    }
    [HarmonyPostfix]
    private static void Postfix(Spawner __instance, Il2CppReferenceArray<BloonEmissionModel> newEmissions, int spawnRound, int emissionIndexOffset)
    {
        ModHelper.PerformAdvancedModHook(mod =>
            mod.PostBloonEmissionsAdded(__instance, newEmissions, spawnRound, emissionIndexOffset));
    }
}