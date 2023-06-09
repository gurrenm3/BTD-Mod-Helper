using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Simulation.Track;
namespace BTD_Mod_Helper.Patches.Spawners;

[HarmonyPatch(typeof(Spawner), nameof(Spawner.AddEmissions))]
internal static class Spawner_AddEmissions
{
    [HarmonyPostfix]
    private static void Postfix(Spawner __instance, Il2CppReferenceArray<BloonEmissionModel> newEmissions,
        int spawnRound, int emissionIndexOffset)
    {
        ModHelper.PerformHook(mod =>
            mod.OnBloonEmissionsAdded(__instance, newEmissions, spawnRound, emissionIndexOffset));
    }
}