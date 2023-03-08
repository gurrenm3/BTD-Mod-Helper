using Il2CppAssets.Scripts.Unity;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for unity audio clips
/// </summary>
public static class AudioClipExtensions
{
    /// <summary>
    /// Plays a sound through the default Game AudioFactory
    /// </summary>
    /// <param name="audioClip">The audio clip to play</param>
    /// <param name="volume">How loud it should be</param>
    /// <param name="groupId">TODO group stuff</param>
    public static void Play(this AudioClip audioClip, string groupId = "FX", float volume = 1f)
    {
        Game.instance.audioFactory.PlaySoundFromUnity(audioClip, audioClip.GetName(), groupId, 0, volume);
    }
}