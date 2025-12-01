using System;
using BTD_Mod_Helper.Api.Internal;
using Il2CppAssets.Scripts.Unity.Audio;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine.AddressableAssets;
namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(AudioFactory), nameof(AudioFactory.CleanUp))]
internal static class AudioFactory_CleanUp
{
    [HarmonyPostfix]
    internal static void Postfix(AudioFactory __instance)
    {
        ResourceHandler.PopulateAudioFactory(__instance);
    }
}

[HarmonyPatch(typeof(AudioFactory), nameof(AudioFactory.ExecuteTask))]
internal static class AudioFactory_ExecuteTask
{
    [HarmonyPrefix]
    internal static void Prefix(AudioFactory __instance, AudioTask audioTask)
    {
        if (audioTask?.audioClipRef?.AssetGUID is { } id &&
            ResourceHandler.RandomAudioClipIds.TryGetValue(id, out var audioClips))
        {
            var clip = audioClips[Random.Shared.Next(audioClips.Count)];
            __instance.audioClipHandles[new AudioClipReference(id)] =
                Addressables.Instance.ResourceManager.CreateCompletedOperation(clip, "");
        }
    }
}