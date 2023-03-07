using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BTD_Mod_Helper.Api;

internal class ResourceHandler
{
    internal static readonly Dictionary<string, byte[]> Resources = new();

    public static readonly Dictionary<string, AssetBundle> Bundles = new();

    internal static void LoadEmbeddedTextures(BloonsMod mod)
    {
        mod.Resources = new Dictionary<string, byte[]>();
        foreach (var fileName in mod.GetAssembly().GetManifestResourceNames()
                     .Where(s => s.EndsWith("png") || s.EndsWith("jpg")))
        {
            var resource = mod.GetAssembly().GetManifestResourceStream(fileName).GetByteArray();
            if (resource == null)
            {
                continue;
            }

            var split = fileName.Split('.');
            var name = split[split.Length - 2];
            var id = ModContent.GetId(mod, name);
            Resources[id] = resource;
            mod.Resources[name] = resource;
        }
    }

    internal static void LoadEmbeddedBundles(BloonsMod mod)
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

    internal static readonly Dictionary<string, Texture2D> TextureCache = new();

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

    internal static byte[] GetTextureBytes(string guid)
    {
        return Resources.TryGetValue(guid, out var bytes) ? bytes : Array.Empty<byte>();
    }

    internal static readonly Dictionary<string, Sprite> SpriteCache = new();

    internal static Sprite CreateSprite(Texture2D texture, float pixelsPerUnit = 10.8f)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f), pixelsPerUnit);
    }

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