using BTD_Mod_Helper.Api.Audio;
using Il2CppAssets.Scripts.Data.Audio;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Audio;
using Il2CppNinjaKiwi.Localization;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(JukeBoxScreen), nameof(JukeBoxScreen.PopulateTrackItem))]
internal static class JukeBoxScreen_PopulateTrackItem
{
    [HarmonyPrefix]
    internal static bool Prefix(JukeBoxScreen __instance, GameObject content, MusicItem track)
    {
        // Free custom tracks have no purchase/visibility checks inside PopulateTrackItem.
        // The native code otherwise loads the entire clip just to read its name for the row's ID.
        if (!track.freeTrack || ModJukeboxTrack.GetLazyTrack(track.id) == null) return true;

        var item = Object.Instantiate(__instance.trackItemPrefab, content.transform, false);
        item.SetTrackItem(track.id, __instance, LocalizationManager.Instance.GetText(track.locKey));
        item.SetBtns(true);
        __instance.trackItemsList.Add(item);
        return false;
    }
}

[HarmonyPatch(typeof(JukeBoxScreen), nameof(JukeBoxScreen.UpdateTrackDisplay))]
internal static class JukeBoxScreen_UpdateTrackDisplay
{
    [HarmonyPrefix]
    internal static bool Prefix(JukeBoxScreen __instance)
    {
        if (ModJukeboxTrack.GetLazyTrack(__instance.previewTrackId) == null) return true;

        // Selecting a row updates its label/buttons without asking GetTrackByName to decode it.
        // PreviewTrackClicked still resolves the actual clip when the user presses play.
        var selectedIsPreview = __instance.previewTrackClip != null &&
                                __instance.previewTrackClip.name == __instance.previewTrackId;
        var playing = Game.instance.audioFactory.musicAudioSource.isPlaying && selectedIsPreview;
        __instance.playImg.enabled = !playing;
        __instance.pauseImg.enabled = playing;
        __instance.UpdateCurrentTrackTxt(__instance.previewTrackId);
        __instance.pauseTrackPositionFill = !selectedIsPreview;
        return false;
    }
}
