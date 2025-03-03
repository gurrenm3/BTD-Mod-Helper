using BTD_Mod_Helper.Api.Legends;
using Il2CppAssets.Scripts.Models.Artifacts;
using UnityEngine;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(RogueArtifactDisplayIcon), nameof(RogueArtifactDisplayIcon.Bind))]
internal class RogueArtifactDisplayIcon_Bind
{
    [HarmonyPostfix]
    internal static void Postfix(RogueArtifactDisplayIcon __instance, ArtifactModelBase artifactModel)
    {
        ModArtifact.HandleSmallIcon(__instance, artifactModel.baseId);
    }

}