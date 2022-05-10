using System;
using static UnityEngine.UI.Button;

namespace BTD_Mod_Helper.Extensions
{
    public static class ButtonClickedEventExt
    {
        public static void AddListener(this ButtonClickedEvent clickEvent, Function funcToExecute)
        {
            clickEvent.AddListener(new Action(() => { funcToExecute(); }));
        }

        public static void SetListener(this ButtonClickedEvent clickEvent, Function funcToExecute)
        {
            clickEvent.RemoveAllPersistantCalls();
            clickEvent.AddListener(funcToExecute);
        }

        public static void RemovePersistantCall(this ButtonClickedEvent clickEvent, int index)
        {
            clickEvent.m_PersistentCalls.m_Calls.RemoveAt(index);
        }

        public static void RemoveAllPersistantCalls(this ButtonClickedEvent clickEvent)
        {
            clickEvent.m_PersistentCalls.Clear();
        }
    }
}
