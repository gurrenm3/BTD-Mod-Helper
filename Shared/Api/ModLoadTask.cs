using System.Collections;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.SMath;

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class for a Coroutine style task that runs during the BTD6 loading screen
/// </summary>
public abstract partial class ModLoadTask : NamedModContent
{
    /// <inheritdoc />
    public sealed override string DisplayNamePlural => base.DisplayNamePlural;

    private IEnumerator iEnumerator;

    internal bool MoveNext()
    {
        iEnumerator ??= Coroutine();
        return iEnumerator.MoveNext();
    }

    //public abstract void Perform();

    /// <summary>
    /// Coroutine style function
    /// </summary>
    /// <returns></returns>
    public abstract IEnumerator Coroutine();

    /// <summary>
    /// Whether to show the progress bar during this task or not
    /// </summary>
    public virtual bool ShowProgressBar => false;

    private float progress;

    /// <summary>
    /// If <see cref="ShowProgressBar"/> is enabled, how much Progress should be shown (from 0 to 1)
    /// </summary>
    public float Progress
    {
        get => progress;
        protected set => progress = Math.Clamp(value, 0, 1);
    }

    /// <summary>
    /// The subtext that appears to the right of the Display Name at the bottom of the loading screen
    /// <br/>
    /// Can be dynamically changed while running the task
    /// </summary>
    public new virtual string Description { get; protected set; } = "";

    /// <inheritdoc />
    public sealed override int RegisterPerFrame => 999;

    /// <inheritdoc />
    public override void Register()
    {
        // nothing here since registering happens after TitleScreen, so ModLoadTasks should already be finished
    }

    internal void RunSync()
    {
        while (MoveNext())
        {
        }
    }
}