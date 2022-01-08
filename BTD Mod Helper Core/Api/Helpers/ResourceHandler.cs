using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Unity.Display;
using MelonLoader;
using UnityEngine;

namespace BTD_Mod_Helper.Api
{
    internal class ResourceHandler
    {
        internal static Dictionary<string, byte[]> resources = new Dictionary<string, byte[]>();
        
        public static readonly Dictionary<string, UnityDisplayNode> Prefabs =
            new Dictionary<string, UnityDisplayNode>();

        public static readonly Dictionary<string, AssetBundle> Bundles = new Dictionary<string, AssetBundle>();
        
        
        internal static readonly Dictionary<string, float> ScalesFor2dModels = new Dictionary<string, float>();
            
        internal static void LoadEmbeddedTextures(BloonsMod mod)
        {
            foreach (var name in mod.Assembly.GetManifestResourceNames().Where(s => s.EndsWith("png")))
            {
                using (var memoryStream = new MemoryStream())
                {
                    if (mod.Assembly.GetManifestResourceStream(name) is Stream stream)
                    {
                        stream.CopyTo(memoryStream);
                        var split = name.Split('.');
                        var guid = mod.IDPrefix + split[split.Length - 2];
                        resources[guid] = memoryStream.ToArray();
                    }
                }
            }
        }

        internal static void LoadEmbeddedBundles(BloonsMod mod)
        {
            foreach (var name in mod.Assembly.GetManifestResourceNames().Where(s => s.EndsWith("bundle")))
            {
                var memoryStream = new MemoryStream();
                if (mod.Assembly.GetManifestResourceStream(name) is Stream stream)
                {
                    stream.CopyTo(memoryStream);
                    var bundle = AssetBundle.LoadFromMemory(memoryStream.ToArray());
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
                        guid += bundle.name.Substring(0, bundle.name.LastIndexOf("."));
                    }
                    else
                    {
                        guid += bundle.name;
                    }
                    Bundles[guid] = bundle;
                    // ModHelper.Msg("Successfully loaded bundle " + guid);
                }
            }
        }

        internal static readonly Dictionary<string, Texture2D> TextureCache = new Dictionary<string, Texture2D>();
        
        internal static Texture2D GetTexture(string guid)
        {
            if (TextureCache.TryGetValue(guid, out var texture2d) && texture2d != null)
            {
                return texture2d;
            }

            if (resources.GetValueOrDefault(guid) is byte[] bytes)
            {
                var texture = new Texture2D(2, 2) { filterMode = FilterMode.Bilinear, mipMapBias = 0};
                ImageConversion.LoadImage(texture, bytes);
                TextureCache[guid] = texture;
                return texture;
            }

            return null;
        }

        internal static readonly Dictionary<string, Sprite> SpriteCache = new Dictionary<string, Sprite>();

        internal static Sprite GetSprite(string guid, float pixelsPerUnit = 10)
        {
            if (SpriteCache.TryGetValue(guid, out var sprite) && sprite != null)
            {
                return sprite;
            }
            
            if (GetTexture(guid) is Texture2D texture)
            {
                return SpriteCache[guid] = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f, 0.5f), pixelsPerUnit);
            }

            return null;
        }
    }
}