using HarmonyLib;
using NinjaKiwi.NKMulti;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(NKMultiConnection), nameof(NKMultiConnection.Receive))]
    internal class NKMultiConnection_Receive
    {
        [HarmonyPostfix]
        internal static void Postfix(NKMultiConnection __instance)
        {
            var messageQueue = __instance.ReceiveQueue;
            if (messageQueue == null || messageQueue.Count == 0)
                return;
            
            for (int i = 0; i < messageQueue.Count; i++)
            {
                var message = messageQueue.Dequeue();
                bool consumed = false;
                MelonMain.PerformHook(mod =>
                {
                    consumed |= mod.ActOnMessage(message);
                });
                if (!consumed)
                {
                    messageQueue.Enqueue(message);
                }
            }
        }
    }

}