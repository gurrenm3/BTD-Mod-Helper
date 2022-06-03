using HarmonyLib;
using NinjaKiwi.NKMulti;

namespace BTD_Mod_Helper.Patches.Player
{
    [HarmonyPatch(typeof(NKMultiGameInterface), nameof(NKMultiGameInterface.Disconnect))]
    public class NKMultiGameInterface_Disconnect
    {
        [HarmonyPostfix]
        public static void Postfix(NKMultiGameInterface __instance) => MelonMain.PerformHook(mod => { mod.OnDisconnected(__instance); });
    }
}
