using System;
using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Internal;

internal class ResourceHandler
{
    internal static readonly Dictionary<string, byte[]> Resources = new();
    internal static readonly Dictionary<string, AudioClip> AudioClips = new();

    public static readonly Dictionary<string, AssetBundle> Bundles = new();

    internal static readonly Dictionary<string, Texture2D> TextureCache = new();

    internal static readonly Dictionary<string, Sprite> SpriteCache = new();

    internal static void LoadEmbeddedTextures(BloonsTD6Mod mod)
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

    internal static void LoadEmbeddedAudio(BloonsTD6Mod mod)
    {
        mod.AudioClips = new Dictionary<string, AudioClip>();

        foreach (var fileName in mod.GetAssembly().GetManifestResourceNames()
                     .Where(s => s.EndsWith(".wav")))
        {
            var split = fileName.Split('.');
            var name = split[^2];
            var id = ModContent.GetId(mod, name);

            try
            {
                using var stream = mod.GetAssembly().GetManifestResourceStream(fileName);
                using var reader = new WaveFileReader(stream);
                var waveFormat = reader.WaveFormat;

                var totalSamples = (int) (reader.SampleCount * waveFormat.Channels);
                var data = new float[totalSamples];

                reader.ToSampleProvider().Read(data, 0, totalSamples);

                var audioClip = AudioClip.Create(id, totalSamples, waveFormat.Channels, waveFormat.SampleRate, false);

                if (audioClip.SetData(data, 0))
                {
                    AudioClips[id] = mod.AudioClips[name] = audioClip;
                }
                else
                {
                    ModHelper.Warning($"Failed to set data for audio clip {fileName}");
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }
        }
    }

    internal static void LoadEmbeddedBundles(BloonsTD6Mod mod)
    {
        foreach (var name in mod.GetAssembly().GetManifestResourceNames().Where(s => s.EndsWith("bundle")))
        {
            var bytes = mod.GetAssembly().GetManifestResourceStream(name).GetByteArray();
            if (bytes == null)
            {
                continue;
            }

            var bundle = AssetBundle.LoadFromMemory(bytes);
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

    internal static Texture2D CreateTexture(string guid)
    {
        if (Resources.TryGetValue(guid, out var bytes))
        {
            var texture = new Texture2D(2, 2) {filterMode = FilterMode.Bilinear, mipMapBias = -.5f};
            ImageConversion.LoadImage(texture, bytes);
            TextureCache[guid] = texture;
            return texture;
        }

        return null;
    }

    internal static Texture2D GetTexture(string id)
    {
        if (TextureCache.TryGetValue(id, out var texture2d) && texture2d != null) return texture2d;

        return CreateTexture(id);
    }

    internal static byte[] GetTextureBytes(string guid) =>
        Resources.TryGetValue(guid, out var bytes) ? bytes : Array.Empty<byte>();

    internal static Sprite CreateSprite(Texture2D texture, float pixelsPerUnit = 10.8f) => Sprite.Create(texture,
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

    internal static Sprite GetSprite(string id, float pixelsPerUnit = 10.8f)
    {
        if (SpriteCache.TryGetValue(id, out var sprite) && sprite != null) return sprite;

        return CreateSprite(id, pixelsPerUnit);
    }
}