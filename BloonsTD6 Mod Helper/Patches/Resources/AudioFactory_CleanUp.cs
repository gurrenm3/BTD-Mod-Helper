using BTD_Mod_Helper.Api.Internal;
using Il2CppAssets.Scripts.Unity.Audio;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine.AddressableAssets;
namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(AudioFactory), nameof(AudioFactory.CleanUp))]
internal static class AudioFactory_CleanUp
{
    [HarmonyPostfix]
    internal static void Postfix(AudioFactory __instance)
    {
        foreach (var (id, clip) in ResourceHandler.AudioClips)
        {
            __instance.audioClipHandles[new AudioClipReference(id)] =
                Addressables.Instance.ResourceManager.CreateCompletedOperation(clip, "");
        }
    }
}