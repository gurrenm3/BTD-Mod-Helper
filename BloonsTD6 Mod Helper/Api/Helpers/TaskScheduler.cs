﻿using System;
using System.Collections;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Rounds;
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
    public static void ScheduleTask(Action action, ScheduleType scheduleType, float amountToWait,
        Func<bool> waitCondition = null)
    {
        try
        {
            MelonCoroutines.Start(Coroutine(action, scheduleType, amountToWait, waitCondition));
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("trampoline"))
                ModHelper.Warning("Notice: Melonloader Coroutine had a trampoline error." +
                                  " This shouldn't have any impact on the mod.");

        }
    }

    /// <summary>
    /// Will wait for amountToWait before executing your Action. If a waitCondition is specified it will continue waiting
    /// amountToWait until waitCondition is true
    /// </summary>
    /// <param name="action"></param>
    /// <param name="scheduleType"></param>
    /// <param name="amountToWait"></param>
    /// <param name="waitCondition"></param>
    /// <returns></returns>
    internal static IEnumerator Coroutine(Action action, ScheduleType scheduleType, float amountToWait,
        Func<bool> waitCondition = null)
    {
        if (waitCondition is null)
        {
            yield return WaiterCoroutine(scheduleType, amountToWait);
        }
        else
        {
            while (!waitCondition.Invoke())
            {
                yield return WaiterCoroutine(scheduleType, amountToWait);
            }
        }

        action.Invoke();
    }

    /// <summary>
    /// This coroutine will wait for amountToWait before finishing
    /// </summary>
    /// <param name="scheduleType"></param>
    /// <param name="amountToWait"></param>
    /// <returns></returns>
    private static IEnumerator WaiterCoroutine(ScheduleType scheduleType, float amountToWait)
    {
        switch (scheduleType)
        {
            case ScheduleType.WaitForSeconds:
                yield return new WaitForSecondsRealtime(amountToWait);
                break;
            case ScheduleType.WaitForFrames:
                for (var i = 0; i <= amountToWait; i++)
                {
                    yield return new WaitForEndOfFrame();
                }
                break;
        }
    }
}