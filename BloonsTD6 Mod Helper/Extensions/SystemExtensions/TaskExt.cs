using System;
using System.Collections;
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
    public static void Then<T>(this Task<T> task, Action<T> action, Action<Il2CppSystem.AggregateException> error = null)
    {
        task.ContinueWith(new Action<Task>(t =>
        {
            var realTask = t.Cast<Task<T>>();
            if (realTask.IsCompletedSuccessfully)
            {
                action(realTask.Result);
            }
            else
            {
                error(t.Exception);
            }
        }));
    }

    /// <summary>
    /// Awaits a task as a coroutine
    /// </summary>
    public static IEnumerator Await(this Task task)
    {
        while (!task.IsCompleted)
        {
            yield return null;
        }
    }

    /// <summary>
    /// Awaits a task as a coroutine
    /// </summary>
    public static IEnumerator Await(this System.Threading.Tasks.Task task)
    {
        while (!task.IsCompleted)
        {
            yield return null;
        }
    }
}