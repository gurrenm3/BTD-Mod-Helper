using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// Initial task to register ModContent from other mods
/// </summary>
internal class ByteWaitTask : ModLoadTask
{
    /// <inheritdoc />
    public override string DisplayName => "Waiting for ByteLoaders...";

    /// <summary>
    /// Don't load this like a normal task
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<ModContent> Load() => Enumerable.Empty<ModContent>();

    public override bool ShowProgressBar => GetContent<ModByteLoader>().Any();

    internal static ByteWaitTask Instance { get; private set; }

    public ByteWaitTask()
    {
        Instance = this;
        mod = ModHelper.Main;
    }

    /// <summary>
    /// Wait for the bytes to all be loaded
    /// </summary>
    public override IEnumerator Coroutine()
    {
        while (!ModByteLoader.loadedAllBytes)
        {
            var loaders = GetContent<ModByteLoader>();
            Progress = loaders.Count(loader => loader.Loaded) / (float) loaders.Count;
            if (loaders.FirstOrDefault(loader => !loader.Loaded) is { } modByteLoader)
            {
                Description = modByteLoader.Name;
            }
            yield return null;
        }
    }
}