using System;
using Il2CppNinjaKiwi.NKMulti;
using Il2CppSystem.Threading.Tasks;
namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(NKMultiGameInterface), nameof(NKMultiGameInterface.Connect))]
    internal class NKMultiGameInterface_Connect
    {
        [HarmonyPostfix]
        public static void Postfix(NKMultiGameInterface __instance, ref Task __result) => __result.ContinueWith(new Action<Task>(_ => OnConnectTaskFinished(__instance)));

        private static void OnConnectTaskFinished(NKMultiGameInterface instance)
        {
            if (instance.IsConnected)
            {
                ModHelper.PerformHook(mod => mod.OnConnected(instance));
                instance.add_PeerConnectedEvent(new Action<int>(peerId => OnPeerConnected(instance, peerId)));
                instance.add_PeerDisconnectedEvent(new Action<int>(peerId => OnPeerDisconnected(instance, peerId)));
            }
            else
            {
                ModHelper.PerformHook(mod => mod.OnConnectFail(instance));
            }
        }

        private static void OnPeerDisconnected(NKMultiGameInterface nkGi, int peerId) => ModHelper.PerformHook(mod => mod.OnPeerDisconnected(nkGi, peerId));

        private static void OnPeerConnected(NKMultiGameInterface nkGi, int peerId) => ModHelper.PerformHook(mod => mod.OnPeerConnected(nkGi, peerId));
    }
}
