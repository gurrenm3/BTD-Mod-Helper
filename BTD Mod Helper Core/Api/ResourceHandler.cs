using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;

namespace BTD_Mod_Helper.Api
{
    internal class ResourceHandler
    {
        internal static Dictionary<string, byte[]> resources = new Dictionary<string, byte[]>();
        
        public static readonly Dictionary<string, UnityDisplayNode> Prefabs =
            new Dictionary<string, UnityDisplayNode>();

        public static readonly Dictionary<string, AssetBundle> bundles = new Dictionary<string, AssetBundle>();
            
        internal static void LoadEmbeddedTextures(BloonsMod mod)
        {
            foreach (var name in mod.Assembly.GetManifestResourceNames().Where(s => s.EndsWith("png")))
            {
                var memoryStream = new MemoryStream();
                if (mod.Assembly.GetManifestResourceStream(name) is Stream stream)
                {
                    stream.CopyTo(memoryStream);
                    var split = name.Split('.');
                    var guid = mod.IDPrefix + split[split.Length - 2];
                    resources[guid] = memoryStream.ToArray();
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
                    var guid = mod.IDPrefix + bundle.name;
                    bundles[guid] = bundle;
                }
            }
        }

        internal static Texture2D GetTexture(string guid)
        {
            if (resources.GetValueOrDefault(guid) is byte[] bytes)
            {
                var texture = new Texture2D(2, 2) { filterMode = FilterMode.Bilinear };
                ImageConversion.LoadImage(texture, bytes);
                return texture;
            }

            return null;
        }

        internal static Sprite GetSprite(string guid, float pixelsPerUnit = 10)
        {
            if (GetTexture(guid) is Texture2D texture)
            {
                return Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f, 0.5f), pixelsPerUnit);
            }

            return null;
        }
    }
}