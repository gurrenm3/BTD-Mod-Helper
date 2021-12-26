using System;
using System.Linq;
using Assets.Scripts.Unity.Tasks;
using BTD_Mod_Helper.Api;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using UnhollowerBaseLib;
using Main = Assets.Main.Main;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(Main), nameof(Main.GetInitialLoadTasks))]
    internal static class Main_GetInitialLoadTasks
    {
        internal const string CustomGameModelLoadName = "Pre-Preparing Darts...";

        [HarmonyPostfix]
        private static void Postfix(ref SeriesTasks __result)
        {
            var tasks = __result.Tasks.Cast<Il2CppReferenceArray<ITask>>().ToList();
            var gameModelLoad = tasks.Last();
            tasks.Remove(gameModelLoad);
            tasks.Add(new Task(CustomGameModelLoadName, Main.__c.__9__47_8).Cast<ITask>());

            tasks.AddRange(ModContent
                .GetContent<ModLoadTask>()
                .OrderBy(task => task.mod.Priority)
                .Select(modLoadTask => modLoadTask.CreateTask()));

            tasks.Add(gameModelLoad);

            __result.Tasks = new SeriesTasks(tasks.ToArray()).Cast<IEnumerable<ITask>>();
        }
    }
}