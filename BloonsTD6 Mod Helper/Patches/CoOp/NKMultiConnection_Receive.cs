using Il2CppNinjaKiwi.NKMulti;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(NKMultiConnection), nameof(NKMultiConnection.Receive))]
internal class NKMultiConnection_Receive
{
    [HarmonyPostfix]
    internal static void Postfix(NKMultiConnection __instance)
    {
        var messageQueue = __instance.ReceiveQueue;
        if (messageQueue == null || messageQueue.Count == 0)
            return;
            
        var messageCount = messageQueue.Count;
            for (var i = 0; i < messageCount; i++)
        {
            var message = messageQueue.Dequeue();
            var consumed = false;
            ModHelper.PerformHook(mod =>
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