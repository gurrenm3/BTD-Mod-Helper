using System.Collections;
using System.Linq;

namespace BTD_Mod_Helper.Api.Internal;

/// <summary>
/// Task to wait for any <see cref="ModByteLoader"/>s that haven't finished by the time load tasks begun
/// </summary>
internal class ByteWaitTask : ModLoadTask
{
    public override bool RunsPreRegistrationPhase => true;

    public override bool ShouldRun => GetContent<ModByteLoader>().Any(loader => !loader.Loaded);

    public override string DisplayName => "Waiting for ByteLoaders...";

    public override bool ShowProgressBar => true;

    /// <summary>
    /// Wait for the bytes to all be loaded
    /// </summary>
    public override IEnumerator Coroutine()
    {
        while (!ModByteLoader.loadedAllBytes)
        {
            var loaders = GetContent<ModByteLoader>();
            Progress = loaders.Count(loader => loader.Loaded) / (float) loaders.Count;
            if (loaders.Find(loader => !loader.Loaded) is { } modByteLoader)
            {
                Description = modByteLoader.Name;
            }
            yield return null;
        }
    }

    public override void RunSync()
    {
        ModByteLoader.currentLoadTask?.Wait();
        GetContent<ModByteLoader>().Where(loader => !loader.Loaded).Do(loader => loader.LoadAllBytes());
    }
}