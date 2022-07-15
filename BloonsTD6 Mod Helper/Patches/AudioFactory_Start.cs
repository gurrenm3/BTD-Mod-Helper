using Assets.Scripts.Unity.Audio;

namespace BTD_Mod_Helper.Patches{
    [HarmonyPatch(typeof(AudioFactory),"Start")]
    internal class AudioFactory_Start{
        [HarmonyPostfix]
        public static void Postfix(AudioFactory __instance){
            ModHelper.PerformHook(mod=>mod.OnAudioFactoryStart(__instance));
        }
    }
}
