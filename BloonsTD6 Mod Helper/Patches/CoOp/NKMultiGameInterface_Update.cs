using Il2CppNinjaKiwi.NKMulti;
namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(NKMultiGameInterface), nameof(NKMultiGameInterface.Update))]
    internal class NKMultiGameInterface_Update
    {
        [HarmonyPriority(Priority.HigherThanNormal)]
        [HarmonyPrefix]
        internal static void Prefix(ref NKMultiGameInterface __instance)
        {
            SessionData.Instance.NkGI = __instance;
            if (__instance.relayConnection == null) 
                return;

            // There exist some game states where send/receive might not be called
            // on a regular basis, e.g. co-op menu, leading to lost messages.

            // In addition, it seems the game will also clear the receive queue in some
            // cases. I think it's in this update method, but I (Sewer) have not confirmed this.
            // In any case, this should help prevent lost messages.  
            __instance.relayConnection.Receive();
            __instance.relayConnection.Send();
        }
    }
}