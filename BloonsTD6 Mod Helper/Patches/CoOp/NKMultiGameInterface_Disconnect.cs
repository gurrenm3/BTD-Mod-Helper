using Il2CppNinjaKiwi.NKMulti;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(NKMultiGameInterface), nameof(NKMultiGameInterface.Disconnect))]
    internal class NKMultiGameInterface_Disconnect
    {
        [HarmonyPostfix]
        public static void Postfix(NKMultiGameInterface __instance) => ModHelper.PerformHook(mod => { mod.OnDisconnected(__instance); });
    }
}
