using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Internal;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Audio;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;

namespace BTD_Mod_Helper.Api.Audio;

/// <summary>
/// Class that lets you add custom Jukebox Tracks from embedded audio
/// </summary>
public abstract class ModJukeboxTrack : NamedModContent
{
    /// <summary>
    /// Name of the AudioClip to use for this track.
    /// <br/>
    /// If loading directly from an embedded resource in your project, simply include the name of the audio file without the extension
    /// <br/>
    /// If your loading the AudioClip from <see cref="AssetBundleName"/>, this should be exact name of the asset within the bundle
    /// </summary>
    public virtual string AudioClipName => Name;

    /// <summary>
    /// If set, will load from an embedded AssetBundle with this name rather than directly from an embedded resource
    /// </summary>
    public virtual string AssetBundleName => null;

    /// <summary>
    /// The final AudioClip used for this track
    /// </summary>
    public virtual AudioClip AudioClip => string.IsNullOrEmpty(AssetBundleName)
        ? GetAudioClip(mod, AudioClipName)
        : GetBundle(mod, AssetBundleName).LoadAssetSync<AudioClip>(AudioClipName);

    /// <summary>
    /// The BTD6 MusicItem that gets created for this track
    /// </summary>
    public MusicItem MusicItem { get; private set; }

    /// <inheritdoc />
    public sealed override string DisplayNamePlural => base.DisplayNamePlural;

    /// <inheritdoc />
    public sealed override string Description => base.Description;

    /// <summary>
    /// Whether to hold off on creating this track's <see cref="AudioClip"/> until the game actually asks to play it,
    /// instead of during loading.
    /// </summary>
    public virtual bool LazyLoadClip => false;

    /// <summary>
    /// How many lazily loaded clips to keep in memory at once across all mods.
    /// </summary>
    public static int MaxLoadedLazyClips { get; set; } = 3;

    /// <summary>
    /// Creates the AudioClip for a <see cref="LazyLoadClip" /> track. Called on the main thread the first time the
    /// game asks for the clip, so it needs to be reasonably quick.
    /// </summary>
    protected virtual AudioClip LoadClip() => AudioClip;

    private static readonly Dictionary<string, ModJukeboxTrack> LazyTracks = [];
    private static readonly LinkedList<ModJukeboxTrack> LoadedLazyClips = [];

    private AudioClip lazyClip;

    internal static ModJukeboxTrack GetLazyTrack(string id) =>
        id != null && LazyTracks.TryGetValue(id, out var track) ? track : null;

    internal AudioClip ResolveLazyClip()
    {
        if (lazyClip != null)
        {
            LoadedLazyClips.Remove(this);
            LoadedLazyClips.AddFirst(this);
            return lazyClip;
        }

        lazyClip = LoadClip();
        if (lazyClip == null) return null;

        MusicItem.Clip = lazyClip;
        LoadedLazyClips.AddFirst(this);

        while (LoadedLazyClips.Count > Mathf.Max(1, MaxLoadedLazyClips))
        {
            LoadedLazyClips.Last!.Value.UnloadLazyClip();
        }

        return lazyClip;
    }

    private void UnloadLazyClip()
    {
        LoadedLazyClips.Remove(this);
        if (lazyClip == null) return;

        MusicItem.Clip = null;
        ResourceHandler.AudioClips.Remove(Id);
        Object.Destroy(lazyClip);
        lazyClip = null;
    }

    /// <summary>
    /// Creates the MusicItem for this track
    /// </summary>
    /// <returns>the MusicItem</returns>
    public virtual MusicItem CreateMusicItem()
    {
        var musicItem = ScriptableObject.CreateInstance<MusicItem>();

        musicItem.id = Id;
        musicItem.name = Id;
        musicItem.locKey = Id;
        musicItem.freeTrack = true;
        musicItem.Clip = LazyLoadClip ? null : AudioClip;
        musicItem.clip = new AudioClipReference("");


        return musicItem;
    }

    /// <inheritdoc />
    public override void Register()
    {
        MusicItem ??= CreateMusicItem();

        if (LazyLoadClip)
        {
            LazyTracks[Id] = this;
        }
        else if (MusicItem.Clip == null)
        {
            ModHelper.Warning($"Failed to register {Id}, unable to find AudioClip {AudioClipName}");
            return;
        }

        GameData.Instance.audioJukeBox.musicTrackData.Insert(0, MusicItem);
    }
}
