using BTD_Mod_Helper.Api.Legends;
using Il2CppAssets.Scripts.Simulation.Artifacts;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(ArtifactManager), nameof(ArtifactManager.Activate))]
internal static class ArtifactManager_Activate
{
    [HarmonyPrefix]
    internal static void Prefix(ArtifactManager __instance, string artifactName, ref bool __state)
    {
        __state = !__instance.activeArtifacts.Any(data => data.artifactBaseModel.name == artifactName);
    }

    [HarmonyPostfix]
    internal static void Postfix(ArtifactManager __instance, string artifactName, bool __state)
    {
        if (__state && ModArtifact.ArtifactCache.TryGetValue(artifactName, out var tuple))
        {
            tuple.Item1.OnActivated(__instance.Sim, tuple.Item2);
        }
    }
}