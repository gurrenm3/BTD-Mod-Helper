using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.ModMenu;
using MelonLoader;
using Octokit;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// Class representing all the data ModHelper can utilize about a mod as separate from the MelonMod / .dll itself.
    /// <br/>
    /// This is used for getting mod information from its GitHub repo, for getting information about enabled mods even
    /// if they don't want to have Mod Helper as a dependency, and keeping track of info about disabled mods.
    /// </summary>
    internal class ModHelperData
    {
        /// <summary>
        /// The ModHelperData objects for currently enabled mods
        /// </summary>
        private static readonly Dictionary<MelonMod, ModHelperData> Data = new Dictionary<MelonMod, ModHelperData>();

        private const string DefaultIcon = "Icon.png";
        private const string ModHelperDataName = "ModHelperData.cs";

        private const string VersionRegex = "string Version = \"([.0-9]+)\";\n";
        private const string NameRegex = "string Name = \"(.+)\";\n";
        private const string DescRegex = "string Description = \"(.+)\";\n";
        private const string IconRegex = "string Icon = \"(.+)\\.png\";\n";
        private const string DllRegex = "string DllName = \"(.+)\\.dll\";\n";
        private const string RepoNameRegex = "string RepoName = \"(.+)\";\n";
        private const string RepoOwnerRegex = "string RepoOwner = \"(.+)\";\n";

        /// <summary>
        /// Reflection happens way faster with this set up
        /// </summary>
        private static readonly Dictionary<string, Action<ModHelperData, string>> Setters;

        static ModHelperData()
        {
            Setters = new Dictionary<string, Action<ModHelperData, string>>();
            foreach (var propertyInfo in typeof(ModHelperData).GetProperties()
                         .Where(info => info.PropertyType == typeof(string)))
            {
                var setMethod = propertyInfo.GetSetMethod(true);
                if (setMethod != null)
                {
                    Setters[propertyInfo.Name] = (Action<ModHelperData, string>) Delegate.CreateDelegate(
                        typeof(Action<ModHelperData, string>), setMethod);
                }
                else
                {
                    ModHelper.Warning($"No setMethod for {propertyInfo.Name}");
                }
            }
        }

        public ModHelperData()
        {
        }

        public ModHelperData(Repository repository)
        {
            Repository = repository;
        }

        public byte[] IconBytes { get; private set; }
        public bool HasNoIcon { get; private set; }

        public string Version { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }
        public string DllName { get; private set; }
        public string RepoName { get; private set; }
        public string RepoOwner { get; private set; }

        public Repository Repository { get; }
        public bool FailedToGetRepoData { get; private set; }

        private string GetContentURL(string name)
        {
            return $"{ModHelperGithub.RawUserContent}/{RepoOwner}/{RepoName}/{Repository.DefaultBranch}/{name}";
        }

        public async Task LoadDataFromRepoAsync()
        {
            try
            {
                var data = await ModHelperHttp.Client.GetStringAsync(GetContentURL(ModHelperDataName));
                ReadValuesFromString(data);
            }
            catch (Exception)
            {
                FailedToGetRepoData = true;
            }
        }

        public void ReadValuesFromString(string data)
        {
            if (Regex.Match(data, VersionRegex) is Match versionMatch) Version = versionMatch.Groups[0].Value;
            if (Regex.Match(data, NameRegex) is Match nameMatch) Name = nameMatch.Groups[0].Value;
            if (Regex.Match(data, DescRegex) is Match descMatch) Description = descMatch.Groups[0].Value;
            if (Regex.Match(data, IconRegex) is Match iconMatch) Icon = iconMatch.Groups[0].Value;
            if (Regex.Match(data, DllRegex) is Match dllMatch) DllName = dllMatch.Groups[0].Value;
            if (Regex.Match(data, RepoNameRegex) is Match repoNameMatch) RepoName = repoNameMatch.Groups[0].Value;
            if (Regex.Match(data, RepoOwnerRegex) is Match repoOwnerMatch) RepoOwner = repoOwnerMatch.Groups[0].Value;
        }

        public async Task LoadIconFromRepoAsync()
        {
            try
            {
                IconBytes = await ModHelperHttp.Client.GetByteArrayAsync(GetContentURL(Icon ?? DefaultIcon));
                if (IconBytes == null || IconBytes.Length == 0)
                {
                    HasNoIcon = true;
                }
            }
            catch (Exception)
            {
                HasNoIcon = true;
            }
        }

        public bool IsAlreadyInstalled()
        {
            return Data.Values.Any(data => data.RepoName == RepoName && data.RepoOwner == RepoOwner);
        }
        
        public static void Load(MelonMod mod)
        {
            var modHelperData = new ModHelperData();

            var data = mod.Assembly.GetValidTypes().FirstOrDefault(type => type.Name == nameof(ModHelperData));
            if (data != null)
            {
                foreach (var fieldInfo in data
                             .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                             .Where(info => info.IsLiteral && !info.IsInitOnly && Setters.ContainsKey(info.Name)))
                {
                    Setters[fieldInfo.Name](modHelperData, fieldInfo.GetRawConstantValue().ToString());
                }
            }

            var iconPath = modHelperData.Icon ?? "Icon.png";
            var assemblyPath = "." + iconPath.Replace("/", ".");
            var resource = mod.Assembly
                .GetManifestResourceNames()
                .FirstOrDefault(s => s.EndsWith(assemblyPath));
            if (resource != null && mod.Assembly.GetManifestResourceStream(resource) is Stream stream)
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    modHelperData.IconBytes = memoryStream.ToArray();
                }
            }
            else
            {
                modHelperData.HasNoIcon = true;
            }

            Data[mod] = modHelperData;
        }

        public static ModHelperData GetModHelperData(MelonMod mod)
        {
            return Data.TryGetValue(mod, out var data) ? data : null;
        }
    }
}