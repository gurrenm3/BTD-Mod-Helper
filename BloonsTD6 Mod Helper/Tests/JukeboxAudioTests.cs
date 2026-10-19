using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Attributes;
using BTD_Mod_Helper.Api.Audio;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.Testing;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Audio;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
using MelonLoader.Utils;
using NAudio.Wave;
using UnityEngine;

namespace BTD_Mod_Helper.Tests;

internal class JukeboxAudioTest : ModTest
{
    public override IEnumerator Test()
    {
        yield return Timeout(EnsureOnMainMenuWithNoPopUps(), 30);

        // These frame counts make the old 50% buffer growth split a stereo frame, including at EOF.
        foreach (var channels in new[] {1, 2, 3, 6})
        {
            using var reader = JukeboxTestTracks.CreateReader(channels, 8193);
            var samples = ResourceHandler.DecodeAudioSamples(reader, true);
            AssertEquals(samples.Data.Length, channels * 8193, "Decoded sample count changed");
            Assert(Math.Abs(samples.Data.Max() - 0.99f) < 0.00001f, "Normalization failed");
        }

        using var playlist = new JukeboxTestPlaylist();
        using var tracks = new JukeboxTestTracks(mod);
        var localWav = Path.Combine(MelonEnvironment.GameRootDirectory, "Jukebox", "This Is Willowshore.wav");
        if (File.Exists(localWav))
        {
            tracks.AddFile(localWav);
            ModHelper.Msg("Jukebox regression includes This Is Willowshore.wav");
        }

        MenuManager.instance.OpenMenu(SceneNames.JukeboxUI, null);
        var deadline = Time.realtimeSinceStartup + 30;
        while (!MenuManager.instance.GetCurrentMenu().Is<JukeBoxScreen>())
        {
            Assert(Time.realtimeSinceStartup < deadline, "Jukebox did not open");
            yield return null;
        }
        yield return new WaitForSecondsRealtime(1);

        var screen = MenuManager.instance.GetCurrentMenu().Cast<JukeBoxScreen>();
        Assert(screen.previewTrackClip != null && screen.previewTrackId != null,
            "Jukebox initialization did not finish");
        AssertEquals(tracks.Tracks.Sum(track => track.DecodeCount), 1,
            "Listing the jukebox decoded tracks beyond its automatic first preview");
        AssertEquals(tracks.Tracks.Last().DecodeCount, 1, "Initial preview did not load the first track");
        foreach (var item in GameData.Instance.audioJukeBox.musicTrackData.ToArray()
                     .Where(item => item.freeTrack && !item.unavailableInJukeBox &&
                                    ModJukeboxTrack.GetLazyTrack(item.id) != null))
        {
            Assert(screen.trackItemsList.ToArray().Concat(screen.playListItemsList.ToArray())
                    .Any(row => row.GetTrackName() == item.id),
                $"Jukebox did not populate registered lazy track {item.id}");
        }
        foreach (var track in tracks.Tracks)
        {
            Assert(screen.trackItemsList.ToArray().Any(item => item.GetTrackName() == track.Id),
                $"Jukebox did not populate {track.Id}");

            var row = screen.trackItemsList.ToArray().Single(item => item.GetTrackName() == track.Id);
            row.selectTrackBtn.onClick.Invoke();
            AssertEquals(screen.previewTrackId, track.Id, "Selecting a row did not update the selected ID");
            AssertEquals(tracks.Tracks.Sum(item => item.DecodeCount), 1, "Selecting a row decoded audio");
        }

        var selected = tracks.Tracks[0];
        var selectedRow = screen.trackItemsList.ToArray().Single(item => item.GetTrackName() == selected.Id);
        selectedRow.selectTrackBtn.onClick.Invoke();
        try
        {
            selectedRow.addBtn.onClick.Invoke();
            Assert(selectedRow.InPlaylist(), "Add button did not put the track in the playlist");
            AssertEquals(tracks.Tracks.Sum(track => track.DecodeCount), 1, "Adding a track decoded audio");
        }
        finally
        {
            if (selectedRow.InPlaylist()) selectedRow.minusBtn.onClick.Invoke();
        }
        Assert(!selectedRow.InPlaylist(), "Remove button did not remove the track from the playlist");
        AssertEquals(tracks.Tracks.Sum(track => track.DecodeCount), 1, "Removing a track decoded audio");

        screen.previewBtn.onClick.Invoke();
        AssertEquals(selected.DecodeCount, 1, "Pressing preview did not decode the selected track");
        AssertEquals(tracks.Tracks.Sum(track => track.DecodeCount), 2, "Preview decoded unrelated tracks");
        AssertEquals(Game.instance.audioFactory.musicAudioSource.clip.name, selected.Id, "Wrong preview clip");

        foreach (var track in new[] {selected, tracks.Tracks.Last()})
        {
            screen.SelectedTrackClicked(track.Id);
            screen.PreviewTrackClicked();
            var clip = screen.previewTrackClip;
            Assert(clip != null, $"No Unity clip for {track.Id}");
            Assert(clip!.channels == 2 && clip.samples > 0, "Invalid Unity clip format");
            var data = new Il2CppStructArray<float>(2);
            Assert(clip.GetData(data, 0), "Could not read Unity clip data");
            Assert(Math.Abs(data[0] - 0.99f) < 0.00001f || track.FilePath != null,
                "Unity clip data differs from decoded samples");
        }
        ModHelper.Msg($"Jukebox populated all {tracks.Tracks.Count} regression tracks");
        yield return Timeout(EnsureOnMainMenuWithNoPopUps(), 30);
    }
}

internal class JukeboxTransitionTest : ModTest
{
    // The standard test profile pauses AudioListener, preventing natural song completion.
    public override bool IsAvailable => !System.Environment.GetCommandLineArgs().Contains("--modhelper.noaudio");

    public override IEnumerator Test()
    {
        // The preceding UI test already returns here; avoid requesting another scene change while it settles.
        if (MenuManager.instance == null || !MenuManager.instance.GetCurrentMenu().Is<MainMenu>())
            yield return Timeout(EnsureOnMainMenuWithNoPopUps(), 30);
        yield return new WaitForSecondsRealtime(1);
        yield return LoadIntoGame();

        using var tracks = new JukeboxTestTracks(mod);
        var audio = Game.instance.audioFactory;
        var factory = AssertNotNull(audio.musicFactory, "Match has no music factory");
        var originalTracks = factory.TrackItemDataList;
        var originalShuffle = factory.ShuffledTrackItemDataList;
        var originalUse = factory.usePlayList;
        var originalRepeat = factory.RepeatTrack;
        var originalShuffleMode = factory.ShufflePlaylist;
        var originalTail = factory.extraTail;
        var originalLimit = ModJukeboxTrack.MaxLoadedLazyClips;
        var originalVolume = AudioListener.volume;
        var mainThread = System.Environment.CurrentManagedThreadId;
        try
        {
            // Muting the listener preserves playback time; pausing it would prevent song completion.
            AudioListener.volume = 0;
            ModJukeboxTrack.MaxLoadedLazyClips = 1;
            factory.TrackItemDataList = new Il2CppSystem.Collections.Generic.List<TrackItemData>();
            foreach (var track in tracks.Tracks)
                factory.TrackItemDataList.Add(new TrackItemData {trackName = track.Id});
            factory.ShuffledTrackItemDataList = factory.TrackItemDataList;
            factory.usePlayList = true;
            factory.RepeatTrack = false;
            factory.ShufflePlaylist = false;
            factory.extraTail = 0.1f;
            factory.currentTrackIndex = 0;
            audio.StopMusic();
            factory.PlayNewTrack(false);

            // Two circuits with more tracks than the cache can hold exercise eviction and wraparound.
            for (var transition = 0; transition < 8; transition++)
            {
                var current = factory.currentTrackIndex;
                var next = tracks.Tracks[(current + 1) % tracks.Tracks.Count];
                var deadline = Time.realtimeSinceStartup + 10;
                while (next.DecodeThread == 0)
                {
                    Assert(Time.realtimeSinceStartup < deadline, $"Next track was not prefetched: {next.Id}");
                    yield return null;
                }
                Assert(next.DecodeThread != mainThread, $"Next track decoded on main thread: {next.Id}");
                Assert(factory.currentTrackIndex == current, "Track changed before prefetch completed");
                while (factory.currentTrackIndex == current)
                {
                    Assert(Time.realtimeSinceStartup < deadline, "Song did not advance automatically");
                    yield return null;
                }
                AssertEquals(factory.currentTrackIndex, (current + 1) % tracks.Tracks.Count,
                    "Automatic transition selected the wrong track");
                Assert(audio.musicAudioSource.clip != null, "Transition left no playing clip");
                AssertEquals(audio.musicAudioSource.clip!.name, next.Id, "Wrong clip playing after transition");
                // Reset the previous track's observation for its next prefetch after eviction.
                tracks.Tracks[current].DecodeThread = 0;
                ModHelper.Msg($"Jukebox automatic transition {transition + 1}/8: {next.Id}");
            }
        }
        finally
        {
            audio.StopMusic();
            factory.TrackItemDataList = originalTracks;
            factory.ShuffledTrackItemDataList = originalShuffle;
            factory.usePlayList = originalUse;
            factory.RepeatTrack = originalRepeat;
            factory.ShufflePlaylist = originalShuffleMode;
            factory.extraTail = originalTail;
            ModJukeboxTrack.MaxLoadedLazyClips = originalLimit;
            AudioListener.volume = originalVolume;
        }
        yield return Timeout(EnsureOnMainMenuWithNoPopUps(), 30);
    }
}

internal sealed class JukeboxTestPlaylist : IDisposable
{
    private readonly Il2CppSystem.Collections.Generic.List<TrackItemData> original = Game.Player.Data.savedPlayList;

    internal JukeboxTestPlaylist()
    {
        // Remove this fixture's entries if an interrupted earlier test saved them before cleanup.
        if (original != null)
        {
            for (var i = original.Count - 1; i >= 0; i--)
            {
                if (original[i].trackName.StartsWith("BloonsTD6 Mod Helper-JukeboxRegression", StringComparison.Ordinal))
                    original.RemoveAt(i);
            }
        }
        // Missing mods can leave saved playlist entries with no UI row, invalidating native row indices.
        // Keep playlist editing in this test independent of the player's installed/enabled mods.
        Game.Player.Data.savedPlayList = new Il2CppSystem.Collections.Generic.List<TrackItemData>();
    }

    public void Dispose()
    {
        Game.Player.Data.savedPlayList = original;
        if (MenuManager.instance.GetCurrentMenu().Is<JukeBoxScreen>())
            MenuManager.instance.GetCurrentMenu().Cast<JukeBoxScreen>().playListDataList = original;
    }
}

internal sealed class JukeboxTestTracks : IDisposable
{
    internal readonly List<Track> Tracks = [];
    private readonly BloonsMod mod;

    internal JukeboxTestTracks(BloonsMod mod)
    {
        this.mod = mod;
        for (var i = 0; i < 4; i++) Add(new Track {mod = mod, TrackName = $"JukeboxRegression{i}"});
    }

    internal void AddFile(string path) => Add(new Track
    {
        mod = mod, TrackName = "JukeboxRegressionFile", FilePath = path
    });

    private void Add(Track track)
    {
        Tracks.Add(track);
        track.Register();
    }

    internal static WaveFileReader CreateReader(int channels, int frames)
    {
        var stream = new MemoryStream();
        using (var writer = new WaveFileWriter(stream, new WaveFormat(44100, 16, channels)))
        {
            for (var i = 0; i < channels * frames; i++) writer.WriteSample(0.25f);
            writer.Flush();
            return new WaveFileReader(new MemoryStream(stream.ToArray()));
        }
    }

    public void Dispose()
    {
        var lazyTracks = (Dictionary<string, ModJukeboxTrack>) AccessTools.Field(typeof(ModJukeboxTrack), "LazyTracks")
            .GetValue(null)!;
        var decoding = AccessTools.Field(typeof(ModJukeboxTrack), "decoding");
        var prefetched = AccessTools.Field(typeof(ModJukeboxTrack), "prefetchedTrack");
        foreach (var track in Tracks)
        {
            (decoding.GetValue(track) as Task<AudioSamples>)?.GetAwaiter().GetResult();
            decoding.SetValue(track, null);
            if (ReferenceEquals(prefetched.GetValue(null), track)) prefetched.SetValue(null, null);
            GameData.Instance.audioJukeBox.musicTrackData.Remove(track.MusicItem);
            AccessTools.Method(typeof(ModJukeboxTrack), "UnloadLazyClip").Invoke(track, null);
            lazyTracks.Remove(track.Id);
            UnityEngine.Object.Destroy(track.MusicItem);
        }
    }

    [DontLoad]
    internal sealed class Track : ModJukeboxTrack
    {
        internal string TrackName;
        internal string FilePath;
        internal volatile int DecodeThread;
        internal int DecodeCount;
        public override string Name => TrackName;
        public override bool LazyLoadClip => true;

        protected override AudioSamples DecodeClip()
        {
            Interlocked.Increment(ref DecodeCount);
            using var reader = FilePath != null ? ResourceHandler.GetWaveStream(FilePath) : CreateReader(2, 88201);
            var samples = ResourceHandler.DecodeAudioSamples(reader, true);
            DecodeThread = System.Environment.CurrentManagedThreadId;
            return samples;
        }
    }
}
