using System.Linq;
using Assets.Scripts.Unity.Tasks;
using BTD_Mod_Helper.Api;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using Main = Assets.Main.Main;

namespace BTD_Mod_Helper.Patches;

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
        tasks.Add(new Task(CustomGameModelLoadName, Main.__c.__9__46_8).Cast<ITask>()); // The last of the Assets_Main_Main___c$$_GetInitialLoadTasks_...
        tasks.Add(new ByteWaitTask().CreateTask());
        tasks.Add(new PreLoadResourcesTask().CreateTask());

        tasks.AddRange(ModHelper.Mods
            .Where(mod => mod.Content.Count > 0)
            .OrderBy(mod => mod.Priority)
            .Select(mod => new ModContentTask {mod = mod})
            .Select(modContentTask => modContentTask.CreateTask()));

        tasks.AddRange(ModContent
            .GetContent<ModLoadTask>()
            .OrderBy(task => task.mod.Priority)
            .Select(modLoadTask => modLoadTask.CreateTask()));

        tasks.Add(gameModelLoad);

        __result.Tasks = new SeriesTasks(tasks.ToArray()).Cast<IEnumerable<ITask>>();
    }
}