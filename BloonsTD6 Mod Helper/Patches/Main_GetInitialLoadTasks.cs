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
        /// <summary>
        /// I noticed that if any tasks are added after the vanilla final task of loading the GameModel, then aren't run.
        /// But, since most tasks we want to add need to deal with the GameModel, I added in a custom task to load the
        /// GameModel that can precede our tasks. Then, the real GameModel load task happens, but I've patched it to
        /// not re-load a new GameModel and instead just return the same one that's already been modified.
        /// </summary>
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