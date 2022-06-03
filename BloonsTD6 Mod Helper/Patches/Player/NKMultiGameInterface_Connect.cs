using System;
using HarmonyLib;
using MelonLoader;
using NinjaKiwi.NKMulti;
using Task = Il2CppSystem.Threading.Tasks.Task;

namespace BTD_Mod_Helper.Patches.Player
{
    [HarmonyPatch(typeof(NKMultiGameInterface), nameof(NKMultiGameInterface.Connect))]
    internal class NKMultiGameInterface_Connect
    {
        [HarmonyPostfix]
        public static void Postfix(NKMultiGameInterface __instance, ref Task __result) => __result.ContinueWith(new Action<Task>(task => OnConnectTaskFinished(__instance, task)));

        private static void OnConnectTaskFinished(NKMultiGameInterface instance, Task obj)
        {
            if (instance.IsConnected)
            {
                MelonMain.PerformHook(mod => { mod.OnConnected(instance); });
                instance.add_PeerConnectedEvent(new Action<int>((peerId) => OnPeerConnected(instance, peerId)));
                instance.add_PeerDisconnectedEvent(new Action<int>((peerId) => OnPeerDisconnected(instance, peerId)));
            }
            else
            {
                MelonMain.PerformHook(mod => { mod.OnConnectFail(instance); });
            }
        }

        private static void OnPeerDisconnected(NKMultiGameInterface nkGi, int peerId) => MelonMain.PerformHook(mod => { mod.OnPeerDisconnected(nkGi, peerId); });

        private static void OnPeerConnected(NKMultiGameInterface nkGi, int peerId) => MelonMain.PerformHook(mod => { mod.OnPeerConnected(nkGi, peerId); });
    }
}
