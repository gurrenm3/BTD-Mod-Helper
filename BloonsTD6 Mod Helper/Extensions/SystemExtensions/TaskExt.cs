using System;
using Il2CppSystem.Threading.Tasks;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Il2Cpp Task
/// </summary>
public static class TaskExt
{
    /// <summary>
    /// Calls ContinueWith properly typed for IL2CPP
    /// </summary>
    public static void ContinueWithIl2Cpp<T>(this Task<T> task, Action<Task<T>> action)
    {
        task.ContinueWith(new Action<Task>(t => action(t.Cast<Task<T>>())));
    }

    /// <summary>
    /// Calls ContinueWith properly typed for IL2CPP with the task's Result
    /// </summary>
    public static void Then<T>(this Task<T> task, Action<T> action)
    {
        task.ContinueWith(new Action<Task>(t => action(t.Cast<Task<T>>().Result)));
    }
}