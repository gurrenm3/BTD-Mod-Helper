using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Audio;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(AudioFactory), nameof(AudioFactory.Start))]
internal class AudioFactory_Start
{
    [HarmonyPostfix]
    public static void Postfix(AudioFactory __instance)
    {
        foreach (var (id, clip) in ResourceHandler.AudioClips)
        {
            __instance.RegisterAudioClip(id, clip);
        }

        ModHelper.PerformHook(mod => mod.OnAudioFactoryStart(__instance));
    }
}