using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Music;
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
        : GetBundle(mod, AssetBundleName).LoadAsset(AudioClipName).Cast<AudioClip>();

    /// <summary>
    /// The BTD6 MusicItem that gets created for this track
    /// </summary>
    public MusicItem MusicItem { get; private set; }

    /// <inheritdoc />
    public sealed override string DisplayNamePlural => base.DisplayNamePlural;

    /// <inheritdoc />
    public sealed override string Description => base.Description;

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
        musicItem.Clip = AudioClip;
        musicItem.clip = new AudioClipReference("");


        return musicItem;
    }

    /// <inheritdoc />
    public override void Register()
    {
        MusicItem ??= CreateMusicItem();

        if (MusicItem.Clip == null)
        {
            ModHelper.Warning($"Failed to register {Id}, unable to find AudioClip {AudioClipName}");
            return;
        }

        GameData.Instance.audioJukeBox.musicTrackData.Insert(0, MusicItem);
    }
}