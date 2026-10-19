using BTD_Mod_Helper.Api.Audio;
namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(InGameMusicFactory), nameof(InGameMusicFactory.PlayNewTrack))]
internal static class InGameMusicFactory_PlayNewTrack
{
    [HarmonyPostfix]
    internal static void Postfix(InGameMusicFactory __instance, bool bossMusic)
    {
        if (bossMusic || __instance.RepeatTrack) return;

        var tracks = __instance.TrackItemDataList;
        var playlist = __instance.ShufflePlaylist ? __instance.ShuffledTrackItemDataList : tracks;
        if (tracks == null || playlist == null) return;

        // Same next track logic as InGameMusicFactory.UpdateMusicFactory uses once the current track finishes
        var next = __instance.currentTrackIndex + 1;
        if (next >= tracks.Count || next >= playlist.Count || playlist[next].isBossTrack) next = 0;
        if (next >= playlist.Count) return;

        ModJukeboxTrack.GetLazyTrack(playlist[next].trackName)?.Prefetch();
    }
}