namespace BTD_Mod_Helper.Api.Audio;

/// <summary>
/// Decoded audio data that can be turned into an AudioClip
/// </summary>
/// <param name="Data">Interleaved samples for all channels</param>
/// <param name="Channels">Number of channels</param>
/// <param name="SampleRate">Samples per second for each channel</param>
public record AudioSamples(float[] Data, int Channels, int SampleRate)
{
    /// <summary>
    /// Length of the audio in seconds
    /// </summary>
    public double Length => (double) Data.Length / Channels / SampleRate;
}
