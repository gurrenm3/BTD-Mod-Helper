using System;
using static UnityEngine.UI.Button;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for ButtonClickedEvents
/// </summary>
public static class ButtonClickedEventExt
{
    /// <summary>
    /// Adds a function to the click event
    /// </summary>
    public static void AddListener(this ButtonClickedEvent clickEvent, Function funcToExecute)
    {
        clickEvent.AddListener(new Action(funcToExecute));
    }

    /// <summary>
    /// Sets a function to be the only listener of a click event
    /// </summary>
    public static void SetListener(this ButtonClickedEvent clickEvent, Function funcToExecute)
    {
        clickEvent.RemoveAllListeners();
        clickEvent.RemoveAllPersistantCalls();
        clickEvent.AddListener(funcToExecute);
    }

    /// <summary>
    /// Remove a specific persistent call from a click event
    /// </summary>
    public static void RemovePersistantCall(this ButtonClickedEvent clickEvent, int index)
    {
        clickEvent.m_PersistentCalls.m_Calls.RemoveAt(index);
    }

    /// <summary>
    /// Removes all specific persistent call from a click event
    /// </summary>
    public static void RemoveAllPersistantCalls(this ButtonClickedEvent clickEvent)
    {
        clickEvent.m_PersistentCalls.Clear();
    }
}