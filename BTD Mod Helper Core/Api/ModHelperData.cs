using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MelonLoader;

namespace BTD_Mod_Helper.Api
{
    internal class ModHelperData
    {
        private static readonly Dictionary<MelonMod, ModHelperData> Data = new Dictionary<MelonMod, ModHelperData>();

        private readonly Dictionary<string, string> values = new Dictionary<string, string>();

        public byte[] IconBytes { get; private set; }

        public static void Load(MelonMod mod)
        {
            var modHelperData = new ModHelperData();
            
            var data = mod.Assembly.GetValidTypes().FirstOrDefault(type => type.Name == nameof(ModHelperData));
            if (data != null)
            {
                foreach (var fieldInfo in data.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                             .Where(info => info.IsLiteral && !info.IsInitOnly))
                {
                    modHelperData[fieldInfo.Name] = fieldInfo.GetRawConstantValue().ToString();
                }
            }
            
            var iconPath = modHelperData["Icon"] ?? "Icon.png";
            var assemblyPath = "." + iconPath.Replace("/", ".");
            var resource = mod.Assembly
                .GetManifestResourceNames()
                .FirstOrDefault(s => s.EndsWith(assemblyPath));
            if (resource != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    if (mod.Assembly.GetManifestResourceStream(resource) is Stream stream)
                    {
                        stream.CopyTo(memoryStream);
                        modHelperData.IconBytes = memoryStream.ToArray();
                    }
                }
            }

            Data[mod] = modHelperData;
        }

        public static ModHelperData GetModHelperData(MelonMod mod) => Data.TryGetValue(mod, out var data) ? data : null;

        public static string GetModHelperData(MelonMod mod, string name) => GetModHelperData(mod)?[name];

        public string this[string name]
        {
            get => values.TryGetValue(name, out var value) ? value : null;
            private set => values[name] = value;
        }
    }
}