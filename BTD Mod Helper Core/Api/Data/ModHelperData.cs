using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Api.Updater;
using MelonLoader;
using Octokit;
using UnityEngine;

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
        internal static readonly Dictionary<MelonMod, ModHelperData> Cache = new Dictionary<MelonMod, ModHelperData>();

        /// <summary>
        /// All ModHelperData, for both enabled and disabled mods
        /// </summary>
        internal static readonly List<ModHelperData> Data = new List<ModHelperData>();

        private const string ModHelperDataName = "ModHelperData.cs";
        protected const string DefaultIcon = "Icon.png";

        private const string VersionRegex = "string Version =\\s*\"([.0-9]+)\";\n";
        private const string NameRegex = "string Name =\\s*\"(.+)\";\n";
        private const string DescRegex = "string Description =\\s*\"(.+)\";\n";
        private const string IconRegex = "string Icon =\\s*\"(.+)\\.png\";\n";
        private const string DllRegex = "string DllName =\\s*\"(.+)\\.dll\";\n";
        private const string RepoNameRegex = "string RepoName =\\s*\"(.+)\";\n";
        private const string RepoOwnerRegex = "string RepoOwner =\\s*\"(.+)\";\n";
        private const string ManualDownloadRegex = "bool ManualDownload =\\s*(false|true);\n";
        private const string ZipRegex = "string ZipName =\\s*\"(.+)\\.zip\";\n";
        private const string AuthorRegex = "string Author =\\s*\"(.+)\";\n";

        private static readonly Dictionary<string, MethodInfo> Setters;

        static ModHelperData()
        {
            Setters = new Dictionary<string, MethodInfo>();
            foreach (var propertyInfo in typeof(ModHelperData).GetProperties())
            {
                var setMethod = propertyInfo.GetSetMethod(true);
                if (setMethod != null)
                {
                    Setters[propertyInfo.Name] = setMethod;
                }
                else
                {
                    ModHelper.Warning($"No setMethod for {propertyInfo.Name}");
                }
            }
        }

        protected byte[] IconBytes { get; private protected set; }
        internal bool HasNoIcon { get; private protected set; }

        public string Version { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Icon { get; protected set; }
        public string DllName { get; protected set; }
        public string RepoName { get; protected set; }
        public string RepoOwner { get; protected set; }
        public bool ManualDownload { get; protected set; }
        public string ZipName { get; protected set; }
        public string Author { get; protected set; }

        // Local Mod Info
        internal MelonMod Mod { get; }
        internal bool Enabled => Mod != null;
        internal bool Disabled => Mod == null;
        internal bool RestartRequired { get; set; }

        // Browser Mod Info
        internal Repository Repository { get; private set; }
        internal bool RepoDataSuccess { get; private set; }
        internal string RepoVersion { get; private set; }
        internal Release LatestRelease { get; private set; }


        internal bool UpdateAvailable =>
            !RestartRequired && RepoDataSuccess && RepoVersion != null && UpdaterHttp.IsUpdate(Version, RepoVersion);

        public ModHelperData()
        {
        }

        public ModHelperData(Repository repository)
        {
            Repository = repository;
            RepoOwner = repository.Owner.Login;
            RepoName = repository.Name;
        }

        public ModHelperData(MelonMod mod)
        {
            Mod = mod;
            Name = mod.Info.Name;
            Version = mod.Info.Version;
            Author = mod.Info.Author;

            var data = mod.Assembly.GetValidTypes().FirstOrDefault(type => type.Name == nameof(ModHelperData));
            if (mod is MelonMain)
            {
                data = typeof(ModHelper);
            }

            if (data != null)
            {
                foreach (var fieldInfo in data
                             .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                             .Where(info => info.IsLiteral && !info.IsInitOnly && Setters.ContainsKey(info.Name)))
                {
                    var rawConstantValue = fieldInfo.GetRawConstantValue();
                    try
                    {
                        Setters[fieldInfo.Name].Invoke(this, new[] {rawConstantValue});
                    }
                    catch (Exception)
                    {
                        ModHelper.Warning(
                            $"The {fieldInfo.Name} of {mod.Info.Name}'s ModHelperData has incorrect type {rawConstantValue.GetType().Name}");
                    }
                }
            }

            // ReSharper disable once ConstantNullCoalescingCondition
            var iconPath = Icon ?? "Icon.png";
            var assemblyPath = "." + iconPath.Replace("/", ".");
            var resource = mod.Assembly
                .GetManifestResourceNames()
                .FirstOrDefault(s => s.EndsWith(assemblyPath));
            if (resource != null && mod.Assembly.GetManifestResourceStream(resource) is Stream stream)
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    IconBytes = memoryStream.ToArray();
                }
            }
            else
            {
                HasNoIcon = true;
            }
        }

        public void ReadValuesFromString(string data)
        {
            if (Regex.Match(data, VersionRegex) is Match versionMatch && versionMatch.Success)
                Version = versionMatch.Groups[1].Value;
            if (Regex.Match(data, NameRegex) is Match nameMatch && nameMatch.Success)
                Name = nameMatch.Groups[1].Value;
            if (Regex.Match(data, DescRegex) is Match descMatch && descMatch.Success)
                Description = descMatch.Groups[1].Value;
            if (Regex.Match(data, IconRegex) is Match iconMatch && iconMatch.Success)
                Icon = iconMatch.Groups[1].Value;
            if (Regex.Match(data, DllRegex) is Match dllMatch && dllMatch.Success)
                DllName = dllMatch.Groups[1].Value;
            if (Regex.Match(data, RepoNameRegex) is Match repoNameMatch && repoNameMatch.Success)
                RepoName = repoNameMatch.Groups[1].Value;
            if (Regex.Match(data, RepoOwnerRegex) is Match repoOwnerMatch && repoOwnerMatch.Success)
                RepoOwner = repoOwnerMatch.Groups[1].Value;
            if (Regex.Match(data, ManualDownloadRegex) is Match manualDownloadMatch && manualDownloadMatch.Success)
                ManualDownload = bool.Parse(manualDownloadMatch.Groups[1].Value);
            if (Regex.Match(data, ZipRegex) is Match zipMatch && zipMatch.Success)
                ZipName = zipMatch.Groups[1].Value;
            if (Regex.Match(data, AuthorRegex) is Match authorMatch && authorMatch.Success)
                Author = authorMatch.Groups[1].Value;
        }

        public static ModHelperData GetModHelperData(MelonMod mod)
        {
            return Cache.TryGetValue(mod, out var data) ? data : null;
        }

        public static void Load(MelonMod mod)
        {
            var modHelperData = new ModHelperData(mod);
            Cache[mod] = modHelperData;
            Data.Add(modHelperData);
        }

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

                if (HasRequiredData())
                {
                    RepoDataSuccess = true;

                    if (ModInstalledLocally(out var modHelperData))
                    {
                        modHelperData.Repository = Repository;
                        modHelperData.RepoVersion = Version;
                        modHelperData.RepoDataSuccess = true;
                    }
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to get ModHelperData for {Repository.Name}");
                ModHelper.Warning(e);
            }
        }

        public bool HasRequiredData()
        {
            return Version != null && RepoName != null && RepoOwner != null;
        }

        public async Task<Release> GetLatestRelease()
        {
            try
            {
                return LatestRelease = await ModHelperGithub.Client.Repository.Release.GetLatest(Repository.Id);
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to get latest release for {Name}");
                ModHelper.Warning(e);
                return null;
            }
            finally
            {
                ModHelperGithub.UpdateRateLimit();
            }
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

        public bool ModInstalledLocally(out ModHelperData modHelperData)
        {
            modHelperData =
                Cache.Values.FirstOrDefault(data => data.RepoName == RepoName && data.RepoOwner == RepoOwner);
            return modHelperData != null;
        }

        public Sprite GetSprite()
        {
            if (IconBytes != null)
            {
                var texture = new Texture2D(2, 2) {filterMode = FilterMode.Bilinear, mipMapBias = -1};
                ImageConversion.LoadImage(texture, IconBytes);
                return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f), 10f);
            }

            return null;
        }
    }
}