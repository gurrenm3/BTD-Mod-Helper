using BTD_Mod_Helper.Api.Audio;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Audio;
using Il2CppAssets.Scripts.Unity.Audio;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(MusicItem), nameof(MusicItem.PreloadAsync))]
internal static class MusicItem_PreloadAsync
{
    [HarmonyPrefix]
    internal static void Prefix(MusicItem __instance)
    {
        if (ModJukeboxTrack.GetLazyTrack(__instance.id) is { } track)
        {
            track.ResolveLazyClip();
        }
    }
}

[HarmonyPatch(typeof(AudioJukeBox), nameof(AudioJukeBox.GetTrackByName))]
internal static class AudioJukeBox_GetTrackByName
{
    [HarmonyPostfix]
    internal static void Postfix(string trackName, ref AudioClip __result)
    {
        if (__result != null) return;

        if (ModJukeboxTrack.GetLazyTrack(trackName) is { } track)
        {
            __result = track.ResolveLazyClip();
        }
    }
}

[HarmonyPatch(typeof(JukeBoxScreen), nameof(JukeBoxScreen.LoadPlaylist))]
internal static class JukeBoxScreen_LoadPlaylist
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        // Init reads the first MusicItem.Clip directly for its automatic preview after LoadPlaylist returns.
        // Resolve that clip here while letting the rest of the rows populate from track metadata.
        var tracks = GameData.Instance.audioJukeBox.musicTrackData;
        if (tracks.Count > 0)
        {
            ModJukeboxTrack.GetLazyTrack(tracks[0].id)?.ResolveLazyClip();
        }
    }
}
