using System.Collections;
using Il2CppAssets.Scripts.Simulation.SMath;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class for a Coroutine style task that runs during the BTD6 loading screen
/// </summary>
public abstract class ModLoadTask : NamedModContent
{
    private IEnumerator iEnumerator;

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

    /// <inheritdoc />
    public sealed override int RegisterPerFrame => 999;

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

    /// <inheritdoc />
    public override void Register()
    {
        // nothing here since registering happens after TitleScreen, so ModLoadTasks should already be finished
        if (ModHelper.FallbackToOldLoading)
        {
            RunSync();
        }
    }

    internal void RunSync()
    {
        while (MoveNext())
        {
        }
    }
}