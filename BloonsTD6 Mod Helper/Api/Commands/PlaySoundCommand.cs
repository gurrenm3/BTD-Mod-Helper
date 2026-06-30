#if DEBUG
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Internal;
using CommandLine;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Commands;

internal class PlaySoundCommand : ModCommand
{
    public override string Command => "playsound";

    public override string Help => "Plays a sound";

    [Value(0, Default = null,
        HelpText = "Sound id, either guid from resource.json, the name within VanillaAudioClips.cs, or mod sound GUID",
        MetaName = "SoundGUID")]
    public string SoundId { get; set; }

    public override bool Execute(ref string resultText)
    {
        if (string.IsNullOrEmpty(SoundId)) return false;

        AudioClip audioClip;

        if (!ResourceHandler.AudioClips.TryGetValue(SoundId, out audioClip))
        {
            if (VanillaAudioClips.ByName.TryGetValue(SoundId, out var realSoundId))
            {
                SoundId = realSoundId;
            }

            audioClip = ResourceLoader.LoadAsync<AudioClip>(SoundId).WaitForCompletion();
        }

        audioClip.Play();

        return true;
    }

    public override IEnumerable<string> SuggestionsForValue(int index) => index switch
    {
        0 => VanillaAudioClips.ByName.Keys,
        _ => base.SuggestionsForValue(index)
    };
}

#endif