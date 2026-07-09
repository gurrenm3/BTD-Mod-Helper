using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.UI;
using Il2CppAssets.Scripts.Unity.Audio;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using NAudio.Vorbis;
using NAudio.Wave;
using UnityEngine;
using UnityEngine.AddressableAssets;
namespace BTD_Mod_Helper.Api.Internal;

/// <summary>
/// Handles embedded resources within Mod Helper mods
/// </summary>
public static class ResourceHandler
{
    /// <summary>
    /// Map of raw embedded resource data by Id
    /// </summary>
    public static readonly Dictionary<string, byte[]> Resources = [];

    /// <summary>
    /// Map of created Audio Clips by Id
    /// </summary>
    public static readonly Dictionary<string, AudioClip> AudioClips = [];

    /// <summary>
    /// Map of loaded Asset Bundles by Id
    /// </summary>
    public static readonly Dictionary<string, AssetBundle> Bundles = [];

    /// <summary>
    /// Cache of created Textures by Id
    /// </summary>
    public static readonly Dictionary<string, Texture2D> TextureCache = [];

    /// <summary>
    /// Cache of created Sprites by Id
    /// </summary>
    public static readonly Dictionary<string, Sprite> SpriteCache = [];

    /// <summary>
    /// Defines a list of IDs that can be used for AudioClipReferences to refer to a random audio clip from the list
    /// </summary>
    public static readonly Dictionary<string, IList<AudioClip>> RandomAudioClipIds = [];

    /// <summary>
    /// Allowed file extensions for images
    /// </summary>
    public static readonly string[] ImageExtensions = [".png", ".jpg"];

    /// <summary>
    /// Allowed file extensions for audio
    /// </summary>
    public static readonly string[] AudioExtensions = [".wav", ".mp3", ".ogg", ".flac", ".aac", ".wma", ".m4a"];

    /// <summary>
    /// ImageSettings for mod images
    /// </summary>
    public static readonly Dictionary<string, ImageSettings> ImageSettings = [];

    internal static readonly List<RenderTexture> RenderTexturesToRelease = [];

    internal static void LoadEmbeddedResources(BloonsMod mod)
    {
        var zipArchives = LoadEmbeddedZipArchives(mod);
        try
        {
            var zipEntries = zipArchives
                .SelectMany(archive => archive.Entries)
                .Where(entry => !string.IsNullOrEmpty(entry.Name))
                .ToList();

            LoadEmbeddedTextures(mod, zipEntries);
            LoadEmbeddedAudio(mod, zipEntries);
            LoadEmbeddedBundles(mod, zipEntries);
        }
        finally
        {
            foreach (var zipArchive in zipArchives)
            {
                zipArchive.Dispose();
            }
        }
    }

    private static List<ZipArchive> LoadEmbeddedZipArchives(BloonsMod mod)
    {
        var assembly = mod.GetAssembly();
        var archives = new List<ZipArchive>();

        foreach (var zipName in assembly.GetManifestResourceNames().Where(s => s.EndsWith(".zip")))
        {
            Stream zipStream = null;
            try
            {
                zipStream = assembly.GetManifestResourceStream(zipName);
                if (zipStream == null) continue;

                archives.Add(new ZipArchive(zipStream, ZipArchiveMode.Read));
                zipStream = null;
            }
            catch (Exception e)
            {
                zipStream?.Dispose();
                ModHelper.Warning("Failed to load embedded resource zip " + zipName);
                ModHelper.Warning(e);
            }
        }

        return archives;
    }

    internal static void LoadEmbeddedTextures(BloonsMod mod, IEnumerable<ZipArchiveEntry> zipEntries = null)
    {
        mod.Resources = new Dictionary<string, byte[]>();

        foreach (var (name, ext, stream) in GetEmbeddedResourceStreams(
                     mod.GetAssembly(), zipEntries, ImageExtensions))
        {
            var resource = stream.GetByteArray();
            if (resource == null) continue;

            var id = ModContent.GetId(mod, name);
            Resources[id] = resource;
            mod.Resources[name] = resource;

            ImageSettings[id] = mod.GetImageSettings(name, ext);
        }
    }

    internal static void LoadEmbeddedAudio(BloonsMod mod, IEnumerable<ZipArchiveEntry> zipEntries = null)
    {
        mod.AudioClips = new Dictionary<string, AudioClip>();

        foreach (var (name, ext, stream) in GetEmbeddedResourceStreams(
                     mod.GetAssembly(), zipEntries, AudioExtensions))
        {
            var id = ModContent.GetId(mod, name);

            try
            {
                using var waveStream = GetWaveStream(stream, ext);

                if (mod.NormalizeAllAudioVolume)
                {
                    BloonsMod.NormalizeAudioVolume.Add(id);
                }

                var audioClip = CreateAudioClip(waveStream, id);
                if (audioClip != null)
                {
                    mod.AudioClips[name] = audioClip;
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to load audio clip {name}.{ext}");
                ModHelper.Warning(e);
            }
        }
    }

    internal static void LoadEmbeddedBundles(BloonsMod mod, IEnumerable<ZipArchiveEntry> zipEntries = null)
    {
        foreach (var (name, _, stream) in GetEmbeddedResourceStreams(mod.GetAssembly(), zipEntries, [".bundle"]))
        {
            var bytes = stream.GetByteArray();
            if (bytes == null) continue;

            LoadBundle(mod, name, bytes);
        }
    }

    private static void LoadBundle(BloonsMod mod, string name, byte[] bytes)
    {
        var stream = new Il2CppSystem.IO.MemoryStream(bytes);
        var bundle = AssetBundle.LoadFromStream(stream);
        stream.Dispose();
        var guid = mod.IDPrefix;
        if (bundle == null)
        {
            ModHelper.Log($"The bundle {name} is null!");
            return;
        }

        if (string.IsNullOrEmpty(bundle.name))
        {
            ModHelper.Log($"The bundle {name} has no name!");
            return;
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

    private static IEnumerable<(string Name, string Ext, Stream Stream)> GetEmbeddedResourceStreams(
        Assembly assembly, IEnumerable<ZipArchiveEntry> zipEntries, string[] extensions)
    {
        foreach (var fileName in assembly.GetManifestResourceNames().Where(s => extensions.Any(s.EndsWith)))
        {
            using var stream = assembly.GetManifestResourceStream(fileName);
            if (stream == null) continue;

            var split = fileName.Split('.');
            yield return (split[^2], split[^1], stream);
        }

        if (zipEntries == null) yield break;

        foreach (var entry in zipEntries.Where(entry => extensions.Any(entry.Name.EndsWith)))
        {
            using var stream = entry.Open();
            var fileName = GetZipEntryFileName(entry);
            yield return (
                Path.GetFileNameWithoutExtension(fileName),
                Path.GetExtension(fileName).TrimStart('.'),
                stream);
        }
    }

    private static string GetZipEntryFileName(ZipArchiveEntry entry)
    {
        var normalized = entry.FullName.Replace('\\', '/');
        var index = normalized.LastIndexOf('/');
        return index >= 0 ? normalized[(index + 1)..] : normalized;
    }

    /// <summary>
    /// Turns a stream into a WaveStream based on file extension
    /// </summary>
    public static WaveStream GetWaveStream(Stream stream, string extension) => extension.Replace(".", "") switch
    {
        "wav" => new WaveFileReader(stream),
        "ogg" => new VorbisWaveReader(stream),
        "mp3" or "flac" or "wma" or "aac" or "m4a" => new StreamMediaFoundationReader(stream),
        _ => throw new FormatException($"Invalid for audio extension {extension}")
    };

    /// <summary>
    /// Gets a WaveStream from a file path
    /// </summary>
    public static WaveStream GetWaveStream(string filePath) => Path.GetExtension(filePath).Replace(".", "") switch
    {
        "wav" => new WaveFileReader(filePath),
        "ogg" => new VorbisWaveReader(filePath),
        "mp3" or "flac" or "wma" or "aac" or "m4a" => new MediaFoundationReader(filePath),
        _ => throw new FormatException($"Invalid for audio extension {Path.GetExtension(filePath)}")
    };


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

            if (BloonsMod.NormalizeAudioVolume.Contains(id))
            {
                var peak = 0f;
                for (var i = 0; i < count; i++)
                {
                    var abs = Math.Abs(result[i]);
                    if (abs > peak) peak = abs;
                }
                if (peak is > 0f and < 0.99f)
                {
                    var scale = 0.99f / peak;
                    for (var i = 0; i < count; i++)
                    {
                        result[i] *= scale;
                    }
                }
            }

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
            ModHelper.Warning("Failed to load audio clip " + id);
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


    internal static Texture2D CreateTexture(string id, ImageSettings imageSettings = null)
    {
        imageSettings ??= ImageSettings.GetValueOrDefault(id, new());
        if (Resources.TryGetValue(id, out var bytes))
        {
            var texture = new Texture2D(2, 2)
            {
                filterMode = imageSettings.FilterMode,
                mipMapBias = imageSettings.MipMapBias,
                wrapMode = imageSettings.WrapMode
            };
            texture.LoadImage(bytes);
            AddTexture(id, texture);
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

        return CreateTexture(id, ImageSettings.GetValueOrDefault(id, new()));
    }

    /// <summary>
    /// Creates or gets a texture from its Id
    /// </summary>
    /// <param name="id">Texture id "ModName-FileName" (no file extension)</param>
    /// <param name="imageSettings">ImageSettings to use</param>
    /// <returns>The texture</returns>
    public static Texture2D GetTexture(string id, ImageSettings imageSettings)
    {
        if (TextureCache.TryGetValue(id, out var texture2d) && texture2d != null) return texture2d;

        return CreateTexture(id, imageSettings);
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
    public static Sprite CreateSprite(this Texture2D texture, float pixelsPerUnit) =>
        texture.CreateSprite(new ImageSettings {PixelsPerUnit = pixelsPerUnit});

    /// <summary>
    /// Creates a Sprite from a Texture2D
    /// </summary>
    /// <param name="texture">Texture</param>
    /// <param name="imageSettings">ImageSettings to use</param>
    /// <returns>new Sprite</returns>
    public static Sprite CreateSprite(this Texture2D texture, ImageSettings imageSettings = null)
    {
        imageSettings ??= new();
        return Sprite.Create(
            texture, new Rect(0, 0, texture.width, texture.height), imageSettings.Pivot, imageSettings.PixelsPerUnit,
            imageSettings.Extrude, imageSettings.MeshType, imageSettings.Border);
    }

    internal static Sprite CreateSprite(string id, ImageSettings imageSettings = null)
    {
        imageSettings ??= ImageSettings.GetValueOrDefault(id, new());
        if (GetTexture(id, imageSettings) is Texture2D texture)
        {
            var sprite = SpriteCache[id] = texture.CreateSprite(imageSettings);
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
    public static Sprite GetSprite(string id, float pixelsPerUnit)
    {
        if (SpriteCache.TryGetValue(id, out var sprite) && sprite != null) return sprite;

        return CreateSprite(id, new ImageSettings {PixelsPerUnit = pixelsPerUnit});
    }

    /// <summary>
    /// Creates or gets a sprite from its Id
    /// </summary>
    /// <param name="id">Sprite id "ModName-FileName" (no file extension)</param>
    /// <param name="imageSettings">ImageSettings to use</param>
    /// <returns>The texture </returns>
    public static Sprite GetSprite(string id, ImageSettings imageSettings = null)
    {
        imageSettings ??= ImageSettings.GetValueOrDefault(id, new());
        if (SpriteCache.TryGetValue(id, out var sprite) && sprite != null) return sprite;

        return CreateSprite(id, imageSettings);
    }

    internal static void PopulateAudioFactory(AudioFactory audioFactory)
    {
        foreach (var (id, clip) in AudioClips)
        {
            audioFactory.audioClipHandles[new AudioClipReference(id)] =
                Addressables.Instance.ResourceManager.CreateCompletedOperation(clip, "");
        }

        foreach (var (id, audioClips) in RandomAudioClipIds)
        {
            audioFactory.audioClipHandles[new AudioClipReference(id)] =
                Addressables.Instance.ResourceManager.CreateCompletedOperation(audioClips.First(), "");
        }
    }
}