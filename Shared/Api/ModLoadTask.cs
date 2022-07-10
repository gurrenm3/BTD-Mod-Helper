using System.Collections;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class for a Coroutine style task that runs during the BTD6 loading screen
/// </summary>
public abstract partial class ModLoadTask : NamedModContent
{
    internal static readonly Dictionary<int, ModLoadTask> Cache = new();

    /// <inheritdoc />
    public sealed override string DisplayNamePlural => base.DisplayNamePlural;

    /// <inheritdoc />
    public sealed override string Description => base.DisplayNamePlural;

    internal IEnumerator iEnumerator;

    //public abstract void Perform();

    /// <summary>
    /// Coroutine style function
    /// </summary>
    /// <returns></returns>
    public abstract IEnumerator Coroutine();


    /// <inheritdoc />
    public sealed override int RegisterPerFrame => 999;

    /// <inheritdoc />
    public override void Register()
    {
        // nothing here since registering happens after TitleScreen, so ModLoadTasks should already be finished
    }
    
    internal void RunSync()
    {
        var coroutine = Coroutine();
        while (coroutine.MoveNext())
        {
        }
    }
}