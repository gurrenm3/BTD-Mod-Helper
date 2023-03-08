using System.Collections.Generic;
using Il2CppSystem;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extension methods for System.Action
/// </summary>
public static class ActionExt
{
    /// <summary>
    /// Return this as a System.Action
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public static Action ToIl2CppSystemAction(this System.Action action)
    {
        return action;
    }

    /// <summary>
    /// Invoke all actions in the list
    /// </summary>
    /// <param name="actions">list of actions to invoke</param>
    public static void InvokeAll(this List<System.Action> actions)
    {
        actions.ForEach(action => action.Invoke());
    }

    /// <summary>
    /// Invoke all actions in the list
    /// </summary>
    /// <typeparam name="T">argument type</typeparam>
    /// <param name="actions">list of actions to invoke</param>
    /// <param name="argument">argument to pass in while invoking</param>
    public static void InvokeAll<T>(this List<System.Action<T>> actions, T argument)
    {
        actions.ForEach(action => action.Invoke(argument));
    }


    /// <summary>
    /// Invoke all actions in the list
    /// </summary>
    /// <param name="actions">list of actions to invoke</param>
    public static void InvokeAll(this List<Action> actions)
    {
        actions.ForEach(action => action.Invoke());
    }

    /// <summary>
    /// Invoke all actions in the list
    /// </summary>
    /// <typeparam name="T">argument type</typeparam>
    /// <param name="actions">list of actions to invoke</param>
    /// <param name="argument">argument to pass in while invoking</param>
    public static void InvokeAll<T>(this List<Action<T>> actions, T argument)
    {
        actions.ForEach(action => action.Invoke(argument));
    }


    /// <summary>
    /// Invoke all actions in the list
    /// </summary>
    /// <param name="actions">list of actions to invoke</param>
    public static void InvokeAll(this Il2CppSystem.Collections.Generic.List<Action> actions)
    {
        foreach (var action in actions)
            action.Invoke();
    }

    /// <summary>
    /// Invoke all actions in the list
    /// </summary>
    /// <typeparam name="T">argument type</typeparam>
    /// <param name="actions">list of actions to invoke</param>
    /// <param name="argument">argument to pass in while invoking</param>
    public static void InvokeAll<T>(this Il2CppSystem.Collections.Generic.List<Action<T>> actions, T argument)
    {
        foreach (var action in actions)
            action.Invoke(argument);
    }


    /// <summary>
    /// Invoke all actions in the list
    /// </summary>
    /// <param name="actions">list of actions to invoke</param>
    public static void InvokeAll(this Il2CppSystem.Collections.Generic.List<System.Action> actions)
    {
        foreach (var action in actions)
            action.Invoke();
    }

    /// <summary>
    /// Invoke all actions in the list
    /// </summary>
    /// <typeparam name="T">argument type</typeparam>
    /// <param name="actions">list of actions to invoke</param>
    /// <param name="argument">argument to pass in while invoking</param>
    public static void InvokeAll<T>(this Il2CppSystem.Collections.Generic.List<System.Action<T>> actions, T argument)
    {
        foreach (var action in actions)
            action.Invoke(argument);
    }
}