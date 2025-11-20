#if DEBUG
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Internal;
using CommandLine;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Commands;

internal class PlaySoundCommand : ModCommand
{
    public override string Command => "playsound";

    public override string Help => "Plays a sound";

    [Value(0, Default = null, HelpText = "Sound id, either guid from resource.json, the name within VanillaAudioClips.cs, or mod sound GUID",
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
}

internal abstract class PlaySoundUICommand : ModCommand<PlaySoundCommand>
{
    protected static MenuManager MenuManager => MenuManager.instance;

    public abstract AudioClip Sound { get; }

    public override string Help => $"Plays the {Command} sound from the menu manager";

    public override bool Execute(ref string resultText)
    {
        Sound.Play("ButtonClickSounds");
        return true;
    }
}

internal class PlaySoundButtonClick1 : PlaySoundUICommand
{
    public override string Command => nameof(MenuManager.buttonClickSound).Replace("Sound", "");
    public override AudioClip Sound => MenuManager.buttonClickSound;
}

internal class PlaySoundButtonClick2 : PlaySoundUICommand
{
    public override string Command => nameof(MenuManager.buttonClick2Sound).Replace("Sound", "");
    public override AudioClip Sound => MenuManager.buttonClick2Sound;
}

internal class PlaySoundButtonClick3 : PlaySoundUICommand
{
    public override string Command => nameof(MenuManager.buttonClick3Sound).Replace("Sound", "");
    public override AudioClip Sound => MenuManager.buttonClick3Sound;
}

#endif