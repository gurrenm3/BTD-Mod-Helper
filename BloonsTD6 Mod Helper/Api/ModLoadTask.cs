using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Internal;
using Il2CppNinjaKiwi.Localization;
using Math = Il2CppAssets.Scripts.Simulation.SMath.Math;

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class for a Coroutine style task that runs during the BTD6 loading screen
/// </summary>
public abstract class ModLoadTask : NamedModContent
{
    private static readonly object LoadTaskLock = new();

    /// <summary>
    /// All necessary LoadTasks for this Launch of the game. Caches result of the first call.
    /// </summary>
    internal static IReadOnlyList<ModLoadTask> AllLoadTasks
    {
        get
        {
            lock (LoadTaskLock)
            {
                if (field != null) return field;

                var list = new List<ModLoadTask>();
                field = list.AsReadOnly();

                list.AddRange(GetContent<ModLoadTask>().Where(task => task.ShouldRun && task.RunsPreRegistrationPhase));

                list.AddRange(ModHelper.Mods
                    .Where(mod => mod.Content.Count > 0)
                    .OrderBy(mod => mod.Priority)
                    .Select(mod => new RegisterModContentTask {mod = mod}));

                list.AddRange(GetContent<ModLoadTask>().Where(task => task.ShouldRun && !task.RunsPreRegistrationPhase));

                return list;
            }
        }
    }

    internal static ModLoadTask CurrentTask { get; private set; }

    /// <inheritdoc />
    public sealed override string DisplayNamePlural => base.DisplayNamePlural;

    /// <summary>
    /// Whether to show the progress bar during this task or not
    /// </summary>
    public virtual bool ShowProgressBar => false;

    /// <summary>
    /// If <see cref="ShowProgressBar" /> is enabled, how much Progress should be shown (from 0 to 1)
    /// </summary>
    public float Progress
    {
        get;
        protected set => field = Math.Clamp(value, 0, 1);
    }

    /// <summary>
    /// The subtext that appears to the right of the Display Name at the bottom of the loading screen
    /// <br />
    /// Can be dynamically changed while running the task
    /// </summary>
    public new virtual string Description { get; protected set; } = "";

    /// <summary>
    /// Whether this load task needs to run before the Registration phase of ModContent
    /// </summary>
    public virtual bool RunsPreRegistrationPhase => false;

    /// <summary>
    /// Whether this load task should run at all on this launch of the game
    /// </summary>
    public virtual bool ShouldRun => true;

    /// <summary>
    /// Whether the Load Task has completed yet
    /// </summary>
    public bool Complete { get; private set; }

    /// <inheritdoc />
    public sealed override int RegisterPerFrame => 999;

    /// <summary>
    /// Coroutine style function
    /// </summary>
    /// <returns></returns>
    public abstract IEnumerator Coroutine();

    /// <inheritdoc />
    public override void Register()
    {
        // nothing here since ModLoadTasks should already be finished
    }

    /// <summary>
    /// Runs the load task coroutine synchronously
    /// </summary>
    public virtual void RunSync()
    {
        var coroutine = Coroutine();
        while (coroutine.MoveNext())
        {
        }
    }

    private static void DoubleCheckLocalizationTable()
    {
        // Fix some peoples' textTable sometimes not being initialized by this point
        if (LocalizationManager.Instance.textTable == null)
        {
            ModHelper.Warning(
                "The text table is null, replacing with default. This usually means a mod messed up the game's localization manager somehow");
            LocalizationManager.Instance.textTable = LocalizationManager.Instance.defaultTable;
        }
    }

    internal static IEnumerator RunAll()
    {
        yield return null; // ensure running on main thread right from start

        DoubleCheckLocalizationTable();

        foreach (var loadTask in AllLoadTasks)
        {
            if (loadTask.Complete) continue;
            CurrentTask = loadTask;
            ModHelper.Msg(loadTask.DisplayName);

            var task = loadTask.Coroutine;
            yield return task.CatchErrors();

            loadTask.Complete = true;

            yield return null;
        }
        CurrentTask = null;
    }

    internal static void RunAllSync()
    {
        DoubleCheckLocalizationTable();
        foreach (var loadTask in AllLoadTasks)
        {
            if (loadTask.Complete) continue;
            CurrentTask = loadTask;
            ModHelper.Msg(loadTask.DisplayName);
            loadTask.RunSync();
            loadTask.Complete = true;
        }
        CurrentTask = null;
    }
}