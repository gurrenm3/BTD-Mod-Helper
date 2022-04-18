using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Extensions;
using UnityEngine;

namespace BTD_Mod_Helper.Api
{
    internal class ResourceHandler
    {
        internal static readonly Dictionary<string, byte[]> Resources = new Dictionary<string, byte[]>();

        public static readonly Dictionary<string, UnityDisplayNode> Prefabs =
            new Dictionary<string, UnityDisplayNode>();

        public static readonly Dictionary<string, AssetBundle> Bundles = new Dictionary<string, AssetBundle>();


        internal static readonly Dictionary<string, float> ScalesFor2dModels = new Dictionary<string, float>();

        internal static void LoadEmbeddedTextures(BloonsMod mod)
        {
            mod.Resources = new Dictionary<string, byte[]>();
            foreach (var fileName in mod.Assembly.GetManifestResourceNames()
                         .Where(s => s.EndsWith("png") || s.EndsWith("jpg")))
            {
                var resource = mod.Assembly.GetManifestResourceStream(fileName).GetByteArray();
                if (resource == null)
                {
                    continue;
                }

                var split = fileName.Split('.');
                var name = split[split.Length - 2];
                var guid = mod.IDPrefix + name;
                Resources[guid] = resource;
                mod.Resources[name] = resource;
            }
        }

        internal static void LoadEmbeddedBundles(BloonsMod mod)
        {
            foreach (var name in mod.Assembly.GetManifestResourceNames().Where(s => s.EndsWith("bundle")))
            {
                var bytes = mod.Assembly.GetManifestResourceStream(name).GetByteArray();
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

        internal static readonly Dictionary<string, Texture2D> TextureCache = new Dictionary<string, Texture2D>();

        internal static Texture2D CreateTexture(string guid)
        {
            if (Resources.TryGetValue(guid, out var bytes))
            {
                var texture = new Texture2D(2, 2) {filterMode = FilterMode.Bilinear, mipMapBias = 0};
                ImageConversion.LoadImage(texture, bytes);
                TextureCache[guid] = texture;
                return texture;
            }

            return null;
        }

        internal static Texture2D GetTexture(string guid)
        {
            if (TextureCache.TryGetValue(guid, out var texture2d) && texture2d != null)
            {
                return texture2d;
            }

            if (Resources.TryGetValue(guid, out var bytes))
            {
                var texture = new Texture2D(2, 2) {filterMode = FilterMode.Bilinear, mipMapBias = 0};
                ImageConversion.LoadImage(texture, bytes);
                TextureCache[guid] = texture;
                return texture;
            }

            return null;
        }

        internal static byte[] GetTextureBytes(string guid)
        {
            Resources.TryGetValue(guid, out byte[] bytes);
            return bytes;
        }

        internal static readonly Dictionary<string, Sprite> SpriteCache = new Dictionary<string, Sprite>();

        internal static Sprite CreateSprite(Texture2D texture, float pixelsPerUnit = 10)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f), pixelsPerUnit);
        }

        internal static Sprite CreateSprite(string guid, float pixelsPerUnit = 10)
        {
            if (GetTexture(guid) is Texture2D texture)
            {
                var sprite = SpriteCache[guid] = CreateSprite(texture, pixelsPerUnit);
                sprite.name = guid;
                return sprite;
            }

            return null;
        }

        internal static Sprite GetSprite(string guid, float pixelsPerUnit = 10)
        {
            if (SpriteCache.TryGetValue(guid, out var sprite) && sprite != null)
            {
                return sprite;
            }

            return CreateSprite(guid, pixelsPerUnit);
        }
    }
}