using System;
using System.Collections;
using BTD_Mod_Helper.Api.Enums;
using UnityEngine;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class for scheduling Tasks using MelonCoroutines
/// </summary>
public static class TaskScheduler
{
    /// <summary>
    /// Schedule a task to execute right now as a Coroutine
    /// </summary>
    /// <param name="iEnumerator"></param>
    public static void ScheduleTask(IEnumerator iEnumerator)
    {
        MelonCoroutines.Start(iEnumerator);
    }

    /// <summary>
    /// Schedule a task to execute later on as a Coroutine. By default will wait until the end of this current frame
    /// </summary>
    /// <param name="action">The action you want to execute once it's time to run your task</param>
    /// <param name="waitCondition">Wait for this to be true before executing task</param>
    public static void ScheduleTask(Action action, Func<bool> waitCondition = null)
    {
        ScheduleTask(action, ScheduleType.WaitForFrames, 0, waitCondition);
    }

    /// <summary>
    /// Schedule a task to execute later on as a Coroutine
    /// </summary>
    /// <param name="action">The action you want to execute once it's time to run your task</param>
    /// <param name="scheduleType">How you want to wait for your task</param>
    /// <param name="amountToWait">The amount you want to wait</param>
    /// ///
    /// <param name="waitCondition">Wait for this to be true before executing task</param>
    public static void ScheduleTask(Action action, ScheduleType scheduleType, int amountToWait,
        Func<bool> waitCondition = null)
    {
        try
        {
            MelonCoroutines.Start(WaiterCoroutine(action, scheduleType, amountToWait, waitCondition));
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("trampoline"))
                ModHelper.Warning("Notice: Melonloader Coroutine had a trampoline error." +
                                  " This shouldn't have any impact on the mod.");
        }
    }

    /// <summary>
    /// Schedule a task to execute later on as a Coroutine. By default will wait until the end of this current frame
    /// </summary>
    /// <param name="action">The action you want to execute once it's time to run your task</param>
    /// <param name="waitCondition">Wait for this to be true before executing task</param>
    /// <param name="stopCondition">Stop waiting if this becomes true</param>
    public static void ScheduleTask(Action action, Func<bool> waitCondition, Func<bool> stopCondition)
    {
        try
        {
            MelonCoroutines.Start(WaiterCoroutine(action, ScheduleType.WaitForFrames, 0, waitCondition, stopCondition));
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("trampoline"))
                ModHelper.Warning("Notice: Melonloader Coroutine had a trampoline error." +
                                  " This shouldn't have any impact on the mod.");
        }
    }

    /// <summary>
    /// Waits for a yield instruction and then completes with an action
    /// </summary>
    /// <param name="yieldInstruction"></param>
    /// <param name="onComplete"></param>
    /// <typeparam name="T"></typeparam>
    public static void ContinueWith<T>(this T yieldInstruction, Action<T> onComplete) where T : YieldInstruction
    {
        MelonCoroutines.Start(WaiterCoroutine(yieldInstruction, onComplete));
    }

    private static IEnumerator WaiterCoroutine<T>(T yieldInstruction, Action<T> onComplete)
    {
        yield return yieldInstruction;
        onComplete(yieldInstruction);
    }

    /// <summary>
    /// This coroutine will wait for amountToWait before finishing
    /// </summary>
    private static IEnumerator WaiterCoroutine(Action action, ScheduleType scheduleType, int amountToWait,
        Func<bool> waitCondition = null, Func<bool> stopCondition = null)
    {
        if (waitCondition != null)
        {
            while (true)
            {
                if (stopCondition != null && stopCondition())
                {
                    yield break;
                }

                if (waitCondition())
                {
                    break;
                }

                yield return null;
            }
        }

        var count = 0;
        switch (scheduleType)
        {
            case ScheduleType.WaitForSeconds:
                yield return new WaitForSecondsRealtime(amountToWait);
                break;
            case ScheduleType.WaitForFrames:
                while (amountToWait >= count)
                {
                    yield return new WaitForEndOfFrame();

                    count++;
                }
                break;
            case ScheduleType.WaitForSecondsScaled:
                yield return new WaitForSeconds(amountToWait);
                break;
        }

        action.Invoke();
    }
}