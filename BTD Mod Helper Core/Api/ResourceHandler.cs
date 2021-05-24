using System.Collections.Generic;
using System.IO;
using System.Linq;
using MelonLoader;
using UnityEngine;

namespace BTD_Mod_Helper.Api
{
    internal class ResourceHandler
    {
        internal static Dictionary<string, byte[]> resources = new Dictionary<string, byte[]>();
            
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
                    
                }
            }
        }
        
    }
}