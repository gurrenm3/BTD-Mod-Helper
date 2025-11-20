using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using Il2CppSystem.IO;
using NAudio.Vorbis;
using NAudio.Wave;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Internal;

/// <summary>
/// Handles embedded resources within Mod Helper mods
/// </summary>
public static class ResourceHandler
{
    /// <summary>
    /// Map of raw embedded resource data by Id
    /// </summary>
    public static readonly Dictionary<string, byte[]> Resources = new();

    /// <summary>
    /// Map of created Audio Clips by Id
    /// </summary>
    public static readonly Dictionary<string, AudioClip> AudioClips = new();

    /// <summary>
    /// Map of loaded Asset Bundles by Id
    /// </summary>
    public static readonly Dictionary<string, AssetBundle> Bundles = new();

    /// <summary>
    /// Cache of created Textures by Id
    /// </summary>
    public static readonly Dictionary<string, Texture2D> TextureCache = new();

    /// <summary>
    /// Cache of created Sprites by Id
    /// </summary>
    public static readonly Dictionary<string, Sprite> SpriteCache = new();

    internal static readonly List<RenderTexture> RenderTexturesToRelease = [];

    internal static void LoadEmbeddedResources(BloonsMod mod)
    {
        LoadEmbeddedTextures(mod);
        LoadEmbeddedAudio(mod);
        LoadEmbeddedBundles(mod);
    }

    internal static void LoadEmbeddedTextures(BloonsMod mod)
    {
        mod.Resources = new Dictionary<string, byte[]>();
        foreach (var fileName in mod.GetAssembly().GetManifestResourceNames()
                     .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg")))
        {
            var resource = mod.GetAssembly().GetManifestResourceStream(fileName).GetByteArray();
            if (resource == null) continue;

            var split = fileName.Split('.');
            var name = split[^2];
            var id = ModContent.GetId(mod, name);
            Resources[id] = resource;
            mod.Resources[name] = resource;
        }
    }

    internal static void LoadEmbeddedAudio(BloonsMod mod)
    {
        mod.AudioClips = new Dictionary<string, AudioClip>();

        foreach (var fileName in mod.GetAssembly().GetManifestResourceNames()
                     .Where(s => s.EndsWith(".wav") || s.EndsWith(".mp3") || s.EndsWith(".ogg")))
        {
            var split = fileName.Split('.');
            var extension = split[^1];
            var name = split[^2];
            var id = ModContent.GetId(mod, name);

            try
            {
                using var stream = mod.GetAssembly().GetManifestResourceStream(fileName);

                WaveStream waveStream;

                switch (extension)
                {
                    case "wav":
                        waveStream = new WaveFileReader(stream);
                        break;
                    case "mp3":
                        waveStream = new Mp3FileReader(stream);
                        break;
                    case "ogg":
                        waveStream = new VorbisWaveReader(stream);
                        break;
                    default:
                        ModHelper.Warning($"Invalid for audio extension {extension} for {fileName}");
                        return;
                }

                using (waveStream)
                {
                    mod.AudioClips[name] = CreateAudioClip(waveStream, id);
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }
        }
    }

    internal static void LoadEmbeddedBundles(BloonsMod mod)
    {
        foreach (var name in mod.GetAssembly().GetManifestResourceNames().Where(s => s.EndsWith("bundle")))
        {
            var bytes = mod.GetAssembly().GetManifestResourceStream(name).GetByteArray();
            if (bytes == null) continue;

            var stream = new MemoryStream(bytes);
            var bundle = AssetBundle.LoadFromStream(stream);
            stream.Dispose();
            var guid = mod.IDPrefix;
            if (bundle == null)
            {
                ModHelper.Log($"The bundle {name} is null!");
                continue;
            }

            if (string.IsNullOrEmpty(bundle.name))
            {
                ModHelper.Log($"The bundle {name} has no name!");
                continue;
            }

            if (bundle.name.EndsWith(".bundle"))
            {
                guid += bundle.name.Substring(0, bundle.name.LastIndexOf(".", StringComparison.Ordinal));
            }
            else
            {
                guid += bundle.name;
            }

            Bundles[guid] = bundle;
            // ModHelper.Msg("Successfully loaded bundle " + guid);
        }
    }


    /// <summary>
    /// Create an AudioClip from a wavestream
    /// </summary>
    /// <param name="reader">Wave Stream</param>
    /// <param name="id">Id for AudioClip</param>
    /// <returns>new AudioClip, or null if unsuccessful</returns>
    public static AudioClip CreateAudioClip(WaveStream reader, string id)
    {
        try
        {
            var sampleProvider = reader.ToSampleProvider();

            var capacity = 4096;
            var buffer = new float[capacity];
            var array = ArrayPool<float>.Shared.Rent(capacity);
            var count = 0;
            int read;

            while ((read = sampleProvider.Read(buffer, 0, buffer.Length)) > 0)
            {
                if (count + read > capacity)
                {
                    var newCap = capacity * 2;
                    var newArray = ArrayPool<float>.Shared.Rent(newCap);

                    Array.Copy(array, newArray, count);
                    ArrayPool<float>.Shared.Return(array);

                    array = newArray;
                    capacity = newCap;
                }

                Array.Copy(buffer, 0, array, count, read);
                count += read;
            }

            var result = new float[count];
            Array.Copy(array, result, count);
            ArrayPool<float>.Shared.Return(array);

            var format = reader.WaveFormat;
            var audioClip = AudioClip.Create(id, result.Length / format.Channels, format.Channels, format.SampleRate, false);

            if (audioClip.SetData(result, 0))
            {
                return AudioClips[id] = audioClip;
            }

            ModHelper.Warning($"Failed to set data for audio clip {id}");
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }

        return null;
    }

    /// <summary>
    /// Create an AudioClip from a wav file
    /// </summary>
    /// <param name="reader">Wav file reader</param>
    /// <param name="id">Id for AudioClip</param>
    /// <returns>new AudioClip, or null if unsuccessful</returns>
    [Obsolete("Use the WaveStream overload instead")]
    public static AudioClip CreateAudioClip(WaveFileReader reader, string id) => CreateAudioClip(reader as WaveStream, id);

    /// <summary>
    /// Create an AudioClip from an mp3 file
    /// </summary>
    /// <param name="reader">mp3 file reader</param>
    /// <param name="id">Id for AudioClip</param>
    /// <returns>new AudioClip, or null if unsuccessful</returns>
    [Obsolete("Use the WaveStream overload instead")]
    public static AudioClip CreateAudioClip(Mp3FileReader reader, string id) => CreateAudioClip(reader as WaveStream, id);

    /// <summary>
    /// Create an AudioClip from an ogg file
    /// </summary>
    /// <param name="reader">mp3 file reader</param>
    /// <param name="id">Id for AudioClip</param>
    /// <returns>new AudioClip, or null if unsuccessful</returns>
    [Obsolete("Use the WaveStream overload instead")]
    public static AudioClip CreateAudioClip(VorbisWaveReader reader, string id) => CreateAudioClip(reader as WaveStream, id);


    internal static Texture2D CreateTexture(string guid)
    {
        if (Resources.TryGetValue(guid, out var bytes))
        {
            var texture = new Texture2D(2, 2) {filterMode = FilterMode.Bilinear, mipMapBias = -.5f};
            texture.LoadImage(bytes);
            AddTexture(guid, texture);
            return texture;
        }

        return null;
    }

    /// <summary>
    /// Creates or gets a texture from its Id
    /// </summary>
    /// <param name="id">Texture id "ModName-FileName" (no file extension)</param>
    /// <returns>The texture</returns>
    public static Texture2D GetTexture(string id)
    {
        if (TextureCache.TryGetValue(id, out var texture2d) && texture2d != null) return texture2d;

        return CreateTexture(id);
    }

    /// <summary>
    /// Adds a texture that can be accessed as a Sprite via the given guid
    /// </summary>
    /// <param name="guid">Texture id "ModName-TextureName"</param>
    /// <param name="texture">The texture</param>
    public static void AddTexture(string guid, Texture2D texture)
    {
        TextureCache[guid] = texture;
    }

    internal static byte[] GetTextureBytes(string guid) => Resources.TryGetValue(guid, out var bytes) ? bytes : [];

    /// <summary>
    /// Creates a Sprite from a Texture2D
    /// </summary>
    /// <param name="texture">Texture</param>
    /// <param name="pixelsPerUnit">Pixels per Unit to use</param>
    /// <returns>new Sprite</returns>
    public static Sprite CreateSprite(this Texture2D texture, float pixelsPerUnit = 10.8f) => Sprite.Create(texture,
        new Rect(0, 0, texture.width, texture.height),
        new Vector2(0.5f, 0.5f), pixelsPerUnit);

    internal static Sprite CreateSprite(string id, float pixelsPerUnit = 10.8f)
    {
        if (GetTexture(id) is Texture2D texture)
        {
            var sprite = SpriteCache[id] = CreateSprite(texture, pixelsPerUnit);
            sprite.name = id;
            return sprite;
        }

        return null;
    }

    /// <summary>
    /// Creates or gets a sprite from its Id
    /// </summary>
    /// <param name="id">Sprite id "ModName-FileName" (no file extension)</param>
    /// <param name="pixelsPerUnit">Pixels per Unit to use</param>
    /// <returns>The texture </returns>
    public static Sprite GetSprite(string id, float pixelsPerUnit = 10.8f)
    {
        if (SpriteCache.TryGetValue(id, out var sprite) && sprite != null) return sprite;

        return CreateSprite(id, pixelsPerUnit);
    }
}