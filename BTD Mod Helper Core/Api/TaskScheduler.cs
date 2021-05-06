using BTD_Mod_Helper.Api.Enums;
using System;
using System.Collections;
using UnityEngine;

namespace BTD_Mod_Helper.Api
{
    public static class TaskScheduler
    {
        /// <summary>
        /// (Cross-Game compatible) Schedule a task to execute right now as a Coroutine
        /// </summary>
        /// <param name="game"></param>
        /// <param name="iEnumerator"></param>
        public static void ScheduleTask(IEnumerator iEnumerator) => MelonLoader.MelonCoroutines.Start(iEnumerator);

        /// <summary>
        /// (Cross-Game compatible) Schedule a task to execute later on as a Coroutine. By default will wait until the end of this current frame
        /// </summary>
        /// <param name="game"></param>
        /// <param name="action">The action you want to execute once it's time to run your task</param>
        /// <param name="waitCondition">Wait for this to be true before executing task</param>
        public static void ScheduleTask(Action action, Func<bool> waitCondition = null)
        {
            ScheduleTask(action, ScheduleType.WaitForFrames, 0, waitCondition);
        }

        /// <summary>
        /// (Cross-Game compatible) Schedule a task to execute later on as a Coroutine
        /// </summary>
        /// <param name="game"></param>
        /// <param name="action">The action you want to execute once it's time to run your task</param>
        /// <param name="scheduleType">How you want to wait for your task</param>
        /// <param name="amountToWait">The amount you want to wait</param>
        /// /// <param name="waitCondition">Wait for this to be true before executing task</param>
        public static void ScheduleTask(Action action, ScheduleType scheduleType, int amountToWait, Func<bool> waitCondition = null)
        {
            MelonLoader.MelonCoroutines.Start(Coroutine(action, scheduleType, amountToWait, waitCondition));
        }

        /// <summary>
        /// Will wait for amountToWait before executing your Action. If a waitCondition is specified it will continue waiting amountToWait until waitCondition is true
        /// </summary>
        /// <param name="action"></param>
        /// <param name="scheduleType"></param>
        /// <param name="amountToWait"></param>
        /// <param name="waitContition"></param>
        /// <returns></returns>
        internal static IEnumerator Coroutine(Action action, ScheduleType scheduleType, int amountToWait, Func<bool> waitContition = null)
        {
            if (waitContition is null)
            {
                yield return WaiterCoroutine(scheduleType, amountToWait);
            }
            else
            {
                while (!waitContition.Invoke())
                {
                    yield return WaiterCoroutine(scheduleType, amountToWait);
                }
            }

            action.Invoke();
        }

        /// <summary>
        /// This coroutine will wait for amountToWait before finishing
        /// </summary>
        /// <param name="action"></param>
        /// <param name="scheduleType"></param>
        /// <param name="amountToWait"></param>
        /// <returns></returns>
        private static IEnumerator WaiterCoroutine(ScheduleType scheduleType, int amountToWait)
        {
            switch (scheduleType)
            {
                case ScheduleType.WaitForSeconds:
                    yield return new WaitForSeconds(amountToWait);
                    break;
                case ScheduleType.WaitForFrames:
                    int count = 0;
                    while (amountToWait >= count)
                    {
                        yield return new WaitForEndOfFrame();
                        count++;
                    }
                    break;
            }
        }
    }
}
